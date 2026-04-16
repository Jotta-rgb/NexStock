using NexStock.UI.Services;
using System;
using System.Windows.Forms;

namespace NexStock.UI
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioApiService _usuarioService = new();

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                btnEntrar.Enabled = false;
                btnEntrar.Text = "Entrando...";

                string email = txtEmail.Text.Trim();
                string senha = txtSenha.Text.Trim();

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                {
                    MessageBox.Show(
                        "Preencha e-mail e senha.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var resultado = await _usuarioService.LoginAsync(email, senha);

                if (resultado == null)
                {
                    MessageBox.Show(
                        "E-mail ou senha inválidos.",
                        "Falha no login",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var principal = new frmPrincipal();
                principal.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao realizar login: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnEntrar.Enabled = true;
                btnEntrar.Text = "Entrar";
            }
        }
    }
}

