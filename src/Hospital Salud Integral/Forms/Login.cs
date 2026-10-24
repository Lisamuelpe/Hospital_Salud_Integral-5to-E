using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Forms.Models;
using Forms.Services;

namespace Forms
{
    public partial class Login : Form
    {
        // Soporte para arrastrar la ventana sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("Por favor ingrese su usuario y contraseña.");
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Validando...";
            Cursor = Cursors.WaitCursor;

            try
            {
                if (AuthService.ValidateLogin(username, password, out Usuario usuario, out string errorMsg))
                {
                    // Éxito: Abrir formulario principal
                    var mainForm = new Main();
                    mainForm.FormClosed += (s, args) =>
                    {
                        // Cuando Main se cierra por logout, limpiamos campos y mostramos Login de nuevo
                        txtPassword.Clear();
                        lblError.Visible = false;
                        btnLogin.Enabled = true;
                        btnLogin.Text = "Iniciar Sesión";
                        this.Show();
                        txtUsername.Focus();
                    };

                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    ShowError(errorMsg);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Iniciar Sesión";
                Cursor = Cursors.Default;
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
