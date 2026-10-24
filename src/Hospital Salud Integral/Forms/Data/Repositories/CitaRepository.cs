using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Forms.Data;
using Forms.Models;

namespace Forms.Data.Repositories
{
    public class CitaRepository
    {
        public List<Cita> GetAll(DateTime? fecha = null, int? idMedico = null, string estado = null, int? idPaciente = null)
        {
            var list = new List<Cita>();
            string sql = @"
                SELECT c.id_cita, c.id_paciente, c.id_medico, c.id_servicio, c.fecha_hora, c.estado, c.motivo_cancelacion,
                       CONCAT(p.nombre, ' ', p.apellido) AS paciente, p.documento,
                       CONCAT(m.nombre, ' ', m.apellido) AS medico,
                       s.nombre AS servicio, s.costo
                FROM citas c
                INNER JOIN pacientes p ON c.id_paciente = p.id_paciente
                INNER JOIN medicos m ON c.id_medico = m.id_medico
                INNER JOIN servicios s ON c.id_servicio = s.id_servicio
                WHERE 1=1";

            var parameters = new List<MySqlParameter>();

            if (fecha.HasValue)
            {
                sql += " AND DATE(c.fecha_hora) = @fecha";
                parameters.Add(new MySqlParameter("@fecha", fecha.Value.Date));
            }
            if (idMedico.HasValue)
            {
                sql += " AND c.id_medico = @medico";
                parameters.Add(new MySqlParameter("@medico", idMedico.Value));
            }
            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
            {
                sql += " AND c.estado = @estado";
                parameters.Add(new MySqlParameter("@estado", estado.Trim()));
            }
            if (idPaciente.HasValue)
            {
                sql += " AND c.id_paciente = @paciente";
                parameters.Add(new MySqlParameter("@paciente", idPaciente.Value));
            }

            sql += " ORDER BY c.fecha_hora DESC;";

            var dt = DbConnection.ExecuteQuery(sql, parameters.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Cita
                {
                    IdCita = Convert.ToInt32(row["id_cita"]),
                    IdPaciente = Convert.ToInt32(row["id_paciente"]),
                    IdMedico = Convert.ToInt32(row["id_medico"]),
                    IdServicio = Convert.ToInt32(row["id_servicio"]),
                    FechaHora = Convert.ToDateTime(row["fecha_hora"]),
                    Estado = row["estado"].ToString(),
                    MotivoCancelacion = row["motivo_cancelacion"] != DBNull.Value ? row["motivo_cancelacion"].ToString() : "",
                    NombrePaciente = row["paciente"].ToString(),
                    DocumentoPaciente = row["documento"].ToString(),
                    NombreMedico = row["medico"].ToString(),
                    NombreServicio = row["servicio"].ToString(),
                    CostoServicio = Convert.ToDecimal(row["costo"])
                });
            }
            return list;
        }

        public Cita GetById(int idCita)
        {
            string sql = @"
                SELECT c.id_cita, c.id_paciente, c.id_medico, c.id_servicio, c.fecha_hora, c.estado, c.motivo_cancelacion,
                       CONCAT(p.nombre, ' ', p.apellido) AS paciente, p.documento,
                       CONCAT(m.nombre, ' ', m.apellido) AS medico,
                       s.nombre AS servicio, s.costo
                FROM citas c
                INNER JOIN pacientes p ON c.id_paciente = p.id_paciente
                INNER JOIN medicos m ON c.id_medico = m.id_medico
                INNER JOIN servicios s ON c.id_servicio = s.id_servicio
                WHERE c.id_cita = @id LIMIT 1;";

            var dt = DbConnection.ExecuteQuery(sql, new MySqlParameter("@id", idCita));
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new Cita
            {
                IdCita = Convert.ToInt32(row["id_cita"]),
                IdPaciente = Convert.ToInt32(row["id_paciente"]),
                IdMedico = Convert.ToInt32(row["id_medico"]),
                IdServicio = Convert.ToInt32(row["id_servicio"]),
                FechaHora = Convert.ToDateTime(row["fecha_hora"]),
                Estado = row["estado"].ToString(),
                MotivoCancelacion = row["motivo_cancelacion"] != DBNull.Value ? row["motivo_cancelacion"].ToString() : "",
                NombrePaciente = row["paciente"].ToString(),
                DocumentoPaciente = row["documento"].ToString(),
                NombreMedico = row["medico"].ToString(),
                NombreServicio = row["servicio"].ToString(),
                CostoServicio = Convert.ToDecimal(row["costo"])
            };
        }

        public bool Insert(Cita c, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                // Regla 1: No programar en el pasado
                if (c.FechaHora < DateTime.Now.AddMinutes(-5))
                {
                    errorMessage = "No se permite programar citas en fechas u horas pasadas.";
                    return false;
                }

                // Regla 2: No asignar a un médico dos citas en el mismo horario (mismo médico dentro de 30 minutos)
                DateTime inicioVentana = c.FechaHora.AddMinutes(-29);
                DateTime finVentana = c.FechaHora.AddMinutes(29);

                string checkMedico = @"
                    SELECT COUNT(*) FROM citas 
                    WHERE id_medico = @medico 
                      AND estado NOT IN ('Cancelada', 'No asistió')
                      AND fecha_hora BETWEEN @inicio AND @fin;";

                long countMedico = Convert.ToInt64(DbConnection.ExecuteScalar(checkMedico,
                    new MySqlParameter("@medico", c.IdMedico),
                    new MySqlParameter("@inicio", inicioVentana),
                    new MySqlParameter("@fin", finVentana)));

                if (countMedico > 0)
                {
                    errorMessage = "El médico ya tiene una cita agendada en ese rango horario.";
                    return false;
                }

                string sql = @"
                    INSERT INTO citas (id_paciente, id_medico, id_servicio, fecha_hora, estado)
                    VALUES (@pac, @med, @serv, @fecha, @est);";

                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@pac", c.IdPaciente),
                    new MySqlParameter("@med", c.IdMedico),
                    new MySqlParameter("@serv", c.IdServicio),
                    new MySqlParameter("@fecha", c.FechaHora),
                    new MySqlParameter("@est", string.IsNullOrWhiteSpace(c.Estado) ? "Programada" : c.Estado));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool Reprogramar(int idCita, DateTime nuevaFechaHora, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (nuevaFechaHora < DateTime.Now.AddMinutes(-5))
                {
                    errorMessage = "No se puede reprogramar a una fecha u hora pasada.";
                    return false;
                }

                var cita = GetById(idCita);
                if (cita == null)
                {
                    errorMessage = "Cita no encontrada.";
                    return false;
                }

                if (cita.Estado == "Atendida" || cita.Estado == "Cancelada")
                {
                    errorMessage = $"No se puede reprogramar una cita con estado '{cita.Estado}'.";
                    return false;
                }

                DateTime inicioVentana = nuevaFechaHora.AddMinutes(-29);
                DateTime finVentana = nuevaFechaHora.AddMinutes(29);

                string checkMedico = @"
                    SELECT COUNT(*) FROM citas 
                    WHERE id_medico = @medico 
                      AND id_cita <> @id
                      AND estado NOT IN ('Cancelada', 'No asistió')
                      AND fecha_hora BETWEEN @inicio AND @fin;";

                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkMedico,
                    new MySqlParameter("@medico", cita.IdMedico),
                    new MySqlParameter("@id", idCita),
                    new MySqlParameter("@inicio", inicioVentana),
                    new MySqlParameter("@fin", finVentana)));

                if (count > 0)
                {
                    errorMessage = "El médico ya tiene otra cita en el horario seleccionado.";
                    return false;
                }

                string sql = "UPDATE citas SET fecha_hora = @fecha, estado = 'Programada' WHERE id_cita = @id;";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@fecha", nuevaFechaHora),
                    new MySqlParameter("@id", idCita));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool Cancelar(int idCita, string motivo, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var cita = GetById(idCita);
                if (cita == null)
                {
                    errorMessage = "Cita no encontrada.";
                    return false;
                }

                if (cita.Estado == "Atendida")
                {
                    errorMessage = "No se puede cancelar una cita que ya fue atendida.";
                    return false;
                }

                string sql = "UPDATE citas SET estado = 'Cancelada', motivo_cancelacion = @motivo WHERE id_cita = @id;";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@motivo", string.IsNullOrWhiteSpace(motivo) ? "Cancelada por el usuario" : motivo.Trim()),
                    new MySqlParameter("@id", idCita));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool ActualizarEstado(int idCita, string nuevoEstado, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sql = "UPDATE citas SET estado = @est WHERE id_cita = @id;";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@est", nuevoEstado),
                    new MySqlParameter("@id", idCita));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
