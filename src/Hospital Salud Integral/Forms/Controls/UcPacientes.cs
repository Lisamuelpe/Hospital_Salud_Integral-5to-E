using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Modals;
using Forms.Models;
using Forms.Services;

namespace Forms.Controls
{
    public partial class UcPacientes : UserControl
    {
        private readonly PacienteRepository _repository = new PacienteRepository();
        private List<Paciente> _pacientesActuales = new List<Paciente>();

        public UcPacientes()
        {
            InitializeComponent();
        }

        private void UcPacientes_Load(object sender, EventArgs e)
        {
            AplicarPermisos();
            CargarPacientes();
        }

        private void AplicarPermisos()
        {
            // Matriz de permisos:
            // Admin: C, L, E, X
            // Recepcionista: C, L, E
            // Medico: L
            btnNuevo.Enabled = SessionManager.CanPerformAction("pacientes", 'C');
            btnEditar.Enabled = SessionManager.CanPerformAction("pacientes", 'E');
            btnEliminar.Visible = SessionManager.CanPerformAction("pacientes", 'X');
            btnAgendarCita.Enabled = SessionManager.CanPerformAction("citas", 'C');
        }

        public void CargarPacientes(string search = "")
        {
            try
            {
                _pacientesActuales = _repository.GetAll(search);
                dgvPacientes.DataSource = null;
                dgvPacientes.DataSource = _pacientesActuales;

                if (dgvPacientes.Columns.Count > 0)
                {
                    dgvPacientes.Columns["IdPaciente"].Visible = false;
                    dgvPacientes.Columns["Documento"].HeaderText = "Documento";
                    dgvPacientes.Columns["Documento"].Width = 140;
                    dgvPacientes.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
                    dgvPacientes.Columns["FechaNacimiento"].HeaderText = "Fecha Nacimiento";
                    dgvPacientes.Columns["FechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvPacientes.Columns["Edad"].HeaderText = "Edad";
                    dgvPacientes.Columns["Edad"].Width = 60;
                    dgvPacientes.Columns["Sexo"].HeaderText = "Sexo";
                    dgvPacientes.Columns["Sexo"].Width = 60;
                    dgvPacientes.Columns["Telefono"].HeaderText = "Teléfono";
                    dgvPacientes.Columns["Nombre"].Visible = false;
                    dgvPacientes.Columns["Apellido"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista de pacientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Paciente GetSelectedPaciente()
        {
            if (dgvPacientes.CurrentRow != null && dgvPacientes.CurrentRow.DataBoundItem is Paciente p)
            {
                return p;
            }
            return null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPacientes(txtBuscar.Text.Trim());
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
            using (var modal = new FrmPacienteModal())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarPacientes();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var seleccionado = GetSelectedPaciente();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un paciente de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var modal = new FrmPacienteModal(seleccionado))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarPacientes();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccionado = GetSelectedPaciente();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un paciente de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Está completamente seguro de eliminar al paciente '{seleccionado.NombreCompleto}' ({seleccionado.Documento})?\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (_repository.Delete(seleccionado.IdPaciente, out string error))
                {
                    MessageBox.Show("Paciente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPacientes();
                }
                else
                {
                    MessageBox.Show(error, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            var seleccionado = GetSelectedPaciente();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un paciente para ver su historial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var modal = new FrmHistorialPacienteModal(seleccionado))
            {
                modal.ShowDialog();
            }
        }

        private void btnAgendarCita_Click(object sender, EventArgs e)
        {
            var seleccionado = GetSelectedPaciente();
            using (var modal = new FrmCitaModal(seleccionado?.IdPaciente))
            {
                modal.ShowDialog();
            }
        }

        private void dgvPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnVerHistorial.PerformClick();
            }
        }
    }
}
