namespace NexStock.UI
{
	partial class frmUsuario
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
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
			components = new System.ComponentModel.Container();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
			notifyIcon1 = new NotifyIcon(components);
			label1 = new Label();
			label2 = new Label();
			panel1 = new Panel();
			label3 = new Label();
			label6 = new Label();
			label5 = new Label();
			label4 = new Label();
			label11 = new Label();
			panel2 = new Panel();
			label7 = new Label();
			label9 = new Label();
			label10 = new Label();
			dataGridView1 = new DataGridView();
			label8 = new Label();
			label12 = new Label();
			label14 = new Label();
			txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
			label15 = new Label();
			txtSenha = new Guna.UI2.WinForms.Guna2TextBox();
			btnCancelar = new Button();
			btnCriarUsuario = new Button();
			button5 = new Button();
			btnDeletar = new Button();
			btnLimpar = new Button();
			btnAtualizar = new Button();
			guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
			btnSair = new Guna.UI2.WinForms.Guna2Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			guna2CustomGradientPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// notifyIcon1
			// 
			notifyIcon1.Text = "notifyIcon1";
			notifyIcon1.Visible = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(17, 107);
			label1.Name = "label1";
			label1.Size = new Size(153, 21);
			label1.TabIndex = 2;
			label1.Text = "Gerenciar Usuários";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.ForeColor = SystemColors.ControlDarkDark;
			label2.Location = new Point(17, 128);
			label2.Name = "label2";
			label2.Size = new Size(230, 13);
			label2.TabIndex = 2;
			label2.Text = "Crie, visualize e remova usuários do sistema";
			// 
			// panel1
			// 
			panel1.BackColor = Color.White;
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label11);
			panel1.Location = new Point(17, 155);
			panel1.Name = "panel1";
			panel1.Size = new Size(397, 73);
			panel1.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(12, 11);
			label3.Name = "label3";
			label3.Size = new Size(82, 13);
			label3.TabIndex = 2;
			label3.Text = "Administrador";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label6.ForeColor = SystemColors.ControlDarkDark;
			label6.Location = new Point(12, 47);
			label6.Name = "label6";
			label6.Size = new Size(133, 12);
			label6.TabIndex = 2;
			label6.Text = "* Editar e excluir movimentações";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label5.ForeColor = SystemColors.ControlDarkDark;
			label5.Location = new Point(12, 35);
			label5.Name = "label5";
			label5.Size = new Size(148, 12);
			label5.TabIndex = 2;
			label5.Text = "* Cadastrar, editar e excluir produtos";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label4.ForeColor = SystemColors.ControlDarkDark;
			label4.Location = new Point(12, 24);
			label4.Name = "label4";
			label4.Size = new Size(126, 12);
			label4.TabIndex = 2;
			label4.Text = "* Criar, editar e excluir usuários";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label11.Location = new Point(636, -28);
			label11.Name = "label11";
			label11.Size = new Size(155, 21);
			label11.TabIndex = 2;
			label11.Text = "Criar Novo Usuário";
			// 
			// panel2
			// 
			panel2.BackColor = Color.White;
			panel2.BorderStyle = BorderStyle.FixedSingle;
			panel2.Controls.Add(label7);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(label10);
			panel2.Location = new Point(17, 234);
			panel2.Name = "panel2";
			panel2.Size = new Size(397, 66);
			panel2.TabIndex = 3;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.Location = new Point(12, 11);
			label7.Name = "label7";
			label7.Size = new Size(47, 13);
			label7.TabIndex = 2;
			label7.Text = "Usuário";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label9.ForeColor = SystemColors.ControlDarkDark;
			label9.Location = new Point(12, 36);
			label9.Name = "label9";
			label9.Size = new Size(180, 12);
			label9.TabIndex = 2;
			label9.Text = "* Preeencher informações da movimentação";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label10.ForeColor = SystemColors.ControlDarkDark;
			label10.Location = new Point(12, 24);
			label10.Name = "label10";
			label10.Size = new Size(158, 12);
			label10.TabIndex = 2;
			label10.Text = "* Registrar entrada e saída de produtos";
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 251, 255);
			dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.BackgroundColor = Color.White;
			dataGridView1.BorderStyle = BorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			dataGridViewCellStyle2.ForeColor = Color.FromArgb(80, 90, 110);
			dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(80, 90, 110);
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dataGridView1.ColumnHeadersHeight = 40;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = Color.FromArgb(50, 60, 80);
			dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(220, 234, 255);
			dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(0, 60, 130);
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
			dataGridView1.GridColor = Color.FromArgb(230, 230, 235);
			dataGridView1.Location = new Point(12, 336);
			dataGridView1.MultiSelect = false;
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.Size = new Size(707, 200);
			dataGridView1.TabIndex = 4;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.Location = new Point(613, 107);
			label8.Name = "label8";
			label8.Size = new Size(155, 21);
			label8.TabIndex = 2;
			label8.Text = "Criar Novo Usuário";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label12.ForeColor = SystemColors.ControlDarkDark;
			label12.Location = new Point(613, 128);
			label12.Name = "label12";
			label12.Size = new Size(232, 13);
			label12.TabIndex = 2;
			label12.Text = "O usuário será criado com o perfil \"Usuário\"";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label14.Location = new Point(613, 155);
			label14.Name = "label14";
			label14.Size = new Size(39, 13);
			label14.TabIndex = 2;
			label14.Text = "E-mail";
			// 
			// txtEmail
			// 
			txtEmail.BorderRadius = 8;
			txtEmail.CustomizableEdges = customizableEdges1;
			txtEmail.DefaultText = "";
			txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			txtEmail.Font = new Font("Segoe UI", 9F);
			txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
			txtEmail.Location = new Point(613, 171);
			txtEmail.Name = "txtEmail";
			txtEmail.PlaceholderText = "usuario@email.com";
			txtEmail.SelectedText = "";
			txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
			txtEmail.Size = new Size(301, 36);
			txtEmail.TabIndex = 5;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label15.Location = new Point(613, 210);
			label15.Name = "label15";
			label15.Size = new Size(39, 13);
			label15.TabIndex = 2;
			label15.Text = "Senha";
			// 
			// txtSenha
			// 
			txtSenha.BorderRadius = 8;
			txtSenha.CustomizableEdges = customizableEdges3;
			txtSenha.DefaultText = "";
			txtSenha.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			txtSenha.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			txtSenha.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			txtSenha.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			txtSenha.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			txtSenha.Font = new Font("Segoe UI", 9F);
			txtSenha.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
			txtSenha.Location = new Point(613, 226);
			txtSenha.Name = "txtSenha";
			txtSenha.PlaceholderText = "Mínimo 6 caracteres";
			txtSenha.SelectedText = "";
			txtSenha.ShadowDecoration.CustomizableEdges = customizableEdges4;
			txtSenha.Size = new Size(301, 36);
			txtSenha.TabIndex = 5;
			txtSenha.TextChanged += txtSenha_TextChanged;
			// 
			// btnCancelar
			// 
			btnCancelar.BackColor = SystemColors.ButtonFace;
			btnCancelar.ForeColor = Color.DimGray;
			btnCancelar.Location = new Point(668, 271);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(92, 29);
			btnCancelar.TabIndex = 1;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = false;
			// 
			// btnCriarUsuario
			// 
			btnCriarUsuario.BackColor = Color.DarkOrange;
			btnCriarUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCriarUsuario.ForeColor = Color.White;
			btnCriarUsuario.Location = new Point(766, 271);
			btnCriarUsuario.Name = "btnCriarUsuario";
			btnCriarUsuario.Size = new Size(148, 29);
			btnCriarUsuario.TabIndex = 1;
			btnCriarUsuario.Text = "Criar Usuário";
			btnCriarUsuario.UseVisualStyleBackColor = false;
			// 
			// button5
			// 
			button5.BackColor = Color.FromArgb(0, 0, 64);
			button5.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button5.ForeColor = Color.White;
			button5.Location = new Point(742, 404);
			button5.Name = "button5";
			button5.Size = new Size(91, 30);
			button5.TabIndex = 1;
			button5.Text = "Atualizar";
			button5.UseVisualStyleBackColor = false;
			button5.Visible = false;
			// 
			// btnDeletar
			// 
			btnDeletar.BackColor = Color.FromArgb(0, 0, 64);
			btnDeletar.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnDeletar.ForeColor = Color.White;
			btnDeletar.Location = new Point(742, 440);
			btnDeletar.Name = "btnDeletar";
			btnDeletar.Size = new Size(91, 30);
			btnDeletar.TabIndex = 1;
			btnDeletar.Text = "Deletar";
			btnDeletar.UseVisualStyleBackColor = false;
			// 
			// btnLimpar
			// 
			btnLimpar.BackColor = Color.FromArgb(0, 0, 64);
			btnLimpar.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnLimpar.ForeColor = Color.White;
			btnLimpar.Location = new Point(742, 476);
			btnLimpar.Name = "btnLimpar";
			btnLimpar.Size = new Size(91, 30);
			btnLimpar.TabIndex = 1;
			btnLimpar.Text = "Limpar";
			btnLimpar.UseVisualStyleBackColor = false;
			// 
			// btnAtualizar
			// 
			btnAtualizar.BackColor = Color.FromArgb(0, 0, 64);
			btnAtualizar.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnAtualizar.ForeColor = Color.White;
			btnAtualizar.Location = new Point(742, 404);
			btnAtualizar.Name = "btnAtualizar";
			btnAtualizar.Size = new Size(91, 30);
			btnAtualizar.TabIndex = 1;
			btnAtualizar.Text = "Atualizar";
			btnAtualizar.UseVisualStyleBackColor = false;
			// 
			// guna2CustomGradientPanel1
			// 
			guna2CustomGradientPanel1.Controls.Add(btnSair);
			guna2CustomGradientPanel1.CustomizableEdges = customizableEdges7;
			guna2CustomGradientPanel1.Location = new Point(0, 0);
			guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
			guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
			guna2CustomGradientPanel1.Size = new Size(994, 58);
			guna2CustomGradientPanel1.TabIndex = 9;
			// 
			// btnSair
			// 
			btnSair.BackColor = Color.Transparent;
			btnSair.BorderRadius = 8;
			btnSair.CustomizableEdges = customizableEdges5;
			btnSair.DisabledState.BorderColor = Color.DarkGray;
			btnSair.DisabledState.CustomBorderColor = Color.DarkGray;
			btnSair.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			btnSair.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			btnSair.FillColor = Color.Transparent;
			btnSair.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnSair.ForeColor = Color.DimGray;
			btnSair.Location = new Point(17, 12);
			btnSair.Name = "btnSair";
			btnSair.ShadowDecoration.CustomizableEdges = customizableEdges6;
			btnSair.Size = new Size(78, 35);
			btnSair.TabIndex = 8;
			btnSair.Text = "⬅️ Sair";
			// 
			// frmUsuario
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ButtonFace;
			ClientSize = new Size(992, 576);
			Controls.Add(guna2CustomGradientPanel1);
			Controls.Add(txtSenha);
			Controls.Add(txtEmail);
			Controls.Add(label15);
			Controls.Add(label14);
			Controls.Add(dataGridView1);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Controls.Add(label12);
			Controls.Add(label2);
			Controls.Add(label8);
			Controls.Add(label1);
			Controls.Add(btnLimpar);
			Controls.Add(btnDeletar);
			Controls.Add(btnAtualizar);
			Controls.Add(button5);
			Controls.Add(btnCriarUsuario);
			Controls.Add(btnCancelar);
			FormBorderStyle = FormBorderStyle.None;
			Name = "frmUsuario";
			Text = "Form1";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			guna2CustomGradientPanel1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private NotifyIcon notifyIcon1;
		private Label label1;
		private Label label2;
		private Panel panel1;
		private Label label6;
		private Label label5;
		private Label label4;
		private Panel panel2;
		private Label label7;
		private Label label9;
		private Label label10;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colEmail;
		private Label label3;
		private Label label11;
		private Label label8;
		private Label label12;
		private Label label14;
		private Guna.UI2.WinForms.Guna2TextBox txtEmail;
		private Label label15;
		private Guna.UI2.WinForms.Guna2TextBox txtSenha;
		private Button btnCancelar;
		private Button btnCriarUsuario;
		private Button button5;
		private Button btnDeletar;
		private Button btnLimpar;
		private Button btnAtualizar;
		private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
		private Guna.UI2.WinForms.Guna2Button btnSair;
	}
}

