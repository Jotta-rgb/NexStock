
using NexStock.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexStock.UI
{
	public partial class frmProdutos : Form
	{
		private readonly ProdutoApiService _produtoService = new();
		private readonly CategoriaApiService _categoriaService = new();
		private readonly LocalizacaoApiService _localizacaoService = new();

		private int? _idSelecionado = null;
		private List<Application.DTOs.ProdutoDto> _produtosCache = new();

		public frmProdutos()
		{
			InitializeComponent();

			Load += frmProdutos_Load;

			dgvProdutos.CellClick += dgvProdutos_CellClick;

			btnBuscarProduto.Click += btnBuscarProduto_Click;

			btnAtualizar.Click += btnAtualizar_Click;
			btnDeletar.Click += btnDeletar_Click;
			btnLimpar.Click += btnLimpar_Click;
			btnSairProdutos.Click += btnSairProdutos_Click;

			guna2Button2.Click += guna2Button2_Click; // Filtrar Estoque Mínimo
			guna2Button3.Click += guna2Button3_Click; // Criar
			guna2Button4.Click += guna2Button4_Click; // Cancelar
		}

		private async void frmProdutos_Load(object? sender, EventArgs e)
		{
			ConfigurarGrid();
			await CarregarCombosAsync();
			await CarregarProdutosAsync();
			LimparCampos();
		}

		private void ConfigurarGrid()
		{
			dgvProdutos.AutoGenerateColumns = false;
			dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvProdutos.MultiSelect = false;
			dgvProdutos.ReadOnly = true;
			dgvProdutos.AllowUserToAddRows = false;
			dgvProdutos.AllowUserToDeleteRows = false;
			dgvProdutos.RowHeadersVisible = false;
		}



		//private void ConfigurarGrid()
		//{
		//	dgvProdutos.AutoGenerateColumns = true;
		//	dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		//	dgvProdutos.MultiSelect = false;
		//	dgvProdutos.ReadOnly = true;
		//	dgvProdutos.AllowUserToAddRows = false;
		//	dgvProdutos.AllowUserToDeleteRows = false;
		//}

		private async Task CarregarCombosAsync()
		{
			try
			{
				var categorias = await _categoriaService.ListarCategoriasAsync();
				cbo.DataSource = null;
				cbo.DataSource = categorias;
				cbo.DisplayMember = "Nome";
				cbo.ValueMember = "Id";
				cbo.SelectedIndex = -1;

				var localizacoes = await _localizacaoService.ListarLocalizacoesAsync();
				guna2ComboBox2.DataSource = null;
				guna2ComboBox2.DataSource = localizacoes;
				guna2ComboBox2.DisplayMember = "Nome";
				guna2ComboBox2.ValueMember = "Id";
				guna2ComboBox2.SelectedIndex = -1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar categorias/localizações: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private async Task CarregarProdutosAsync()
		{
			try
			{
				_produtosCache = await _produtoService.ListarProdutosAsync();

				dgvProdutos.DataSource = null;
				dgvProdutos.DataSource = _produtosCache;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar produtos: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}



		//private async Task CarregarProdutosAsync()
		//{
		//	try
		//	{
		//		dgvProdutos.AutoGenerateColumns = false;

		//		_produtosCache = await _produtoService.ListarProdutosAsync();

		//		dgvProdutos.DataSource = null;
		//		dgvProdutos.DataSource = _produtosCache;
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show(
		//			$"Erro ao carregar produtos: {ex.Message}",
		//			"Erro",
		//			MessageBoxButtons.OK,
		//			MessageBoxIcon.Error);
		//	}
		//}


		private void LimparCampos()
		{
			txtNomeProduto.Text = string.Empty;
			txtUnidadeProduto.Text = string.Empty;
			txtQuantidadeProduto.Text = string.Empty;
			txtEstoqueProduto.Text = string.Empty;
			txtBuscarNomeProduto.Text = string.Empty;

			cbo.SelectedIndex = -1;
			guna2ComboBox2.SelectedIndex = -1;

			_idSelecionado = null;
			dgvProdutos.ClearSelection();
		}

		private int? ObterIdSelecionadoGrid()
		{
			if (dgvProdutos.CurrentRow == null)
				return null;

			if (dgvProdutos.CurrentRow.Cells["colId"]?.Value == null)
				return null;

			return Convert.ToInt32(dgvProdutos.CurrentRow.Cells["colId"].Value);
		}

		private async void dgvProdutos_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			var id = ObterIdSelecionadoGrid();
			if (!id.HasValue)
				return;

			_idSelecionado = id.Value;

			try
			{
				var produto = await _produtoService.BuscarProdutoPorIdAsync(id.Value);

				if (produto != null)
				{
					txtNomeProduto.Text = produto.Nome;
					txtUnidadeProduto.Text = produto.Unidade;
					txtQuantidadeProduto.Text = produto.Quantidade.ToString();
					txtEstoqueProduto.Text = produto.EstoqueMinimo.ToString();

					cbo.SelectedValue = produto.CategoriaId;
					guna2ComboBox2.SelectedValue = produto.LocalizacaoId;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar produto selecionado: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private bool ValidarFormulario(out string nome, out string unidade, out int quantidade, out int estoqueMinimo, out int categoriaId, out int localizacaoId)
		{
			nome = txtNomeProduto.Text.Trim();
			unidade = txtUnidadeProduto.Text.Trim();
			quantidade = 0;
			estoqueMinimo = 0;
			categoriaId = 0;
			localizacaoId = 0;

			if (string.IsNullOrWhiteSpace(nome))
			{
				MessageBox.Show("Informe o nome do produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (string.IsNullOrWhiteSpace(unidade))
			{
				MessageBox.Show("Informe a unidade do produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (!int.TryParse(txtQuantidadeProduto.Text.Trim(), out quantidade) || quantidade < 0)
			{
				MessageBox.Show("Informe uma quantidade válida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (!int.TryParse(txtEstoqueProduto.Text.Trim(), out estoqueMinimo) || estoqueMinimo < 0)
			{
				MessageBox.Show("Informe um estoque mínimo válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (cbo.SelectedValue == null || !int.TryParse(cbo.SelectedValue.ToString(), out categoriaId))
			{
				MessageBox.Show("Selecione uma categoria.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (guna2ComboBox2.SelectedValue == null || !int.TryParse(guna2ComboBox2.SelectedValue.ToString(), out localizacaoId))
			{
				MessageBox.Show("Selecione uma localização.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private async Task CriarProdutoAsync()
		{
			try
			{
				if (!ValidarFormulario(out var nome, out var unidade, out var quantidade, out var estoqueMinimo, out var categoriaId, out var localizacaoId))
					return;


				guna2Button3.Enabled = false;

				var produto = await _produtoService.CadastrarProdutoAsync(
					nome,
					unidade,
					quantidade,
					estoqueMinimo,
					categoriaId,
					localizacaoId);

				if (produto != null)
				{
					MessageBox.Show(
						"Produto criado com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarProdutosAsync();
					LimparCampos();
				}
				else
				{
					MessageBox.Show(
						"Não foi possível criar o produto.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao criar produto: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{

				guna2Button3.Enabled = true;
			}
		}

		private async void btnAdicionar_Click(object? sender, EventArgs e)
		{
			await CriarProdutoAsync();
		}

		private async void guna2Button3_Click(object? sender, EventArgs e)
		{
			await CriarProdutoAsync();
		}

		private async void btnAtualizar_Click(object? sender, EventArgs e)
		{
			try
			{
				if (!_idSelecionado.HasValue)
				{
					MessageBox.Show(
						"Selecione um produto no grid para atualizar.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				if (!ValidarFormulario(out var nome, out var unidade, out var quantidade, out var estoqueMinimo, out var categoriaId, out var localizacaoId))
					return;

				btnAtualizar.Enabled = false;

				var dto = new Application.DTOs.AtualizarProdutoDto
				{
					Nome = nome,
					Unidade = unidade,
					Quantidade = quantidade,
					EstoqueMinimo = estoqueMinimo,
					CategoriaId = categoriaId,
					LocalizacaoId = localizacaoId
				};

				var ok = await _produtoService.AtualizarProdutoAsync(_idSelecionado.Value, dto);

				if (ok)
				{
					MessageBox.Show(
						"Produto atualizado com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarProdutosAsync();
					LimparCampos();
				}
				else
				{
					MessageBox.Show(
						"Não foi possível atualizar o produto.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao atualizar produto: {ex.Message}",
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
						"Selecione um produto no grid para excluir.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				var confirmar = MessageBox.Show(
					"Deseja realmente excluir este produto?",
					"Confirmação",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (confirmar != DialogResult.Yes)
					return;

				btnDeletar.Enabled = false;

				var ok = await _produtoService.ExcluirProdutoAsync(_idSelecionado.Value);

				if (ok)
				{
					MessageBox.Show(
						"Produto excluído com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await CarregarProdutosAsync();
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



		private async void btnBuscarProduto_Click(object? sender, EventArgs e)
		{
			try
			{
				string termo = txtBuscarNomeProduto.Text.Trim();

				if (string.IsNullOrWhiteSpace(termo))
				{
					dgvProdutos.DataSource = null;
					dgvProdutos.DataSource = _produtosCache;
					return;
				}

				var filtrados = _produtosCache
					.Where(p => !string.IsNullOrWhiteSpace(p.Nome) &&
								p.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase))
					.ToList();

				dgvProdutos.DataSource = null;
				dgvProdutos.DataSource = filtrados;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao buscar produtos: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void guna2Button2_Click(object? sender, EventArgs e)
		{
			try
			{
				var filtrados = _produtosCache
					.Where(p => p.Quantidade <= p.EstoqueMinimo)
					.ToList();

				dgvProdutos.DataSource = null;
				dgvProdutos.DataSource = filtrados;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao filtrar estoque mínimo: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void btnLimpar_Click(object? sender, EventArgs e)
		{
			LimparCampos();
			dgvProdutos.DataSource = null;
			dgvProdutos.DataSource = _produtosCache;
		}

		private void guna2Button4_Click(object? sender, EventArgs e)
		{
			LimparCampos();
		}

		private void btnSairProdutos_Click(object? sender, EventArgs e)
		{
			Close();
		}

		private void btnBuscarProduto_Click_1(object sender, EventArgs e)
		{

		}

		private void guna2Button2_Click_1(object sender, EventArgs e)
		{

		}

		private void guna2Button3_Click_1(object sender, EventArgs e)
		{

		}
	}
}




