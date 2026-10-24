using System;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Forms.Data;
using Forms.Models;

namespace Forms.Services
{
    public static class AuthService
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return string.Empty;
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool ValidateLogin(string username, string password, out Usuario usuario, out string errorMessage)
        {
            usuario = null;
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Por favor ingrese su usuario y contraseña.";
                return false;
            }

            try
            {
                string sql = @"
                    SELECT u.id_usuario, u.username, u.password_hash, u.roles, u.id_medico, u.activo, u.ultimo_acceso,
                           CONCAT(m.nombre, ' ', m.apellido) AS nombre_medico
                    FROM usuarios u
                    LEFT JOIN medicos m ON u.id_medico = m.id_medico
                    WHERE u.username = @username
                    LIMIT 1;";

                var dt = DbConnection.ExecuteQuery(sql, new MySqlParameter("@username", username.Trim()));
                if (dt.Rows.Count == 0)
                {
                    // Mensaje genérico por seguridad (Sección 4.1 del documento técnico)
                    errorMessage = "Credenciales incorrectas. Verifique su usuario y contraseña.";
                    return false;
                }

                var row = dt.Rows[0];
                bool activo = Convert.ToInt32(row["activo"]) == 1;
                if (!activo)
                {
                    errorMessage = "Su cuenta se encuentra desactivada o bloqueada. Contacte al administrador.";
                    return false;
                }

                string storedHash = row["password_hash"].ToString();
                string inputHash = HashPassword(password);

                if (!string.Equals(storedHash, inputHash, StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = "Credenciales incorrectas. Verifique su usuario y contraseña.";
                    return false;
                }

                usuario = new Usuario
                {
                    IdUsuario = Convert.ToInt32(row["id_usuario"]),
                    Username = row["username"].ToString(),
                    PasswordHash = storedHash,
                    Roles = row["roles"].ToString(),
                    IdMedico = row["id_medico"] != DBNull.Value ? (int?)Convert.ToInt32(row["id_medico"]) : null,
                    Activo = activo,
                    UltimoAcceso = row["ultimo_acceso"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["ultimo_acceso"]) : null,
                    NombreMedico = row["nombre_medico"] != DBNull.Value ? row["nombre_medico"].ToString() : null
                };

                // Actualizar último acceso
                string updateAccessSql = "UPDATE usuarios SET ultimo_acceso = NOW() WHERE id_usuario = @id;";
                DbConnection.ExecuteNonQuery(updateAccessSql, new MySqlParameter("@id", usuario.IdUsuario));

                SessionManager.SetCurrentSession(usuario);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Error al conectar con la base de datos: " + ex.Message;
                return false;
            }
        }

        public static bool ChangePassword(int idUsuario, string currentPassword, string newPassword, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            {
                errorMessage = "La nueva contraseña debe tener al menos 6 caracteres.";
                return false;
            }

            try
            {
                string sqlCheck = "SELECT password_hash FROM usuarios WHERE id_usuario = @id;";
                var obj = DbConnection.ExecuteScalar(sqlCheck, new MySqlParameter("@id", idUsuario));
                if (obj == null)
                {
                    errorMessage = "Usuario no encontrado.";
                    return false;
                }

                string currentHash = obj.ToString();
                if (!string.Equals(currentHash, HashPassword(currentPassword), StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = "La contraseña actual no es correcta.";
                    return false;
                }

                string newHash = HashPassword(newPassword);
                string sqlUpdate = "UPDATE usuarios SET password_hash = @hash WHERE id_usuario = @id;";
                DbConnection.ExecuteNonQuery(sqlUpdate, 
                    new MySqlParameter("@hash", newHash), 
                    new MySqlParameter("@id", idUsuario));

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Error al cambiar la contraseña: " + ex.Message;
                return false;
            }
        }
    }
}
