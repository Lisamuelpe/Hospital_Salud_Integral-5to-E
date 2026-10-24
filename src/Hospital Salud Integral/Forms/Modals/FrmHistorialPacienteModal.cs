using System;
using System.Windows.Forms;
using Forms.Data.Repositories;
using Forms.Models;

namespace Forms.Modals
{
    public partial class FrmHistorialPacienteModal : Form
    {
        private readonly int _idPaciente;
        private readonly string _nombreCompleto;
        private readonly string _documento;
        private readonly PacienteRepository _repository = new PacienteRepository();

        public FrmHistorialPacienteModal(Paciente paciente)
        {
            InitializeComponent();
            _idPaciente = paciente.IdPaciente;
            _nombreCompleto = paciente.NombreCompleto;
            _documento = paciente.Documento;
        }

        private void FrmHistorialPacienteModal_Load(object sender, EventArgs e)
        {
            lblPacienteDatos.Text = $"Paciente: {_nombreCompleto}  |  Documento: {_documento}";
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            try
            {
                var dt = _repository.GetHistorialCitasYConsultas(_idPaciente);
                dgvHistorial.DataSource = dt;
                if (dgvHistorial.Columns.Count > 0)
                {
                    dgvHistorial.Columns["id_cita"].HeaderText = "N° Cita";
                    dgvHistorial.Columns["id_cita"].Width = 60;
                    dgvHistorial.Columns["fecha_hora"].HeaderText = "Fecha y Hora";
                    dgvHistorial.Columns["estado"].HeaderText = "Estado";
                    dgvHistorial.Columns["medico"].HeaderText = "Médico Tratante";
                    dgvHistorial.Columns["servicio"].HeaderText = "Servicio";
                    dgvHistorial.Columns["diagnostico"].HeaderText = "Diagnóstico";
                    dgvHistorial.Columns["observaciones"].HeaderText = "Observaciones";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
