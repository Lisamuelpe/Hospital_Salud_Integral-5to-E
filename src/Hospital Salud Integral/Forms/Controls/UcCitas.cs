using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Modals;
using Forms.Models;
using Forms.Services;

namespace Forms.Controls
{
    public partial class UcCitas : UserControl
    {
        private readonly CitaRepository _citaRepo = new CitaRepository();
        private readonly MedicoRepository _medicoRepo = new MedicoRepository();
        private List<Cita> _citasActuales = new List<Cita>();

        public UcCitas()
        {
            InitializeComponent();
        }

        private void UcCitas_Load(object sender, EventArgs e)
        {
            CargarFiltros();
            AplicarPermisos();
            CargarCitas();
        }

        private void CargarFiltros()
        {
            // Médicos en combo de filtro
            var medicos = _medicoRepo.GetAll();
            var listMedicos = new List<dynamic>
            {
                new { Id = (int?)null, Nombre = "-- Todos los Médicos --" }
            };
            foreach (var m in medicos)
            {
                listMedicos.Add(new { Id = (int?)m.IdMedico, Nombre = m.NombreCompleto });
            }

            cboFiltroMedico.DisplayMember = "Nombre";
            cboFiltroMedico.ValueMember = "Id";
            cboFiltroMedico.DataSource = listMedicos;

            // Si es médico, bloquear el filtro a su propio usuario
            if (SessionManager.IsMedico && SessionManager.CurrentUser.IdMedico.HasValue)
            {
                cboFiltroMedico.SelectedValue = SessionManager.CurrentUser.IdMedico.Value;
                cboFiltroMedico.Enabled = false;
            }

            cboFiltroEstado.SelectedIndex = 0; // "Todos"
            dtpFiltroFecha.Value = DateTime.Today;
        }

        private void AplicarPermisos()
        {
            // Matriz:
            // Admin: C, L, E, X
            // Medico: L (las suyas) y actualizar estado
            // Recepcionista: C, L, E, cancelar
            btnNuevaCita.Enabled = SessionManager.CanPerformAction("citas", 'C');
            btnConfirmar.Enabled = SessionManager.CanPerformAction("citas", 'E');
            btnReprogramar.Enabled = SessionManager.CanPerformAction("citas", 'E');
            btnCancelarCita.Enabled = SessionManager.CanPerformAction("citas", 'E') || SessionManager.IsAdmin;
            btnMarcarNoAsistio.Enabled = SessionManager.CanPerformAction("citas", 'E');

            // Abrir consulta
            btnAbrirConsulta.Visible = SessionManager.CanAccessModule("consultas");
        }

        public void CargarCitas()
        {
            try
            {
                DateTime? fecha = chkFiltrarFecha.Checked ? (DateTime?)dtpFiltroFecha.Value.Date : null;
                int? idMedico = (cboFiltroMedico.SelectedValue != null && cboFiltroMedico.SelectedValue is int idVal) ? (int?)idVal : null;
                string estado = cboFiltroEstado.SelectedItem?.ToString();

                // Si es médico, forzar siempre su IdMedico
                if (SessionManager.IsMedico && SessionManager.CurrentUser.IdMedico.HasValue)
                {
                    idMedico = SessionManager.CurrentUser.IdMedico.Value;
                }

                _citasActuales = _citaRepo.GetAll(fecha, idMedico, estado);
                dgvCitas.DataSource = null;
                dgvCitas.DataSource = _citasActuales;

                if (dgvCitas.Columns.Count > 0)
                {
                    dgvCitas.Columns["IdCita"].HeaderText = "N° Cita";
                    dgvCitas.Columns["IdCita"].Width = 60;
                    dgvCitas.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                    dgvCitas.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
                    dgvCitas.Columns["FechaHora"].Width = 145;
                    dgvCitas.Columns["Estado"].HeaderText = "Estado";
                    dgvCitas.Columns["Estado"].Width = 100;
                    dgvCitas.Columns["NombrePaciente"].HeaderText = "Paciente";
                    dgvCitas.Columns["DocumentoPaciente"].HeaderText = "Documento";
                    dgvCitas.Columns["NombreMedico"].HeaderText = "Médico";
                    dgvCitas.Columns["NombreServicio"].HeaderText = "Servicio";
                    dgvCitas.Columns["CostoServicio"].HeaderText = "Costo ($)";
                    dgvCitas.Columns["CostoServicio"].DefaultCellStyle.Format = "N2";
                    dgvCitas.Columns["MotivoCancelacion"].HeaderText = "Motivo Cancelación";

                    dgvCitas.Columns["IdPaciente"].Visible = false;
                    dgvCitas.Columns["IdMedico"].Visible = false;
                    dgvCitas.Columns["IdServicio"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar citas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Cita GetSelectedCita()
        {
            if (dgvCitas.CurrentRow != null && dgvCitas.CurrentRow.DataBoundItem is Cita c)
            {
                return c;
            }
            return null;
        }

        private void chkFiltrarFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFiltroFecha.Enabled = chkFiltrarFecha.Checked;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarCitas();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            chkFiltrarFecha.Checked = false;
            cboFiltroEstado.SelectedIndex = 0;
            if (!SessionManager.IsMedico)
            {
                cboFiltroMedico.SelectedIndex = 0;
            }
            CargarCitas();
        }

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            using (var modal = new FrmCitaModal())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarCitas();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var cita = GetSelectedCita();
            if (cita == null)
            {
                MessageBox.Show("Seleccione una cita.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cita.Estado == "Atendida" || cita.Estado == "Cancelada")
            {
                MessageBox.Show($"No se puede confirmar una cita con estado '{cita.Estado}'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_citaRepo.ActualizarEstado(cita.IdCita, "Confirmada", out string error))
            {
                MessageBox.Show("Cita confirmada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCitas();
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReprogramar_Click(object sender, EventArgs e)
        {
            var cita = GetSelectedCita();
            if (cita == null)
            {
                MessageBox.Show("Seleccione una cita.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cita.Estado == "Atendida" || cita.Estado == "Cancelada")
            {
                MessageBox.Show($"No se puede reprogramar una cita con estado '{cita.Estado}'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (FrmPromptModal.ShowPrompt("Reprogramar Cita", "Nueva Fecha y Hora (Formato: DD/MM/AAAA HH:MM ej: 25/10/2026 10:30):", out string fechaHoraStr, cita.FechaHora.ToString("dd/MM/yyyy HH:mm")))
            {
                if (DateTime.TryParse(fechaHoraStr, out DateTime nuevaFecha))
                {
                    if (_citaRepo.Reprogramar(cita.IdCita, nuevaFecha, out string error))
                    {
                        MessageBox.Show("Cita reprogramada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                    }
                    else
                    {
                        MessageBox.Show(error, "Error al reprogramar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Formato de fecha u hora no válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            var cita = GetSelectedCita();
            if (cita == null)
            {
                MessageBox.Show("Seleccione una cita para cancelar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cita.Estado == "Atendida")
            {
                MessageBox.Show("No se puede cancelar una cita médica ya atendida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de cancelar la cita #{cita.IdCita} del paciente {cita.NombrePaciente}?",
                "Confirmar Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            if (FrmPromptModal.ShowPrompt("Motivo de Cancelación", "Ingrese el motivo de la cancelación de la cita:", out string motivo))
            {
                if (_citaRepo.Cancelar(cita.IdCita, motivo, out string error))
                {
                    MessageBox.Show("Cita cancelada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCitas();
                }
                else
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMarcarNoAsistio_Click(object sender, EventArgs e)
        {
            var cita = GetSelectedCita();
            if (cita == null) return;

            if (cita.Estado == "Atendida")
            {
                MessageBox.Show("La cita ya fue atendida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Marcar la cita #{cita.IdCita} como 'No asistió'?",
                "Confirmar Inasistencia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_citaRepo.ActualizarEstado(cita.IdCita, "No asistió", out string error))
                {
                    MessageBox.Show("Estado actualizado a 'No asistió'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCitas();
                }
                else
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAbrirConsulta_Click(object sender, EventArgs e)
        {
            var cita = GetSelectedCita();
            if (cita == null)
            {
                MessageBox.Show("Seleccione una cita de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cita.Estado == "Cancelada" || cita.Estado == "No asistió")
            {
                MessageBox.Show($"No se puede abrir consulta para una cita '{cita.Estado}'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var modal = new FrmConsultaModal(cita.IdCita))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarCitas();
                }
            }
        }

        private void dgvCitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnAbrirConsulta.PerformClick();
            }
        }
    }
}
