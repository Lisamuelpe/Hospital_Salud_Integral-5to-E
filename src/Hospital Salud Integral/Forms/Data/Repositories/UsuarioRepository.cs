using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Forms.Data;
using Forms.Models;
using Forms.Services;

namespace Forms.Data.Repositories
{
    public class UsuarioRepository
    {
        public List<Usuario> GetAll(string search = "")
        {
            var list = new List<Usuario>();
            string sql = @"
                SELECT u.id_usuario, u.username, u.password_hash, u.roles, u.id_medico, u.activo, u.ultimo_acceso,
                       CONCAT(m.nombre, ' ', m.apellido) AS nombre_medico
                FROM usuarios u
                LEFT JOIN medicos m ON u.id_medico = m.id_medico
                WHERE 1=1";

            var parameters = new List<MySqlParameter>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                sql += " AND (u.username LIKE @search OR u.roles LIKE @search OR m.nombre LIKE @search OR m.apellido LIKE @search)";
                parameters.Add(new MySqlParameter("@search", "%" + search.Trim() + "%"));
            }
            sql += " ORDER BY u.username;";

            var dt = DbConnection.ExecuteQuery(sql, parameters.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Usuario
                {
                    IdUsuario = Convert.ToInt32(row["id_usuario"]),
                    Username = row["username"].ToString(),
                    PasswordHash = row["password_hash"].ToString(),
                    Roles = row["roles"].ToString(),
                    IdMedico = row["id_medico"] != DBNull.Value ? (int?)Convert.ToInt32(row["id_medico"]) : null,
                    Activo = Convert.ToInt32(row["activo"]) == 1,
                    UltimoAcceso = row["ultimo_acceso"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["ultimo_acceso"]) : null,
                    NombreMedico = row["nombre_medico"] != DBNull.Value ? row["nombre_medico"].ToString() : ""
                });
            }
            return list;
        }

        public bool Insert(Usuario u, string plainPassword, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkSql = "SELECT COUNT(*) FROM usuarios WHERE username = @user;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, new MySqlParameter("@user", u.Username.Trim())));
                if (count > 0)
                {
                    errorMessage = "El nombre de usuario ya está registrado.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(plainPassword) || plainPassword.Length < 6)
                {
                    errorMessage = "La contraseña debe tener al menos 6 caracteres.";
                    return false;
                }

                string hash = AuthService.HashPassword(plainPassword);

                string sql = @"
                    INSERT INTO usuarios (username, password_hash, roles, id_medico, activo)
                    VALUES (@user, @hash, @role, @med, @act);";

                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@user", u.Username.Trim()),
                    new MySqlParameter("@hash", hash),
                    new MySqlParameter("@role", u.Roles),
                    new MySqlParameter("@med", u.IdMedico.HasValue ? (object)u.IdMedico.Value : DBNull.Value),
                    new MySqlParameter("@act", u.Activo ? 1 : 0));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool Update(Usuario u, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string checkSql = "SELECT COUNT(*) FROM usuarios WHERE username = @user AND id_usuario <> @id;";
                long count = Convert.ToInt64(DbConnection.ExecuteScalar(checkSql, 
                    new MySqlParameter("@user", u.Username.Trim()),
                    new MySqlParameter("@id", u.IdUsuario)));
                if (count > 0)
                {
                    errorMessage = "El nombre de usuario ya está en uso.";
                    return false;
                }

                string sql = @"
                    UPDATE usuarios 
                    SET username = @user, roles = @role, id_medico = @med, activo = @act
                    WHERE id_usuario = @id;";

                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@user", u.Username.Trim()),
                    new MySqlParameter("@role", u.Roles),
                    new MySqlParameter("@med", u.IdMedico.HasValue ? (object)u.IdMedico.Value : DBNull.Value),
                    new MySqlParameter("@act", u.Activo ? 1 : 0),
                    new MySqlParameter("@id", u.IdUsuario));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool ResetPassword(int idUsuario, string newPlainPassword, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(newPlainPassword) || newPlainPassword.Length < 6)
                {
                    errorMessage = "La contraseña debe tener al menos 6 caracteres.";
                    return false;
                }

                string hash = AuthService.HashPassword(newPlainPassword);
                string sql = "UPDATE usuarios SET password_hash = @hash WHERE id_usuario = @id;";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@hash", hash),
                    new MySqlParameter("@id", idUsuario));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool ToggleActivo(int idUsuario, bool nuevoEstado, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sql = "UPDATE usuarios SET activo = @act WHERE id_usuario = @id;";
                DbConnection.ExecuteNonQuery(sql,
                    new MySqlParameter("@act", nuevoEstado ? 1 : 0),
                    new MySqlParameter("@id", idUsuario));
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
