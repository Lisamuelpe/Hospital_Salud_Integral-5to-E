using System;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Models;

namespace Forms.Modals
{
    public partial class FrmMedicoModal : Form
    {
        private readonly MedicoRepository _medicoRepo = new MedicoRepository();
        private readonly CatalogoRepository _catalogoRepo = new CatalogoRepository();
        private readonly Medico _medicoExistente;

        public FrmMedicoModal(Medico medico = null)
        {
            InitializeComponent();
            _medicoExistente = medico;
            CargarEspecialidades();

            if (_medicoExistente != null)
            {
                lblTitle.Text = "Editar Médico";
                txtLicencia.Text = _medicoExistente.Licencia;
                txtNombre.Text = _medicoExistente.Nombre;
                txtApellido.Text = _medicoExistente.Apellido;
                txtTelefono.Text = _medicoExistente.Telefono;
                cboEspecialidad.SelectedValue = _medicoExistente.IdEspecialidad;
            }
            else
            {
                lblTitle.Text = "Nuevo Médico";
            }
        }

        private void CargarEspecialidades()
        {
            var especialidades = _catalogoRepo.GetEspecialidades();
            cboEspecialidad.DisplayMember = "Nombre";
            cboEspecialidad.ValueMember = "IdEspecialidad";
            cboEspecialidad.DataSource = especialidades;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string lic = txtLicencia.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string tel = txtTelefono.Text.Trim();

            if (string.IsNullOrWhiteSpace(lic) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Por favor complete la licencia, nombre y apellido.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboEspecialidad.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad médica.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEspecialidad = Convert.ToInt32(cboEspecialidad.SelectedValue);

            if (_medicoExistente == null)
            {
                var nuevo = new Medico
                {
                    Licencia = lic,
                    Nombre = nombre,
                    Apellido = apellido,
                    IdEspecialidad = idEspecialidad,
                    Telefono = tel
                };

                if (_medicoRepo.Insert(nuevo, out string error))
                {
                    MessageBox.Show("Médico registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(error, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _medicoExistente.Licencia = lic;
                _medicoExistente.Nombre = nombre;
                _medicoExistente.Apellido = apellido;
                _medicoExistente.IdEspecialidad = idEspecialidad;
                _medicoExistente.Telefono = tel;

                if (_medicoRepo.Update(_medicoExistente, out string error))
                {
                    MessageBox.Show("Médico actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
