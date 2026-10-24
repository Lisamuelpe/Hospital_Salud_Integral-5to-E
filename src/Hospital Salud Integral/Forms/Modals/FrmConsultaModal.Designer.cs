namespace Forms.Modals
{
    partial class FrmConsultaModal
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblCitaInfo = new System.Windows.Forms.Label();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.grpReceta = new System.Windows.Forms.GroupBox();
            this.btnEliminarMedicamento = new System.Windows.Forms.Button();
            this.btnAgregarMedicamento = new System.Windows.Forms.Button();
            this.dgvReceta = new System.Windows.Forms.DataGridView();
            this.txtDetalles = new System.Windows.Forms.TextBox();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.nudDuracion = new System.Windows.Forms.NumericUpDown();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.txtDosis = new System.Windows.Forms.TextBox();
            this.lblDosis = new System.Windows.Forms.Label();
            this.cboMedicamento = new System.Windows.Forms.ComboBox();
            this.lblMedicamento = new System.Windows.Forms.Label();
            this.grpClinico = new System.Windows.Forms.GroupBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.grpReceta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).BeginInit();
            this.grpClinico.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(860, 45);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Atención de Consulta y Prescripción";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlInfo.Controls.Add(this.lblCitaInfo);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 45);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(860, 50);
            this.pnlInfo.TabIndex = 1;
            // 
            // lblCitaInfo
            // 
            this.lblCitaInfo.AutoSize = true;
            this.lblCitaInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCitaInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblCitaInfo.Location = new System.Drawing.Point(15, 15);
            this.lblCitaInfo.Name = "lblCitaInfo";
            this.lblCitaInfo.Size = new System.Drawing.Size(185, 17);
            this.lblCitaInfo.TabIndex = 0;
            this.lblCitaInfo.Text = "Información de la consulta...";
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grpReceta);
            this.pnlCenter.Controls.Add(this.grpClinico);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 95);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCenter.Size = new System.Drawing.Size(860, 465);
            this.pnlCenter.TabIndex = 2;
            // 
            // grpReceta
            // 
            this.grpReceta.Controls.Add(this.btnEliminarMedicamento);
            this.grpReceta.Controls.Add(this.btnAgregarMedicamento);
            this.grpReceta.Controls.Add(this.dgvReceta);
            this.grpReceta.Controls.Add(this.txtDetalles);
            this.grpReceta.Controls.Add(this.lblDetalles);
            this.grpReceta.Controls.Add(this.nudDuracion);
            this.grpReceta.Controls.Add(this.lblDuracion);
            this.grpReceta.Controls.Add(this.txtDosis);
            this.grpReceta.Controls.Add(this.lblDosis);
            this.grpReceta.Controls.Add(this.cboMedicamento);
            this.grpReceta.Controls.Add(this.lblMedicamento);
            this.grpReceta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReceta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpReceta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.grpReceta.Location = new System.Drawing.Point(15, 185);
            this.grpReceta.Name = "grpReceta";
            this.grpReceta.Size = new System.Drawing.Size(830, 265);
            this.grpReceta.TabIndex = 1;
            this.grpReceta.TabStop = false;
            this.grpReceta.Text = "Prescripción Médica (Receta Opcional)";
            // 
            // btnEliminarMedicamento
            // 
            this.btnEliminarMedicamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarMedicamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminarMedicamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarMedicamento.FlatAppearance.BorderSize = 0;
            this.btnEliminarMedicamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarMedicamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarMedicamento.ForeColor = System.Drawing.Color.White;
            this.btnEliminarMedicamento.Location = new System.Drawing.Point(715, 80);
            this.btnEliminarMedicamento.Name = "btnEliminarMedicamento";
            this.btnEliminarMedicamento.Size = new System.Drawing.Size(100, 28);
            this.btnEliminarMedicamento.TabIndex = 10;
            this.btnEliminarMedicamento.Text = "Quitar Ítem";
            this.btnEliminarMedicamento.UseVisualStyleBackColor = false;
            this.btnEliminarMedicamento.Click += new System.EventHandler(this.btnEliminarMedicamento_Click);
            // 
            // btnAgregarMedicamento
            // 
            this.btnAgregarMedicamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarMedicamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnAgregarMedicamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarMedicamento.FlatAppearance.BorderSize = 0;
            this.btnAgregarMedicamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMedicamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarMedicamento.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMedicamento.Location = new System.Drawing.Point(600, 80);
            this.btnAgregarMedicamento.Name = "btnAgregarMedicamento";
            this.btnAgregarMedicamento.Size = new System.Drawing.Size(105, 28);
            this.btnAgregarMedicamento.TabIndex = 9;
            this.btnAgregarMedicamento.Text = "+ Agregar";
            this.btnAgregarMedicamento.UseVisualStyleBackColor = false;
            this.btnAgregarMedicamento.Click += new System.EventHandler(this.btnAgregarMedicamento_Click);
            // 
            // dgvReceta
            // 
            this.dgvReceta.AllowUserToAddRows = false;
            this.dgvReceta.AllowUserToDeleteRows = false;
            this.dgvReceta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReceta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceta.BackgroundColor = System.Drawing.Color.White;
            this.dgvReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceta.Location = new System.Drawing.Point(15, 115);
            this.dgvReceta.Name = "dgvReceta";
            this.dgvReceta.ReadOnly = true;
            this.dgvReceta.RowHeadersVisible = false;
            this.dgvReceta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceta.Size = new System.Drawing.Size(800, 140);
            this.dgvReceta.TabIndex = 8;
            // 
            // txtDetalles
            // 
            this.txtDetalles.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDetalles.Location = new System.Drawing.Point(15, 82);
            this.txtDetalles.Name = "txtDetalles";
            this.txtDetalles.Size = new System.Drawing.Size(570, 24);
            this.txtDetalles.TabIndex = 7;
            // 
            // lblDetalles
            // 
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblDetalles.Location = new System.Drawing.Point(15, 65);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(206, 15);
            this.lblDetalles.TabIndex = 6;
            this.lblDetalles.Text = "Indicaciones / Estudios Adicionales:";
            // 
            // nudDuracion
            // 
            this.nudDuracion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudDuracion.Location = new System.Drawing.Point(540, 38);
            this.nudDuracion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuracion.Name = "nudDuracion";
            this.nudDuracion.Size = new System.Drawing.Size(75, 24);
            this.nudDuracion.TabIndex = 5;
            this.nudDuracion.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblDuracion.Location = new System.Drawing.Point(540, 20);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(65, 15);
            this.lblDuracion.TabIndex = 4;
            this.lblDuracion.Text = "Días tratam:";
            // 
            // txtDosis
            // 
            this.txtDosis.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDosis.Location = new System.Drawing.Point(325, 38);
            this.txtDosis.Name = "txtDosis";
            this.txtDosis.Size = new System.Drawing.Size(200, 24);
            this.txtDosis.TabIndex = 3;
            // 
            // lblDosis
            // 
            this.lblDosis.AutoSize = true;
            this.lblDosis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblDosis.Location = new System.Drawing.Point(325, 20);
            this.lblDosis.Name = "lblDosis";
            this.lblDosis.Size = new System.Drawing.Size(126, 15);
            this.lblDosis.TabIndex = 2;
            this.lblDosis.Text = "Dosis (ej. 1 cada 8h):";
            // 
            // cboMedicamento
            // 
            this.cboMedicamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedicamento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMedicamento.FormattingEnabled = true;
            this.cboMedicamento.Location = new System.Drawing.Point(15, 38);
            this.cboMedicamento.Name = "cboMedicamento";
            this.cboMedicamento.Size = new System.Drawing.Size(295, 24);
            this.cboMedicamento.TabIndex = 1;
            // 
            // lblMedicamento
            // 
            this.lblMedicamento.AutoSize = true;
            this.lblMedicamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblMedicamento.Location = new System.Drawing.Point(15, 20);
            this.lblMedicamento.Name = "lblMedicamento";
            this.lblMedicamento.Size = new System.Drawing.Size(85, 15);
            this.lblMedicamento.TabIndex = 0;
            this.lblMedicamento.Text = "Medicamento:";
            // 
            // grpClinico
            // 
            this.grpClinico.Controls.Add(this.txtObservaciones);
            this.grpClinico.Controls.Add(this.lblObservaciones);
            this.grpClinico.Controls.Add(this.txtDiagnostico);
            this.grpClinico.Controls.Add(this.lblDiagnostico);
            this.grpClinico.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpClinico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpClinico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.grpClinico.Location = new System.Drawing.Point(15, 15);
            this.grpClinico.Name = "grpClinico";
            this.grpClinico.Size = new System.Drawing.Size(830, 170);
            this.grpClinico.TabIndex = 0;
            this.grpClinico.TabStop = false;
            this.grpClinico.Text = "Registro Clínico de la Consulta";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtObservaciones.Location = new System.Drawing.Point(15, 105);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(800, 50);
            this.txtObservaciones.TabIndex = 3;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblObservaciones.Location = new System.Drawing.Point(15, 87);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(183, 15);
            this.lblObservaciones.TabIndex = 2;
            this.lblObservaciones.Text = "Observaciones y Recomendaciones:";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiagnostico.Location = new System.Drawing.Point(15, 38);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnostico.Size = new System.Drawing.Size(800, 45);
            this.txtDiagnostico.TabIndex = 1;
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiagnostico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblDiagnostico.Location = new System.Drawing.Point(15, 20);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(144, 15);
            this.lblDiagnostico.TabIndex = 0;
            this.lblDiagnostico.Text = "Diagnóstico Médico (*):";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlBottom.Controls.Add(this.btnGuardar);
            this.pnlBottom.Controls.Add(this.btnCerrar);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 560);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(860, 50);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(620, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 34);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar Atención";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(758, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 34);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmConsultaModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 610);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consulta Médica";
            this.Load += new System.EventHandler(this.FrmConsultaModal_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.grpReceta.ResumeLayout(false);
            this.grpReceta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).EndInit();
            this.grpClinico.ResumeLayout(false);
            this.grpClinico.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblCitaInfo;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.GroupBox grpClinico;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.GroupBox grpReceta;
        private System.Windows.Forms.Label lblMedicamento;
        private System.Windows.Forms.ComboBox cboMedicamento;
        private System.Windows.Forms.Label lblDosis;
        private System.Windows.Forms.TextBox txtDosis;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.NumericUpDown nudDuracion;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.TextBox txtDetalles;
        private System.Windows.Forms.Button btnAgregarMedicamento;
        private System.Windows.Forms.Button btnEliminarMedicamento;
        private System.Windows.Forms.DataGridView dgvReceta;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
    }
}
