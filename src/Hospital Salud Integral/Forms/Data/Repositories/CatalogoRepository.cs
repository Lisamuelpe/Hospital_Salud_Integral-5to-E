using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Forms.Data;
using Forms.Models;

namespace Forms.Data.Repositories
{
    public class CatalogoRepository
    {
        #region Departamentos
        public List<Departamento> GetDepartamentos()
        {
            var list = new List<Departamento>();
            string sql = "SELECT id_departamento, nombre, ubicacion FROM departamentos ORDER BY nombre;";
            var dt = DbConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Departamento
                {
                    IdDepartamento = Convert.ToInt32(row["id_departamento"]),
                    Nombre = row["nombre"].ToString(),
                    Ubicacion = row["ubicacion"].ToString()
                });
            }
            return list;
        }

        public bool InsertDepartamento(Departamento d, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkSql = "SELECT COUNT(*) FROM departamentos WHERE nombre = @nom;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, new MySqlParameter("@nom", d.Nombre.Trim())));
                if (count > 0)
                {
                    errorMessage = "Ya existe un departamento con ese nombre.";
                    return false;
                }

                string sql = "INSERT INTO departamentos (nombre, ubicacion) VALUES (@nom, @ubi);";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@nom", d.Nombre.Trim()),
                    new MySqlParameter("@ubi", d.Ubicacion.Trim()));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool UpdateDepartamento(Departamento d, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkSql = "SELECT COUNT(*) FROM departamentos WHERE nombre = @nom AND id_departamento <> @id;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, 
                    new MySqlParameter("@nom", d.Nombre.Trim()),
                    new MySqlParameter("@id", d.IdDepartamento)));
                if (count > 0)
                {
                    errorMessage = "El nombre de departamento ya existe.";
                    return false;
                }

                string sql = "UPDATE departamentos SET nombre = @nom, ubicacion = @ubi WHERE id_departamento = @id;";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@nom", d.Nombre.Trim()),
                    new MySqlParameter("@ubi", d.Ubicacion.Trim()),
                    new MySqlParameter("@id", d.IdDepartamento));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool DeleteDepartamento(int id, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                // Regla de negocio: No se puede eliminar si tiene especialidades o servicios
                string checkEsp = "SELECT COUNT(*) FROM especialidades WHERE id_departamento = @id;";
                long countEsp = Convert.ToInt64(DbConnection.ExecuteScalar(checkEsp, new MySqlParameter("@id", id)));
                if (countEsp > 0)
                {
                    errorMessage = "No se puede eliminar el departamento porque tiene especialidades asociadas.";
                    return false;
                }

                string checkServ = "SELECT COUNT(*) FROM servicios WHERE id_departamento = @id;";
                long countServ = Convert.ToInt64(DbConnection.ExecuteScalar(checkServ, new MySqlParameter("@id", id)));
                if (countServ > 0)
                {
                    errorMessage = "No se puede eliminar el departamento porque tiene servicios asociados.";
                    return false;
                }

                string sql = "DELETE FROM departamentos WHERE id_departamento = @id;";
                DbConnection.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
        #endregion

        #region Especialidades
        public List<Especialidad> GetEspecialidades(int? idDepartamento = null)
        {
            var list = new List<Especialidad>();
            string sql = @"
                SELECT e.id_especialidad, e.id_departamento, e.nombre, d.nombre AS nombre_departamento
                FROM especialidades e
                INNER JOIN departamentos d ON e.id_departamento = d.id_departamento";

            var parameters = new List<MySqlParameter>();
            if (idDepartamento.HasValue)
            {
                sql += " WHERE e.id_departamento = @dep";
                parameters.Add(new MySqlParameter("@dep", idDepartamento.Value));
            }
            sql += " ORDER BY e.nombre;";

            var dt = DbConnection.ExecuteQuery(sql, parameters.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Especialidad
                {
                    IdEspecialidad = Convert.ToInt32(row["id_especialidad"]),
                    IdDepartamento = Convert.ToInt32(row["id_departamento"]),
                    Nombre = row["nombre"].ToString(),
                    NombreDepartamento = row["nombre_departamento"].ToString()
                });
            }
            return list;
        }

        public bool InsertEspecialidad(Especialidad e, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkSql = "SELECT COUNT(*) FROM especialidades WHERE nombre = @nom;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, new MySqlParameter("@nom", e.Nombre.Trim())));
                if (count > 0)
                {
                    errorMessage = "Ya existe una especialidad con este nombre.";
                    return false;
                }

                string sql = "INSERT INTO especialidades (id_departamento, nombre) VALUES (@dep, @nom);";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@dep", e.IdDepartamento),
                    new MySqlParameter("@nom", e.Nombre.Trim()));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool UpdateEspecialidad(Especialidad e, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkSql = "SELECT COUNT(*) FROM especialidades WHERE nombre = @nom AND id_especialidad <> @id;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, 
                    new MySqlParameter("@nom", e.Nombre.Trim()),
                    new MySqlParameter("@id", e.IdEspecialidad)));
                if (count > 0)
                {
                    errorMessage = "El nombre de especialidad ya está en uso.";
                    return false;
                }

                string sql = "UPDATE especialidades SET id_departamento = @dep, nombre = @nom WHERE id_especialidad = @id;";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@dep", e.IdDepartamento),
                    new MySqlParameter("@nom", e.Nombre.Trim()),
                    new MySqlParameter("@id", e.IdEspecialidad));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool DeleteEspecialidad(int id, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkMedicos = "SELECT COUNT(*) FROM medicos WHERE id_especialidad = @id;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkMedicos, new MySqlParameter("@id", id)));
                if (count > 0)
                {
                    errorMessage = "No se puede eliminar la especialidad porque tiene médicos asignados.";
                    return false;
                }

                string sql = "DELETE FROM especialidades WHERE id_especialidad = @id;";
                DbConnection.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
        #endregion

        #region Servicios
        public List<Servicio> GetServicios(int? idDepartamento = null)
        {
            var list = new List<Servicio>();
            string sql = @"
                SELECT s.id_servicio, s.id_departamento, s.nombre, s.costo, d.nombre AS nombre_departamento
                FROM servicios s
                INNER JOIN departamentos d ON s.id_departamento = d.id_departamento";

            var parameters = new List<MySqlParameter>();
            if (idDepartamento.HasValue)
            {
                sql += " WHERE s.id_departamento = @dep";
                parameters.Add(new MySqlParameter("@dep", idDepartamento.Value));
            }
            sql += " ORDER BY s.nombre;";

            var dt = DbConnection.ExecuteQuery(sql, parameters.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Servicio
                {
                    IdServicio = Convert.ToInt32(row["id_servicio"]),
                    IdDepartamento = Convert.ToInt32(row["id_departamento"]),
                    Nombre = row["nombre"].ToString(),
                    Costo = Convert.ToDecimal(row["costo"]),
                    NombreDepartamento = row["nombre_departamento"].ToString()
                });
            }
            return list;
        }

        public bool InsertServicio(Servicio s, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sql = "INSERT INTO servicios (id_departamento, nombre, costo) VALUES (@dep, @nom, @costo);";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@dep", s.IdDepartamento),
                    new MySqlParameter("@nom", s.Nombre.Trim()),
                    new MySqlParameter("@costo", s.Costo));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool UpdateServicio(Servicio s, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sql = "UPDATE servicios SET id_departamento = @dep, nombre = @nom, costo = @costo WHERE id_servicio = @id;";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@dep", s.IdDepartamento),
                    new MySqlParameter("@nom", s.Nombre.Trim()),
                    new MySqlParameter("@costo", s.Costo),
                    new MySqlParameter("@id", s.IdServicio));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool DeleteServicio(int id, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkCitas = "SELECT COUNT(*) FROM citas WHERE id_servicio = @id;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkCitas, new MySqlParameter("@id", id)));
                if (count > 0)
                {
                    errorMessage = "No se puede eliminar el servicio porque está asociado a citas médicas.";
                    return false;
                }

                string sql = "DELETE FROM servicios WHERE id_servicio = @id;";
                DbConnection.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
        #endregion
    }
}
