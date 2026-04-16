using Guna.UI2.WinForms;
using NexStock.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexStock.UI
{
	public partial class frmMovimentacoes : Form
	{
		private readonly MovimentacaoApiService _movimentacaoService = new();
		private readonly ProdutoApiService _produtoService = new();
		private readonly LocalizacaoApiService _localizacaoService = new();
		private readonly CategoriaApiService _categoriaService = new();

		private int? _idSelecionado = null;
		private string _filtroAtivo = "TODOS";

		private List<Application.DTOs.MovimentacaoDto> _movimentacoesCache = new();
		private List<Application.DTOs.ProdutoDto> _produtosCache = new();
		private List<Application.DTOs.CategoriaDto> _categoriasCache = new();
		private List<Application.DTOs.LocalizacaoDto> _localizacoesCache = new();

		public frmMovimentacoes()
		{
			InitializeComponent();

			btnCriar.Click += btnCriar_Click;
			btnDeletar.Click += btnDeletar_Click;
			btnLimpar.Click += btnLimpar_Click_1;
			btnBuscar.Click += btnBuscar_Click;
			btnCancelar.Click += btnCancelar_Click;
			btnTodos.Click += btnTodos_Click;
			btnEntradas.Click += btnEntradas_Click;
			btnSaidas.Click += btnSaidas_Click;
			btnSair.Click += btnSair_Click;

			dgvMovimentacoes.CellClick += dgvMovimentacoes_CellClick;
			cboProduto.SelectedIndexChanged += cboProduto_SelectedIndexChanged;
		}

		private async void frmMovimentacoes_Load(object sender, EventArgs e)
		{
			ConfigurarGrid();
			ConfigurarComboTipo();
			await CarregarDadosBaseAsync();
			LimparCampos();
			AplicarFiltroVisual("TODOS");
			RenderizarGrid(_movimentacoesCache);
			cboProduto.DropDownWidth = cboProduto.Width;


		}

		private void ConfigurarGrid()
		{
			dgvMovimentacoes.AutoGenerateColumns = true;
			dgvMovimentacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvMovimentacoes.MultiSelect = false;
			dgvMovimentacoes.ReadOnly = true;
			dgvMovimentacoes.AllowUserToAddRows = false;
			dgvMovimentacoes.AllowUserToDeleteRows = false;
			dgvMovimentacoes.RowHeadersVisible = false;
		}

		private void ConfigurarComboTipo()
		{
			cboTipo.DataSource = null;
			cboTipo.Items.Clear();
			cboTipo.Items.Add("entrada");
			cboTipo.Items.Add("saida");
			cboTipo.SelectedIndex = -1;
		}

		private async Task CarregarDadosBaseAsync()
		{
			try
			{
				_movimentacoesCache = await _movimentacaoService.ListarMovimentacoesAsync();
				_produtosCache = await _produtoService.ListarProdutosAsync();
				_categoriasCache = await _categoriaService.ListarCategoriasAsync();
				_localizacoesCache = await _localizacaoService.ListarLocalizacoesAsync();

				cboProduto.DataSource = null;
				cboProduto.DataSource = _produtosCache;
				cboProduto.DisplayMember = "Nome";
				cboProduto.ValueMember = "Id";
				cboProduto.SelectedIndex = -1;

				cboCategoria.DataSource = null;
				cboCategoria.DataSource = _categoriasCache;
				cboCategoria.DisplayMember = "Nome";
				cboCategoria.ValueMember = "Id";
				cboCategoria.SelectedIndex = -1;

				cboLocalizacao.DataSource = null;
				cboLocalizacao.DataSource = _localizacoesCache;
				cboLocalizacao.DisplayMember = "Nome";
				cboLocalizacao.ValueMember = "Id";
				cboLocalizacao.SelectedIndex = -1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar dados da tela: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void RenderizarGrid(IEnumerable<Application.DTOs.MovimentacaoDto> lista)
		{
			var produtosPorId = _produtosCache.ToDictionary(p => p.Id, p => p);
			var categoriasPorId = _categoriasCache.ToDictionary(c => c.Id, c => c.Nome);
			var localizacoesPorId = _localizacoesCache.ToDictionary(l => l.Id, l => l.Nome);

			var dados = lista.Select(m =>
			{
				produtosPorId.TryGetValue(m.ProdutoId, out var produto);

				string nomeProduto = produto?.Nome ?? string.Empty;
				string nomeCategoria = produto != null && categoriasPorId.ContainsKey(produto.CategoriaId)
					? categoriasPorId[produto.CategoriaId]
					: string.Empty;

				string nomeLocalizacao = produto != null && localizacoesPorId.ContainsKey(produto.LocalizacaoId)
					? localizacoesPorId[produto.LocalizacaoId]
					: string.Empty;

				return new
				{
					m.Id,
					Produto = nomeProduto,
					Tipo = m.Tipo,
					Quantidade = m.Quantidade,
					Responsavel = m.Responsavel,
					NotaFiscal = m.NotaFiscal,
					Data = m.Data,
					Categoria = nomeCategoria,
					Localizacao = nomeLocalizacao
				};
			}).ToList();

			dgvMovimentacoes.DataSource = null;
			dgvMovimentacoes.DataSource = dados;

			if (dgvMovimentacoes.Columns["Id"] != null)
				dgvMovimentacoes.Columns["Id"].HeaderText = "Id";

			if (dgvMovimentacoes.Columns["Produto"] != null)
				dgvMovimentacoes.Columns["Produto"].HeaderText = "Produto";

			if (dgvMovimentacoes.Columns["Tipo"] != null)
				dgvMovimentacoes.Columns["Tipo"].HeaderText = "Tipo";

			if (dgvMovimentacoes.Columns["Quantidade"] != null)
				dgvMovimentacoes.Columns["Quantidade"].HeaderText = "Quantidade";

			if (dgvMovimentacoes.Columns["Responsavel"] != null)
				dgvMovimentacoes.Columns["Responsavel"].HeaderText = "Responsável";

			if (dgvMovimentacoes.Columns["NotaFiscal"] != null)
				dgvMovimentacoes.Columns["NotaFiscal"].HeaderText = "Nota Fiscal";

			if (dgvMovimentacoes.Columns["Data"] != null)
				dgvMovimentacoes.Columns["Data"].HeaderText = "Data";

			if (dgvMovimentacoes.Columns["Categoria"] != null)
				dgvMovimentacoes.Columns["Categoria"].HeaderText = "Categoria";

			if (dgvMovimentacoes.Columns["Localizacao"] != null)
				dgvMovimentacoes.Columns["Localizacao"].HeaderText = "Localização";

			dgvMovimentacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		}

		private void LimparCampos()
		{
			txtBuscarProduto.Text = string.Empty;
			txtNF.Text = string.Empty;
			txtResponsavel.Text = string.Empty;
			txtQuantidade.Text = string.Empty;

			cboProduto.SelectedIndex = -1;
			cboCategoria.SelectedIndex = -1;
			cboLocalizacao.SelectedIndex = -1;
			cboTipo.SelectedIndex = -1;

			dtpData.Value = DateTime.Now;

			_idSelecionado = null;
			dgvMovimentacoes.ClearSelection();
		}

		private int? ObterIdSelecionadoGrid()
		{
			if (dgvMovimentacoes.CurrentRow == null)
				return null;

			if (dgvMovimentacoes.CurrentRow.Cells["Id"]?.Value == null)
				return null;

			return Convert.ToInt32(dgvMovimentacoes.CurrentRow.Cells["Id"].Value);
		}

		private async void dgvMovimentacoes_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			var id = ObterIdSelecionadoGrid();
			if (!id.HasValue)
				return;

			_idSelecionado = id.Value;

			try
			{
				var mov = await _movimentacaoService.BuscarMovimentacaoPorIdAsync(id.Value);

				if (mov == null)
					return;

				txtNF.Text = mov.NotaFiscal ?? string.Empty;
				txtResponsavel.Text = mov.Responsavel ?? string.Empty;
				txtQuantidade.Text = mov.Quantidade.ToString();
				dtpData.Value = mov.Data == default ? DateTime.Now : mov.Data;

				cboProduto.SelectedValue = mov.ProdutoId;

				int indiceTipo = cboTipo.Items.IndexOf(mov.Tipo?.ToLower());
				cboTipo.SelectedIndex = indiceTipo;

				var produto = _produtosCache.FirstOrDefault(p => p.Id == mov.ProdutoId);
				if (produto != null)
				{
					cboCategoria.SelectedValue = produto.CategoriaId;
					cboLocalizacao.SelectedValue = produto.LocalizacaoId;
				}
				else
				{
					cboCategoria.SelectedIndex = -1;
					cboLocalizacao.SelectedIndex = -1;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar movimentação selecionada: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private bool ValidarCamposBase(
			out int produtoId,
			out string tipo,
			out int quantidade,
			out string responsavel,
			out string? notaFiscal)
		{
			produtoId = 0;
			tipo = cboTipo.SelectedItem?.ToString()?.Trim().ToLower() ?? string.Empty;
			quantidade = 0;
			responsavel = txtResponsavel.Text.Trim();
			notaFiscal = txtNF.Text.Trim();

			if (cboProduto.SelectedValue == null || !int.TryParse(cboProduto.SelectedValue.ToString(), out produtoId))
			{
				MessageBox.Show(
					"Selecione um produto.",
					"Atenção",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return false;
			}

			if (string.IsNullOrWhiteSpace(tipo))
			{
				MessageBox.Show(
					"Selecione o tipo da movimentação.",
					"Atenção",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return false;
			}

			if (!int.TryParse(txtQuantidade.Text.Trim(), out quantidade) || quantidade <= 0)
			{
				MessageBox.Show(
					"Informe uma quantidade válida maior que zero.",
					"Atenção",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return false;
			}

			if (string.IsNullOrWhiteSpace(responsavel))
			{
				MessageBox.Show(
					"Informe o nome do responsável.",
					"Atenção",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private async Task CriarMovimentacaoAsync()
		{
			try
			{
				if (!ValidarCamposBase(out var produtoId, out var tipo, out var quantidade, out var responsavel, out var notaFiscal))
					return;

				btnCriar.Enabled = false;

				var movimentacaoCriada = await _movimentacaoService.CadastrarMovimentacaoAsync(
					tipo: tipo,
					quantidade: quantidade,
					responsavel: responsavel,
					notaFiscal: notaFiscal,
					produtoId: produtoId,
					usuarioId: 1
				);

				if (movimentacaoCriada != null)
				{
					MessageBox.Show(
						"Movimentação criada com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await RecarregarTelaAsync();
					LimparCampos();
				}
				else
				{
					MessageBox.Show(
						"Não foi possível criar a movimentação.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao criar movimentação: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				btnCriar.Enabled = true;
			}
		}

		private async Task RecarregarTelaAsync()
		{
			_movimentacoesCache = await _movimentacaoService.ListarMovimentacoesAsync();
			AplicarFiltroAtual();
		}

		private void AplicarFiltroAtual()
		{
			IEnumerable<Application.DTOs.MovimentacaoDto> lista = _movimentacoesCache;

			if (_filtroAtivo == "ENTRADAS")
			{
				lista = lista.Where(m => string.Equals(m.Tipo, "entrada", StringComparison.OrdinalIgnoreCase));
			}
			else if (_filtroAtivo == "SAIDAS")
			{
				lista = lista.Where(m =>
					string.Equals(m.Tipo, "saida", StringComparison.OrdinalIgnoreCase) ||
					string.Equals(m.Tipo, "saída", StringComparison.OrdinalIgnoreCase));
			}

			string termo = txtBuscarProduto.Text.Trim();
			if (!string.IsNullOrWhiteSpace(termo))
			{
				var produtosPorId = _produtosCache.ToDictionary(p => p.Id, p => p.Nome ?? string.Empty);

				lista = lista.Where(m =>
					(!string.IsNullOrWhiteSpace(m.Responsavel) &&
					 m.Responsavel.Contains(termo, StringComparison.OrdinalIgnoreCase))
					||
					(!string.IsNullOrWhiteSpace(m.NotaFiscal) &&
					 m.NotaFiscal.Contains(termo, StringComparison.OrdinalIgnoreCase))
					||
					(produtosPorId.ContainsKey(m.ProdutoId) &&
					 produtosPorId[m.ProdutoId].Contains(termo, StringComparison.OrdinalIgnoreCase))
				);
			}

			RenderizarGrid(lista);
		}

		private void AplicarFiltroVisual(string filtro)
		{
			_filtroAtivo = filtro;

			btnTodos.FillColor = filtro == "TODOS"
				? System.Drawing.Color.FromArgb(0, 0, 64)
				: System.Drawing.Color.Silver;

			btnEntradas.FillColor = filtro == "ENTRADAS"
				? System.Drawing.Color.FromArgb(0, 0, 64)
				: System.Drawing.Color.Silver;

			btnSaidas.FillColor = filtro == "SAIDAS"
				? System.Drawing.Color.FromArgb(0, 0, 64)
				: System.Drawing.Color.Silver;
		}

		private async void btnCriar_Click(object? sender, EventArgs e)
		{
			await CriarMovimentacaoAsync();
		}

		private async void btnDeletar_Click(object? sender, EventArgs e)
		{
			try
			{
				if (!_idSelecionado.HasValue)
				{
					MessageBox.Show(
						"Selecione uma movimentação no grid para excluir.",
						"Atenção",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					return;
				}

				var confirmar = MessageBox.Show(
					"Deseja realmente excluir esta movimentação?",
					"Confirmação",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (confirmar != DialogResult.Yes)
					return;

				btnDeletar.Enabled = false;

				var ok = await _movimentacaoService.ExcluirMovimentacaoAsync(_idSelecionado.Value);

				if (ok)
				{
					MessageBox.Show(
						"Movimentação excluída com sucesso.",
						"Sucesso",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					await RecarregarTelaAsync();
					LimparCampos();
				}
				else
				{
					MessageBox.Show(
						"Não foi possível excluir a movimentação.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao excluir movimentação: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				btnDeletar.Enabled = true;
			}
		}

		private void btnLimpar_Click_1(object? sender, EventArgs e)
		{
			LimparCampos();
			AplicarFiltroVisual("TODOS");
			RenderizarGrid(_movimentacoesCache);
		}

		private void btnCancelar_Click(object? sender, EventArgs e)
		{
			LimparCampos();
		}

		private void btnBuscar_Click(object? sender, EventArgs e)
		{
			AplicarFiltroAtual();
		}

		private void btnTodos_Click(object? sender, EventArgs e)
		{
			AplicarFiltroVisual("TODOS");
			AplicarFiltroAtual();
		}

		private void btnEntradas_Click(object? sender, EventArgs e)
		{
			AplicarFiltroVisual("ENTRADAS");
			AplicarFiltroAtual();
		}

		private void btnSaidas_Click(object? sender, EventArgs e)
		{
			AplicarFiltroVisual("SAIDAS");
			AplicarFiltroAtual();
		}

		private void btnSair_Click(object? sender, EventArgs e)
		{
			Close();
		}

		private void cboProduto_SelectedIndexChanged(object? sender, EventArgs e)
		{
			try
			{
				if (cboProduto.SelectedValue == null)
					return;

				if (!int.TryParse(cboProduto.SelectedValue.ToString(), out int produtoId))
					return;

				var produto = _produtosCache.FirstOrDefault(p => p.Id == produtoId);
				if (produto == null)
					return;

				cboCategoria.SelectedValue = produto.CategoriaId;
				cboLocalizacao.SelectedValue = produto.LocalizacaoId;
			}
			catch
			{
			}
		}

		private void guna2HtmlLabel1_Click(object sender, EventArgs e) { }

		private void btnCriar_Click_1(object sender, EventArgs e)
		{

		}
	}
}


