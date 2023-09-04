namespace TP_Forms_04._09._23
{
    partial class Form1
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.remover = new System.Windows.Forms.Button();
            this.pesquisar = new System.Windows.Forms.Button();
            this.salvar = new System.Windows.Forms.Button();
            this.novo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataNasc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.adicionar = new System.Windows.Forms.Button();
            this.principalTelefone = new System.Windows.Forms.CheckBox();
            this.tipoTelefone = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tipoTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.princip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // remover
            // 
            this.remover.Location = new System.Drawing.Point(651, 12);
            this.remover.Name = "remover";
            this.remover.Size = new System.Drawing.Size(94, 29);
            this.remover.TabIndex = 0;
            this.remover.Text = "Remover";
            this.remover.UseVisualStyleBackColor = true;
            this.remover.Click += new System.EventHandler(this.remover_Click);
            // 
            // pesquisar
            // 
            this.pesquisar.Location = new System.Drawing.Point(427, 12);
            this.pesquisar.Name = "pesquisar";
            this.pesquisar.Size = new System.Drawing.Size(94, 29);
            this.pesquisar.TabIndex = 1;
            this.pesquisar.Text = "Pesquisar";
            this.pesquisar.UseVisualStyleBackColor = true;
            this.pesquisar.Click += new System.EventHandler(this.pesquisar_Click);
            // 
            // salvar
            // 
            this.salvar.Location = new System.Drawing.Point(221, 12);
            this.salvar.Name = "salvar";
            this.salvar.Size = new System.Drawing.Size(94, 29);
            this.salvar.TabIndex = 2;
            this.salvar.Text = "Salvar";
            this.salvar.UseVisualStyleBackColor = true;
            this.salvar.Click += new System.EventHandler(this.salvar_Click);
            // 
            // novo
            // 
            this.novo.Location = new System.Drawing.Point(21, 12);
            this.novo.Name = "novo";
            this.novo.Size = new System.Drawing.Size(94, 29);
            this.novo.TabIndex = 3;
            this.novo.Text = "Novo";
            this.novo.UseVisualStyleBackColor = true;
            this.novo.Click += new System.EventHandler(this.novo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Email,
            this.Nome,
            this.dataNasc,
            this.Idade,
            this.telefone});
            this.dataGridView1.Location = new System.Drawing.Point(57, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(679, 188);
            this.dataGridView1.TabIndex = 4;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.MinimumWidth = 6;
            this.Nome.Name = "Nome";
            this.Nome.Width = 125;
            // 
            // dataNasc
            // 
            this.dataNasc.HeaderText = "Data Nasc";
            this.dataNasc.MinimumWidth = 6;
            this.dataNasc.Name = "dataNasc";
            this.dataNasc.Width = 125;
            // 
            // Idade
            // 
            this.Idade.HeaderText = "Idade";
            this.Idade.MinimumWidth = 6;
            this.Idade.Name = "Idade";
            this.Idade.Width = 125;
            // 
            // telefone
            // 
            this.telefone.HeaderText = "Telefone";
            this.telefone.MinimumWidth = 6;
            this.telefone.Name = "telefone";
            this.telefone.Width = 125;
            // 
            // listar
            // 
            this.listar.Location = new System.Drawing.Point(245, 409);
            this.listar.Name = "listar";
            this.listar.Size = new System.Drawing.Size(276, 29);
            this.listar.TabIndex = 5;
            this.listar.Text = "Listar Contatos";
            this.listar.UseVisualStyleBackColor = true;
            this.listar.Click += new System.EventHandler(this.listar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(80, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 27);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(80, 172);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(35, 27);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(121, 172);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(35, 27);
            this.textBox4.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(162, 172);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(43, 27);
            this.textBox5.TabIndex = 10;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(449, 170);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(125, 27);
            this.textBox6.TabIndex = 11;
            // 
            // adicionar
            // 
            this.adicionar.Location = new System.Drawing.Point(684, 170);
            this.adicionar.Name = "adicionar";
            this.adicionar.Size = new System.Drawing.Size(94, 29);
            this.adicionar.TabIndex = 12;
            this.adicionar.Text = "Adicionar";
            this.adicionar.UseVisualStyleBackColor = true;
            this.adicionar.Click += new System.EventHandler(this.adicionar_Click);
            // 
            // principalTelefone
            // 
            this.principalTelefone.AutoSize = true;
            this.principalTelefone.Location = new System.Drawing.Point(590, 175);
            this.principalTelefone.Name = "principalTelefone";
            this.principalTelefone.Size = new System.Drawing.Size(88, 24);
            this.principalTelefone.TabIndex = 13;
            this.principalTelefone.Text = "Principal";
            this.principalTelefone.UseVisualStyleBackColor = true;
            // 
            // tipoTelefone
            // 
            this.tipoTelefone.FormattingEnabled = true;
            this.tipoTelefone.Items.AddRange(new object[] {
            "Residencial",
            "Móvel",
            "Comercial"});
            this.tipoTelefone.Location = new System.Drawing.Point(337, 169);
            this.tipoTelefone.Name = "tipoTelefone";
            this.tipoTelefone.Size = new System.Drawing.Size(106, 28);
            this.tipoTelefone.TabIndex = 14;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoTel,
            this.numero,
            this.princip});
            this.dataGridView2.Location = new System.Drawing.Point(316, 68);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(442, 79);
            this.dataGridView2.TabIndex = 15;
            // 
            // tipoTel
            // 
            this.tipoTel.HeaderText = "Tipo";
            this.tipoTel.MinimumWidth = 6;
            this.tipoTel.Name = "tipoTel";
            this.tipoTel.Width = 125;
            // 
            // numero
            // 
            this.numero.HeaderText = "Número";
            this.numero.MinimumWidth = 6;
            this.numero.Name = "numero";
            this.numero.Width = 125;
            // 
            // princip
            // 
            this.princip.HeaderText = "Principal";
            this.princip.MinimumWidth = 6;
            this.princip.Name = "princip";
            this.princip.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "E-mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Data Nascimento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Telefone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tipo Tel:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.tipoTelefone);
            this.Controls.Add(this.principalTelefone);
            this.Controls.Add(this.adicionar);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.novo);
            this.Controls.Add(this.salvar);
            this.Controls.Add(this.pesquisar);
            this.Controls.Add(this.remover);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button remover;
        private Button pesquisar;
        private Button salvar;
        private Button novo;
        private DataGridView dataGridView1;
        private Button listar;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button adicionar;
        private CheckBox principalTelefone;
        private ComboBox tipoTelefone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn dataNasc;
        private DataGridViewTextBoxColumn Idade;
        private DataGridViewTextBoxColumn telefone;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn tipoTel;
        private DataGridViewTextBoxColumn numero;
        private DataGridViewTextBoxColumn princip;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}