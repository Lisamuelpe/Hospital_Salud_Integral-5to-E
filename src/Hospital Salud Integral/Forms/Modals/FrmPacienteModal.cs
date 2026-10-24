using System;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Models;

namespace Forms.Modals
{
    public partial class FrmPacienteModal : Form
    {
        private readonly PacienteRepository _repository = new PacienteRepository();
        private readonly Paciente _pacienteExistente;

        public FrmPacienteModal(Paciente paciente = null)
        {
            InitializeComponent();
            _pacienteExistente = paciente;

            if (_pacienteExistente != null)
            {
                lblTitle.Text = "Editar Paciente";
                txtDocumento.Text = _pacienteExistente.Documento;
                txtNombre.Text = _pacienteExistente.Nombre;
                txtApellido.Text = _pacienteExistente.Apellido;
                dtpFechaNac.Value = _pacienteExistente.FechaNacimiento > dtpFechaNac.MinDate && _pacienteExistente.FechaNacimiento < dtpFechaNac.MaxDate 
                    ? _pacienteExistente.FechaNacimiento 
                    : DateTime.Today.AddYears(-20);
                cboSexo.SelectedItem = _pacienteExistente.Sexo;
                txtTelefono.Text = _pacienteExistente.Telefono;
            }
            else
            {
                lblTitle.Text = "Nuevo Paciente";
                dtpFechaNac.Value = DateTime.Today.AddYears(-25);
                cboSexo.SelectedIndex = 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string doc = txtDocumento.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string sexo = cboSexo.SelectedItem != null ? cboSexo.SelectedItem.ToString() : "";
            string tel = txtTelefono.Text.Trim();
            DateTime fechaNac = dtpFechaNac.Value;

            if (string.IsNullOrWhiteSpace(doc) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Por favor complete el documento, nombre y apellido.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fechaNac > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser posterior a hoy.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_pacienteExistente == null)
            {
                var nuevo = new Paciente
                {
                    Documento = doc,
                    Nombre = nombre,
                    Apellido = apellido,
                    FechaNacimiento = fechaNac,
                    Sexo = sexo,
                    Telefono = tel
                };

                if (_repository.Insert(nuevo, out string error))
                {
                    MessageBox.Show("Paciente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(error, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _pacienteExistente.Documento = doc;
                _pacienteExistente.Nombre = nombre;
                _pacienteExistente.Apellido = apellido;
                _pacienteExistente.FechaNacimiento = fechaNac;
                _pacienteExistente.Sexo = sexo;
                _pacienteExistente.Telefono = tel;

                if (_repository.Update(_pacienteExistente, out string error))
                {
                    MessageBox.Show("Datos del paciente actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
