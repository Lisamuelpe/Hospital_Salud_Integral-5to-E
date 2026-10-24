using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Models;
using Forms.Services;

namespace Forms.Modals
{
    public partial class FrmCitaModal : Form
    {
        private readonly CitaRepository _citaRepo = new CitaRepository();
        private readonly PacienteRepository _pacienteRepo = new PacienteRepository();
        private readonly MedicoRepository _medicoRepo = new MedicoRepository();
        private readonly CatalogoRepository _catalogoRepo = new CatalogoRepository();

        private List<Servicio> _servicios;

        public FrmCitaModal(int? preselectedPacienteId = null)
        {
            InitializeComponent();
            CargarCombos(preselectedPacienteId);
        }

        private void CargarCombos(int? preselectedPacienteId)
        {
            // Pacientes
            var pacientes = _pacienteRepo.GetAll();
            cboPaciente.DisplayMember = "NombreCompleto";
            cboPaciente.ValueMember = "IdPaciente";
            cboPaciente.DataSource = pacientes;
            if (preselectedPacienteId.HasValue)
            {
                cboPaciente.SelectedValue = preselectedPacienteId.Value;
            }

            // Servicios
            _servicios = _catalogoRepo.GetServicios();
            cboServicio.DisplayMember = "Nombre";
            cboServicio.ValueMember = "IdServicio";
            cboServicio.DataSource = _servicios;

            // Médicos
            var medicos = _medicoRepo.GetAll();
            cboMedico.DisplayMember = "NombreCompleto";
            cboMedico.ValueMember = "IdMedico";
            cboMedico.DataSource = medicos;

            // Si el usuario logueado es médico, fijarlo
            if (SessionManager.IsMedico && SessionManager.CurrentUser.IdMedico.HasValue)
            {
                cboMedico.SelectedValue = SessionManager.CurrentUser.IdMedico.Value;
                cboMedico.Enabled = false;
            }

            // Fecha y hora mínimas
            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today.AddDays(1);
            dtpHora.Value = DateTime.Today.AddHours(9); // 9:00 AM
        }

        private void cboServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServicio.SelectedItem is Servicio servicio)
            {
                lblCosto.Text = $"Costo: ${servicio.Costo:N2}";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboPaciente.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un paciente.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboServicio.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un servicio.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMedico.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un médico.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;
            DateTime fechaHoraCompleta = fecha.Add(hora);

            if (fechaHoraCompleta < DateTime.Now)
            {
                MessageBox.Show("No se puede agendar una cita en una hora pasada.", "Horario inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevaCita = new Cita
            {
                IdPaciente = Convert.ToInt32(cboPaciente.SelectedValue),
                IdServicio = Convert.ToInt32(cboServicio.SelectedValue),
                IdMedico = Convert.ToInt32(cboMedico.SelectedValue),
                FechaHora = fechaHoraCompleta,
                Estado = "Programada"
            };

            if (_citaRepo.Insert(nuevaCita, out string error))
            {
                MessageBox.Show("Cita agendada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(error, "Error al agendar cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
