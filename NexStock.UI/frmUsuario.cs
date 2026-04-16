using NexStock.UI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexStock.UI
{
	public partial class frmUsuario : Form
	{
		private readonly UsuarioApiService _usuarioService = new();

		private int? _idSelecionado = null;

		public frmUsuario()
		{
			InitializeComponent();

			Load += frmUsuario_Load;

			dataGridView1.CellClick += dataGridView1_CellClick;

			btnCriarUsuario.Click += btnCriarUsuario_Click;

			btnAtualizar.Click += btnAtualizar_Click;
			btnDeletar.Click += btnDeletar_Click;
			btnLimpar.Click += btnLimpar_Click;
			btnCancelar.Click += btnCancelar_Click;
			btnSair.Click += btnSair_Click;
		}

		private async void frmUsuario_Load(object? sender, EventArgs e)
		{
			await CarregarUsuariosAsync();
			ConfigurarGrid();
			LimparCampos();
		}

		private void ConfigurarGrid()
		{
			dataGridView1.AutoGenerateColumns = true;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.MultiSelect = false;
			dataGridView1.ReadOnly = true;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
		}

		private async Task CarregarUsuariosAsync()
		{
			try
			{
				var usuarios = await _usuarioService.ListarUsuariosAsync();

				dataGridView1.DataSource = null;
				dataGridView1.DataSource = usuarios;

				if (dataGridView1.Columns.Contains("Perfil"))
				{
					dataGridView1.Columns["Perfil"].Visible = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar usuários: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}



		private void LimparCampos()
		{
			txtEmail.Text = string.Empty;
			txtSenha.Text = string.Empty;

			_idSelecionado = null;

			dataGridView1.ClearSelection();
		}

		private int? ObterIdSelecionadoGrid()
		{
			if (dataGridView1.CurrentRow == null)
				return null;

			if (dataGridView1.CurrentRow.Cells["Id"]?.Value == null)
				return null;

			return Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
		}

		private async void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			var id = ObterIdSelecionadoGrid();
			if (!id.HasValue)
				return;

			_idSelecionado = id.Value;

			try
			{
				var usuario = await _usuarioService.BuscarUsuarioPorIdAsync(id.Value);

				if (usuario != null)
				{
					txtEmail.Text = usuario.Email ?? string.Empty;

					// Por segurança, não carregamos senha existente.
					txtSenha.Text = string.Empty;
					txtSenha.PlaceholderText = "Digite nova senha se necessário";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar usuário selecionado: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private async void btnCriarUsuario_Click(object? sender, EventArgs e)
		{
			await CriarUsuarioAsync();
		}

		private async void btnAdicionar_Click(object? sender, EventArgs e)
		{
			await CriarUsuarioAsync();
		}

		private async Task CriarUsuarioAsync()
		{
			try
			{
				string email = txtEmail.Text.Trim();
				string senha = txtSenha.Text.Trim();

				if (string.IsNullOrWhiteSpace(email))
				{
					MessageBox.Show(
						"Informe o e-mail do usuário.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				if (string.IsNullOrWhiteSpace(senha))
				{
					MessageBox.Show(
						"Informe a senha do usuário.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				if (senha.Length < 6)
				{
					MessageBox.Show(
						"A senha deve ter no mínimo 6 caracteres.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				btnCriarUsuario.Enabled = false;


				var usuarioCriado = await _usuarioService.CadastrarUsuarioAsync(email, senha);

				if (usuarioCriado != null)
				{
					MessageBox.Show(
						"Usuário criado com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarUsuariosAsync();
					LimparCampos();
				}
				else
				{
					MessageBox.Show(
						"Não foi possível criar o usuário.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao criar usuário: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				btnCriarUsuario.Enabled = true;

			}
		}

		private async void btnAtualizar_Click(object? sender, EventArgs e)
		{
			try
			{
				if (!_idSelecionado.HasValue)
				{
					MessageBox.Show(
						"Selecione um usuário no grid para atualizar.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				string email = txtEmail.Text.Trim();

				if (string.IsNullOrWhiteSpace(email))
				{
					MessageBox.Show(
						"Informe o e-mail do usuário.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				btnAtualizar.Enabled = false;

				var dto = new Application.DTOs.AtualizarUsuarioDto
				{
					Email = email
				};

				var ok = await _usuarioService.AtualizarUsuarioAsync(_idSelecionado.Value, dto);

				if (ok)
				{
					MessageBox.Show(
						"Usuário atualizado com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarUsuariosAsync();
					LimparCampos();
				}
				else
				{
					MessageBox.Show(
						"Não foi possível atualizar o usuário.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao atualizar usuário: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				btnAtualizar.Enabled = true;
			}
		}

		private async void btnDeletar_Click(object? sender, EventArgs e)
		{
			try
			{
				if (!_idSelecionado.HasValue)
				{
					MessageBox.Show(
						"Selecione um usuário no grid para excluir.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				var confirmacao = MessageBox.Show(
					"Tem certeza que deseja excluir este usuário?",
					"Confirmar exclusão",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (confirmacao != DialogResult.Yes)
					return;

				btnDeletar.Enabled = false;

				var ok = await _usuarioService.ExcluirUsuarioAsync(_idSelecionado.Value);

				if (ok)
				{
					MessageBox.Show(
						"Usuário excluído com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarUsuariosAsync();
					LimparCampos();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Operação não permitida",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
			}
			finally
			{
				btnDeletar.Enabled = true;
			}
		}




		private void btnLimpar_Click(object? sender, EventArgs e)
		{
			LimparCampos();
		}

		private void btnCancelar_Click(object? sender, EventArgs e)
		{
			LimparCampos();
		}

		private void btnSair_Click(object? sender, EventArgs e)
		{
			Close();
		}

		private void txtSenha_TextChanged(object sender, EventArgs e)
		{

		}
	}
}



