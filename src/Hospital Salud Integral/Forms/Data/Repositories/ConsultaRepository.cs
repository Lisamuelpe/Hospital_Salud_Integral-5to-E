using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Forms.Data;
using Forms.Models;

namespace Forms.Data.Repositories
{
    public class ConsultaRepository
    {
        public Consulta GetByCitaId(int idCita)
        {
            string sql = @"
                SELECT c.id_consulta, c.id_cita, c.diagnostico, c.observaciones, c.fecha_consulta,
                       CONCAT(p.nombre, ' ', p.apellido) AS paciente, p.documento,
                       CONCAT(m.nombre, ' ', m.apellido) AS medico,
                       s.nombre AS servicio, ci.fecha_hora AS fecha_hora_cita
                FROM consultas c
                INNER JOIN citas ci ON c.id_cita = ci.id_cita
                INNER JOIN pacientes p ON ci.id_paciente = p.id_paciente
                INNER JOIN medicos m ON ci.id_medico = m.id_medico
                INNER JOIN servicios s ON ci.id_servicio = s.id_servicio
                WHERE c.id_cita = @cita LIMIT 1;";

            var dt = DbConnection.ExecuteQuery(sql, new MySqlParameter("@cita", idCita));
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new Consulta
            {
                IdConsulta = Convert.ToInt32(row["id_consulta"]),
                IdCita = Convert.ToInt32(row["id_cita"]),
                Diagnostico = row["diagnostico"].ToString(),
                Observaciones = row["observaciones"] != DBNull.Value ? row["observaciones"].ToString() : "",
                FechaConsulta = Convert.ToDateTime(row["fecha_consulta"]),
                NombrePaciente = row["paciente"].ToString(),
                DocumentoPaciente = row["documento"].ToString(),
                NombreMedico = row["medico"].ToString(),
                Servicio = row["servicio"].ToString(),
                FechaHoraCita = Convert.ToDateTime(row["fecha_hora_cita"])
            };
        }

        public List<DetalleReceta> GetRecetasByConsulta(int idConsulta)
        {
            var list = new List<DetalleReceta>();
            string sql = @"
                SELECT dr.id_consulta, dr.id_medicamento, dr.dosis, dr.duracion_dias, dr.detalles,
                       m.nombre AS medicamento, m.presentacion
                FROM detalle_receta dr
                INNER JOIN medicamentos m ON dr.id_medicamento = m.id_medicamento
                WHERE dr.id_consulta = @id;";

            var dt = DbConnection.ExecuteQuery(sql, new MySqlParameter("@id", idConsulta));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DetalleReceta
                {
                    IdConsulta = Convert.ToInt32(row["id_consulta"]),
                    IdMedicamento = Convert.ToInt32(row["id_medicamento"]),
                    NombreMedicamento = row["medicamento"].ToString(),
                    PresentacionMedicamento = row["presentacion"].ToString(),
                    Dosis = row["dosis"].ToString(),
                    DuracionDias = Convert.ToInt32(row["duracion_dias"]),
                    Detalles = row["detalles"] != DBNull.Value ? row["detalles"].ToString() : ""
                });
            }
            return list;
        }

        public bool RegistrarConsultaConReceta(Consulta consulta, List<DetalleReceta> recetas, out string warnings, out string errorMessage)
        {
            warnings = string.Empty;
            errorMessage = string.Empty;

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Validar que la cita no tenga ya una consulta registrada (1 : 0..1)
                        string checkSql = "SELECT COUNT(*) FROM consultas WHERE id_cita = @cita;";
                        using (var checkCmd = new MySqlCommand(checkSql, conn, trans))
                        {
                            checkCmd.Parameters.AddWithValue("@cita", consulta.IdCita);
                            long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                            if (count > 0)
                            {
                                errorMessage = "Esta cita ya tiene una consulta clínica registrada.";
                                trans.Rollback();
                                return false;
                            }
                        }

                        // 2. Insertar consulta
                        string insertConsultaSql = @"
                            INSERT INTO consultas (id_cita, diagnostico, observaciones, fecha_consulta)
                            VALUES (@cita, @diag, @obs, NOW());
                            SELECT LAST_INSERT_ID();";

                        int idConsultaGenerada = 0;
                        using (var cmdConsulta = new MySqlCommand(insertConsultaSql, conn, trans))
                        {
                            cmdConsulta.Parameters.AddWithValue("@cita", consulta.IdCita);
                            cmdConsulta.Parameters.AddWithValue("@diag", consulta.Diagnostico.Trim());
                            cmdConsulta.Parameters.AddWithValue("@obs", string.IsNullOrWhiteSpace(consulta.Observaciones) ? (object)DBNull.Value : consulta.Observaciones.Trim());
                            idConsultaGenerada = Convert.ToInt32(cmdConsulta.ExecuteScalar());
                        }

                        // 3. Marcar cita como 'Atendida'
                        string updateCitaSql = "UPDATE citas SET estado = 'Atendida' WHERE id_cita = @cita;";
                        using (var cmdCita = new MySqlCommand(updateCitaSql, conn, trans))
                        {
                            cmdCita.Parameters.AddWithValue("@cita", consulta.IdCita);
                            cmdCita.ExecuteNonQuery();
                        }

                        // 4. Procesar receta y stock de medicamentos
                        if (recetas != null && recetas.Count > 0)
                        {
                            var warningList = new List<string>();

                            foreach (var item in recetas)
                            {
                                // Verificar stock actual
                                string checkStockSql = "SELECT stock, nombre FROM medicamentos WHERE id_medicamento = @med FOR UPDATE;";
                                int currentStock = 0;
                                string medNombre = item.NombreMedicamento;
                                using (var cmdStock = new MySqlCommand(checkStockSql, conn, trans))
                                {
                                    cmdStock.Parameters.AddWithValue("@med", item.IdMedicamento);
                                    using (var reader = cmdStock.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            currentStock = Convert.ToInt32(reader["stock"]);
                                            medNombre = reader["nombre"].ToString();
                                        }
                                    }
                                }

                                if (currentStock <= 0)
                                {
                                    warningList.Add($"¡Atención! El medicamento '{medNombre}' está AGOTADO en inventario.");
                                }
                                else if (currentStock <= 15)
                                {
                                    warningList.Add($"Aviso: El medicamento '{medNombre}' cuenta con stock bajo ({currentStock} disponibles).");
                                }

                                // Insertar en detalle_receta
                                string insertRecetaSql = @"
                                    INSERT INTO detalle_receta (id_consulta, id_medicamento, dosis, duracion_dias, detalles)
                                    VALUES (@con, @med, @dos, @dur, @det);";

                                using (var cmdReceta = new MySqlCommand(insertRecetaSql, conn, trans))
                                {
                                    cmdReceta.Parameters.AddWithValue("@con", idConsultaGenerada);
                                    cmdReceta.Parameters.AddWithValue("@med", item.IdMedicamento);
                                    cmdReceta.Parameters.AddWithValue("@dos", item.Dosis.Trim());
                                    cmdReceta.Parameters.AddWithValue("@dur", item.DuracionDias);
                                    cmdReceta.Parameters.AddWithValue("@det", string.IsNullOrWhiteSpace(item.Detalles) ? (object)DBNull.Value : item.Detalles.Trim());
                                    cmdReceta.ExecuteNonQuery();
                                }
                            }

                            if (warningList.Count > 0)
                            {
                                warnings = string.Join("\n", warningList);
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        errorMessage = ex.Message;
                        return false;
                    }
                }
            }
        }
    }
}
