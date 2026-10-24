namespace Forms.Controls
{
    partial class UcPerfil
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
            this.pnlCardPerfil = new System.Windows.Forms.Panel();
            this.lblUltimoAcceso = new System.Windows.Forms.Label();
            this.lblMedicoAsignado = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPerfilHeader = new System.Windows.Forms.Label();
            this.pnlCardPassword = new System.Windows.Forms.Panel();
            this.btnCambiarPassword = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblPasswordHeader = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlCardPerfil.SuspendLayout();
            this.pnlCardPassword.SuspendLayout();
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
            this.lblSubtitle.Size = new System.Drawing.Size(262, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Información de su cuenta y cambio de clave";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(134, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Perfil Propio";
            // 
            // pnlCardPerfil
            // 
            this.pnlCardPerfil.BackColor = System.Drawing.Color.White;
            this.pnlCardPerfil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardPerfil.Controls.Add(this.lblUltimoAcceso);
            this.pnlCardPerfil.Controls.Add(this.lblMedicoAsignado);
            this.pnlCardPerfil.Controls.Add(this.lblRol);
            this.pnlCardPerfil.Controls.Add(this.lblUsername);
            this.pnlCardPerfil.Controls.Add(this.lblPerfilHeader);
            this.pnlCardPerfil.Location = new System.Drawing.Point(20, 85);
            this.pnlCardPerfil.Name = "pnlCardPerfil";
            this.pnlCardPerfil.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCardPerfil.Size = new System.Drawing.Size(430, 260);
            this.pnlCardPerfil.TabIndex = 1;
            // 
            // lblUltimoAcceso
            // 
            this.lblUltimoAcceso.AutoSize = true;
            this.lblUltimoAcceso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUltimoAcceso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblUltimoAcceso.Location = new System.Drawing.Point(20, 185);
            this.lblUltimoAcceso.Name = "lblUltimoAcceso";
            this.lblUltimoAcceso.Size = new System.Drawing.Size(95, 17);
            this.lblUltimoAcceso.TabIndex = 4;
            this.lblUltimoAcceso.Text = "Último Acceso: ";
            // 
            // lblMedicoAsignado
            // 
            this.lblMedicoAsignado.AutoSize = true;
            this.lblMedicoAsignado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMedicoAsignado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblMedicoAsignado.Location = new System.Drawing.Point(20, 145);
            this.lblMedicoAsignado.Name = "lblMedicoAsignado";
            this.lblMedicoAsignado.Size = new System.Drawing.Size(117, 17);
            this.lblMedicoAsignado.TabIndex = 3;
            this.lblMedicoAsignado.Text = "Médico Vinculado: ";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblRol.Location = new System.Drawing.Point(20, 105);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(90, 17);
            this.lblRol.TabIndex = 2;
            this.lblRol.Text = "Rol Asignado: ";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lblUsername.Location = new System.Drawing.Point(20, 65);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(129, 17);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Nombre de Usuario: ";
            // 
            // lblPerfilHeader
            // 
            this.lblPerfilHeader.AutoSize = true;
            this.lblPerfilHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPerfilHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.lblPerfilHeader.Location = new System.Drawing.Point(20, 20);
            this.lblPerfilHeader.Name = "lblPerfilHeader";
            this.lblPerfilHeader.Size = new System.Drawing.Size(175, 21);
            this.lblPerfilHeader.TabIndex = 0;
            this.lblPerfilHeader.Text = "Datos de Autenticación";
            // 
            // pnlCardPassword
            // 
            this.pnlCardPassword.BackColor = System.Drawing.Color.White;
            this.pnlCardPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardPassword.Controls.Add(this.btnCambiarPassword);
            this.pnlCardPassword.Controls.Add(this.txtConfirmPassword);
            this.pnlCardPassword.Controls.Add(this.lblConfirm);
            this.pnlCardPassword.Controls.Add(this.txtNewPassword);
            this.pnlCardPassword.Controls.Add(this.lblNew);
            this.pnlCardPassword.Controls.Add(this.txtCurrentPassword);
            this.pnlCardPassword.Controls.Add(this.lblCurrent);
            this.pnlCardPassword.Controls.Add(this.lblPasswordHeader);
            this.pnlCardPassword.Location = new System.Drawing.Point(470, 85);
            this.pnlCardPassword.Name = "pnlCardPassword";
            this.pnlCardPassword.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCardPassword.Size = new System.Drawing.Size(430, 310);
            this.pnlCardPassword.TabIndex = 2;
            // 
            // btnCambiarPassword
            // 
            this.btnCambiarPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnCambiarPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarPassword.FlatAppearance.BorderSize = 0;
            this.btnCambiarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCambiarPassword.ForeColor = System.Drawing.Color.White;
            this.btnCambiarPassword.Location = new System.Drawing.Point(20, 250);
            this.btnCambiarPassword.Name = "btnCambiarPassword";
            this.btnCambiarPassword.Size = new System.Drawing.Size(385, 36);
            this.btnCambiarPassword.TabIndex = 7;
            this.btnCambiarPassword.Text = "Actualizar Contraseña";
            this.btnCambiarPassword.UseVisualStyleBackColor = false;
            this.btnCambiarPassword.Click += new System.EventHandler(this.btnCambiarPassword_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(20, 205);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(385, 25);
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblConfirm.Location = new System.Drawing.Point(20, 185);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(126, 15);
            this.lblConfirm.TabIndex = 5;
            this.lblConfirm.Text = "Confirmar Contraseña:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPassword.Location = new System.Drawing.Point(20, 145);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(385, 25);
            this.txtNewPassword.TabIndex = 4;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblNew.Location = new System.Drawing.Point(20, 125);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(107, 15);
            this.lblNew.TabIndex = 3;
            this.lblNew.Text = "Nueva Contraseña:";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCurrentPassword.Location = new System.Drawing.Point(20, 85);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(385, 25);
            this.txtCurrentPassword.TabIndex = 2;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblCurrent.Location = new System.Drawing.Point(20, 65);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(107, 15);
            this.lblCurrent.TabIndex = 1;
            this.lblCurrent.Text = "Contraseña Actual:";
            // 
            // lblPasswordHeader
            // 
            this.lblPasswordHeader.AutoSize = true;
            this.lblPasswordHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPasswordHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.lblPasswordHeader.Location = new System.Drawing.Point(20, 20);
            this.lblPasswordHeader.Name = "lblPasswordHeader";
            this.lblPasswordHeader.Size = new System.Drawing.Size(161, 21);
            this.lblPasswordHeader.TabIndex = 0;
            this.lblPasswordHeader.Text = "Cambiar Contraseña";
            // 
            // UcPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlCardPassword);
            this.Controls.Add(this.pnlCardPerfil);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcPerfil";
            this.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.Size = new System.Drawing.Size(950, 600);
            this.Load += new System.EventHandler(this.UcPerfil_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCardPerfil.ResumeLayout(false);
            this.pnlCardPerfil.PerformLayout();
            this.pnlCardPassword.ResumeLayout(false);
            this.pnlCardPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlCardPerfil;
        private System.Windows.Forms.Label lblPerfilHeader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblMedicoAsignado;
        private System.Windows.Forms.Label lblUltimoAcceso;
        private System.Windows.Forms.Panel pnlCardPassword;
        private System.Windows.Forms.Label lblPasswordHeader;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnCambiarPassword;
    }
}
