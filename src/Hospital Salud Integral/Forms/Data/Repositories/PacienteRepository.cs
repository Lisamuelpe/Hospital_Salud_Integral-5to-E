using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Forms.Data;
using Forms.Models;

namespace Forms.Data.Repositories
{
    public class PacienteRepository
    {
        public List<Paciente> GetAll(string search = "")
        {
            var list = new List<Paciente>();
            string sql = @"
                SELECT id_paciente, documento, nombre, apellido, fecha_nacimiento, sexo, telefono
                FROM pacientes
                WHERE 1=1";

            var parameters = new List<MySqlParameter>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                sql += " AND (documento LIKE @search OR nombre LIKE @search OR apellido LIKE @search)";
                parameters.Add(new MySqlParameter("@search", "%" + search.Trim() + "%"));
            }
            sql += " ORDER BY apellido, nombre;";

            var dt = DbConnection.ExecuteQuery(sql, parameters.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Paciente
                {
                    IdPaciente = Convert.ToInt32(row["id_paciente"]),
                    Documento = row["documento"].ToString(),
                    Nombre = row["nombre"].ToString(),
                    Apellido = row["apellido"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]),
                    Sexo = row["sexo"].ToString(),
                    Telefono = row["telefono"] != DBNull.Value ? row["telefono"].ToString() : ""
                });
            }
            return list;
        }

        public Paciente GetById(int id)
        {
            string sql = "SELECT * FROM pacientes WHERE id_paciente = @id LIMIT 1;";
            var dt = DbConnection.ExecuteQuery(sql, new MySqlParameter("@id", id));
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new Paciente
            {
                IdPaciente = Convert.ToInt32(row["id_paciente"]),
                Documento = row["documento"].ToString(),
                Nombre = row["nombre"].ToString(),
                Apellido = row["apellido"].ToString(),
                FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]),
                Sexo = row["sexo"].ToString(),
                Telefono = row["telefono"] != DBNull.Value ? row["telefono"].ToString() : ""
            };
        }

        public bool Insert(Paciente p, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                // Validar documento único
                string checkSql = "SELECT COUNT(*) FROM pacientes WHERE documento = @doc;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, new MySqlParameter("@doc", p.Documento.Trim())));
                if (count > 0)
                {
                    errorMessage = "Ya existe un paciente registrado con el documento: " + p.Documento;
                    return false;
                }

                string sql = @"
                    INSERT INTO pacientes (documento, nombre, apellido, fecha_nacimiento, sexo, telefono)
                    VALUES (@doc, @nom, @ape, @fecha, @sexo, @tel);";

                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@doc", p.Documento.Trim()),
                    new MySqlParameter("@nom", p.Nombre.Trim()),
                    new MySqlParameter("@ape", p.Apellido.Trim()),
                    new MySqlParameter("@fecha", p.FechaNacimiento.Date),
                    new MySqlParameter("@sexo", p.Sexo.Trim()),
                    new MySqlParameter("@tel", string.IsNullOrWhiteSpace(p.Telefono) ? (object)DBNull.Value : p.Telefono.Trim()));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool Update(Paciente p, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                // Validar documento duplicado en otro paciente
                string checkSql = "SELECT COUNT(*) FROM pacientes WHERE documento = @doc AND id_paciente <> @id;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, 
                    new MySqlParameter("@doc", p.Documento.Trim()),
                    new MySqlParameter("@id", p.IdPaciente)));
                if (count > 0)
                {
                    errorMessage = "El documento ya pertenece a otro paciente.";
                    return false;
                }

                string sql = @"
                    UPDATE pacientes 
                    SET documento = @doc, nombre = @nom, apellido = @ape, 
                        fecha_nacimiento = @fecha, sexo = @sexo, telefono = @tel
                    WHERE id_paciente = @id;";

                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@doc", p.Documento.Trim()),
                    new MySqlParameter("@nom", p.Nombre.Trim()),
                    new MySqlParameter("@ape", p.Apellido.Trim()),
                    new MySqlParameter("@fecha", p.FechaNacimiento.Date),
                    new MySqlParameter("@sexo", p.Sexo.Trim()),
                    new MySqlParameter("@tel", string.IsNullOrWhiteSpace(p.Telefono) ? (object)DBNull.Value : p.Telefono.Trim()),
                    new MySqlParameter("@id", p.IdPaciente));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool Delete(int id, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                // Verificar si tiene citas asociadas
                string checkSql = "SELECT COUNT(*) FROM citas WHERE id_paciente = @id;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, new MySqlParameter("@id", id)));
                if (count > 0)
                {
                    errorMessage = "No se puede eliminar el paciente porque tiene citas registradas en el sistema.";
                    return false;
                }

                string sql = "DELETE FROM pacientes WHERE id_paciente = @id;";
                DbConnection.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public DataTable GetHistorialCitasYConsultas(int idPaciente)
        {
            string sql = @"
                SELECT c.id_cita, c.fecha_hora, c.estado, 
                       CONCAT(m.nombre, ' ', m.apellido) AS medico,
                       s.nombre AS servicio,
                       con.diagnostico, con.observaciones
                FROM citas c
                INNER JOIN medicos m ON c.id_medico = m.id_medico
                INNER JOIN servicios s ON c.id_servicio = s.id_servicio
                LEFT JOIN consultas con ON c.id_cita = con.id_cita
                WHERE c.id_paciente = @id
                ORDER BY c.fecha_hora DESC;";

            return DbConnection.ExecuteQuery(sql, new MySqlParameter("@id", idPaciente));
        }
    }
}
