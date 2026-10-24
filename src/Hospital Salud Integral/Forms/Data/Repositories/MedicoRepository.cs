using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Forms.Data;
using Forms.Models;

namespace Forms.Data.Repositories
{
    public class MedicoRepository
    {
        public List<Medico> GetAll(string search = "")
        {
            var list = new List<Medico>();
            string sql = @"
                SELECT m.id_medico, m.id_especialidad, m.nombre, m.apellido, m.licencia, m.telefono,
                       e.nombre AS especialidad
                FROM medicos m
                INNER JOIN especialidades e ON m.id_especialidad = e.id_especialidad
                WHERE 1=1";

            var parameters = new List<MySqlParameter>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                sql += " AND (m.licencia LIKE @search OR m.nombre LIKE @search OR m.apellido LIKE @search OR e.nombre LIKE @search)";
                parameters.Add(new MySqlParameter("@search", "%" + search.Trim() + "%"));
            }
            sql += " ORDER BY m.apellido, m.nombre;";

            var dt = DbConnection.ExecuteQuery(sql, parameters.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Medico
                {
                    IdMedico = Convert.ToInt32(row["id_medico"]),
                    IdEspecialidad = Convert.ToInt32(row["id_especialidad"]),
                    Nombre = row["nombre"].ToString(),
                    Apellido = row["apellido"].ToString(),
                    Licencia = row["licencia"].ToString(),
                    Telefono = row["telefono"] != DBNull.Value ? row["telefono"].ToString() : "",
                    NombreEspecialidad = row["especialidad"].ToString()
                });
            }
            return list;
        }

        public bool Insert(Medico m, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkSql = "SELECT COUNT(*) FROM medicos WHERE licencia = @lic;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, new MySqlParameter("@lic", m.Licencia.Trim())));
                if (count > 0)
                {
                    errorMessage = "Ya existe un médico con la licencia médica: " + m.Licencia;
                    return false;
                }

                string sql = @"
                    INSERT INTO medicos (id_especialidad, nombre, apellido, licencia, telefono)
                    VALUES (@esp, @nom, @ape, @lic, @tel);";

                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@esp", m.IdEspecialidad),
                    new MySqlParameter("@nom", m.Nombre.Trim()),
                    new MySqlParameter("@ape", m.Apellido.Trim()),
                    new MySqlParameter("@lic", m.Licencia.Trim()),
                    new MySqlParameter("@tel", string.IsNullOrWhiteSpace(m.Telefono) ? (object)DBNull.Value : m.Telefono.Trim()));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool Update(Medico m, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkSql = "SELECT COUNT(*) FROM medicos WHERE licencia = @lic AND id_medico <> @id;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, 
                    new MySqlParameter("@lic", m.Licencia.Trim()),
                    new MySqlParameter("@id", m.IdMedico)));
                if (count > 0)
                {
                    errorMessage = "La licencia médica ya está registrada por otro profesional.";
                    return false;
                }

                string sql = @"
                    UPDATE medicos 
                    SET id_especialidad = @esp, nombre = @nom, apellido = @ape, 
                        licencia = @lic, telefono = @tel
                    WHERE id_medico = @id;";

                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@esp", m.IdEspecialidad),
                    new MySqlParameter("@nom", m.Nombre.Trim()),
                    new MySqlParameter("@ape", m.Apellido.Trim()),
                    new MySqlParameter("@lic", m.Licencia.Trim()),
                    new MySqlParameter("@tel", string.IsNullOrWhiteSpace(m.Telefono) ? (object)DBNull.Value : m.Telefono.Trim()),
                    new MySqlParameter("@id", m.IdMedico));

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
                string checkSql = "SELECT COUNT(*) FROM citas WHERE id_medico = @id;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, new MySqlParameter("@id", id)));
                if (count > 0)
                {
                    errorMessage = "No se puede eliminar el médico porque tiene citas programadas o atendidas.";
                    return false;
                }

                string sql = "DELETE FROM medicos WHERE id_medico = @id;";
                DbConnection.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
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
