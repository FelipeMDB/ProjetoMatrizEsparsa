using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MatrizEsparsa
{
    public partial class Matrizes : Form
    {

        ListaCruzada matriz1;
        ListaCruzada matriz2;
        String arquivoMatriz1;
        bool exibindo;

        public Matrizes()
        {
            InitializeComponent();
        }

        public void Listar(ListaCruzada matrizM, DataGridView dgv)
        {
            exibindo = true;
            matrizM.Listar(dgv);
            exibindo = false;
        }

        public void AlterarValor(int linha, int coluna, double valor)
        {
            exibindo = true;
            dgvMatrizUm.Rows[linha - 1].Cells[coluna - 1].Value = valor;
            exibindo = false;
        }

        private void btnSomarK_Click(object sender, EventArgs e)  //soma a uma coluna da matriz, o valor de uma constante K
        {
            double numero;
            if (!double.TryParse(txtValor.Text, out numero))    //verificamos se a pessoa digitou um número, caso não tenha,
                MessageBox.Show("Você deve digitar um número"); //o método não será realizado e diremos a ela que ela deve inserir um valor numérico
            else
            {
                matriz1.SomarConstanteK(Convert.ToInt32(nColuna.Value), numero);//parãmetros: a coluna e a constante
                Listar(matriz1,dgvMatrizUm);
            }

        }

        public void FazerLeitura(ref ListaCruzada matrizM)
        {
            string[] instanciacao;  //variável que será utilizada para instanciar uma matriz com os respcetivos valores x e y
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                arquivoMatriz1 = dlgAbrir.FileName;
                var arquivo = new StreamReader(arquivoMatriz1);

                instanciacao = arquivo.ReadLine().Split();//a primeira linha do arquivo nos indicará qual será o tamanho dessa matriz 
                matrizM = new ListaCruzada(Convert.ToInt32(instanciacao[0]), Convert.ToInt32(instanciacao[1]));//após ler a primeira linha, utilizamos os valores dela para instanciar a matriz

                while (!arquivo.EndOfStream) //o arquivo será lido completamente e criaremos as células passadas pelo arquivo
                {
                    Celula lido = Celula.LerRegistro(arquivo);
                    matrizM.Inserir(lido.Linha, lido.Coluna, lido.Valor);
                }
                
                arquivo.Close();
            }
        }

        private void btnExibirMatrizDois_Click(object sender, EventArgs e)
        {
            Listar(matriz2, dgvMatrizDois);       //chama o método listar que lista a matriz em um dataGridView
        }

        private void btnLerMatrizDois_Click(object sender, EventArgs e)
        {
            FazerLeitura(ref matriz2);           //chama o método que lê o arquivo texto que contém a matriz
        }

        private void btnLerMatrizUm_Click(object sender, EventArgs e)
        {
            FazerLeitura(ref matriz1);          //chama o método que lê o arquivo texto que contém a matriz
        }

        private void btnExibirMatrizUm_Click_1(object sender, EventArgs e)
        {
            Listar(matriz1, dgvMatrizUm);       //chama o método listar que lista a matriz em um dataGridView
        }


        int coluna = 0; //variáveis para salvar a célula anterior e dessa forma voltá-la para sua cor padrão sem precisar listar novamente a matriz
        int linha = 0;
        private void btnBuscar_Click(object sender, EventArgs e)  //chama o método que busca o valor desejado através da linha e coluna e o exibe em um messageBox 
        {
            double? buscado = matriz1.Buscar(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value));
            if (buscado != null)
            {
                
                dgvMatrizUm.Rows[linha].Cells[coluna].Style.BackColor = Color.White;  //a celula que foi buscada anteriormente volta à cor original
                dgvMatrizUm.Rows[Convert.ToInt32(nLinha.Value) - 1].Cells[Convert.ToInt32(nColuna.Value) - 1].Style.BackColor = Color.Yellow;//mudamos a cor para chamar a atenção do usuário
                MessageBox.Show($"Valor da posição ({nLinha.Value}, {nColuna.Value}): {buscado}");

                linha = Convert.ToInt32(nLinha.Value) - 1;  
                coluna = Convert.ToInt32(nColuna.Value) - 1;
            }
            else
                MessageBox.Show("Digite uma linha e coluna dentro dos limites da matriz");
        }

        private void btnLimpar_Click(object sender, EventArgs e)  //chama o método que libera todas as posições armazenadas de uma matriz c
        {                                                         //deixando-a completamente vazia
            matriz1.LimparMatriz();
            Listar(matriz1, dgvMatrizUm);    //lista a matriz(neste caso vazia)
        }

        private void btnInserir_Click(object sender, EventArgs e)//chama o método inserir, que insere um valor com base na linha e coluna desejada
        {
            double numero;

            if (!double.TryParse(txtValor.Text, out numero))    //verificamos se a pessoa digitou um número, caso não tenha,
                MessageBox.Show("Você deve digitar um número"); //o método não será realizado e diremos a ela que ela deve inserir um valor numérico
            else
            {
                if (matriz1.Inserir(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value), numero))
                    AlterarValor(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value), numero);
                else
                    MessageBox.Show("Já existe um valor nesta posição ou valor de linha e coluna fora dos limites da matriz");

            }
        }

        private void btnSomarMatrizes_Click(object sender, EventArgs e)   //chama método que Soma duas matrizes 
        {
            ListaCruzada resultado = matriz1.SomarMatrizes(matriz2);      //criamos uma terceira matriz que é a soma das duas já existentes
            if (resultado != null)
            {
                Listar(resultado, dgvResultado);                             //listamos a matriz
                lblResultados.Visible = true;
                lblResultados.Text = "Resultado da soma:";
                tbMatrizes.SelectedTab = tabResultados;                        //usuário é direcionada a tab com o resultado
            }
            else
                MessageBox.Show("As matrizes devem ser de mesmo tamanho para a soma");
        }

        private void btnRemover_Click(object sender, EventArgs e)           //chamamos o método remover que remove o valor de uma célula
        {
            if (matriz1.Remover(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value))) //parâmetros : coluna e linha do valor a ser removido (retorna true se removeu ou se já não existia)
                AlterarValor(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value), 0);
            else
                MessageBox.Show("Digite um valor nos limites da matriz para excluir"); // método remover retorna false se o valor fornecido não era válido
        }           

        private void btnMultiplicarMatrizes_Click(object sender, EventArgs e)
        {
            ListaCruzada resultado = matriz1.MultiplicarMatrizes(matriz2);
            if (resultado != null)
            {
                Listar(resultado, dgvResultado);                                //listamos a matriz
                lblResultados.Visible = true;
                lblResultados.Text = "Resultado da Multiplicação:";
                tbMatrizes.SelectedTab = tabResultados;                        //usuário é direcionada a tab com o resultado
            }
            else
                MessageBox.Show("As matrizes não são compatíveis para multiplicação");
        }

        private void Matrizes_Load(object sender, EventArgs e)
        {
            matriz1 = new ListaCruzada(5, 3);      //instançiação padrão, para caso o usuário deseje ver uma matriz logo que iniciar o programa
            matriz2 = new ListaCruzada(5, 3);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            matriz1.Gravar(new StreamWriter(arquivoMatriz1)); //chama o método gravar para salvar a matriz em um arquivo txt
        }

        private void dgvMatrizUm_CellValueChanged(object sender, DataGridViewCellEventArgs e)  //método para caso o usuário mude o valor da célula no prórpio grid view 
        {                                                                                     //o valor também seja alterado na matriz
            if (!exibindo)                    
            {
                int coluna = e.ColumnIndex + 1;
                int linha = e.RowIndex + 1;
                double valor;

                if (dgvMatrizUm.Rows[linha - 1].Cells[coluna - 1].Value != null && double.TryParse(dgvMatrizUm.Rows[linha - 1].Cells[coluna - 1].Value.ToString(), out valor))
                {
                    if (matriz1.Alterar(linha, coluna, valor))
                        AlterarValor(linha, coluna, valor);
                }
                else
                    MessageBox.Show("Digite um valor válido");       //lista a matriz
            }

        }
    }
}
