using System;
using System.Windows.Forms;

namespace Forms.Modals
{
    public partial class FrmPromptModal : Form
    {
        public string InputText => txtInput.Text.Trim();

        public FrmPromptModal(string title, string prompt, string defaultVal = "")
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblPrompt.Text = prompt;
            txtInput.Text = defaultVal;
        }

        public static bool ShowPrompt(string title, string prompt, out string result, string defaultVal = "")
        {
            using (var form = new FrmPromptModal(title, prompt, defaultVal))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    result = form.InputText;
                    return true;
                }
            }
            result = string.Empty;
            return false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Por favor complete el campo requerido.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInput.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
