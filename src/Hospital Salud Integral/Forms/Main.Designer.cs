namespace Forms
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblSessionUser = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblTestEnvironment = new System.Windows.Forms.Label();
            this.lblHospitalBrand = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnNavPerfil = new System.Windows.Forms.Button();
            this.btnNavUsuarios = new System.Windows.Forms.Button();
            this.btnNavMedicamentos = new System.Windows.Forms.Button();
            this.btnNavCitas = new System.Windows.Forms.Button();
            this.btnNavCatalogos = new System.Windows.Forms.Button();
            this.btnNavMedicos = new System.Windows.Forms.Button();
            this.btnNavPacientes = new System.Windows.Forms.Button();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.lblSidebarBrand = new System.Windows.Forms.Label();
            this.pnlContentHost = new System.Windows.Forms.Panel();
            this.timerInactividad = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTopHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.BackColor = System.Drawing.Color.White;
            this.pnlTopHeader.Controls.Add(this.btnClose);
            this.pnlTopHeader.Controls.Add(this.lblSessionUser);
            this.pnlTopHeader.Controls.Add(this.btnLogout);
            this.pnlTopHeader.Controls.Add(this.lblTestEnvironment);
            this.pnlTopHeader.Controls.Add(this.lblHospitalBrand);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(440, 0);
            this.pnlTopHeader.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(1928, 106);
            this.pnlTopHeader.TabIndex = 0;
            // 
            // lblSessionUser
            // 
            this.lblSessionUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSessionUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSessionUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.lblSessionUser.Location = new System.Drawing.Point(921, 38);
            this.lblSessionUser.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSessionUser.Name = "lblSessionUser";
            this.lblSessionUser.Size = new System.Drawing.Size(596, 38);
            this.lblSessionUser.TabIndex = 2;
            this.lblSessionUser.Text = "👤 Usuario: admin (Administración)";
            this.lblSessionUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.Location = new System.Drawing.Point(1553, 20);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 62);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Cerrar Sesión";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblTestEnvironment
            // 
            this.lblTestEnvironment.AutoSize = true;
            this.lblTestEnvironment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.lblTestEnvironment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTestEnvironment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(100)))), ((int)(((byte)(4)))));
            this.lblTestEnvironment.Location = new System.Drawing.Point(430, 35);
            this.lblTestEnvironment.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTestEnvironment.Name = "lblTestEnvironment";
            this.lblTestEnvironment.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.lblTestEnvironment.Size = new System.Drawing.Size(444, 40);
            this.lblTestEnvironment.TabIndex = 1;
            this.lblTestEnvironment.Text = "Entorno de pruebas · datos ficticios";
            // 
            // lblHospitalBrand
            // 
            this.lblHospitalBrand.AutoSize = true;
            this.lblHospitalBrand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHospitalBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblHospitalBrand.Location = new System.Drawing.Point(30, 31);
            this.lblHospitalBrand.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHospitalBrand.Name = "lblHospitalBrand";
            this.lblHospitalBrand.Size = new System.Drawing.Size(364, 45);
            this.lblHospitalBrand.TabIndex = 0;
            this.lblHospitalBrand.Text = "Hospital Salud Integral";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlSidebar.Controls.Add(this.btnNavPerfil);
            this.pnlSidebar.Controls.Add(this.btnNavUsuarios);
            this.pnlSidebar.Controls.Add(this.btnNavMedicamentos);
            this.pnlSidebar.Controls.Add(this.btnNavCitas);
            this.pnlSidebar.Controls.Add(this.btnNavCatalogos);
            this.pnlSidebar.Controls.Add(this.btnNavMedicos);
            this.pnlSidebar.Controls.Add(this.btnNavPacientes);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.pnlBrand);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(440, 1310);
            this.pnlSidebar.TabIndex = 1;
            // 
            // btnNavPerfil
            // 
            this.btnNavPerfil.BackColor = System.Drawing.Color.Transparent;
            this.btnNavPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavPerfil.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavPerfil.FlatAppearance.BorderSize = 0;
            this.btnNavPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPerfil.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavPerfil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavPerfil.Location = new System.Drawing.Point(0, 715);
            this.btnNavPerfil.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNavPerfil.Name = "btnNavPerfil";
            this.btnNavPerfil.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnNavPerfil.Size = new System.Drawing.Size(440, 87);
            this.btnNavPerfil.TabIndex = 7;
            this.btnNavPerfil.Text = "👤 Mi Perfil";
            this.btnNavPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavPerfil.UseVisualStyleBackColor = false;
            this.btnNavPerfil.Click += new System.EventHandler(this.btnNavPerfil_Click);
            // 
            // btnNavUsuarios
            // 
            this.btnNavUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.btnNavUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavUsuarios.FlatAppearance.BorderSize = 0;
            this.btnNavUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavUsuarios.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavUsuarios.Location = new System.Drawing.Point(0, 628);
            this.btnNavUsuarios.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNavUsuarios.Name = "btnNavUsuarios";
            this.btnNavUsuarios.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnNavUsuarios.Size = new System.Drawing.Size(440, 87);
            this.btnNavUsuarios.TabIndex = 6;
            this.btnNavUsuarios.Text = "👥 Usuarios y Roles";
            this.btnNavUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavUsuarios.UseVisualStyleBackColor = false;
            this.btnNavUsuarios.Click += new System.EventHandler(this.btnNavUsuarios_Click);
            // 
            // btnNavMedicamentos
            // 
            this.btnNavMedicamentos.BackColor = System.Drawing.Color.Transparent;
            this.btnNavMedicamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavMedicamentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavMedicamentos.FlatAppearance.BorderSize = 0;
            this.btnNavMedicamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMedicamentos.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavMedicamentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavMedicamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavMedicamentos.Location = new System.Drawing.Point(0, 541);
            this.btnNavMedicamentos.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNavMedicamentos.Name = "btnNavMedicamentos";
            this.btnNavMedicamentos.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnNavMedicamentos.Size = new System.Drawing.Size(440, 87);
            this.btnNavMedicamentos.TabIndex = 5;
            this.btnNavMedicamentos.Text = "💊 Medicamentos";
            this.btnNavMedicamentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavMedicamentos.UseVisualStyleBackColor = false;
            this.btnNavMedicamentos.Click += new System.EventHandler(this.btnNavMedicamentos_Click);
            // 
            // btnNavCitas
            // 
            this.btnNavCitas.BackColor = System.Drawing.Color.Transparent;
            this.btnNavCitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCitas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCitas.FlatAppearance.BorderSize = 0;
            this.btnNavCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCitas.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavCitas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavCitas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCitas.Location = new System.Drawing.Point(0, 454);
            this.btnNavCitas.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNavCitas.Name = "btnNavCitas";
            this.btnNavCitas.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnNavCitas.Size = new System.Drawing.Size(440, 87);
            this.btnNavCitas.TabIndex = 4;
            this.btnNavCitas.Text = "📅 Agenda y Citas";
            this.btnNavCitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCitas.UseVisualStyleBackColor = false;
            this.btnNavCitas.Click += new System.EventHandler(this.btnNavCitas_Click);
            // 
            // btnNavCatalogos
            // 
            this.btnNavCatalogos.BackColor = System.Drawing.Color.Transparent;
            this.btnNavCatalogos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCatalogos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCatalogos.FlatAppearance.BorderSize = 0;
            this.btnNavCatalogos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCatalogos.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavCatalogos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavCatalogos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCatalogos.Location = new System.Drawing.Point(0, 367);
            this.btnNavCatalogos.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNavCatalogos.Name = "btnNavCatalogos";
            this.btnNavCatalogos.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnNavCatalogos.Size = new System.Drawing.Size(440, 87);
            this.btnNavCatalogos.TabIndex = 3;
            this.btnNavCatalogos.Text = "🏥 Departamentos y Serv.";
            this.btnNavCatalogos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCatalogos.UseVisualStyleBackColor = false;
            this.btnNavCatalogos.Click += new System.EventHandler(this.btnNavCatalogos_Click);
            // 
            // btnNavMedicos
            // 
            this.btnNavMedicos.BackColor = System.Drawing.Color.Transparent;
            this.btnNavMedicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavMedicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavMedicos.FlatAppearance.BorderSize = 0;
            this.btnNavMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMedicos.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavMedicos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavMedicos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavMedicos.Location = new System.Drawing.Point(0, 280);
            this.btnNavMedicos.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNavMedicos.Name = "btnNavMedicos";
            this.btnNavMedicos.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnNavMedicos.Size = new System.Drawing.Size(440, 87);
            this.btnNavMedicos.TabIndex = 2;
            this.btnNavMedicos.Text = "🩺 Médicos";
            this.btnNavMedicos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavMedicos.UseVisualStyleBackColor = false;
            this.btnNavMedicos.Click += new System.EventHandler(this.btnNavMedicos_Click);
            // 
            // btnNavPacientes
            // 
            this.btnNavPacientes.BackColor = System.Drawing.Color.Transparent;
            this.btnNavPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavPacientes.FlatAppearance.BorderSize = 0;
            this.btnNavPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPacientes.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavPacientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavPacientes.Location = new System.Drawing.Point(0, 193);
            this.btnNavPacientes.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNavPacientes.Name = "btnNavPacientes";
            this.btnNavPacientes.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnNavPacientes.Size = new System.Drawing.Size(440, 87);
            this.btnNavPacientes.TabIndex = 1;
            this.btnNavPacientes.Text = "🗂 Pacientes";
            this.btnNavPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavPacientes.UseVisualStyleBackColor = false;
            this.btnNavPacientes.Click += new System.EventHandler(this.btnNavPacientes_Click);
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.Location = new System.Drawing.Point(0, 106);
            this.btnNavDashboard.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnNavDashboard.Size = new System.Drawing.Size(440, 87);
            this.btnNavDashboard.TabIndex = 0;
            this.btnNavDashboard.Text = "📊 Panel Principal";
            this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.UseVisualStyleBackColor = false;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlBrand.Controls.Add(this.lblSidebarBrand);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(440, 106);
            this.pnlBrand.TabIndex = 0;
            // 
            // lblSidebarBrand
            // 
            this.lblSidebarBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSidebarBrand.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSidebarBrand.ForeColor = System.Drawing.Color.White;
            this.lblSidebarBrand.Location = new System.Drawing.Point(0, 0);
            this.lblSidebarBrand.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSidebarBrand.Name = "lblSidebarBrand";
            this.lblSidebarBrand.Size = new System.Drawing.Size(440, 106);
            this.lblSidebarBrand.TabIndex = 0;
            this.lblSidebarBrand.Text = "SALUD INTEGRAL";
            this.lblSidebarBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContentHost
            // 
            this.pnlContentHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContentHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentHost.Location = new System.Drawing.Point(440, 106);
            this.pnlContentHost.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlContentHost.Name = "pnlContentHost";
            this.pnlContentHost.Size = new System.Drawing.Size(1928, 1204);
            this.pnlContentHost.TabIndex = 2;
            // 
            // timerInactividad
            // 
            this.timerInactividad.Interval = 30000;
            this.timerInactividad.Tick += new System.EventHandler(this.timerInactividad_Tick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnClose.Location = new System.Drawing.Point(1826, 19);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 67);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2368, 1310);
            this.Controls.Add(this.pnlContentHost);
            this.Controls.Add(this.pnlTopHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(1974, 1088);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Salud Integral - Sistema de Gestión Hospitalaria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlBrand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblHospitalBrand;
        private System.Windows.Forms.Label lblTestEnvironment;
        private System.Windows.Forms.Label lblSessionUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Label lblSidebarBrand;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavPacientes;
        private System.Windows.Forms.Button btnNavMedicos;
        private System.Windows.Forms.Button btnNavCatalogos;
        private System.Windows.Forms.Button btnNavCitas;
        private System.Windows.Forms.Button btnNavMedicamentos;
        private System.Windows.Forms.Button btnNavUsuarios;
        private System.Windows.Forms.Button btnNavPerfil;
        private System.Windows.Forms.Panel pnlContentHost;
        private System.Windows.Forms.Timer timerInactividad;
        private System.Windows.Forms.Button btnClose;
    }
}