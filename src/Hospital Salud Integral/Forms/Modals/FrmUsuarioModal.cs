using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Models;

namespace Forms.Modals
{
    public partial class FrmUsuarioModal : Form
    {
        private readonly UsuarioRepository _userRepo = new UsuarioRepository();
        private readonly MedicoRepository _medicoRepo = new MedicoRepository();
        private readonly Usuario _usuarioExistente;

        public FrmUsuarioModal(Usuario usuario = null)
        {
            InitializeComponent();
            _usuarioExistente = usuario;
            CargarMedicos();

            if (_usuarioExistente != null)
            {
                lblTitle.Text = "Editar Usuario";
                txtUsername.Text = _usuarioExistente.Username;
                cboRol.SelectedItem = _usuarioExistente.Roles;
                chkActivo.Checked = _usuarioExistente.Activo;
                if (_usuarioExistente.IdMedico.HasValue)
                {
                    cboMedico.SelectedValue = _usuarioExistente.IdMedico.Value;
                }
                else
                {
                    cboMedico.SelectedIndex = 0;
                }

                lblPassword.Text = "Nueva Contraseña (dejar vacío para mantener):";
            }
            else
            {
                lblTitle.Text = "Nuevo Usuario";
                cboRol.SelectedIndex = 0;
                cboMedico.SelectedIndex = 0;
            }
        }

        private void CargarMedicos()
        {
            var medicos = _medicoRepo.GetAll();
            var list = new List<dynamic>
            {
                new { Id = (int?)null, Nombre = "-- Ninguno (No es médico) --" }
            };
            foreach (var m in medicos)
            {
                list.Add(new { Id = (int?)m.IdMedico, Nombre = m.NombreCompleto });
            }

            cboMedico.DisplayMember = "Nombre";
            cboMedico.ValueMember = "Id";
            cboMedico.DataSource = list;
        }

        private void cboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rol = cboRol.SelectedItem?.ToString();
            cboMedico.Enabled = string.Equals(rol, "Médico", StringComparison.OrdinalIgnoreCase);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string rol = cboRol.SelectedItem?.ToString();
            string password = txtPassword.Text;
            bool activo = chkActivo.Checked;
            int? idMedico = (cboMedico.SelectedValue != null && cboMedico.SelectedValue is int idVal) ? (int?)idVal : null;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(rol))
            {
                MessageBox.Show("Por favor indique el nombre de usuario y el rol.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_usuarioExistente == null)
            {
                if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                {
                    MessageBox.Show("La contraseña es obligatoria y debe tener al menos 6 caracteres.", "Contraseña requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                var nuevo = new Usuario
                {
                    Username = username,
                    Roles = rol,
                    IdMedico = idMedico,
                    Activo = activo
                };

                if (_userRepo.Insert(nuevo, password, out string error))
                {
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(error, "Error al crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _usuarioExistente.Username = username;
                _usuarioExistente.Roles = rol;
                _usuarioExistente.IdMedico = idMedico;
                _usuarioExistente.Activo = activo;

                if (_userRepo.Update(_usuarioExistente, out string error))
                {
                    // Si ingresó nueva contraseña, actualizarla
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        if (password.Length < 6)
                        {
                            MessageBox.Show("La nueva contraseña debe tener al menos 6 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        _userRepo.ResetPassword(_usuarioExistente.IdUsuario, password, out string pwdError);
                    }

                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(error, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
