using System;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Models;

namespace Forms.Modals
{
    public partial class FrmMedicamentoModal : Form
    {
        private readonly MedicamentoRepository _medicamentoRepo = new MedicamentoRepository();
        private readonly Medicamento _medicamentoExistente;

        public FrmMedicamentoModal(Medicamento medicamento = null)
        {
            InitializeComponent();
            _medicamentoExistente = medicamento;

            if (_medicamentoExistente != null)
            {
                lblTitle.Text = "Editar Medicamento";
                txtNombre.Text = _medicamentoExistente.Nombre;
                txtPresentacion.Text = _medicamentoExistente.Presentacion;
                nudStock.Value = Math.Max(0, _medicamentoExistente.Stock);
            }
            else
            {
                lblTitle.Text = "Nuevo Medicamento";
                nudStock.Value = 10;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string pres = txtPresentacion.Text.Trim();
            int stock = (int)nudStock.Value;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(pres))
            {
                MessageBox.Show("Por favor ingrese el nombre y la presentación del medicamento.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_medicamentoExistente == null)
            {
                var nuevo = new Medicamento
                {
                    Nombre = nombre,
                    Presentacion = pres,
                    Stock = stock
                };

                if (_medicamentoRepo.Insert(nuevo, out string error))
                {
                    MessageBox.Show("Medicamento registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _medicamentoExistente.Nombre = nombre;
                _medicamentoExistente.Presentacion = pres;
                _medicamentoExistente.Stock = stock;

                if (_medicamentoRepo.Update(_medicamentoExistente, out string error))
                {
                    MessageBox.Show("Medicamento actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
