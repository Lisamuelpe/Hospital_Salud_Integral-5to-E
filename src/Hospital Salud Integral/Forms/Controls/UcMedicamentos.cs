using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Modals;
using Forms.Models;
using Forms.Services;

namespace Forms.Controls
{
    public partial class UcMedicamentos : UserControl
    {
        private readonly MedicamentoRepository _repository = new MedicamentoRepository();
        private List<Medicamento> _medicamentosActuales = new List<Medicamento>();

        public UcMedicamentos()
        {
            InitializeComponent();
        }

        private void UcMedicamentos_Load(object sender, EventArgs e)
        {
            AplicarPermisos();
            CargarMedicamentos();
        }

        private void AplicarPermisos()
        {
            bool canManage = SessionManager.IsAdmin;
            btnNuevo.Visible = canManage;
            btnEditar.Visible = canManage;
            btnEliminar.Visible = canManage;
        }

        public void CargarMedicamentos(string search = "")
        {
            try
            {
                bool soloStockBajo = chkSoloStockBajo.Checked;
                _medicamentosActuales = _repository.GetAll(search, soloStockBajo);
                dgvMedicamentos.DataSource = null;
                dgvMedicamentos.DataSource = _medicamentosActuales;

                if (dgvMedicamentos.Columns.Count > 0)
                {
                    dgvMedicamentos.Columns["IdMedicamento"].HeaderText = "Código";
                    dgvMedicamentos.Columns["IdMedicamento"].Width = 80;
                    dgvMedicamentos.Columns["Nombre"].HeaderText = "Nombre del Medicamento";
                    dgvMedicamentos.Columns["Presentacion"].HeaderText = "Presentación";
                    dgvMedicamentos.Columns["Stock"].HeaderText = "Existencias (Unid.)";
                    dgvMedicamentos.Columns["Stock"].Width = 140;
                    dgvMedicamentos.Columns["EstadoStock"].HeaderText = "Estado del Stock";
                    dgvMedicamentos.Columns["EstadoStock"].Width = 150;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar medicamentos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Medicamento GetSelectedMedicamento()
        {
            if (dgvMedicamentos.CurrentRow != null && dgvMedicamentos.CurrentRow.DataBoundItem is Medicamento m)
            {
                return m;
            }
            return null;
        }

        private void dgvMedicamentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMedicamentos.Columns[e.ColumnIndex].Name == "EstadoStock" && e.Value != null)
            {
                string estado = e.Value.ToString();
                if (estado == "Agotado")
                {
                    e.CellStyle.BackColor = Color.FromArgb(248, 215, 218);
                    e.CellStyle.ForeColor = Color.FromArgb(114, 28, 36);
                    e.CellStyle.Font = new Font(dgvMedicamentos.Font, FontStyle.Bold);
                }
                else if (estado == "Stock Bajo")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 243, 205);
                    e.CellStyle.ForeColor = Color.FromArgb(133, 100, 4);
                    e.CellStyle.Font = new Font(dgvMedicamentos.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(212, 237, 218);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 87, 36);
                }
            }
        }

        private void chkSoloStockBajo_CheckedChanged(object sender, EventArgs e)
        {
            CargarMedicamentos(txtBuscar.Text.Trim());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarMedicamentos(txtBuscar.Text.Trim());
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
            using (var modal = new FrmMedicamentoModal())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarMedicamentos();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedMedicamento();
            if (sel == null)
            {
                MessageBox.Show("Seleccione un medicamento de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var modal = new FrmMedicamentoModal(sel))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarMedicamentos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedMedicamento();
            if (sel == null)
            {
                MessageBox.Show("Seleccione un medicamento de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de eliminar el medicamento '{sel.Nombre}'?\nNo se puede eliminar si figura en recetas clínicas emitidas.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (_repository.Delete(sel.IdMedicamento, out string error))
                {
                    MessageBox.Show("Medicamento eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMedicamentos();
                }
                else
                {
                    MessageBox.Show(error, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
