namespace Forms.Controls
{
    partial class UcCatalogos
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
            this.tabCatalogos = new System.Windows.Forms.TabControl();
            this.tabDepartamentos = new System.Windows.Forms.TabPage();
            this.dgvDepartamentos = new System.Windows.Forms.DataGridView();
            this.pnlDepToolbar = new System.Windows.Forms.Panel();
            this.btnEliminarDep = new System.Windows.Forms.Button();
            this.btnEditarDep = new System.Windows.Forms.Button();
            this.btnNuevoDep = new System.Windows.Forms.Button();
            this.tabEspecialidades = new System.Windows.Forms.TabPage();
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            this.pnlEspToolbar = new System.Windows.Forms.Panel();
            this.btnEliminarEsp = new System.Windows.Forms.Button();
            this.btnEditarEsp = new System.Windows.Forms.Button();
            this.btnNuevaEsp = new System.Windows.Forms.Button();
            this.tabServicios = new System.Windows.Forms.TabPage();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.pnlServToolbar = new System.Windows.Forms.Panel();
            this.btnEliminarServ = new System.Windows.Forms.Button();
            this.btnEditarServ = new System.Windows.Forms.Button();
            this.btnNuevoServ = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tabCatalogos.SuspendLayout();
            this.tabDepartamentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).BeginInit();
            this.pnlDepToolbar.SuspendLayout();
            this.tabEspecialidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            this.pnlEspToolbar.SuspendLayout();
            this.tabServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.pnlServToolbar.SuspendLayout();
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
            this.lblSubtitle.Size = new System.Drawing.Size(344, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Departamentos hospitalarios, especialidades y cartera de servicios";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Catálogos Institucionales";
            // 
            // tabCatalogos
            // 
            this.tabCatalogos.Controls.Add(this.tabDepartamentos);
            this.tabCatalogos.Controls.Add(this.tabEspecialidades);
            this.tabCatalogos.Controls.Add(this.tabServicios);
            this.tabCatalogos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCatalogos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabCatalogos.Location = new System.Drawing.Point(20, 70);
            this.tabCatalogos.Name = "tabCatalogos";
            this.tabCatalogos.SelectedIndex = 0;
            this.tabCatalogos.Size = new System.Drawing.Size(910, 510);
            this.tabCatalogos.TabIndex = 1;
            this.tabCatalogos.SelectedIndexChanged += new System.EventHandler(this.tabCatalogos_SelectedIndexChanged);
            // 
            // tabDepartamentos
            // 
            this.tabDepartamentos.BackColor = System.Drawing.Color.White;
            this.tabDepartamentos.Controls.Add(this.dgvDepartamentos);
            this.tabDepartamentos.Controls.Add(this.pnlDepToolbar);
            this.tabDepartamentos.Location = new System.Drawing.Point(4, 26);
            this.tabDepartamentos.Name = "tabDepartamentos";
            this.tabDepartamentos.Padding = new System.Windows.Forms.Padding(10);
            this.tabDepartamentos.Size = new System.Drawing.Size(902, 480);
            this.tabDepartamentos.TabIndex = 0;
            this.tabDepartamentos.Text = "Departamentos";
            // 
            // dgvDepartamentos
            // 
            this.dgvDepartamentos.AllowUserToAddRows = false;
            this.dgvDepartamentos.AllowUserToDeleteRows = false;
            this.dgvDepartamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartamentos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDepartamentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartamentos.Location = new System.Drawing.Point(10, 55);
            this.dgvDepartamentos.MultiSelect = false;
            this.dgvDepartamentos.Name = "dgvDepartamentos";
            this.dgvDepartamentos.ReadOnly = true;
            this.dgvDepartamentos.RowHeadersVisible = false;
            this.dgvDepartamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartamentos.Size = new System.Drawing.Size(882, 415);
            this.dgvDepartamentos.TabIndex = 1;
            // 
            // pnlDepToolbar
            // 
            this.pnlDepToolbar.Controls.Add(this.btnEliminarDep);
            this.pnlDepToolbar.Controls.Add(this.btnEditarDep);
            this.pnlDepToolbar.Controls.Add(this.btnNuevoDep);
            this.pnlDepToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDepToolbar.Location = new System.Drawing.Point(10, 10);
            this.pnlDepToolbar.Name = "pnlDepToolbar";
            this.pnlDepToolbar.Size = new System.Drawing.Size(882, 45);
            this.pnlDepToolbar.TabIndex = 0;
            // 
            // btnEliminarDep
            // 
            this.btnEliminarDep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminarDep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarDep.FlatAppearance.BorderSize = 0;
            this.btnEliminarDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarDep.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDep.Location = new System.Drawing.Point(795, 6);
            this.btnEliminarDep.Name = "btnEliminarDep";
            this.btnEliminarDep.Size = new System.Drawing.Size(80, 32);
            this.btnEliminarDep.TabIndex = 2;
            this.btnEliminarDep.Text = "Eliminar";
            this.btnEliminarDep.UseVisualStyleBackColor = false;
            this.btnEliminarDep.Click += new System.EventHandler(this.btnEliminarDep_Click);
            // 
            // btnEditarDep
            // 
            this.btnEditarDep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.btnEditarDep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarDep.FlatAppearance.BorderSize = 0;
            this.btnEditarDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarDep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarDep.ForeColor = System.Drawing.Color.White;
            this.btnEditarDep.Location = new System.Drawing.Point(705, 6);
            this.btnEditarDep.Name = "btnEditarDep";
            this.btnEditarDep.Size = new System.Drawing.Size(80, 32);
            this.btnEditarDep.TabIndex = 1;
            this.btnEditarDep.Text = "Editar";
            this.btnEditarDep.UseVisualStyleBackColor = false;
            this.btnEditarDep.Click += new System.EventHandler(this.btnEditarDep_Click);
            // 
            // btnNuevoDep
            // 
            this.btnNuevoDep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnNuevoDep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoDep.FlatAppearance.BorderSize = 0;
            this.btnNuevoDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoDep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoDep.ForeColor = System.Drawing.Color.White;
            this.btnNuevoDep.Location = new System.Drawing.Point(595, 6);
            this.btnNuevoDep.Name = "btnNuevoDep";
            this.btnNuevoDep.Size = new System.Drawing.Size(100, 32);
            this.btnNuevoDep.TabIndex = 0;
            this.btnNuevoDep.Text = "+ Nuevo";
            this.btnNuevoDep.UseVisualStyleBackColor = false;
            this.btnNuevoDep.Click += new System.EventHandler(this.btnNuevoDep_Click);
            // 
            // tabEspecialidades
            // 
            this.tabEspecialidades.BackColor = System.Drawing.Color.White;
            this.tabEspecialidades.Controls.Add(this.dgvEspecialidades);
            this.tabEspecialidades.Controls.Add(this.pnlEspToolbar);
            this.tabEspecialidades.Location = new System.Drawing.Point(4, 26);
            this.tabEspecialidades.Name = "tabEspecialidades";
            this.tabEspecialidades.Padding = new System.Windows.Forms.Padding(10);
            this.tabEspecialidades.Size = new System.Drawing.Size(902, 480);
            this.tabEspecialidades.TabIndex = 1;
            this.tabEspecialidades.Text = "Especialidades";
            // 
            // dgvEspecialidades
            // 
            this.dgvEspecialidades.AllowUserToAddRows = false;
            this.dgvEspecialidades.AllowUserToDeleteRows = false;
            this.dgvEspecialidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEspecialidades.BackgroundColor = System.Drawing.Color.White;
            this.dgvEspecialidades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEspecialidades.Location = new System.Drawing.Point(10, 55);
            this.dgvEspecialidades.MultiSelect = false;
            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.ReadOnly = true;
            this.dgvEspecialidades.RowHeadersVisible = false;
            this.dgvEspecialidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEspecialidades.Size = new System.Drawing.Size(882, 415);
            this.dgvEspecialidades.TabIndex = 2;
            // 
            // pnlEspToolbar
            // 
            this.pnlEspToolbar.Controls.Add(this.btnEliminarEsp);
            this.pnlEspToolbar.Controls.Add(this.btnEditarEsp);
            this.pnlEspToolbar.Controls.Add(this.btnNuevaEsp);
            this.pnlEspToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEspToolbar.Location = new System.Drawing.Point(10, 10);
            this.pnlEspToolbar.Name = "pnlEspToolbar";
            this.pnlEspToolbar.Size = new System.Drawing.Size(882, 45);
            this.pnlEspToolbar.TabIndex = 1;
            // 
            // btnEliminarEsp
            // 
            this.btnEliminarEsp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarEsp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminarEsp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarEsp.FlatAppearance.BorderSize = 0;
            this.btnEliminarEsp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarEsp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarEsp.ForeColor = System.Drawing.Color.White;
            this.btnEliminarEsp.Location = new System.Drawing.Point(795, 6);
            this.btnEliminarEsp.Name = "btnEliminarEsp";
            this.btnEliminarEsp.Size = new System.Drawing.Size(80, 32);
            this.btnEliminarEsp.TabIndex = 2;
            this.btnEliminarEsp.Text = "Eliminar";
            this.btnEliminarEsp.UseVisualStyleBackColor = false;
            this.btnEliminarEsp.Click += new System.EventHandler(this.btnEliminarEsp_Click);
            // 
            // btnEditarEsp
            // 
            this.btnEditarEsp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarEsp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.btnEditarEsp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarEsp.FlatAppearance.BorderSize = 0;
            this.btnEditarEsp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarEsp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarEsp.ForeColor = System.Drawing.Color.White;
            this.btnEditarEsp.Location = new System.Drawing.Point(705, 6);
            this.btnEditarEsp.Name = "btnEditarEsp";
            this.btnEditarEsp.Size = new System.Drawing.Size(80, 32);
            this.btnEditarEsp.TabIndex = 1;
            this.btnEditarEsp.Text = "Editar";
            this.btnEditarEsp.UseVisualStyleBackColor = false;
            this.btnEditarEsp.Click += new System.EventHandler(this.btnEditarEsp_Click);
            // 
            // btnNuevaEsp
            // 
            this.btnNuevaEsp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaEsp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnNuevaEsp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaEsp.FlatAppearance.BorderSize = 0;
            this.btnNuevaEsp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaEsp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevaEsp.ForeColor = System.Drawing.Color.White;
            this.btnNuevaEsp.Location = new System.Drawing.Point(595, 6);
            this.btnNuevaEsp.Name = "btnNuevaEsp";
            this.btnNuevaEsp.Size = new System.Drawing.Size(100, 32);
            this.btnNuevaEsp.TabIndex = 0;
            this.btnNuevaEsp.Text = "+ Nueva";
            this.btnNuevaEsp.UseVisualStyleBackColor = false;
            this.btnNuevaEsp.Click += new System.EventHandler(this.btnNuevaEsp_Click);
            // 
            // tabServicios
            // 
            this.tabServicios.BackColor = System.Drawing.Color.White;
            this.tabServicios.Controls.Add(this.dgvServicios);
            this.tabServicios.Controls.Add(this.pnlServToolbar);
            this.tabServicios.Location = new System.Drawing.Point(4, 26);
            this.tabServicios.Name = "tabServicios";
            this.tabServicios.Padding = new System.Windows.Forms.Padding(10);
            this.tabServicios.Size = new System.Drawing.Size(902, 480);
            this.tabServicios.TabIndex = 2;
            this.tabServicios.Text = "Servicios Médicos";
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServicios.Location = new System.Drawing.Point(10, 55);
            this.dgvServicios.MultiSelect = false;
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowHeadersVisible = false;
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(882, 415);
            this.dgvServicios.TabIndex = 3;
            // 
            // pnlServToolbar
            // 
            this.pnlServToolbar.Controls.Add(this.btnEliminarServ);
            this.pnlServToolbar.Controls.Add(this.btnEditarServ);
            this.pnlServToolbar.Controls.Add(this.btnNuevoServ);
            this.pnlServToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlServToolbar.Location = new System.Drawing.Point(10, 10);
            this.pnlServToolbar.Name = "pnlServToolbar";
            this.pnlServToolbar.Size = new System.Drawing.Size(882, 45);
            this.pnlServToolbar.TabIndex = 2;
            // 
            // btnEliminarServ
            // 
            this.btnEliminarServ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarServ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminarServ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarServ.FlatAppearance.BorderSize = 0;
            this.btnEliminarServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarServ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarServ.ForeColor = System.Drawing.Color.White;
            this.btnEliminarServ.Location = new System.Drawing.Point(795, 6);
            this.btnEliminarServ.Name = "btnEliminarServ";
            this.btnEliminarServ.Size = new System.Drawing.Size(80, 32);
            this.btnEliminarServ.TabIndex = 2;
            this.btnEliminarServ.Text = "Eliminar";
            this.btnEliminarServ.UseVisualStyleBackColor = false;
            this.btnEliminarServ.Click += new System.EventHandler(this.btnEliminarServ_Click);
            // 
            // btnEditarServ
            // 
            this.btnEditarServ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarServ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.btnEditarServ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarServ.FlatAppearance.BorderSize = 0;
            this.btnEditarServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarServ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarServ.ForeColor = System.Drawing.Color.White;
            this.btnEditarServ.Location = new System.Drawing.Point(705, 6);
            this.btnEditarServ.Name = "btnEditarServ";
            this.btnEditarServ.Size = new System.Drawing.Size(80, 32);
            this.btnEditarServ.TabIndex = 1;
            this.btnEditarServ.Text = "Editar";
            this.btnEditarServ.UseVisualStyleBackColor = false;
            this.btnEditarServ.Click += new System.EventHandler(this.btnEditarServ_Click);
            // 
            // btnNuevoServ
            // 
            this.btnNuevoServ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoServ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnNuevoServ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoServ.FlatAppearance.BorderSize = 0;
            this.btnNuevoServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoServ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoServ.ForeColor = System.Drawing.Color.White;
            this.btnNuevoServ.Location = new System.Drawing.Point(595, 6);
            this.btnNuevoServ.Name = "btnNuevoServ";
            this.btnNuevoServ.Size = new System.Drawing.Size(100, 32);
            this.btnNuevoServ.TabIndex = 0;
            this.btnNuevoServ.Text = "+ Nuevo";
            this.btnNuevoServ.UseVisualStyleBackColor = false;
            this.btnNuevoServ.Click += new System.EventHandler(this.btnNuevoServ_Click);
            // 
            // UcCatalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.tabCatalogos);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcCatalogos";
            this.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.Size = new System.Drawing.Size(950, 600);
            this.Load += new System.EventHandler(this.UcCatalogos_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabCatalogos.ResumeLayout(false);
            this.tabDepartamentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).EndInit();
            this.pnlDepToolbar.ResumeLayout(false);
            this.tabEspecialidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            this.pnlEspToolbar.ResumeLayout(false);
            this.tabServicios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.pnlServToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TabControl tabCatalogos;
        private System.Windows.Forms.TabPage tabDepartamentos;
        private System.Windows.Forms.TabPage tabEspecialidades;
        private System.Windows.Forms.TabPage tabServicios;
        private System.Windows.Forms.Panel pnlDepToolbar;
        private System.Windows.Forms.Button btnEliminarDep;
        private System.Windows.Forms.Button btnEditarDep;
        private System.Windows.Forms.Button btnNuevoDep;
        private System.Windows.Forms.DataGridView dgvDepartamentos;
        private System.Windows.Forms.DataGridView dgvEspecialidades;
        private System.Windows.Forms.Panel pnlEspToolbar;
        private System.Windows.Forms.Button btnEliminarEsp;
        private System.Windows.Forms.Button btnEditarEsp;
        private System.Windows.Forms.Button btnNuevaEsp;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.Panel pnlServToolbar;
        private System.Windows.Forms.Button btnEliminarServ;
        private System.Windows.Forms.Button btnEditarServ;
        private System.Windows.Forms.Button btnNuevoServ;
    }
}
