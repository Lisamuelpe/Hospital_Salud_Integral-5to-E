namespace Forms.Modals
{
    partial class FrmCitaModal
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cboPaciente = new System.Windows.Forms.ComboBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.cboServicio = new System.Windows.Forms.ComboBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblMedico = new System.Windows.Forms.Label();
            this.cboMedico = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(480, 45);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Programar Nueva Cita";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblPaciente.Location = new System.Drawing.Point(25, 60);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(65, 17);
            this.lblPaciente.TabIndex = 1;
            this.lblPaciente.Text = "Paciente:";
            // 
            // cboPaciente
            // 
            this.cboPaciente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPaciente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaciente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPaciente.FormattingEnabled = true;
            this.cboPaciente.Location = new System.Drawing.Point(25, 82);
            this.cboPaciente.Name = "cboPaciente";
            this.cboPaciente.Size = new System.Drawing.Size(430, 25);
            this.cboPaciente.TabIndex = 2;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblServicio.Location = new System.Drawing.Point(25, 120);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(60, 17);
            this.lblServicio.TabIndex = 3;
            this.lblServicio.Text = "Servicio:";
            // 
            // cboServicio
            // 
            this.cboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboServicio.FormattingEnabled = true;
            this.cboServicio.Location = new System.Drawing.Point(25, 142);
            this.cboServicio.Name = "cboServicio";
            this.cboServicio.Size = new System.Drawing.Size(300, 25);
            this.cboServicio.TabIndex = 4;
            this.cboServicio.SelectedIndexChanged += new System.EventHandler(this.cboServicio_SelectedIndexChanged);
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCosto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.lblCosto.Location = new System.Drawing.Point(340, 145);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(95, 19);
            this.lblCosto.TabIndex = 5;
            this.lblCosto.Text = "Costo: $0.00";
            // 
            // lblMedico
            // 
            this.lblMedico.AutoSize = true;
            this.lblMedico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMedico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblMedico.Location = new System.Drawing.Point(25, 180);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(117, 17);
            this.lblMedico.TabIndex = 6;
            this.lblMedico.Text = "Médico Tratante:";
            // 
            // cboMedico
            // 
            this.cboMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedico.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMedico.FormattingEnabled = true;
            this.cboMedico.Location = new System.Drawing.Point(25, 202);
            this.cboMedico.Name = "cboMedico";
            this.cboMedico.Size = new System.Drawing.Size(430, 25);
            this.cboMedico.TabIndex = 7;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblFecha.Location = new System.Drawing.Point(25, 240);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 17);
            this.lblFecha.TabIndex = 8;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(25, 262);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 25);
            this.dtpFecha.TabIndex = 9;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblHora.Location = new System.Drawing.Point(255, 240);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(42, 17);
            this.lblHora.TabIndex = 10;
            this.lblHora.Text = "Hora:";
            // 
            // dtpHora
            // 
            this.dtpHora.CustomFormat = "hh:mm tt";
            this.dtpHora.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHora.Location = new System.Drawing.Point(255, 262);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(200, 25);
            this.dtpHora.TabIndex = 11;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(215, 315);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 36);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Agendar Cita";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(345, 315);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmCitaModal
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(480, 370);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cboMedico);
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.cboServicio);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.cboPaciente);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCitaModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cita Médica";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cboPaciente;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.ComboBox cboServicio;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.ComboBox cboMedico;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
