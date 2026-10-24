using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Modals;
using Forms.Models;
using Forms.Services;

namespace Forms.Controls
{
    public partial class UcUsuarios : UserControl
    {
        private readonly UsuarioRepository _repository = new UsuarioRepository();
        private List<Usuario> _usuariosActuales = new List<Usuario>();

        public UcUsuarios()
        {
            InitializeComponent();
        }

        private void UcUsuarios_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsAdmin)
            {
                pnlToolbar.Enabled = false;
                dgvUsuarios.Enabled = false;
                MessageBox.Show("Acceso denegado: este módulo es exclusivo del rol Administración.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CargarUsuarios();
        }

        public void CargarUsuarios(string search = "")
        {
            try
            {
                _usuariosActuales = _repository.GetAll(search);
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = _usuariosActuales;

                if (dgvUsuarios.Columns.Count > 0)
                {
                    dgvUsuarios.Columns["IdUsuario"].HeaderText = "ID";
                    dgvUsuarios.Columns["IdUsuario"].Width = 60;
                    dgvUsuarios.Columns["Username"].HeaderText = "Usuario";
                    dgvUsuarios.Columns["Roles"].HeaderText = "Rol Asignado";
                    dgvUsuarios.Columns["NombreMedico"].HeaderText = "Médico Vinculado";
                    dgvUsuarios.Columns["Activo"].HeaderText = "Estado Activo";
                    dgvUsuarios.Columns["Activo"].Width = 100;
                    dgvUsuarios.Columns["UltimoAcceso"].HeaderText = "Último Acceso";
                    dgvUsuarios.Columns["UltimoAcceso"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

                    dgvUsuarios.Columns["PasswordHash"].Visible = false;
                    dgvUsuarios.Columns["IdMedico"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Usuario GetSelectedUsuario()
        {
            if (dgvUsuarios.CurrentRow != null && dgvUsuarios.CurrentRow.DataBoundItem is Usuario u)
            {
                return u;
            }
            return null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios(txtBuscar.Text.Trim());
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var modal = new FrmUsuarioModal())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedUsuario();
            if (sel == null)
            {
                MessageBox.Show("Seleccione un usuario de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var modal = new FrmUsuarioModal(sel))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }

        private void btnToggleActivo_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedUsuario();
            if (sel == null)
            {
                MessageBox.Show("Seleccione un usuario de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (sel.IdUsuario == SessionManager.CurrentUser.IdUsuario)
            {
                MessageBox.Show("No puede desactivar su propia cuenta activa.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool nuevoEstado = !sel.Activo;
            string accionStr = nuevoEstado ? "activar" : "bloquear / desactivar";

            var confirm = MessageBox.Show(
                $"¿Desea {accionStr} la cuenta de '{sel.Username}'?",
                "Confirmar Acción de Cuenta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_repository.ToggleActivo(sel.IdUsuario, nuevoEstado, out string error))
                {
                    MessageBox.Show($"La cuenta de {sel.Username} ha sido {(nuevoEstado ? "activada" : "desactivada")}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedUsuario();
            if (sel == null)
            {
                MessageBox.Show("Seleccione un usuario para restablecer la contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FrmPromptModal.ShowPrompt("Restablecer Contraseña", $"Ingrese la nueva contraseña para '{sel.Username}':", out string nuevaClave))
            {
                if (nuevaClave.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener un mínimo de 6 caracteres.", "Clave muy corta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_repository.ResetPassword(sel.IdUsuario, nuevaClave, out string error))
                {
                    MessageBox.Show($"Contraseña actualizada con éxito para el usuario '{sel.Username}'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMatrizPermisos_Click(object sender, EventArgs e)
        {
            string matriz = @"
===========================================================
  MATRIZ INSTITUCIONAL DE PERMISOS POR ROL
  C = Crear | L = Leer | E = Editar | X = Eliminar
===========================================================

Módulo                | Administración | Médico         | Recepcionista
----------------------|----------------|----------------|---------------
Panel Principal       | L              | L (su agenda)  | L
Pacientes             | C, L, E, X     | L              | C, L, E
Médicos               | C, L, E, X     | L              | L
Deptos. y Espec.      | C, L, E, X     | L              | L
Servicios             | C, L, E, X     | L              | L
Citas                 | C, L, E, X     | L (las suyas),E| C, L, E, cancelar
Consultas             | L              | C, L, E        | -
Receta (detalle)      | L              | C, L, E        | -
Medicamentos          | C, L, E, X     | L              | -
Usuarios y roles      | C, L, E, X     | -              | -
Perfil propio         | L, E           | L, E           | L, E

* El sistema aplica estas reglas tanto a nivel visual como en la capa lógica del servidor.";

            MessageBox.Show(matriz, "Matriz de Permisos por Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
