using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Modals;
using Forms.Models;
using Forms.Services;

namespace Forms.Controls
{
    public partial class UcMedicos : UserControl
    {
        private readonly MedicoRepository _repository = new MedicoRepository();
        private List<Medico> _medicosActuales = new List<Medico>();

        public UcMedicos()
        {
            InitializeComponent();
        }

        private void UcMedicos_Load(object sender, EventArgs e)
        {
            AplicarPermisos();
            CargarMedicos();
        }

        private void AplicarPermisos()
        {
            // Solo Administrador puede C, E, X
            btnNuevo.Visible = SessionManager.CanPerformAction("medicos", 'C');
            btnEditar.Visible = SessionManager.CanPerformAction("medicos", 'E');
            btnEliminar.Visible = SessionManager.CanPerformAction("medicos", 'X');
        }

        public void CargarMedicos(string search = "")
        {
            try
            {
                _medicosActuales = _repository.GetAll(search);
                dgvMedicos.DataSource = null;
                dgvMedicos.DataSource = _medicosActuales;

                if (dgvMedicos.Columns.Count > 0)
                {
                    dgvMedicos.Columns["IdMedico"].Visible = false;
                    dgvMedicos.Columns["IdEspecialidad"].Visible = false;
                    dgvMedicos.Columns["Licencia"].HeaderText = "Licencia Médica";
                    dgvMedicos.Columns["Licencia"].Width = 140;
                    dgvMedicos.Columns["NombreCompleto"].HeaderText = "Nombre del Profesional";
                    dgvMedicos.Columns["NombreEspecialidad"].HeaderText = "Especialidad Asignada";
                    dgvMedicos.Columns["Telefono"].HeaderText = "Teléfono de Contacto";
                    dgvMedicos.Columns["Nombre"].Visible = false;
                    dgvMedicos.Columns["Apellido"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar médicos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Medico GetSelectedMedico()
        {
            if (dgvMedicos.CurrentRow != null && dgvMedicos.CurrentRow.DataBoundItem is Medico m)
            {
                return m;
            }
            return null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarMedicos(txtBuscar.Text.Trim());
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
            using (var modal = new FrmMedicoModal())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarMedicos();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var seleccionado = GetSelectedMedico();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un médico de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var modal = new FrmMedicoModal(seleccionado))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarMedicos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccionado = GetSelectedMedico();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un médico de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de eliminar al médico '{seleccionado.NombreCompleto}' ({seleccionado.Licencia})?\nNo se podrá eliminar si tiene citas asociadas.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (_repository.Delete(seleccionado.IdMedico, out string error))
                {
                    MessageBox.Show("Médico eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMedicos();
                }
                else
                {
                    MessageBox.Show(error, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
