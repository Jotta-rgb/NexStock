using NexStock.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexStock.UI
{
	public partial class frmCategorias : Form
	{
		private readonly CategoriaApiService _categoriaService = new();

		private int? _idSelecionado = null;
		private List<Application.DTOs.CategoriaDto> _categoriasCache = new();

		public frmCategorias()
		{
			InitializeComponent();

			btnCriarCategoria.Click += btnCriarCategoria_Click;
			btnAtualizar.Click += btnAtualizar_Click;
			btnDeletar.Click += btnDeletar_Click;
			btnLimpar.Click += btnLimpar_Click;
			btnCancelar.Click += btnCancelar_Click;
			btnSair.Click += btnSair_Click;

			guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
		}

		private async void frmCategorias_Load(object sender, EventArgs e)
		{
			ConfigurarGrid();
			await CarregarCategoriasAsync();
			LimparCampos();
		}

		private void ConfigurarGrid()
		{
			guna2DataGridView1.AutoGenerateColumns = true;
			guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			guna2DataGridView1.MultiSelect = false;
			guna2DataGridView1.ReadOnly = true;
			guna2DataGridView1.AllowUserToAddRows = false;
			guna2DataGridView1.AllowUserToDeleteRows = false;
		}

		private async Task CarregarCategoriasAsync()
		{
			try
			{
				_categoriasCache = await _categoriaService.ListarCategoriasAsync();

				guna2DataGridView1.DataSource = null;
				guna2DataGridView1.DataSource = _categoriasCache;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar categorias: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void LimparCampos()
		{
			txtCorredor.Text = string.Empty;
			txtBuscarCategoria.Text = string.Empty;

			_idSelecionado = null;

			guna2DataGridView1.ClearSelection();
		}

		private bool ValidarFormulario(out string nome)
		{
			nome = txtCorredor.Text.Trim();

			if (string.IsNullOrWhiteSpace(nome))
			{
				MessageBox.Show(
					"Informe o nome da categoria.",
					"Atenção",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private int? ObterIdSelecionadoGrid()
		{
			if (guna2DataGridView1.CurrentRow == null)
				return null;

			if (guna2DataGridView1.CurrentRow.Cells["Id"]?.Value == null)
				return null;

			return Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Id"].Value);
		}

		private async void guna2DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			var id = ObterIdSelecionadoGrid();
			if (!id.HasValue)
				return;

			_idSelecionado = id.Value;

			try
			{
				var categoria = await _categoriaService.BuscarCategoriaPorIdAsync(id.Value);

				if (categoria != null)
				{
					txtCorredor.Text = categoria.Nome ?? string.Empty;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar categoria selecionada: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private async Task CriarCategoriaAsync()
		{
			try
			{
				if (!ValidarFormulario(out var nome))
					return;

				btnCriarCategoria.Enabled = false;

				var categoriaCriada = await _categoriaService.CadastrarCategoriaAsync(nome);

				if (categoriaCriada != null)
				{
					MessageBox.Show(
						"Categoria criada com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarCategoriasAsync();
					LimparCampos();
				}
				else
				{
					MessageBox.Show(
						"Não foi possível criar a categoria.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao criar categoria: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				btnCriarCategoria.Enabled = true;
			}
		}

		private async void btnCriarCategoria_Click(object? sender, EventArgs e)
		{
			await CriarCategoriaAsync();
		}

		private async void btnAtualizar_Click(object? sender, EventArgs e)
		{
			try
			{
				if (!_idSelecionado.HasValue)
				{
					MessageBox.Show(
						"Selecione uma categoria no grid para atualizar.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				if (!ValidarFormulario(out var nome))
					return;

				btnAtualizar.Enabled = false;

				var ok = await _categoriaService.AtualizarCategoriaAsync(_idSelecionado.Value, nome);

				if (ok)
				{
					MessageBox.Show(
						"Categoria atualizada com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarCategoriasAsync();
					LimparCampos();
				}
				else
				{
					MessageBox.Show(
						"Não foi possível atualizar a categoria.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao atualizar categoria: {ex.Message}",
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
						"Selecione uma categoria no grid para excluir.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				var confirmar = MessageBox.Show(
					"Deseja realmente excluir esta categoria?",
					"Confirmação",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (confirmar != DialogResult.Yes)
					return;

				btnDeletar.Enabled = false;

				var ok = await _categoriaService.ExcluirCategoriaAsync(_idSelecionado.Value);

				if (ok)
				{
					MessageBox.Show(
						"Categoria excluída com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarCategoriasAsync();
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

			guna2DataGridView1.DataSource = null;
			guna2DataGridView1.DataSource = _categoriasCache;
		}

		private void btnCancelar_Click(object? sender, EventArgs e)
		{
			LimparCampos();
		}

		private void btnPesquisar_Click(object sender, EventArgs e)
		{
			try
			{
				string termo = txtBuscarCategoria.Text.Trim();

				if (string.IsNullOrWhiteSpace(termo))
				{
					guna2DataGridView1.DataSource = null;
					guna2DataGridView1.DataSource = _categoriasCache;
					return;
				}

				var filtradas = _categoriasCache
					.Where(c => !string.IsNullOrWhiteSpace(c.Nome) &&
								c.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase))
					.ToList();

				guna2DataGridView1.DataSource = null;
				guna2DataGridView1.DataSource = filtradas;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao pesquisar categoria: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
		{
			// Evento mantido porque está vinculado no designer.
			// Se quiser busca automática enquanto digita, posso adaptar depois.
		}

		private void guna2HtmlLabel3_Click(object sender, EventArgs e)
		{
			// Evento gerado pelo designer. Pode ficar vazio.
		}

		private void btnSair_Click(object? sender, EventArgs e)
		{
			Close();
		}
	}
}



