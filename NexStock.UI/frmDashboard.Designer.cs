namespace NexStock.UI
{
	partial class frmDashboard
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			colMinNome = new DataGridViewTextBoxColumn();
			colMinQuantidade = new DataGridViewTextBoxColumn();
			colMinEstoqueMinimo = new DataGridViewTextBoxColumn();
			colMinCategoriaId = new DataGridViewTextBoxColumn();
			colMinLocalizacaoId = new DataGridViewTextBoxColumn();
			colSaidaNome = new DataGridViewTextBoxColumn();
			colSaidaQuantidade = new DataGridViewTextBoxColumn();
			colSaidaCategoriaId = new DataGridViewTextBoxColumn();
			colSaidaLocalizacaoId = new DataGridViewTextBoxColumn();
			btnSair = new Guna.UI2.WinForms.Guna2Button();
			lblDashboardEstoque = new Guna.UI2.WinForms.Guna2HtmlLabel();
			guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
			lblTotalProdutos = new Guna.UI2.WinForms.Guna2HtmlLabel();
			lblTituloTotalProdutos = new Guna.UI2.WinForms.Guna2HtmlLabel();
			guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
			lblTotalEstoqueMinimo = new Guna.UI2.WinForms.Guna2HtmlLabel();
			guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			lblEstoque = new Guna.UI2.WinForms.Guna2HtmlLabel();
			guna2CustomGradientPanel3 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
			lblTotalSemEstoque = new Guna.UI2.WinForms.Guna2HtmlLabel();
			guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			lblSemEstoque = new Guna.UI2.WinForms.Guna2HtmlLabel();
			grpProdutosMinimo = new Guna.UI2.WinForms.Guna2GroupBox();
			dgvProdutosEstoqueMinimo = new Guna.UI2.WinForms.Guna2DataGridView();
			grpProdutosSaidas = new Guna.UI2.WinForms.Guna2GroupBox();
			dgvProdutosMaisSaida = new Guna.UI2.WinForms.Guna2DataGridView();
			btnAtualizarDashboard = new Guna.UI2.WinForms.Guna2Button();
			guna2CustomGradientPanel1.SuspendLayout();
			guna2CustomGradientPanel2.SuspendLayout();
			guna2CustomGradientPanel3.SuspendLayout();
			grpProdutosMinimo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvProdutosEstoqueMinimo).BeginInit();
			grpProdutosSaidas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvProdutosMaisSaida).BeginInit();
			SuspendLayout();
			// 
			// colMinNome
			// 
			colMinNome.DataPropertyName = "Nome";
			colMinNome.HeaderText = "Produto";
			colMinNome.Name = "colMinNome";
			colMinNome.ReadOnly = true;
			// 
			// colMinQuantidade
			// 
			colMinQuantidade.DataPropertyName = "Quantidade";
			colMinQuantidade.HeaderText = "Quantidade";
			colMinQuantidade.Name = "colMinQuantidade";
			colMinQuantidade.ReadOnly = true;
			// 
			// colMinEstoqueMinimo
			// 
			colMinEstoqueMinimo.DataPropertyName = "EstoqueMinimo";
			colMinEstoqueMinimo.HeaderText = "Estoque Mínimo";
			colMinEstoqueMinimo.Name = "colMinEstoqueMinimo";
			colMinEstoqueMinimo.ReadOnly = true;
			// 
			// colMinCategoriaId
			// 
			colMinCategoriaId.DataPropertyName = "CategoriaId";
			colMinCategoriaId.HeaderText = "Categoria";
			colMinCategoriaId.Name = "colMinCategoriaId";
			colMinCategoriaId.ReadOnly = true;
			// 
			// colMinLocalizacaoId
			// 
			colMinLocalizacaoId.DataPropertyName = "LocalizacaoId";
			colMinLocalizacaoId.HeaderText = "Localização";
			colMinLocalizacaoId.Name = "colMinLocalizacaoId";
			colMinLocalizacaoId.ReadOnly = true;
			// 
			// colSaidaNome
			// 
			colSaidaNome.DataPropertyName = "Nome";
			colSaidaNome.HeaderText = "Produto";
			colSaidaNome.Name = "colSaidaNome";
			colSaidaNome.ReadOnly = true;
			// 
			// colSaidaQuantidade
			// 
			colSaidaQuantidade.DataPropertyName = "Quantidade";
			colSaidaQuantidade.HeaderText = "Quantidade";
			colSaidaQuantidade.Name = "colSaidaQuantidade";
			colSaidaQuantidade.ReadOnly = true;
			// 
			// colSaidaCategoriaId
			// 
			colSaidaCategoriaId.DataPropertyName = "CategoriaId";
			colSaidaCategoriaId.HeaderText = "Categoria";
			colSaidaCategoriaId.Name = "colSaidaCategoriaId";
			colSaidaCategoriaId.ReadOnly = true;
			// 
			// colSaidaLocalizacaoId
			// 
			colSaidaLocalizacaoId.DataPropertyName = "LocalizacaoId";
			colSaidaLocalizacaoId.HeaderText = "Localização";
			colSaidaLocalizacaoId.Name = "colSaidaLocalizacaoId";
			colSaidaLocalizacaoId.ReadOnly = true;
			// 
			// btnSair
			// 
			btnSair.BackColor = Color.Transparent;
			btnSair.BorderRadius = 8;
			btnSair.CustomizableEdges = customizableEdges1;
			btnSair.DisabledState.BorderColor = Color.DarkGray;
			btnSair.DisabledState.CustomBorderColor = Color.DarkGray;
			btnSair.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			btnSair.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			btnSair.FillColor = Color.Transparent;
			btnSair.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnSair.ForeColor = Color.DimGray;
			btnSair.Location = new Point(17, 12);
			btnSair.Name = "btnSair";
			btnSair.ShadowDecoration.CustomizableEdges = customizableEdges2;
			btnSair.Size = new Size(78, 35);
			btnSair.TabIndex = 8;
			btnSair.Text = "⬅️ Sair";
			btnSair.Click += btnSair_Click;
			// 
			// lblDashboardEstoque
			// 
			lblDashboardEstoque.BackColor = Color.Transparent;
			lblDashboardEstoque.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDashboardEstoque.Location = new Point(140, 23);
			lblDashboardEstoque.Name = "lblDashboardEstoque";
			lblDashboardEstoque.Size = new Size(374, 49);
			lblDashboardEstoque.TabIndex = 1;
			lblDashboardEstoque.Text = "Dashboard de Estoque";
			// 
			// guna2CustomGradientPanel1
			// 
			guna2CustomGradientPanel1.BorderRadius = 10;
			guna2CustomGradientPanel1.Controls.Add(lblTotalProdutos);
			guna2CustomGradientPanel1.Controls.Add(lblTituloTotalProdutos);
			guna2CustomGradientPanel1.CustomizableEdges = customizableEdges3;
			guna2CustomGradientPanel1.FillColor = Color.FromArgb(59, 130, 246);
			guna2CustomGradientPanel1.FillColor2 = Color.FromArgb(59, 130, 246);
			guna2CustomGradientPanel1.FillColor3 = Color.FromArgb(59, 130, 246);
			guna2CustomGradientPanel1.FillColor4 = Color.FromArgb(59, 130, 246);
			guna2CustomGradientPanel1.Location = new Point(30, 90);
			guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
			guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
			guna2CustomGradientPanel1.Size = new Size(320, 100);
			guna2CustomGradientPanel1.TabIndex = 2;
			// 
			// lblTotalProdutos
			// 
			lblTotalProdutos.BackColor = Color.Transparent;
			lblTotalProdutos.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTotalProdutos.ForeColor = Color.White;
			lblTotalProdutos.Location = new Point(110, 34);
			lblTotalProdutos.Name = "lblTotalProdutos";
			lblTotalProdutos.Size = new Size(23, 49);
			lblTotalProdutos.TabIndex = 1;
			lblTotalProdutos.Text = "0";
			// 
			// lblTituloTotalProdutos
			// 
			lblTituloTotalProdutos.BackColor = Color.Transparent;
			lblTituloTotalProdutos.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTituloTotalProdutos.ForeColor = Color.White;
			lblTituloTotalProdutos.Location = new Point(110, 17);
			lblTituloTotalProdutos.Name = "lblTituloTotalProdutos";
			lblTituloTotalProdutos.Size = new Size(128, 22);
			lblTituloTotalProdutos.TabIndex = 0;
			lblTituloTotalProdutos.Text = "Total de Produtos";
			// 
			// guna2CustomGradientPanel2
			// 
			guna2CustomGradientPanel2.BorderRadius = 10;
			guna2CustomGradientPanel2.Controls.Add(lblTotalEstoqueMinimo);
			guna2CustomGradientPanel2.Controls.Add(guna2HtmlLabel1);
			guna2CustomGradientPanel2.Controls.Add(lblEstoque);
			guna2CustomGradientPanel2.CustomizableEdges = customizableEdges5;
			guna2CustomGradientPanel2.FillColor = Color.FromArgb(245, 158, 11);
			guna2CustomGradientPanel2.FillColor2 = Color.FromArgb(245, 158, 11);
			guna2CustomGradientPanel2.FillColor3 = Color.FromArgb(245, 158, 11);
			guna2CustomGradientPanel2.FillColor4 = Color.FromArgb(245, 158, 11);
			guna2CustomGradientPanel2.Location = new Point(370, 90);
			guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
			guna2CustomGradientPanel2.ShadowDecoration.CustomizableEdges = customizableEdges6;
			guna2CustomGradientPanel2.Size = new Size(320, 100);
			guna2CustomGradientPanel2.TabIndex = 2;
			// 
			// lblTotalEstoqueMinimo
			// 
			lblTotalEstoqueMinimo.BackColor = Color.Transparent;
			lblTotalEstoqueMinimo.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTotalEstoqueMinimo.ForeColor = Color.White;
			lblTotalEstoqueMinimo.Location = new Point(110, 34);
			lblTotalEstoqueMinimo.Name = "lblTotalEstoqueMinimo";
			lblTotalEstoqueMinimo.Size = new Size(23, 49);
			lblTotalEstoqueMinimo.TabIndex = 1;
			lblTotalEstoqueMinimo.Text = "0";
			// 
			// guna2HtmlLabel1
			// 
			guna2HtmlLabel1.BackColor = Color.Transparent;
			guna2HtmlLabel1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			guna2HtmlLabel1.ForeColor = Color.White;
			guna2HtmlLabel1.Location = new Point(110, 34);
			guna2HtmlLabel1.Name = "guna2HtmlLabel1";
			guna2HtmlLabel1.Size = new Size(3, 2);
			guna2HtmlLabel1.TabIndex = 1;
			guna2HtmlLabel1.Text = null;
			// 
			// lblEstoque
			// 
			lblEstoque.BackColor = Color.Transparent;
			lblEstoque.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEstoque.ForeColor = Color.White;
			lblEstoque.Location = new Point(110, 17);
			lblEstoque.Name = "lblEstoque";
			lblEstoque.Size = new Size(143, 22);
			lblEstoque.TabIndex = 3;
			lblEstoque.Text = "Em Estoque Mínimo";
			// 
			// guna2CustomGradientPanel3
			// 
			guna2CustomGradientPanel3.BorderRadius = 10;
			guna2CustomGradientPanel3.Controls.Add(lblTotalSemEstoque);
			guna2CustomGradientPanel3.Controls.Add(guna2HtmlLabel3);
			guna2CustomGradientPanel3.Controls.Add(lblSemEstoque);
			guna2CustomGradientPanel3.CustomizableEdges = customizableEdges7;
			guna2CustomGradientPanel3.FillColor = Color.FromArgb(239, 68, 68);
			guna2CustomGradientPanel3.FillColor2 = Color.FromArgb(239, 68, 68);
			guna2CustomGradientPanel3.FillColor3 = Color.FromArgb(239, 68, 68);
			guna2CustomGradientPanel3.FillColor4 = Color.FromArgb(239, 68, 68);
			guna2CustomGradientPanel3.Location = new Point(710, 90);
			guna2CustomGradientPanel3.Name = "guna2CustomGradientPanel3";
			guna2CustomGradientPanel3.ShadowDecoration.CustomizableEdges = customizableEdges8;
			guna2CustomGradientPanel3.Size = new Size(320, 100);
			guna2CustomGradientPanel3.TabIndex = 2;
			// 
			// lblTotalSemEstoque
			// 
			lblTotalSemEstoque.BackColor = Color.Transparent;
			lblTotalSemEstoque.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTotalSemEstoque.ForeColor = Color.White;
			lblTotalSemEstoque.Location = new Point(110, 34);
			lblTotalSemEstoque.Name = "lblTotalSemEstoque";
			lblTotalSemEstoque.Size = new Size(23, 49);
			lblTotalSemEstoque.TabIndex = 1;
			lblTotalSemEstoque.Text = "0";
			// 
			// guna2HtmlLabel3
			// 
			guna2HtmlLabel3.BackColor = Color.Transparent;
			guna2HtmlLabel3.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			guna2HtmlLabel3.ForeColor = Color.White;
			guna2HtmlLabel3.Location = new Point(110, 34);
			guna2HtmlLabel3.Name = "guna2HtmlLabel3";
			guna2HtmlLabel3.Size = new Size(3, 2);
			guna2HtmlLabel3.TabIndex = 1;
			guna2HtmlLabel3.Text = null;
			// 
			// lblSemEstoque
			// 
			lblSemEstoque.BackColor = Color.Transparent;
			lblSemEstoque.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblSemEstoque.ForeColor = Color.White;
			lblSemEstoque.Location = new Point(110, 17);
			lblSemEstoque.Name = "lblSemEstoque";
			lblSemEstoque.Size = new Size(93, 22);
			lblSemEstoque.TabIndex = 3;
			lblSemEstoque.Text = "Sem Estoque";
			// 
			// grpProdutosMinimo
			// 
			grpProdutosMinimo.Controls.Add(dgvProdutosEstoqueMinimo);
			grpProdutosMinimo.CustomBorderColor = Color.White;
			grpProdutosMinimo.CustomizableEdges = customizableEdges9;
			grpProdutosMinimo.FillColor = Color.WhiteSmoke;
			grpProdutosMinimo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			grpProdutosMinimo.ForeColor = Color.Black;
			grpProdutosMinimo.Location = new Point(30, 220);
			grpProdutosMinimo.Name = "grpProdutosMinimo";
			grpProdutosMinimo.ShadowDecoration.CustomizableEdges = customizableEdges10;
			grpProdutosMinimo.Size = new Size(550, 350);
			grpProdutosMinimo.TabIndex = 3;
			grpProdutosMinimo.Text = "Produtos em Estoque Mínimo";
			// 
			// dgvProdutosEstoqueMinimo
			// 
			dgvProdutosEstoqueMinimo.AllowUserToAddRows = false;
			dgvProdutosEstoqueMinimo.AllowUserToDeleteRows = false;
			dgvProdutosEstoqueMinimo.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 251, 255);
			dgvProdutosEstoqueMinimo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dgvProdutosEstoqueMinimo.AutoGenerateColumns = false;
			dgvProdutosEstoqueMinimo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvProdutosEstoqueMinimo.BackgroundColor = Color.White;
			dgvProdutosEstoqueMinimo.BorderStyle = BorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = Color.FromArgb(80, 90, 110);
			dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(80, 90, 110);
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvProdutosEstoqueMinimo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvProdutosEstoqueMinimo.ColumnHeadersHeight = 40;
			dgvProdutosEstoqueMinimo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dgvProdutosEstoqueMinimo.Columns.AddRange(new DataGridViewColumn[] { colMinNome, colMinQuantidade, colMinEstoqueMinimo, colMinCategoriaId, colMinLocalizacaoId });
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = Color.FromArgb(50, 60, 80);
			dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(220, 234, 255);
			dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(0, 60, 130);
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			dgvProdutosEstoqueMinimo.DefaultCellStyle = dataGridViewCellStyle3;
			dgvProdutosEstoqueMinimo.GridColor = Color.FromArgb(230, 230, 235);
			dgvProdutosEstoqueMinimo.Location = new Point(21, 52);
			dgvProdutosEstoqueMinimo.MultiSelect = false;
			dgvProdutosEstoqueMinimo.Name = "dgvProdutosEstoqueMinimo";
			dgvProdutosEstoqueMinimo.ReadOnly = true;
			dgvProdutosEstoqueMinimo.RowHeadersVisible = false;
			dgvProdutosEstoqueMinimo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvProdutosEstoqueMinimo.Size = new Size(508, 279);
			dgvProdutosEstoqueMinimo.TabIndex = 0;
			dgvProdutosEstoqueMinimo.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(250, 251, 255);
			dgvProdutosEstoqueMinimo.ThemeStyle.AlternatingRowsStyle.Font = null;
			dgvProdutosEstoqueMinimo.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
			dgvProdutosEstoqueMinimo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
			dgvProdutosEstoqueMinimo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
			dgvProdutosEstoqueMinimo.ThemeStyle.BackColor = Color.White;
			dgvProdutosEstoqueMinimo.ThemeStyle.GridColor = Color.FromArgb(230, 230, 235);
			dgvProdutosEstoqueMinimo.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
			dgvProdutosEstoqueMinimo.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
			dgvProdutosEstoqueMinimo.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dgvProdutosEstoqueMinimo.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(80, 90, 110);
			dgvProdutosEstoqueMinimo.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dgvProdutosEstoqueMinimo.ThemeStyle.HeaderStyle.Height = 40;
			dgvProdutosEstoqueMinimo.ThemeStyle.ReadOnly = true;
			dgvProdutosEstoqueMinimo.ThemeStyle.RowsStyle.BackColor = Color.White;
			dgvProdutosEstoqueMinimo.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dgvProdutosEstoqueMinimo.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dgvProdutosEstoqueMinimo.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
			dgvProdutosEstoqueMinimo.ThemeStyle.RowsStyle.Height = 25;
			dgvProdutosEstoqueMinimo.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(220, 234, 255);
			dgvProdutosEstoqueMinimo.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(0, 60, 130);
			// 
			// grpProdutosSaidas
			// 
			grpProdutosSaidas.Controls.Add(dgvProdutosMaisSaida);
			grpProdutosSaidas.CustomBorderColor = Color.White;
			grpProdutosSaidas.CustomizableEdges = customizableEdges11;
			grpProdutosSaidas.FillColor = Color.WhiteSmoke;
			grpProdutosSaidas.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			grpProdutosSaidas.ForeColor = Color.Black;
			grpProdutosSaidas.Location = new Point(586, 220);
			grpProdutosSaidas.Name = "grpProdutosSaidas";
			grpProdutosSaidas.ShadowDecoration.CustomizableEdges = customizableEdges12;
			grpProdutosSaidas.Size = new Size(550, 350);
			grpProdutosSaidas.TabIndex = 3;
			grpProdutosSaidas.Text = "Produtos com Mais Saídas";
			// 
			// dgvProdutosMaisSaida
			// 
			dgvProdutosMaisSaida.AllowUserToAddRows = false;
			dgvProdutosMaisSaida.AllowUserToDeleteRows = false;
			dgvProdutosMaisSaida.AllowUserToResizeRows = false;
			dataGridViewCellStyle4.BackColor = Color.FromArgb(250, 251, 255);
			dgvProdutosMaisSaida.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			dgvProdutosMaisSaida.AutoGenerateColumns = false;
			dgvProdutosMaisSaida.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvProdutosMaisSaida.BackgroundColor = Color.White;
			dgvProdutosMaisSaida.BorderStyle = BorderStyle.None;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle5.ForeColor = Color.FromArgb(80, 90, 110);
			dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(80, 90, 110);
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			dgvProdutosMaisSaida.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			dgvProdutosMaisSaida.ColumnHeadersHeight = 40;
			dgvProdutosMaisSaida.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dgvProdutosMaisSaida.Columns.AddRange(new DataGridViewColumn[] { colSaidaNome, colSaidaQuantidade, colSaidaCategoriaId, colSaidaLocalizacaoId });
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Window;
			dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle6.ForeColor = Color.FromArgb(50, 60, 80);
			dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(220, 234, 255);
			dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(0, 60, 130);
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
			dgvProdutosMaisSaida.DefaultCellStyle = dataGridViewCellStyle6;
			dgvProdutosMaisSaida.GridColor = Color.FromArgb(230, 230, 235);
			dgvProdutosMaisSaida.Location = new Point(21, 52);
			dgvProdutosMaisSaida.MultiSelect = false;
			dgvProdutosMaisSaida.Name = "dgvProdutosMaisSaida";
			dgvProdutosMaisSaida.ReadOnly = true;
			dgvProdutosMaisSaida.RowHeadersVisible = false;
			dgvProdutosMaisSaida.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvProdutosMaisSaida.Size = new Size(508, 279);
			dgvProdutosMaisSaida.TabIndex = 0;
			dgvProdutosMaisSaida.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(250, 251, 255);
			dgvProdutosMaisSaida.ThemeStyle.AlternatingRowsStyle.Font = null;
			dgvProdutosMaisSaida.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
			dgvProdutosMaisSaida.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
			dgvProdutosMaisSaida.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
			dgvProdutosMaisSaida.ThemeStyle.BackColor = Color.White;
			dgvProdutosMaisSaida.ThemeStyle.GridColor = Color.FromArgb(230, 230, 235);
			dgvProdutosMaisSaida.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
			dgvProdutosMaisSaida.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
			dgvProdutosMaisSaida.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dgvProdutosMaisSaida.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(80, 90, 110);
			dgvProdutosMaisSaida.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dgvProdutosMaisSaida.ThemeStyle.HeaderStyle.Height = 40;
			dgvProdutosMaisSaida.ThemeStyle.ReadOnly = true;
			dgvProdutosMaisSaida.ThemeStyle.RowsStyle.BackColor = Color.White;
			dgvProdutosMaisSaida.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dgvProdutosMaisSaida.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dgvProdutosMaisSaida.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
			dgvProdutosMaisSaida.ThemeStyle.RowsStyle.Height = 25;
			dgvProdutosMaisSaida.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(220, 234, 255);
			dgvProdutosMaisSaida.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(0, 60, 130);
			// 
			// btnAtualizarDashboard
			// 
			btnAtualizarDashboard.BorderRadius = 10;
			btnAtualizarDashboard.CustomizableEdges = customizableEdges13;
			btnAtualizarDashboard.DisabledState.BorderColor = Color.DarkGray;
			btnAtualizarDashboard.DisabledState.CustomBorderColor = Color.DarkGray;
			btnAtualizarDashboard.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			btnAtualizarDashboard.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			btnAtualizarDashboard.FillColor = Color.DarkOrange;
			btnAtualizarDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnAtualizarDashboard.ForeColor = Color.White;
			btnAtualizarDashboard.Location = new Point(493, 587);
			btnAtualizarDashboard.Name = "btnAtualizarDashboard";
			btnAtualizarDashboard.ShadowDecoration.CustomizableEdges = customizableEdges14;
			btnAtualizarDashboard.Size = new Size(180, 45);
			btnAtualizarDashboard.TabIndex = 4;
			btnAtualizarDashboard.Text = "Atualizar";
			// 
			// frmDashboard
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1207, 711);
			Controls.Add(btnAtualizarDashboard);
			Controls.Add(grpProdutosSaidas);
			Controls.Add(grpProdutosMinimo);
			Controls.Add(guna2CustomGradientPanel3);
			Controls.Add(guna2CustomGradientPanel2);
			Controls.Add(guna2CustomGradientPanel1);
			Controls.Add(lblDashboardEstoque);
			Controls.Add(btnSair);
			Name = "frmDashboard";
			Text = "frmDashboard";
			guna2CustomGradientPanel1.ResumeLayout(false);
			guna2CustomGradientPanel1.PerformLayout();
			guna2CustomGradientPanel2.ResumeLayout(false);
			guna2CustomGradientPanel2.PerformLayout();
			guna2CustomGradientPanel3.ResumeLayout(false);
			guna2CustomGradientPanel3.PerformLayout();
			grpProdutosMinimo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvProdutosEstoqueMinimo).EndInit();
			grpProdutosSaidas.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvProdutosMaisSaida).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridViewTextBoxColumn colMinNome;
		private DataGridViewTextBoxColumn colMinQuantidade;
		private DataGridViewTextBoxColumn colMinEstoqueMinimo;
		private DataGridViewTextBoxColumn colMinCategoriaId;
		private DataGridViewTextBoxColumn colMinLocalizacaoId;
		private DataGridViewTextBoxColumn colSaidaNome;
		private DataGridViewTextBoxColumn colSaidaQuantidade;
		private DataGridViewTextBoxColumn colSaidaCategoriaId;
		private DataGridViewTextBoxColumn colSaidaLocalizacaoId;
		private Guna.UI2.WinForms.Guna2Button btnSair;
		private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardEstoque;
		private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
		private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
		private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel3;
		private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloTotalProdutos;
		private Guna.UI2.WinForms.Guna2HtmlLabel lblEstoque;
		private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalProdutos;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
		private Guna.UI2.WinForms.Guna2HtmlLabel lblSemEstoque;
		private Guna.UI2.WinForms.Guna2GroupBox grpProdutosMinimo;
		private Guna.UI2.WinForms.Guna2GroupBox grpProdutosSaidas;
		private Guna.UI2.WinForms.Guna2DataGridView dgvProdutosEstoqueMinimo;
		private Guna.UI2.WinForms.Guna2DataGridView dgvProdutosMaisSaida;
		private Guna.UI2.WinForms.Guna2Button btnAtualizarDashboard;
		private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalEstoqueMinimo;
		private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalSemEstoque;
	}
}

