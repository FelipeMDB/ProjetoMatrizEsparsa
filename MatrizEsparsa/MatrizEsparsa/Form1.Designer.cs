namespace MatrizEsparsa
{
    partial class Matrizes
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMatrizUm = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSomarK = new System.Windows.Forms.Button();
            this.btnSomarMatrizes = new System.Windows.Forms.Button();
            this.dgvMatrizDois = new System.Windows.Forms.DataGridView();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnMultiplicarMatrizes = new System.Windows.Forms.Button();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.nLinha = new System.Windows.Forms.NumericUpDown();
            this.nColuna = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLerMatrizDois = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExibirMatrizUm = new System.Windows.Forms.Button();
            this.btnLerMatrizUm = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExibirMatrizDois = new System.Windows.Forms.Button();
            this.tbMatrizes = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabResultados = new System.Windows.Forms.TabPage();
            this.lblResultados = new System.Windows.Forms.Label();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrizUm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrizDois)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLinha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nColuna)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tbMatrizes.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMatrizUm
            // 
            this.dgvMatrizUm.AllowUserToAddRows = false;
            this.dgvMatrizUm.AllowUserToDeleteRows = false;
            this.dgvMatrizUm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMatrizUm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrizUm.ColumnHeadersVisible = false;
            this.dgvMatrizUm.Location = new System.Drawing.Point(139, 23);
            this.dgvMatrizUm.Name = "dgvMatrizUm";
            this.dgvMatrizUm.RowHeadersVisible = false;
            this.dgvMatrizUm.Size = new System.Drawing.Size(387, 322);
            this.dgvMatrizUm.TabIndex = 0;
            this.dgvMatrizUm.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatrizUm_CellValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscar.Location = new System.Drawing.Point(203, 145);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(152, 39);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(452, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "Matrizes Esparsas";
            // 
            // btnSomarK
            // 
            this.btnSomarK.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSomarK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSomarK.Location = new System.Drawing.Point(203, 102);
            this.btnSomarK.Name = "btnSomarK";
            this.btnSomarK.Size = new System.Drawing.Size(152, 39);
            this.btnSomarK.TabIndex = 8;
            this.btnSomarK.Text = "Somar Constante ";
            this.btnSomarK.UseVisualStyleBackColor = true;
            this.btnSomarK.Click += new System.EventHandler(this.btnSomarK_Click);
            // 
            // btnSomarMatrizes
            // 
            this.btnSomarMatrizes.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSomarMatrizes.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSomarMatrizes.Location = new System.Drawing.Point(189, 119);
            this.btnSomarMatrizes.Name = "btnSomarMatrizes";
            this.btnSomarMatrizes.Size = new System.Drawing.Size(120, 46);
            this.btnSomarMatrizes.TabIndex = 9;
            this.btnSomarMatrizes.Text = "Somar Matrizes";
            this.btnSomarMatrizes.UseVisualStyleBackColor = true;
            this.btnSomarMatrizes.Click += new System.EventHandler(this.btnSomarMatrizes_Click);
            // 
            // dgvMatrizDois
            // 
            this.dgvMatrizDois.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMatrizDois.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrizDois.Location = new System.Drawing.Point(25, 23);
            this.dgvMatrizDois.Name = "dgvMatrizDois";
            this.dgvMatrizDois.Size = new System.Drawing.Size(387, 322);
            this.dgvMatrizDois.TabIndex = 10;
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(214, 47);
            this.txtValor.Multiline = true;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(121, 25);
            this.txtValor.TabIndex = 13;
            this.txtValor.Text = "K";
            // 
            // btnMultiplicarMatrizes
            // 
            this.btnMultiplicarMatrizes.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiplicarMatrizes.ForeColor = System.Drawing.Color.Black;
            this.btnMultiplicarMatrizes.Location = new System.Drawing.Point(41, 53);
            this.btnMultiplicarMatrizes.Name = "btnMultiplicarMatrizes";
            this.btnMultiplicarMatrizes.Size = new System.Drawing.Size(120, 46);
            this.btnMultiplicarMatrizes.TabIndex = 14;
            this.btnMultiplicarMatrizes.Text = "Multiplicar Matrizes";
            this.btnMultiplicarMatrizes.UseVisualStyleBackColor = true;
            this.btnMultiplicarMatrizes.Click += new System.EventHandler(this.btnMultiplicarMatrizes_Click);
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.FileName = "openFileDialog1";
            // 
            // nLinha
            // 
            this.nLinha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nLinha.Location = new System.Drawing.Point(88, 33);
            this.nLinha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nLinha.Name = "nLinha";
            this.nLinha.Size = new System.Drawing.Size(120, 24);
            this.nLinha.TabIndex = 17;
            this.nLinha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nColuna
            // 
            this.nColuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nColuna.Location = new System.Drawing.Point(88, 63);
            this.nColuna.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nColuna.Name = "nColuna";
            this.nColuna.Size = new System.Drawing.Size(120, 24);
            this.nColuna.TabIndex = 18;
            this.nColuna.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(35, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Linha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(23, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Coluna:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSomarK);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnRemover);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnInserir);
            this.groupBox1.Controls.Add(this.txtValor);
            this.groupBox1.Controls.Add(this.nColuna);
            this.groupBox1.Controls.Add(this.nLinha);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(145, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 196);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operações com uma matriz";
            // 
            // btnRemover
            // 
            this.btnRemover.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.ForeColor = System.Drawing.Color.Black;
            this.btnRemover.Location = new System.Drawing.Point(6, 101);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(152, 39);
            this.btnRemover.TabIndex = 28;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserir.ForeColor = System.Drawing.Color.Black;
            this.btnInserir.Location = new System.Drawing.Point(6, 145);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(152, 39);
            this.btnInserir.TabIndex = 25;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSomarMatrizes);
            this.groupBox2.Controls.Add(this.btnMultiplicarMatrizes);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(564, 406);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 196);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operações com duas matrizes";
            // 
            // btnLerMatrizDois
            // 
            this.btnLerMatrizDois.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLerMatrizDois.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnLerMatrizDois.Location = new System.Drawing.Point(418, 38);
            this.btnLerMatrizDois.Name = "btnLerMatrizDois";
            this.btnLerMatrizDois.Size = new System.Drawing.Size(120, 43);
            this.btnLerMatrizDois.TabIndex = 15;
            this.btnLerMatrizDois.Text = "Ler Arquivo\r\n";
            this.btnLerMatrizDois.UseVisualStyleBackColor = true;
            this.btnLerMatrizDois.Click += new System.EventHandler(this.btnLerMatrizDois_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSalvar);
            this.groupBox3.Controls.Add(this.btnExibirMatrizUm);
            this.groupBox3.Controls.Add(this.btnLerMatrizUm);
            this.groupBox3.Controls.Add(this.btnLimpar);
            this.groupBox3.Controls.Add(this.dgvMatrizUm);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(541, 365);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Matriz Principal";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSalvar.Location = new System.Drawing.Point(6, 196);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(121, 37);
            this.btnSalvar.TabIndex = 30;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExibirMatrizUm
            // 
            this.btnExibirMatrizUm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExibirMatrizUm.Location = new System.Drawing.Point(6, 89);
            this.btnExibirMatrizUm.Name = "btnExibirMatrizUm";
            this.btnExibirMatrizUm.Size = new System.Drawing.Size(121, 40);
            this.btnExibirMatrizUm.TabIndex = 29;
            this.btnExibirMatrizUm.Text = "Exibir matriz";
            this.btnExibirMatrizUm.UseVisualStyleBackColor = true;
            this.btnExibirMatrizUm.Click += new System.EventHandler(this.btnExibirMatrizUm_Click_1);
            // 
            // btnLerMatrizUm
            // 
            this.btnLerMatrizUm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnLerMatrizUm.Location = new System.Drawing.Point(6, 38);
            this.btnLerMatrizUm.Name = "btnLerMatrizUm";
            this.btnLerMatrizUm.Size = new System.Drawing.Size(121, 40);
            this.btnLerMatrizUm.TabIndex = 24;
            this.btnLerMatrizUm.Text = "Ler Arquivo";
            this.btnLerMatrizUm.UseVisualStyleBackColor = true;
            this.btnLerMatrizUm.Click += new System.EventHandler(this.btnLerMatrizUm_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(6, 141);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(121, 40);
            this.btnLimpar.TabIndex = 27;
            this.btnLimpar.Text = "Limpar Matriz";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnExibirMatrizDois);
            this.groupBox4.Controls.Add(this.btnLerMatrizDois);
            this.groupBox4.Controls.Add(this.dgvMatrizDois);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(564, 35);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(548, 365);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Matriz Secundária";
            // 
            // btnExibirMatrizDois
            // 
            this.btnExibirMatrizDois.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExibirMatrizDois.Location = new System.Drawing.Point(418, 87);
            this.btnExibirMatrizDois.Name = "btnExibirMatrizDois";
            this.btnExibirMatrizDois.Size = new System.Drawing.Size(121, 40);
            this.btnExibirMatrizDois.TabIndex = 30;
            this.btnExibirMatrizDois.Text = "Exibir matriz";
            this.btnExibirMatrizDois.UseVisualStyleBackColor = true;
            this.btnExibirMatrizDois.Click += new System.EventHandler(this.btnExibirMatrizDois_Click);
            // 
            // tbMatrizes
            // 
            this.tbMatrizes.Controls.Add(this.tabPage1);
            this.tbMatrizes.Controls.Add(this.tabResultados);
            this.tbMatrizes.Location = new System.Drawing.Point(12, 12);
            this.tbMatrizes.Name = "tbMatrizes";
            this.tbMatrizes.SelectedIndex = 0;
            this.tbMatrizes.Size = new System.Drawing.Size(1141, 645);
            this.tbMatrizes.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1133, 619);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Matrizes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabResultados
            // 
            this.tabResultados.Controls.Add(this.lblResultados);
            this.tabResultados.Controls.Add(this.dgvResultado);
            this.tabResultados.Location = new System.Drawing.Point(4, 22);
            this.tabResultados.Name = "tabResultados";
            this.tabResultados.Padding = new System.Windows.Forms.Padding(3);
            this.tabResultados.Size = new System.Drawing.Size(1133, 619);
            this.tabResultados.TabIndex = 1;
            this.tabResultados.Text = "Resultados";
            this.tabResultados.UseVisualStyleBackColor = true;
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.Location = new System.Drawing.Point(188, 40);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(70, 25);
            this.lblResultados.TabIndex = 1;
            this.lblResultados.Text = "label2";
            this.lblResultados.Visible = false;
            // 
            // dgvResultado
            // 
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(191, 80);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.Size = new System.Drawing.Size(706, 394);
            this.dgvResultado.TabIndex = 0;
            // 
            // Matrizes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 665);
            this.Controls.Add(this.tbMatrizes);
            this.Name = "Matrizes";
            this.Text = "Matrizes";
            this.Load += new System.EventHandler(this.Matrizes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrizUm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrizDois)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLinha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nColuna)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tbMatrizes.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabResultados.ResumeLayout(false);
            this.tabResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMatrizUm;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSomarK;
        private System.Windows.Forms.Button btnSomarMatrizes;
        private System.Windows.Forms.DataGridView dgvMatrizDois;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnMultiplicarMatrizes;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.NumericUpDown nLinha;
        private System.Windows.Forms.NumericUpDown nColuna;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLerMatrizDois;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExibirMatrizUm;
        private System.Windows.Forms.Button btnLerMatrizUm;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnExibirMatrizDois;
        private System.Windows.Forms.TabControl tbMatrizes;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabResultados;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblResultados;
    }
}

