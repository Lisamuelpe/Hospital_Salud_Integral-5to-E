using System;
using System.Drawing;
using System.Windows.Forms;
using Forms.Controls;
using Forms.Services;

namespace Forms
{
    public partial class Main : Form
    {
        private Button _currentNavButton;
        private UserControl _currentControl;

        // Caché de controles
        private UcDashboard _ucDashboard;
        private UcPacientes _ucPacientes;
        private UcMedicos _ucMedicos;
        private UcCatalogos _ucCatalogos;
        private UcCitas _ucCitas;
        private UcMedicamentos _ucMedicamentos;
        private UcUsuarios _ucUsuarios;
        private UcPerfil _ucPerfil;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                this.Close();
                return;
            }

            // Mostrar usuario y rol
            var user = SessionManager.CurrentUser;
            lblSessionUser.Text = $"👤 {user.Username} ({user.Roles})";

            // Aplicar visibilidad de navegación según la matriz de permisos
            ConfigurarNavegacionPorRol();

            // Iniciar temporizador de inactividad (aviso a los 15 minutos de inactividad)
            timerInactividad.Start();

            // Cargar panel principal por defecto
            btnNavDashboard.PerformClick();
        }

        private void ConfigurarNavegacionPorRol()
        {
            btnNavDashboard.Visible = SessionManager.CanAccessModule("dashboard");
            btnNavPacientes.Visible = SessionManager.CanAccessModule("pacientes");
            btnNavMedicos.Visible = SessionManager.CanAccessModule("medicos");
            btnNavCatalogos.Visible = SessionManager.CanAccessModule("departamentos");
            btnNavCitas.Visible = SessionManager.CanAccessModule("citas");
            btnNavMedicamentos.Visible = SessionManager.CanAccessModule("medicamentos");
            btnNavUsuarios.Visible = SessionManager.CanAccessModule("usuarios");
            btnNavPerfil.Visible = SessionManager.CanAccessModule("perfil");
        }

        private void SetActiveView(UserControl control, Button navButton)
        {
            SessionManager.RegisterActivity();

            if (_currentNavButton != null)
            {
                _currentNavButton.BackColor = Color.Transparent;
                _currentNavButton.ForeColor = Color.FromArgb(203, 213, 225);
            }

            _currentNavButton = navButton;
            if (_currentNavButton != null)
            {
                _currentNavButton.BackColor = Color.FromArgb(44, 127, 130);
                _currentNavButton.ForeColor = Color.White;
            }

            if (_currentControl != control)
            {
                pnlContentHost.SuspendLayout();
                pnlContentHost.Controls.Clear();
                control.Dock = DockStyle.Fill;
                pnlContentHost.Controls.Add(control);
                pnlContentHost.ResumeLayout(true);
                _currentControl = control;
            }
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            if (_ucDashboard == null)
            {
                _ucDashboard = new UcDashboard();
            }
            else
            {
                _ucDashboard.CargarDatos();
            }
            SetActiveView(_ucDashboard, btnNavDashboard);
        }

        private void btnNavPacientes_Click(object sender, EventArgs e)
        {
            if (_ucPacientes == null)
            {
                _ucPacientes = new UcPacientes();
            }
            else
            {
                _ucPacientes.CargarPacientes();
            }
            SetActiveView(_ucPacientes, btnNavPacientes);
        }

        private void btnNavMedicos_Click(object sender, EventArgs e)
        {
            if (_ucMedicos == null)
            {
                _ucMedicos = new UcMedicos();
            }
            else
            {
                _ucMedicos.CargarMedicos();
            }
            SetActiveView(_ucMedicos, btnNavMedicos);
        }

        private void btnNavCatalogos_Click(object sender, EventArgs e)
        {
            if (_ucCatalogos == null)
            {
                _ucCatalogos = new UcCatalogos();
            }
            else
            {
                _ucCatalogos.CargarDepartamentos();
            }
            SetActiveView(_ucCatalogos, btnNavCatalogos);
        }

        private void btnNavCitas_Click(object sender, EventArgs e)
        {
            if (_ucCitas == null)
            {
                _ucCitas = new UcCitas();
            }
            else
            {
                _ucCitas.CargarCitas();
            }
            SetActiveView(_ucCitas, btnNavCitas);
        }

        private void btnNavMedicamentos_Click(object sender, EventArgs e)
        {
            if (!SessionManager.CanAccessModule("medicamentos"))
            {
                MessageBox.Show("Acceso denegado a este módulo.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_ucMedicamentos == null)
            {
                _ucMedicamentos = new UcMedicamentos();
            }
            else
            {
                _ucMedicamentos.CargarMedicamentos();
            }
            SetActiveView(_ucMedicamentos, btnNavMedicamentos);
        }

        private void btnNavUsuarios_Click(object sender, EventArgs e)
        {
            if (!SessionManager.CanAccessModule("usuarios"))
            {
                MessageBox.Show("Acceso denegado: este módulo es exclusivo del rol Administración.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_ucUsuarios == null)
            {
                _ucUsuarios = new UcUsuarios();
            }
            else
            {
                _ucUsuarios.CargarUsuarios();
            }
            SetActiveView(_ucUsuarios, btnNavUsuarios);
        }

        private void btnNavPerfil_Click(object sender, EventArgs e)
        {
            if (_ucPerfil == null)
            {
                _ucPerfil = new UcPerfil();
            }
            else
            {
                _ucPerfil.CargarDatosPerfil();
            }
            SetActiveView(_ucPerfil, btnNavPerfil);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Está seguro de cerrar la sesión de su cuenta institucional?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                timerInactividad.Stop();
                SessionManager.ClearSession();
                this.Close();
            }
        }

        private void timerInactividad_Tick(object sender, EventArgs e)
        {
            // Tiempo límite de inactividad: 15 minutos (Sección 4.1 del documento técnico)
            var tiempoInactivo = DateTime.Now - SessionManager.LastActivityTime;
            if (tiempoInactivo.TotalMinutes >= 15)
            {
                timerInactividad.Stop();
                MessageBox.Show(
                    "Su sesión ha expirado por inactividad prolongada por motivos de seguridad institucional.\nSerá redirigido al inicio de sesión.",
                    "Sesión Expirada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                SessionManager.ClearSession();
                this.Close();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerInactividad.Stop();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
