using System;
using System.Windows.Forms;
using Forms.Services;

namespace Forms.Controls
{
    public partial class UcPerfil : UserControl
    {
        public UcPerfil()
        {
            InitializeComponent();
        }

        private void UcPerfil_Load(object sender, EventArgs e)
        {
            CargarDatosPerfil();
        }

        public void CargarDatosPerfil()
        {
            var user = SessionManager.CurrentUser;
            if (user != null)
            {
                lblUsername.Text = "Nombre de Usuario: " + user.Username;
                lblRol.Text = "Rol Asignado: " + user.Roles;
                lblMedicoAsignado.Text = "Médico Vinculado: " + (!string.IsNullOrWhiteSpace(user.NombreMedico) ? user.NombreMedico : "(Ninguno)");
                lblUltimoAcceso.Text = "Último Acceso: " + (user.UltimoAcceso.HasValue ? user.UltimoAcceso.Value.ToString("dd/MM/yyyy hh:mm tt") : "Primer inicio de sesión");
            }
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            string actual = txtCurrentPassword.Text;
            string nueva = txtNewPassword.Text;
            string confirmar = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(actual) || string.IsNullOrWhiteSpace(nueva) || string.IsNullOrWhiteSpace(confirmar))
            {
                MessageBox.Show("Por favor complete todos los campos de contraseña.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nueva.Length < 6)
            {
                MessageBox.Show("La nueva contraseña debe tener al menos 6 caracteres.", "Clave muy corta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (!string.Equals(nueva, confirmar))
            {
                MessageBox.Show("La nueva contraseña y su confirmación no coinciden.", "No coinciden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (AuthService.ChangePassword(SessionManager.CurrentUser.IdUsuario, actual, nueva, out string error))
            {
                MessageBox.Show("Contraseña actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCurrentPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            else
            {
                MessageBox.Show(error, "Error al cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
