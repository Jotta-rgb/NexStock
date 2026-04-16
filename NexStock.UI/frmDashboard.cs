using NexStock.UI.Service.Models;
using NexStock.UI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexStock.UI
{
	public partial class frmDashboard : Form
	{
		private readonly DashboardApiService _dashboardService = new();

		private DashboardDto? _dashboardCache = null;

		public frmDashboard()
		{
			InitializeComponent();

			Load += frmDashboard_Load;
			btnAtualizarDashboard.Click += btnAtualizarDashboard_Click;
		}

		private async void frmDashboard_Load(object? sender, EventArgs e)
		{
			ConfigurarGridEstoqueMinimo();
			ConfigurarGridProdutosMaisSaida();

			await CarregarDashboardAsync();
		}

		private void ConfigurarGridEstoqueMinimo()
		{
			dgvProdutosEstoqueMinimo.AutoGenerateColumns = false;
			dgvProdutosEstoqueMinimo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvProdutosEstoqueMinimo.MultiSelect = false;
			dgvProdutosEstoqueMinimo.ReadOnly = true;
			dgvProdutosEstoqueMinimo.AllowUserToAddRows = false;
			dgvProdutosEstoqueMinimo.AllowUserToDeleteRows = false;
			dgvProdutosEstoqueMinimo.RowHeadersVisible = false;
			dgvProdutosEstoqueMinimo.Columns.Clear();

			dgvProdutosEstoqueMinimo.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Nome",
				HeaderText = "Produto",
				DataPropertyName = "Nome",
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
			});

			dgvProdutosEstoqueMinimo.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Quantidade",
				HeaderText = "Quantidade",
				DataPropertyName = "Quantidade",
				Width = 90
			});

			dgvProdutosEstoqueMinimo.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "EstoqueMinimo",
				HeaderText = "Estoque Mínimo",
				DataPropertyName = "EstoqueMinimo",
				Width = 120
			});

			dgvProdutosEstoqueMinimo.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "CategoriaId",
				HeaderText = "Categoria",
				DataPropertyName = "CategoriaId",
				Width = 90
			});

			dgvProdutosEstoqueMinimo.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "LocalizacaoId",
				HeaderText = "Localização",
				DataPropertyName = "LocalizacaoId",
				Width = 100
			});
		}

		private void ConfigurarGridProdutosMaisSaida()
		{
			dgvProdutosMaisSaida.AutoGenerateColumns = false;
			dgvProdutosMaisSaida.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvProdutosMaisSaida.MultiSelect = false;
			dgvProdutosMaisSaida.ReadOnly = true;
			dgvProdutosMaisSaida.AllowUserToAddRows = false;
			dgvProdutosMaisSaida.AllowUserToDeleteRows = false;
			dgvProdutosMaisSaida.RowHeadersVisible = false;
			dgvProdutosMaisSaida.Columns.Clear();

			dgvProdutosMaisSaida.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Nome",
				HeaderText = "Produto",
				DataPropertyName = "Nome",
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
			});

			dgvProdutosMaisSaida.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Quantidade",
				HeaderText = "Quantidade",
				DataPropertyName = "Quantidade",
				Width = 90
			});

			dgvProdutosMaisSaida.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "CategoriaId",
				HeaderText = "Categoria",
				DataPropertyName = "CategoriaId",
				Width = 90
			});

			dgvProdutosMaisSaida.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "LocalizacaoId",
				HeaderText = "Localização",
				DataPropertyName = "LocalizacaoId",
				Width = 100
			});
		}

		private async Task CarregarDashboardAsync()
		{
			try
			{
				btnAtualizarDashboard.Enabled = false;

				var dashboard = await _dashboardService.ObterDashboardAsync();

				if (dashboard == null)
				{
					MessageBox.Show(
						"Não foi possível carregar os dados do dashboard.",
						"Erro",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					LimparDashboard();
					return;
				}

				_dashboardCache = dashboard;

				PreencherCards(dashboard);
				PreencherGridEstoqueMinimo(dashboard.ProdutosEstoqueMinimo);
				PreencherGridProdutosMaisSaida(dashboard.ProdutosMaisSaida);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Erro ao carregar dashboard: {ex.Message}",
					"Erro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				LimparDashboard();
			}
			finally
			{
				btnAtualizarDashboard.Enabled = true;
			}
		}

		private void PreencherCards(DashboardDto dashboard)
		{
			lblTotalProdutos.Text = dashboard.TotalProdutos.ToString();
			lblTotalEstoqueMinimo.Text = dashboard.TotalProdutosEstoqueMinimo.ToString();
			lblTotalSemEstoque.Text = dashboard.TotalProdutosSemEstoque.ToString();
		}

		private void PreencherGridEstoqueMinimo(List<ProdutoDto> produtos)
		{
			dgvProdutosEstoqueMinimo.DataSource = null;
			dgvProdutosEstoqueMinimo.DataSource = produtos ?? new List<ProdutoDto>();
		}

		private void PreencherGridProdutosMaisSaida(List<ProdutoDto> produtos)
		{
			dgvProdutosMaisSaida.DataSource = null;
			dgvProdutosMaisSaida.DataSource = produtos ?? new List<ProdutoDto>();
		}

		private void LimparDashboard()
		{
			lblTotalProdutos.Text = "0";
			lblTotalEstoqueMinimo.Text = "0";
			lblTotalSemEstoque.Text = "0";

			dgvProdutosEstoqueMinimo.DataSource = null;
			dgvProdutosMaisSaida.DataSource = null;

			_dashboardCache = null;
		}

		private async void btnAtualizarDashboard_Click(object? sender, EventArgs e)
		{
			await CarregarDashboardAsync();
		}

		private void btnSair_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}




