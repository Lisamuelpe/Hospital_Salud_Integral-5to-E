using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Models;
using Forms.Services;

namespace Forms.Modals
{
    public partial class FrmConsultaModal : Form
    {
        private readonly int _idCita;
        private readonly ConsultaRepository _consultaRepo = new ConsultaRepository();
        private readonly MedicamentoRepository _medicamentoRepo = new MedicamentoRepository();
        private readonly CitaRepository _citaRepo = new CitaRepository();

        private Cita _cita;
        private Consulta _consultaExistente;
        private readonly BindingList<DetalleReceta> _recetaItems = new BindingList<DetalleReceta>();
        private List<Medicamento> _medicamentosList;

        public FrmConsultaModal(int idCita)
        {
            InitializeComponent();
            _idCita = idCita;
        }

        private void FrmConsultaModal_Load(object sender, EventArgs e)
        {
            _cita = _citaRepo.GetById(_idCita);
            if (_cita == null)
            {
                MessageBox.Show("Cita médica no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblCitaInfo.Text = $"Cita #{_cita.IdCita} | Paciente: {_cita.NombrePaciente} ({_cita.DocumentoPaciente}) | Servicio: {_cita.NombreServicio} | Médico: {_cita.NombreMedico} | Fecha: {_cita.FechaHora:dd/MM/yyyy hh:mm tt}";

            // Configurar DataGridView de recetas
            dgvReceta.AutoGenerateColumns = false;
            dgvReceta.Columns.Clear();

            dgvReceta.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreMedicamento", HeaderText = "Medicamento", Width = 220 });
            dgvReceta.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PresentacionMedicamento", HeaderText = "Presentación", Width = 150 });
            dgvReceta.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Dosis", HeaderText = "Dosis", Width = 140 });
            dgvReceta.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DuracionDias", HeaderText = "Duración (días)", Width = 110 });
            dgvReceta.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Detalles", HeaderText = "Indicaciones", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            dgvReceta.DataSource = _recetaItems;

            // Cargar medicamentos en combo
            CargarMedicamentos();

            // Verificar si ya existe consulta
            _consultaExistente = _consultaRepo.GetByCitaId(_idCita);
            if (_consultaExistente != null)
            {
                // Modo solo lectura
                lblTitle.Text = "Consulta Médica (Atendida - Solo Lectura)";
                txtDiagnostico.Text = _consultaExistente.Diagnostico;
                txtObservaciones.Text = _consultaExistente.Observaciones;

                txtDiagnostico.ReadOnly = true;
                txtObservaciones.ReadOnly = true;

                btnGuardar.Visible = false;
                btnAgregarMedicamento.Enabled = false;
                btnEliminarMedicamento.Enabled = false;
                cboMedicamento.Enabled = false;
                txtDosis.Enabled = false;
                nudDuracion.Enabled = false;
                txtDetalles.Enabled = false;

                // Cargar recetas emitidas
                var recetas = _consultaRepo.GetRecetasByConsulta(_consultaExistente.IdConsulta);
                foreach (var r in recetas)
                {
                    _recetaItems.Add(r);
                }
            }
            else
            {
                // Solo un médico puede registrar la consulta
                if (!SessionManager.IsMedico && !SessionManager.IsAdmin)
                {
                    lblTitle.Text = "Consulta Médica (Acceso de solo lectura)";
                    btnGuardar.Visible = false;
                    btnAgregarMedicamento.Enabled = false;
                    btnEliminarMedicamento.Enabled = false;
                }
            }
        }

        private void CargarMedicamentos()
        {
            _medicamentosList = _medicamentoRepo.GetAll();
            cboMedicamento.DataSource = _medicamentosList.Select(m => new
            {
                m.IdMedicamento,
                DisplayText = $"{m.Nombre} ({m.Presentacion}) - Stock: {m.Stock} [{m.EstadoStock}]",
                m.Nombre,
                m.Presentacion,
                m.Stock
            }).ToList();

            cboMedicamento.DisplayMember = "DisplayText";
            cboMedicamento.ValueMember = "IdMedicamento";
        }

        private void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {
            if (cboMedicamento.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un medicamento del inventario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idMed = Convert.ToInt32(cboMedicamento.SelectedValue);
            var med = _medicamentosList.FirstOrDefault(m => m.IdMedicamento == idMed);
            if (med == null) return;

            string dosis = txtDosis.Text.Trim();
            if (string.IsNullOrWhiteSpace(dosis))
            {
                MessageBox.Show("Por favor indique la dosis del medicamento (ej: 1 comprimido cada 8 horas).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDosis.Focus();
                return;
            }

            // Validar si ya está en la receta
            if (_recetaItems.Any(r => r.IdMedicamento == idMed))
            {
                MessageBox.Show("El medicamento ya se encuentra agregado en la receta actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (med.Stock <= 0)
            {
                var r = MessageBox.Show($"El medicamento '{med.Nombre}' está AGOTADO en inventario.\n¿Desea agregarlo a la receta de todas formas?", "Medicamento Agotado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r != DialogResult.Yes) return;
            }
            else if (med.Stock <= 15)
            {
                MessageBox.Show($"Aviso: El medicamento '{med.Nombre}' tiene existencias bajas ({med.Stock} disponibles).", "Stock Bajo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _recetaItems.Add(new DetalleReceta
            {
                IdMedicamento = med.IdMedicamento,
                NombreMedicamento = med.Nombre,
                PresentacionMedicamento = med.Presentacion,
                Dosis = dosis,
                DuracionDias = (int)nudDuracion.Value,
                Detalles = txtDetalles.Text.Trim()
            });

            // Limpiar inputs
            txtDosis.Clear();
            txtDetalles.Clear();
            nudDuracion.Value = 7;
        }

        private void btnEliminarMedicamento_Click(object sender, EventArgs e)
        {
            if (dgvReceta.CurrentRow != null && dgvReceta.CurrentRow.DataBoundItem is DetalleReceta item)
            {
                _recetaItems.Remove(item);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string diagnostico = txtDiagnostico.Text.Trim();
            string observaciones = txtObservaciones.Text.Trim();

            if (string.IsNullOrWhiteSpace(diagnostico))
            {
                MessageBox.Show("El diagnóstico médico es obligatorio para registrar la atención de la consulta.", "Diagnóstico Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnostico.Focus();
                return;
            }

            var confirm = MessageBox.Show(
                "¿Está seguro de guardar la consulta clínica y marcar la cita como 'Atendida'?",
                "Confirmar Registro Clínico",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            var nuevaConsulta = new Consulta
            {
                IdCita = _idCita,
                Diagnostico = diagnostico,
                Observaciones = observaciones
            };

            var recetasList = _recetaItems.ToList();

            if (_consultaRepo.RegistrarConsultaConReceta(nuevaConsulta, recetasList, out string warnings, out string error))
            {
                string mensajeExito = "Consulta y atención médica registradas con éxito.\nLa cita ahora está en estado 'Atendida'.";
                if (!string.IsNullOrWhiteSpace(warnings))
                {
                    mensajeExito += "\n\nAlertas de inventario:\n" + warnings;
                }

                MessageBox.Show(mensajeExito, "Atención Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(error, "Error al guardar consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
