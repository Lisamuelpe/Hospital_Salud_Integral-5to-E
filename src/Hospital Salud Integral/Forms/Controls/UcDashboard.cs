using System;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Modals;
using Forms.Services;

namespace Forms.Controls
{
    public partial class UcDashboard : UserControl
    {
        private readonly DashboardRepository _dashboardRepo = new DashboardRepository();

        public UcDashboard()
        {
            InitializeComponent();
        }

        private void UcDashboard_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos()
        {
            try
            {
                int? idMedicoFiltro = (SessionManager.IsMedico && SessionManager.CurrentUser.IdMedico.HasValue) 
                    ? SessionManager.CurrentUser.IdMedico.Value 
                    : (int?)null;

                // Subtítulo según rol
                if (SessionManager.IsAdmin)
                {
                    lblRoleSubtitle.Text = "Indicadores globales de la clínica y resumen operativo general.";
                    cardPacientes.Visible = true;
                    cardStock.Visible = true;
                }
                else if (SessionManager.IsMedico)
                {
                    lblRoleSubtitle.Text = $"Agenda personal del Dr(a). {SessionManager.CurrentUser.Username} para el día de hoy.";
                    cardPacientes.Visible = false;
                    cardStock.Visible = false;
                    lblCitasTitle.Text = "MIS CITAS HOY";
                    lblPendientesTitle.Text = "MIS PENDIENTES";
                    btnNuevoPaciente.Visible = false;
                    btnNuevaCita.Visible = false;
                }
                else if (SessionManager.IsRecepcionista)
                {
                    lblRoleSubtitle.Text = "Atención al paciente y recepción de citas del día.";
                    cardStock.Visible = false;
                    cardPacientes.Visible = true;
                }

                // Cargar métricas
                lblCitasCount.Text = _dashboardRepo.GetCitasHoyCount(idMedicoFiltro).ToString();
                lblPendientesCount.Text = _dashboardRepo.GetCitasPendientesHoyCount(idMedicoFiltro).ToString();
                lblPacientesCount.Text = _dashboardRepo.GetTotalPacientesCount().ToString();
                lblStockCount.Text = _dashboardRepo.GetMedicamentosStockBajoCount().ToString();

                // Cargar agenda
                var dt = _dashboardRepo.GetAgendaHoy(idMedicoFiltro);
                dgvAgenda.DataSource = dt;

                if (dgvAgenda.Columns.Count > 0)
                {
                    dgvAgenda.Columns["id_cita"].HeaderText = "N° Cita";
                    dgvAgenda.Columns["id_cita"].Width = 60;
                    dgvAgenda.Columns["hora"].HeaderText = "Hora";
                    dgvAgenda.Columns["hora"].Width = 80;
                    dgvAgenda.Columns["paciente"].HeaderText = "Paciente";
                    dgvAgenda.Columns["telefono"].HeaderText = "Teléfono";
                    dgvAgenda.Columns["medico"].HeaderText = "Médico Tratante";
                    dgvAgenda.Columns["servicio"].HeaderText = "Servicio";
                    dgvAgenda.Columns["estado"].HeaderText = "Estado";
                }
            }
            catch (Exception ex)
            {
                // Manejo silencioso o aviso amigable
                lblRoleSubtitle.Text = "No se pudo conectar a la base de datos (" + ex.Message + ")";
            }
        }

        private void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
            using (var modal = new FrmPacienteModal())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            using (var modal = new FrmCitaModal())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }
    }
}
