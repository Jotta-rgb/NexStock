
namespace NexStock.UI
{
	partial class frmLocalizacoes
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Titulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
			label1 = new Label();
			dgvLocalizacoes = new Guna.UI2.WinForms.Guna2DataGridView();
			colId = new DataGridViewTextBoxColumn();
			colNome = new DataGridViewTextBoxColumn();
			btnPesquisar = new Guna.UI2.WinForms.Guna2Button();
			btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
			btnDeletar = new Guna.UI2.WinForms.Guna2Button();
			txtBuscarLocalizaco = new Guna.UI2.WinForms.Guna2TextBox();
			btnLimpar = new Guna.UI2.WinForms.Guna2Button();
			guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			txtCorredor = new Guna.UI2.WinForms.Guna2TextBox();
			btnCriar = new Guna.UI2.WinForms.Guna2Button();
			btnCancelar = new Guna.UI2.WinForms.Guna2Button();
			guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
			btnSair = new Guna.UI2.WinForms.Guna2Button();
			((System.ComponentModel.ISupportInitialize)dgvLocalizacoes).BeginInit();
			guna2CustomGradientPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// Titulo
			// 
			Titulo.BackColor = Color.Transparent;
			Titulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			Titulo.Location = new Point(21, 49);
			Titulo.Name = "Titulo";
			Titulo.Size = new Size(124, 32);
			Titulo.TabIndex = 0;
			Titulo.Text = "Localizações";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = SystemColors.ControlDarkDark;
			label1.Location = new Point(21, 84);
			label1.Name = "label1";
			label1.Size = new Size(190, 15);
			label1.TabIndex = 1;
			label1.Text = "Crie ou pesquise uma localização";
			label1.Click += label1_Click;
			// 
			// dgvLocalizacoes
			// 
			dgvLocalizacoes.AllowUserToAddRows = false;
			dgvLocalizacoes.AllowUserToDeleteRows = false;
			dgvLocalizacoes.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 251, 255);
			dgvLocalizacoes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dgvLocalizacoes.AutoGenerateColumns = false;
			dgvLocalizacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvLocalizacoes.BackgroundColor = Color.White;
			dgvLocalizacoes.BorderStyle = BorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = Color.FromArgb(80, 90, 110);
			dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(80, 90, 110);
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvLocalizacoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvLocalizacoes.ColumnHeadersHeight = 40;
			dgvLocalizacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dgvLocalizacoes.Columns.AddRange(new DataGridViewColumn[] { colId, colNome });
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = Color.FromArgb(50, 60, 80);
			dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(220, 234, 255);
			dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(0, 60, 130);
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			dgvLocalizacoes.DefaultCellStyle = dataGridViewCellStyle3;
			dgvLocalizacoes.GridColor = Color.FromArgb(230, 230, 235);
			dgvLocalizacoes.Location = new Point(21, 139);
			dgvLocalizacoes.MultiSelect = false;
			dgvLocalizacoes.Name = "dgvLocalizacoes";
			dgvLocalizacoes.ReadOnly = true;
			dgvLocalizacoes.RowHeadersVisible = false;
			dgvLocalizacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvLocalizacoes.Size = new Size(747, 368);
			dgvLocalizacoes.TabIndex = 3;
			dgvLocalizacoes.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(250, 251, 255);
			dgvLocalizacoes.ThemeStyle.AlternatingRowsStyle.Font = null;
			dgvLocalizacoes.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
			dgvLocalizacoes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
			dgvLocalizacoes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
			dgvLocalizacoes.ThemeStyle.BackColor = Color.White;
			dgvLocalizacoes.ThemeStyle.GridColor = Color.FromArgb(230, 230, 235);
			dgvLocalizacoes.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
			dgvLocalizacoes.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
			dgvLocalizacoes.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dgvLocalizacoes.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(80, 90, 110);
			dgvLocalizacoes.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dgvLocalizacoes.ThemeStyle.HeaderStyle.Height = 40;
			dgvLocalizacoes.ThemeStyle.ReadOnly = true;
			dgvLocalizacoes.ThemeStyle.RowsStyle.BackColor = Color.White;
			dgvLocalizacoes.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dgvLocalizacoes.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dgvLocalizacoes.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
			dgvLocalizacoes.ThemeStyle.RowsStyle.Height = 25;
			dgvLocalizacoes.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(220, 234, 255);
			dgvLocalizacoes.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(0, 60, 130);
			dgvLocalizacoes.CellContentClick += dgvLocalizacoes_CellContentClick;
			// 
			// colId
			// 
			colId.DataPropertyName = "Id";
			colId.HeaderText = "ID";
			colId.Name = "colId";
			colId.ReadOnly = true;
			colId.Visible = false;
			// 
			// colNome
			// 
			colNome.DataPropertyName = "Nome";
			colNome.HeaderText = "Localização";
			colNome.Name = "colNome";
			colNome.ReadOnly = true;
			// 
			// btnPesquisar
			// 
			btnPesquisar.BorderRadius = 8;
			btnPesquisar.CustomizableEdges = customizableEdges1;
			btnPesquisar.DisabledState.BorderColor = Color.DarkGray;
			btnPesquisar.DisabledState.CustomBorderColor = Color.DarkGray;
			btnPesquisar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			btnPesquisar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			btnPesquisar.FillColor = Color.DarkOrange;
			btnPesquisar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnPesquisar.ForeColor = Color.White;
			btnPesquisar.Location = new Point(359, 87);
			btnPesquisar.Name = "btnPesquisar";
			btnPesquisar.ShadowDecoration.CustomizableEdges = customizableEdges2;
			btnPesquisar.Size = new Size(78, 27);
			btnPesquisar.TabIndex = 2;
			btnPesquisar.Text = "Buscar";
			btnPesquisar.Click += btnPesquisar_Click_1;
			// 
			// btnAtualizar
			// 
			btnAtualizar.BorderRadius = 8;
			btnAtualizar.CustomizableEdges = customizableEdges3;
			btnAtualizar.DisabledState.BorderColor = Color.DarkGray;
			btnAtualizar.DisabledState.CustomBorderColor = Color.DarkGray;
			btnAtualizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			btnAtualizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			btnAtualizar.FillColor = Color.DarkOrange;
			btnAtualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnAtualizar.ForeColor = Color.White;
			btnAtualizar.Location = new Point(521, 513);
			btnAtualizar.Name = "btnAtualizar";
			btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges4;
			btnAtualizar.Size = new Size(79, 24);
			btnAtualizar.TabIndex = 7;
			btnAtualizar.Text = "Atualizar";
			btnAtualizar.Click += btnAtualizar_Click_1;
			// 
			// btnDeletar
			// 
			btnDeletar.BorderRadius = 8;
			btnDeletar.CustomizableEdges = customizableEdges5;
			btnDeletar.DisabledState.BorderColor = Color.DarkGray;
			btnDeletar.DisabledState.CustomBorderColor = Color.DarkGray;
			btnDeletar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			btnDeletar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			btnDeletar.FillColor = Color.DarkOrange;
			btnDeletar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnDeletar.ForeColor = Color.White;
			btnDeletar.Location = new Point(606, 513);
			btnDeletar.Name = "btnDeletar";
			btnDeletar.ShadowDecoration.CustomizableEdges = customizableEdges6;
			btnDeletar.Size = new Size(79, 24);
			btnDeletar.TabIndex = 8;
			btnDeletar.Text = "Deletar";
			btnDeletar.Click += btnDeletar_Click;
			// 
			// txtBuscarLocalizaco
			// 
			txtBuscarLocalizaco.BorderRadius = 8;
			txtBuscarLocalizaco.CustomizableEdges = customizableEdges7;
			txtBuscarLocalizaco.DefaultText = "";
			txtBuscarLocalizaco.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			txtBuscarLocalizaco.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			txtBuscarLocalizaco.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			txtBuscarLocalizaco.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			txtBuscarLocalizaco.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			txtBuscarLocalizaco.Font = new Font("Segoe UI", 9F);
			txtBuscarLocalizaco.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
			txtBuscarLocalizaco.Location = new Point(21, 87);
			txtBuscarLocalizaco.Name = "txtBuscarLocalizaco";
			txtBuscarLocalizaco.PlaceholderText = "Buscar localização...";
			txtBuscarLocalizaco.SelectedText = "";
			txtBuscarLocalizaco.ShadowDecoration.CustomizableEdges = customizableEdges8;
			txtBuscarLocalizaco.Size = new Size(332, 36);
			txtBuscarLocalizaco.TabIndex = 1;
			txtBuscarLocalizaco.TextChanged += txtBuscarLocalizaco_TextChanged;
			// 
			// btnLimpar
			// 
			btnLimpar.BorderRadius = 8;
			btnLimpar.CustomizableEdges = customizableEdges9;
			btnLimpar.DisabledState.BorderColor = Color.DarkGray;
			btnLimpar.DisabledState.CustomBorderColor = Color.DarkGray;
			btnLimpar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			btnLimpar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			btnLimpar.FillColor = Color.DarkOrange;
			btnLimpar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnLimpar.ForeColor = Color.White;
			btnLimpar.Location = new Point(691, 513);
			btnLimpar.Name = "btnLimpar";
			btnLimpar.ShadowDecoration.CustomizableEdges = customizableEdges10;
			btnLimpar.Size = new Size(79, 24);
			btnLimpar.TabIndex = 9;
			btnLimpar.Text = "Limpar";
			btnLimpar.Click += btnLimpar_Click;
			// 
			// guna2HtmlLabel1
			// 
			guna2HtmlLabel1.BackColor = Color.Transparent;
			guna2HtmlLabel1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			guna2HtmlLabel1.Location = new Point(824, 96);
			guna2HtmlLabel1.Name = "guna2HtmlLabel1";
			guna2HtmlLabel1.Size = new Size(198, 27);
			guna2HtmlLabel1.TabIndex = 10;
			guna2HtmlLabel1.Text = "Criar Nova Localização";
			// 
			// txtCorredor
			// 
			txtCorredor.BorderRadius = 8;
			txtCorredor.CustomizableEdges = customizableEdges11;
			txtCorredor.DefaultText = "";
			txtCorredor.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			txtCorredor.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			txtCorredor.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			txtCorredor.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			txtCorredor.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			txtCorredor.Font = new Font("Segoe UI", 9F);
			txtCorredor.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
			txtCorredor.Location = new Point(824, 139);
			txtCorredor.Name = "txtCorredor";
			txtCorredor.PlaceholderText = "Nome da localização";
			txtCorredor.SelectedText = "";
			txtCorredor.ShadowDecoration.CustomizableEdges = customizableEdges12;
			txtCorredor.Size = new Size(200, 36);
			txtCorredor.TabIndex = 4;
			// 
			// btnCriar
			// 
			btnCriar.BorderRadius = 8;
			btnCriar.CustomizableEdges = customizableEdges13;
			btnCriar.DisabledState.BorderColor = Color.DarkGray;
			btnCriar.DisabledState.CustomBorderColor = Color.DarkGray;
			btnCriar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			btnCriar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			btnCriar.FillColor = Color.DarkOrange;
			btnCriar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCriar.ForeColor = Color.White;
			btnCriar.Location = new Point(945, 181);
			btnCriar.Name = "btnCriar";
			btnCriar.ShadowDecoration.CustomizableEdges = customizableEdges14;
			btnCriar.Size = new Size(79, 24);
			btnCriar.TabIndex = 6;
			btnCriar.Text = "Criar";
			btnCriar.Click += btnCriar_Click_1;
			// 
			// btnCancelar
			// 
			btnCancelar.BorderRadius = 8;
			btnCancelar.CustomizableEdges = customizableEdges15;
			btnCancelar.DisabledState.BorderColor = Color.DarkGray;
			btnCancelar.DisabledState.CustomBorderColor = Color.DarkGray;
			btnCancelar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			btnCancelar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			btnCancelar.FillColor = Color.Silver;
			btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCancelar.ForeColor = Color.White;
			btnCancelar.Location = new Point(860, 181);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges16;
			btnCancelar.Size = new Size(79, 24);
			btnCancelar.TabIndex = 5;
			btnCancelar.Text = "Cancelar";
			btnCancelar.Click += btnCancelar_Click;
			// 
			// guna2CustomGradientPanel1
			// 
			guna2CustomGradientPanel1.Controls.Add(btnSair);
			guna2CustomGradientPanel1.CustomizableEdges = customizableEdges19;
			guna2CustomGradientPanel1.Location = new Point(0, 0);
			guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
			guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges20;
			guna2CustomGradientPanel1.Size = new Size(1090, 43);
			guna2CustomGradientPanel1.TabIndex = 11;
			// 
			// btnSair
			// 
			btnSair.BackColor = Color.Transparent;
			btnSair.BorderRadius = 8;
			btnSair.CustomizableEdges = customizableEdges17;
			btnSair.DisabledState.BorderColor = Color.DarkGray;
			btnSair.DisabledState.CustomBorderColor = Color.DarkGray;
			btnSair.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			btnSair.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			btnSair.FillColor = Color.Transparent;
			btnSair.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnSair.ForeColor = Color.DimGray;
			btnSair.Location = new Point(21, 8);
			btnSair.Name = "btnSair";
			btnSair.ShadowDecoration.CustomizableEdges = customizableEdges18;
			btnSair.Size = new Size(78, 29);
			btnSair.TabIndex = 0;
			btnSair.Text = "⬅️ Sair";
			btnSair.Click += btnSair_Click;
			// 
			// frmLocalizacoes
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1076, 556);
			Controls.Add(guna2CustomGradientPanel1);
			Controls.Add(btnCancelar);
			Controls.Add(btnCriar);
			Controls.Add(txtCorredor);
			Controls.Add(guna2HtmlLabel1);
			Controls.Add(btnLimpar);
			Controls.Add(txtBuscarLocalizaco);
			Controls.Add(btnDeletar);
			Controls.Add(btnAtualizar);
			Controls.Add(btnPesquisar);
			Controls.Add(dgvLocalizacoes);
			Controls.Add(label1);
			Controls.Add(Titulo);
			FormBorderStyle = FormBorderStyle.None;
			Name = "frmLocalizacoes";
			Text = "frmLocalizacoes";
			Load += frmLocalizacoes_Load_1;
			((System.ComponentModel.ISupportInitialize)dgvLocalizacoes).EndInit();
			guna2CustomGradientPanel1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Guna.UI2.WinForms.Guna2HtmlLabel Titulo;
		private Label label1;
		private Guna.UI2.WinForms.Guna2DataGridView dgvLocalizacoes;
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colNome;
		private Guna.UI2.WinForms.Guna2Button btnPesquisar;
		private Guna.UI2.WinForms.Guna2Button btnAtualizar;
		private Guna.UI2.WinForms.Guna2Button btnDeletar;
		private Guna.UI2.WinForms.Guna2TextBox txtBuscarLocalizaco;
		private Guna.UI2.WinForms.Guna2Button btnLimpar;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
		private Guna.UI2.WinForms.Guna2TextBox txtCorredor;
		private Guna.UI2.WinForms.Guna2Button btnCriar;
		private Guna.UI2.WinForms.Guna2Button btnCancelar;
		private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
		private Guna.UI2.WinForms.Guna2Button btnSair;
	}
}

