using NexStock.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexStock.UI
{
	public partial class frmLocalizacoes : Form
	{
		private readonly LocalizacaoApiService _localizacaoService = new();

		private int? _idSelecionado = null;
		private List<Application.DTOs.LocalizacaoDto> _localizacoesCache = new();

		public frmLocalizacoes()
		{
			InitializeComponent();
		}

		private async void frmLocalizacoes_Load_1(object sender, EventArgs e)
		{
			ConfigurarGrid();
			await CarregarLocalizacoesAsync();
			LimparCampos();
		}

		private void ConfigurarGrid()
		{
			dgvLocalizacoes.AutoGenerateColumns = false;
			dgvLocalizacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvLocalizacoes.MultiSelect = false;
			dgvLocalizacoes.ReadOnly = true;
			dgvLocalizacoes.AllowUserToAddRows = false;
			dgvLocalizacoes.AllowUserToDeleteRows = false;
		}



		private async Task CarregarLocalizacoesAsync()
		{
			try
			{
				_localizacoesCache = await _localizacaoService.ListarLocalizacoesAsync();

				dgvLocalizacoes.DataSource = null;
				dgvLocalizacoes.DataSource = _localizacoesCache;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar localizações: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void LimparCampos()
		{
			txtCorredor.Text = string.Empty;
			txtBuscarLocalizaco.Text = string.Empty;

			_idSelecionado = null;

			dgvLocalizacoes.ClearSelection();
		}

		private bool ValidarFormulario(out string nome)
		{
			nome = txtCorredor.Text.Trim();

			if (string.IsNullOrWhiteSpace(nome))
			{
				MessageBox.Show(
					"Informe o nome da localização.",
					"Atenção",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private int? ObterIdSelecionadoGrid()
		{
			if (dgvLocalizacoes.CurrentRow == null)
				return null;

			if (dgvLocalizacoes.CurrentRow.Cells["Id"]?.Value == null)
				return null;

			return Convert.ToInt32(dgvLocalizacoes.CurrentRow.Cells["Id"].Value);
		}

		private async void dgvLocalizacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			var id = ObterIdSelecionadoGrid();
			if (!id.HasValue)
				return;

			_idSelecionado = id.Value;

			try
			{
				var localizacao = await _localizacaoService.BuscarLocalizacaoPorIdAsync(id.Value);

				if (localizacao != null)
				{
					txtCorredor.Text = localizacao.Nome ?? string.Empty;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar localização selecionada: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private async Task CriarLocalizacaoAsync()
		{
			try
			{
				if (!ValidarFormulario(out var nome))
					return;

				btnCriar.Enabled = false;

				var localizacaoCriada = await _localizacaoService.CadastrarLocalizacaoAsync(nome);

				if (localizacaoCriada != null)
				{
					MessageBox.Show(
						"Localização criada com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarLocalizacoesAsync();
					LimparCampos();
				}
				else
				{
					MessageBox.Show(
						"Não foi possível criar a localização.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao criar localização: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				btnCriar.Enabled = true;
			}
		}

		private async void btnCriar_Click_1(object sender, EventArgs e)
		{
			await CriarLocalizacaoAsync();
		}

		private async void btnAtualizar_Click_1(object sender, EventArgs e)
		{
			try
			{
				if (!_idSelecionado.HasValue)
				{
					MessageBox.Show(
						"Selecione uma localização no grid para atualizar.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				if (!ValidarFormulario(out var nome))
					return;

				btnAtualizar.Enabled = false;

				var ok = await _localizacaoService.AtualizarLocalizacaoAsync(_idSelecionado.Value, nome);

				if (ok)
				{
					MessageBox.Show(
						"Localização atualizada com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarLocalizacoesAsync();
					LimparCampos();
				}
				else
				{
					MessageBox.Show(
						"Não foi possível atualizar a localização.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao atualizar localização: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				btnAtualizar.Enabled = true;
			}
		}

		private async void btnDeletar_Click(object sender, EventArgs e)
		{
			try
			{
				if (!_idSelecionado.HasValue)
				{
					MessageBox.Show(
						"Selecione uma localização no grid para excluir.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				var confirmar = MessageBox.Show(
					"Deseja realmente excluir esta localização?",
					"Confirmação",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (confirmar != DialogResult.Yes)
					return;

				btnDeletar.Enabled = false;

				var ok = await _localizacaoService.ExcluirLocalizacaoAsync(_idSelecionado.Value);

				if (ok)
				{
					MessageBox.Show(
						"Localização excluída com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarLocalizacoesAsync();
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


		private void btnLimpar_Click(object sender, EventArgs e)
		{
			LimparCampos();

			dgvLocalizacoes.DataSource = null;
			dgvLocalizacoes.DataSource = _localizacoesCache;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			LimparCampos();
		}

		private void btnPesquisar_Click_1(object sender, EventArgs e)
		{
			try
			{
				string termo = txtBuscarLocalizaco.Text.Trim();

				if (string.IsNullOrWhiteSpace(termo))
				{
					dgvLocalizacoes.DataSource = null;
					dgvLocalizacoes.DataSource = _localizacoesCache;
					return;
				}

				var filtradas = _localizacoesCache
					.Where(l => !string.IsNullOrWhiteSpace(l.Nome) &&
								l.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase))
					.ToList();

				dgvLocalizacoes.DataSource = null;
				dgvLocalizacoes.DataSource = filtradas;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao pesquisar localização: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void txtBuscarLocalizaco_TextChanged(object sender, EventArgs e)
		{
			// Opcional: deixar vazio por enquanto.
			// Se quiser busca automática enquanto digita, depois posso adaptar.
		}

		private void label1_Click(object sender, EventArgs e)
		{
			// Evento gerado pelo designer. Pode ficar vazio.
		}

		private void btnSair_Click(object? sender, EventArgs e)
		{
			Close();
		}
	}
}



