namespace Forms.Controls
{
    partial class UcDashboard
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
            this.pnlCards = new System.Windows.Forms.Panel();
            this.cardStock = new System.Windows.Forms.Panel();
            this.lblStockCount = new System.Windows.Forms.Label();
            this.lblStockTitle = new System.Windows.Forms.Label();
            this.cardPacientes = new System.Windows.Forms.Panel();
            this.lblPacientesCount = new System.Windows.Forms.Label();
            this.lblPacientesTitle = new System.Windows.Forms.Label();
            this.cardPendientes = new System.Windows.Forms.Panel();
            this.lblPendientesCount = new System.Windows.Forms.Label();
            this.lblPendientesTitle = new System.Windows.Forms.Label();
            this.cardCitas = new System.Windows.Forms.Panel();
            this.lblCitasCount = new System.Windows.Forms.Label();
            this.lblCitasTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnNuevaCita = new System.Windows.Forms.Button();
            this.btnNuevoPaciente = new System.Windows.Forms.Button();
            this.lblRoleSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvAgenda = new System.Windows.Forms.DataGridView();
            this.lblAgendaTitle = new System.Windows.Forms.Label();
            this.pnlCards.SuspendLayout();
            this.cardStock.SuspendLayout();
            this.cardPacientes.SuspendLayout();
            this.cardPendientes.SuspendLayout();
            this.cardCitas.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgenda)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCards
            // 
            this.pnlCards.Controls.Add(this.cardStock);
            this.pnlCards.Controls.Add(this.cardPacientes);
            this.pnlCards.Controls.Add(this.cardPendientes);
            this.pnlCards.Controls.Add(this.cardCitas);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(20, 75);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(910, 110);
            this.pnlCards.TabIndex = 1;
            // 
            // cardStock
            // 
            this.cardStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.cardStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardStock.Controls.Add(this.lblStockCount);
            this.cardStock.Controls.Add(this.lblStockTitle);
            this.cardStock.Location = new System.Drawing.Point(680, 5);
            this.cardStock.Name = "cardStock";
            this.cardStock.Size = new System.Drawing.Size(215, 95);
            this.cardStock.TabIndex = 3;
            // 
            // lblStockCount
            // 
            this.lblStockCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblStockCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(100)))), ((int)(((byte)(4)))));
            this.lblStockCount.Location = new System.Drawing.Point(10, 38);
            this.lblStockCount.Name = "lblStockCount";
            this.lblStockCount.Size = new System.Drawing.Size(195, 45);
            this.lblStockCount.TabIndex = 1;
            this.lblStockCount.Text = "0";
            this.lblStockCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStockTitle
            // 
            this.lblStockTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(100)))), ((int)(((byte)(4)))));
            this.lblStockTitle.Location = new System.Drawing.Point(10, 10);
            this.lblStockTitle.Name = "lblStockTitle";
            this.lblStockTitle.Size = new System.Drawing.Size(195, 20);
            this.lblStockTitle.TabIndex = 0;
            this.lblStockTitle.Text = "STOCK BAJO O AGOTADO";
            this.lblStockTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardPacientes
            // 
            this.cardPacientes.BackColor = System.Drawing.Color.White;
            this.cardPacientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPacientes.Controls.Add(this.lblPacientesCount);
            this.cardPacientes.Controls.Add(this.lblPacientesTitle);
            this.cardPacientes.Location = new System.Drawing.Point(455, 5);
            this.cardPacientes.Name = "cardPacientes";
            this.cardPacientes.Size = new System.Drawing.Size(215, 95);
            this.cardPacientes.TabIndex = 2;
            // 
            // lblPacientesCount
            // 
            this.lblPacientesCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPacientesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.lblPacientesCount.Location = new System.Drawing.Point(10, 38);
            this.lblPacientesCount.Name = "lblPacientesCount";
            this.lblPacientesCount.Size = new System.Drawing.Size(195, 45);
            this.lblPacientesCount.TabIndex = 1;
            this.lblPacientesCount.Text = "0";
            this.lblPacientesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPacientesTitle
            // 
            this.lblPacientesTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPacientesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblPacientesTitle.Location = new System.Drawing.Point(10, 10);
            this.lblPacientesTitle.Name = "lblPacientesTitle";
            this.lblPacientesTitle.Size = new System.Drawing.Size(195, 20);
            this.lblPacientesTitle.TabIndex = 0;
            this.lblPacientesTitle.Text = "TOTAL PACIENTES";
            this.lblPacientesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardPendientes
            // 
            this.cardPendientes.BackColor = System.Drawing.Color.White;
            this.cardPendientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPendientes.Controls.Add(this.lblPendientesCount);
            this.cardPendientes.Controls.Add(this.lblPendientesTitle);
            this.cardPendientes.Location = new System.Drawing.Point(230, 5);
            this.cardPendientes.Name = "cardPendientes";
            this.cardPendientes.Size = new System.Drawing.Size(215, 95);
            this.cardPendientes.TabIndex = 1;
            // 
            // lblPendientesCount
            // 
            this.lblPendientesCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPendientesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.lblPendientesCount.Location = new System.Drawing.Point(10, 38);
            this.lblPendientesCount.Name = "lblPendientesCount";
            this.lblPendientesCount.Size = new System.Drawing.Size(195, 45);
            this.lblPendientesCount.TabIndex = 1;
            this.lblPendientesCount.Text = "0";
            this.lblPendientesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPendientesTitle
            // 
            this.lblPendientesTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPendientesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblPendientesTitle.Location = new System.Drawing.Point(10, 10);
            this.lblPendientesTitle.Name = "lblPendientesTitle";
            this.lblPendientesTitle.Size = new System.Drawing.Size(195, 20);
            this.lblPendientesTitle.TabIndex = 0;
            this.lblPendientesTitle.Text = "CITAS PENDIENTES HOY";
            this.lblPendientesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardCitas
            // 
            this.cardCitas.BackColor = System.Drawing.Color.White;
            this.cardCitas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardCitas.Controls.Add(this.lblCitasCount);
            this.cardCitas.Controls.Add(this.lblCitasTitle);
            this.cardCitas.Location = new System.Drawing.Point(5, 5);
            this.cardCitas.Name = "cardCitas";
            this.cardCitas.Size = new System.Drawing.Size(215, 95);
            this.cardCitas.TabIndex = 0;
            // 
            // lblCitasCount
            // 
            this.lblCitasCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCitasCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.lblCitasCount.Location = new System.Drawing.Point(10, 38);
            this.lblCitasCount.Name = "lblCitasCount";
            this.lblCitasCount.Size = new System.Drawing.Size(195, 45);
            this.lblCitasCount.TabIndex = 1;
            this.lblCitasCount.Text = "0";
            this.lblCitasCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCitasTitle
            // 
            this.lblCitasTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCitasTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblCitasTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCitasTitle.Name = "lblCitasTitle";
            this.lblCitasTitle.Size = new System.Drawing.Size(195, 20);
            this.lblCitasTitle.TabIndex = 0;
            this.lblCitasTitle.Text = "TOTAL CITAS HOY";
            this.lblCitasTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnNuevaCita);
            this.pnlHeader.Controls.Add(this.btnNuevoPaciente);
            this.pnlHeader.Controls.Add(this.lblRoleSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(20, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(910, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnNuevaCita
            // 
            this.btnNuevaCita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnNuevaCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaCita.FlatAppearance.BorderSize = 0;
            this.btnNuevaCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaCita.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevaCita.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCita.Location = new System.Drawing.Point(770, 12);
            this.btnNuevaCita.Name = "btnNuevaCita";
            this.btnNuevaCita.Size = new System.Drawing.Size(130, 36);
            this.btnNuevaCita.TabIndex = 3;
            this.btnNuevaCita.Text = "+ Nueva Cita";
            this.btnNuevaCita.UseVisualStyleBackColor = false;
            this.btnNuevaCita.Click += new System.EventHandler(this.btnNuevaCita_Click);
            // 
            // btnNuevoPaciente
            // 
            this.btnNuevoPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNuevoPaciente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoPaciente.FlatAppearance.BorderSize = 0;
            this.btnNuevoPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoPaciente.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevoPaciente.ForeColor = System.Drawing.Color.White;
            this.btnNuevoPaciente.Location = new System.Drawing.Point(625, 12);
            this.btnNuevoPaciente.Name = "btnNuevoPaciente";
            this.btnNuevoPaciente.Size = new System.Drawing.Size(135, 36);
            this.btnNuevoPaciente.TabIndex = 2;
            this.btnNuevoPaciente.Text = "+ Nuevo Paciente";
            this.btnNuevoPaciente.UseVisualStyleBackColor = false;
            this.btnNuevoPaciente.Click += new System.EventHandler(this.btnNuevoPaciente_Click);
            // 
            // lblRoleSubtitle
            // 
            this.lblRoleSubtitle.AutoSize = true;
            this.lblRoleSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRoleSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.lblRoleSubtitle.Location = new System.Drawing.Point(5, 32);
            this.lblRoleSubtitle.Name = "lblRoleSubtitle";
            this.lblRoleSubtitle.Size = new System.Drawing.Size(193, 17);
            this.lblRoleSubtitle.TabIndex = 1;
            this.lblRoleSubtitle.Text = "Indicadores y agenda en tiempo real";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(169, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Panel Principal";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.dgvAgenda);
            this.pnlContent.Controls.Add(this.lblAgendaTitle);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(20, 185);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(15);
            this.pnlContent.Size = new System.Drawing.Size(910, 395);
            this.pnlContent.TabIndex = 2;
            // 
            // dgvAgenda
            // 
            this.dgvAgenda.AllowUserToAddRows = false;
            this.dgvAgenda.AllowUserToDeleteRows = false;
            this.dgvAgenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgenda.BackgroundColor = System.Drawing.Color.White;
            this.dgvAgenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAgenda.Location = new System.Drawing.Point(15, 45);
            this.dgvAgenda.Name = "dgvAgenda";
            this.dgvAgenda.ReadOnly = true;
            this.dgvAgenda.RowHeadersVisible = false;
            this.dgvAgenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgenda.Size = new System.Drawing.Size(878, 333);
            this.dgvAgenda.TabIndex = 1;
            // 
            // lblAgendaTitle
            // 
            this.lblAgendaTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAgendaTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAgendaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.lblAgendaTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAgendaTitle.Name = "lblAgendaTitle";
            this.lblAgendaTitle.Size = new System.Drawing.Size(878, 30);
            this.lblAgendaTitle.TabIndex = 0;
            this.lblAgendaTitle.Text = "Agenda de Citas del Día";
            // 
            // UcDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcDashboard";
            this.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.Size = new System.Drawing.Size(950, 600);
            this.Load += new System.EventHandler(this.UcDashboard_Load);
            this.pnlCards.ResumeLayout(false);
            this.cardStock.ResumeLayout(false);
            this.cardPacientes.ResumeLayout(false);
            this.cardPendientes.ResumeLayout(false);
            this.cardCitas.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRoleSubtitle;
        private System.Windows.Forms.Button btnNuevoPaciente;
        private System.Windows.Forms.Button btnNuevaCita;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel cardCitas;
        private System.Windows.Forms.Label lblCitasTitle;
        private System.Windows.Forms.Label lblCitasCount;
        private System.Windows.Forms.Panel cardPendientes;
        private System.Windows.Forms.Label lblPendientesCount;
        private System.Windows.Forms.Label lblPendientesTitle;
        private System.Windows.Forms.Panel cardPacientes;
        private System.Windows.Forms.Label lblPacientesCount;
        private System.Windows.Forms.Label lblPacientesTitle;
        private System.Windows.Forms.Panel cardStock;
        private System.Windows.Forms.Label lblStockCount;
        private System.Windows.Forms.Label lblStockTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblAgendaTitle;
        private System.Windows.Forms.DataGridView dgvAgenda;
    }
}
