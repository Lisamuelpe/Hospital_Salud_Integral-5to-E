namespace Forms.Controls
{
    partial class UcCitas
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cboFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.cboFiltroMedico = new System.Windows.Forms.ComboBox();
            this.lblFiltroMedico = new System.Windows.Forms.Label();
            this.chkFiltrarFecha = new System.Windows.Forms.CheckBox();
            this.dtpFiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnAbrirConsulta = new System.Windows.Forms.Button();
            this.btnMarcarNoAsistio = new System.Windows.Forms.Button();
            this.btnCancelarCita = new System.Windows.Forms.Button();
            this.btnReprogramar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnNuevaCita = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(20, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(910, 55);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.lblSubtitle.Location = new System.Drawing.Point(5, 32);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(328, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Programación, estados, reprogramación y apertura clínica";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Gestión de Agenda";
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.White;
            this.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilters.Controls.Add(this.btnLimpiarFiltros);
            this.pnlFilters.Controls.Add(this.btnFiltrar);
            this.pnlFilters.Controls.Add(this.cboFiltroEstado);
            this.pnlFilters.Controls.Add(this.lblFiltroEstado);
            this.pnlFilters.Controls.Add(this.cboFiltroMedico);
            this.pnlFilters.Controls.Add(this.lblFiltroMedico);
            this.pnlFilters.Controls.Add(this.chkFiltrarFecha);
            this.pnlFilters.Controls.Add(this.dtpFiltroFecha);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(20, 70);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(910, 50);
            this.pnlFilters.TabIndex = 1;
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.btnLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(810, 10);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(85, 28);
            this.btnLimpiarFiltros.TabIndex = 7;
            this.btnLimpiarFiltros.Text = "Restablecer";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(725, 10);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(80, 28);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cboFiltroEstado
            // 
            this.cboFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFiltroEstado.FormattingEnabled = true;
            this.cboFiltroEstado.Items.AddRange(new object[] {
            "Todos",
            "Programada",
            "Confirmada",
            "Atendida",
            "Cancelada",
            "No asistió"});
            this.cboFiltroEstado.Location = new System.Drawing.Point(585, 13);
            this.cboFiltroEstado.Name = "cboFiltroEstado";
            this.cboFiltroEstado.Size = new System.Drawing.Size(130, 23);
            this.cboFiltroEstado.TabIndex = 5;
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroEstado.Location = new System.Drawing.Point(535, 16);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(45, 15);
            this.lblFiltroEstado.TabIndex = 4;
            this.lblFiltroEstado.Text = "Estado:";
            // 
            // cboFiltroMedico
            // 
            this.cboFiltroMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroMedico.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFiltroMedico.FormattingEnabled = true;
            this.cboFiltroMedico.Location = new System.Drawing.Point(325, 13);
            this.cboFiltroMedico.Name = "cboFiltroMedico";
            this.cboFiltroMedico.Size = new System.Drawing.Size(195, 23);
            this.cboFiltroMedico.TabIndex = 3;
            // 
            // lblFiltroMedico
            // 
            this.lblFiltroMedico.AutoSize = true;
            this.lblFiltroMedico.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroMedico.Location = new System.Drawing.Point(270, 16);
            this.lblFiltroMedico.Name = "lblFiltroMedico";
            this.lblFiltroMedico.Size = new System.Drawing.Size(50, 15);
            this.lblFiltroMedico.TabIndex = 2;
            this.lblFiltroMedico.Text = "Médico:";
            // 
            // chkFiltrarFecha
            // 
            this.chkFiltrarFecha.AutoSize = true;
            this.chkFiltrarFecha.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.chkFiltrarFecha.Location = new System.Drawing.Point(12, 16);
            this.chkFiltrarFecha.Name = "chkFiltrarFecha";
            this.chkFiltrarFecha.Size = new System.Drawing.Size(60, 19);
            this.chkFiltrarFecha.TabIndex = 0;
            this.chkFiltrarFecha.Text = "Fecha:";
            this.chkFiltrarFecha.UseVisualStyleBackColor = true;
            this.chkFiltrarFecha.CheckedChanged += new System.EventHandler(this.chkFiltrarFecha_CheckedChanged);
            // 
            // dtpFiltroFecha
            // 
            this.dtpFiltroFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFiltroFecha.Enabled = false;
            this.dtpFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFiltroFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFiltroFecha.Location = new System.Drawing.Point(75, 14);
            this.dtpFiltroFecha.Name = "dtpFiltroFecha";
            this.dtpFiltroFecha.Size = new System.Drawing.Size(180, 23);
            this.dtpFiltroFecha.TabIndex = 1;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlActions.Controls.Add(this.btnAbrirConsulta);
            this.pnlActions.Controls.Add(this.btnMarcarNoAsistio);
            this.pnlActions.Controls.Add(this.btnCancelarCita);
            this.pnlActions.Controls.Add(this.btnReprogramar);
            this.pnlActions.Controls.Add(this.btnConfirmar);
            this.pnlActions.Controls.Add(this.btnNuevaCita);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(20, 120);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(910, 48);
            this.pnlActions.TabIndex = 2;
            // 
            // btnAbrirConsulta
            // 
            this.btnAbrirConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnAbrirConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirConsulta.FlatAppearance.BorderSize = 0;
            this.btnAbrirConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirConsulta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAbrirConsulta.ForeColor = System.Drawing.Color.White;
            this.btnAbrirConsulta.Location = new System.Drawing.Point(735, 7);
            this.btnAbrirConsulta.Name = "btnAbrirConsulta";
            this.btnAbrirConsulta.Size = new System.Drawing.Size(170, 34);
            this.btnAbrirConsulta.TabIndex = 5;
            this.btnAbrirConsulta.Text = "🩺 Atender / Consulta";
            this.btnAbrirConsulta.UseVisualStyleBackColor = false;
            this.btnAbrirConsulta.Click += new System.EventHandler(this.btnAbrirConsulta_Click);
            // 
            // btnMarcarNoAsistio
            // 
            this.btnMarcarNoAsistio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnMarcarNoAsistio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcarNoAsistio.FlatAppearance.BorderSize = 0;
            this.btnMarcarNoAsistio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarNoAsistio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMarcarNoAsistio.ForeColor = System.Drawing.Color.White;
            this.btnMarcarNoAsistio.Location = new System.Drawing.Point(460, 8);
            this.btnMarcarNoAsistio.Name = "btnMarcarNoAsistio";
            this.btnMarcarNoAsistio.Size = new System.Drawing.Size(115, 32);
            this.btnMarcarNoAsistio.TabIndex = 4;
            this.btnMarcarNoAsistio.Text = "No Asistió";
            this.btnMarcarNoAsistio.UseVisualStyleBackColor = false;
            this.btnMarcarNoAsistio.Click += new System.EventHandler(this.btnMarcarNoAsistio_Click);
            // 
            // btnCancelarCita
            // 
            this.btnCancelarCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancelarCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarCita.FlatAppearance.BorderSize = 0;
            this.btnCancelarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarCita.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelarCita.ForeColor = System.Drawing.Color.White;
            this.btnCancelarCita.Location = new System.Drawing.Point(345, 8);
            this.btnCancelarCita.Name = "btnCancelarCita";
            this.btnCancelarCita.Size = new System.Drawing.Size(105, 32);
            this.btnCancelarCita.TabIndex = 3;
            this.btnCancelarCita.Text = "Cancelar Cita";
            this.btnCancelarCita.UseVisualStyleBackColor = false;
            this.btnCancelarCita.Click += new System.EventHandler(this.btnCancelarCita_Click);
            // 
            // btnReprogramar
            // 
            this.btnReprogramar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnReprogramar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReprogramar.FlatAppearance.BorderSize = 0;
            this.btnReprogramar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprogramar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReprogramar.ForeColor = System.Drawing.Color.White;
            this.btnReprogramar.Location = new System.Drawing.Point(230, 8);
            this.btnReprogramar.Name = "btnReprogramar";
            this.btnReprogramar.Size = new System.Drawing.Size(105, 32);
            this.btnReprogramar.TabIndex = 2;
            this.btnReprogramar.Text = "Reprogramar";
            this.btnReprogramar.UseVisualStyleBackColor = false;
            this.btnReprogramar.Click += new System.EventHandler(this.btnReprogramar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(135, 8);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(85, 32);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNuevaCita
            // 
            this.btnNuevaCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnNuevaCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaCita.FlatAppearance.BorderSize = 0;
            this.btnNuevaCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaCita.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevaCita.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCita.Location = new System.Drawing.Point(10, 8);
            this.btnNuevaCita.Name = "btnNuevaCita";
            this.btnNuevaCita.Size = new System.Drawing.Size(115, 32);
            this.btnNuevaCita.TabIndex = 0;
            this.btnNuevaCita.Text = "+ Agendar Cita";
            this.btnNuevaCita.UseVisualStyleBackColor = false;
            this.btnNuevaCita.Click += new System.EventHandler(this.btnNuevaCita_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.dgvCitas);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(20, 168);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(910, 412);
            this.pnlGrid.TabIndex = 3;
            // 
            // dgvCitas
            // 
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCitas.Location = new System.Drawing.Point(0, 0);
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(908, 410);
            this.dgvCitas.TabIndex = 0;
            this.dgvCitas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCitas_CellDoubleClick);
            // 
            // UcCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcCitas";
            this.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.Size = new System.Drawing.Size(950, 600);
            this.Load += new System.EventHandler(this.UcCitas_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.CheckBox chkFiltrarFecha;
        private System.Windows.Forms.DateTimePicker dtpFiltroFecha;
        private System.Windows.Forms.Label lblFiltroMedico;
        private System.Windows.Forms.ComboBox cboFiltroMedico;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cboFiltroEstado;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnNuevaCita;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnReprogramar;
        private System.Windows.Forms.Button btnCancelarCita;
        private System.Windows.Forms.Button btnMarcarNoAsistio;
        private System.Windows.Forms.Button btnAbrirConsulta;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvCitas;
    }
}
