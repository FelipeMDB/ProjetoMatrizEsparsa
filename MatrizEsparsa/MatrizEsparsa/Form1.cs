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

        public Matrizes()
        {
            InitializeComponent();
        }

        private void btnSomarK_Click(object sender, EventArgs e)  //soma a uma coluna da matriz, o valor de uma constante K
        {
            matriz1.SomarConstanteK(Convert.ToInt32(nColuna.Value),double.Parse(txtValor.Text));//parãmetros: a coluna e a constante
            matriz1.Listar(dgvMatrizUm);        //listamos o resultado da soma
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
                    matrizM.AdicionarCelula(lido.Linha, lido.Coluna, lido.Valor);
                }
                
                arquivo.Close();
            }
        }

        private void btnExibirMatrizDois_Click(object sender, EventArgs e)
        {
            matriz2.Listar(dgvMatrizDois);       //chama o método listar que lista a matriz em um dataGridView
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
            matriz1.Listar(dgvMatrizUm);        //chama o método listar que lista a matriz em um dataGridView
        }

        private void btnBuscar_Click(object sender, EventArgs e)  //chama o método que busca o valor desejado através da linha e coluna e o exibe em um messageBox 
        {
            MessageBox.Show($"Valor da posição ({nLinha.Value}, {nColuna.Value}): {matriz1.Buscar(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value))}");
        }

        private void btnLimpar_Click(object sender, EventArgs e)  //chama o método que libera todas as posições armazenadas de uma matriz c
        {                                                         //deixando-a completamente vazia
            matriz1.LimparMatriz();
            matriz1.Listar(dgvMatrizUm);    //lista a matriz(neste caso vazia)
        }


        private void btnInserir_Click(object sender, EventArgs e)//chama o método inserir, que insere um valor com base na linha e coluna desejada
        {
            double numero;

            if (!double.TryParse(txtValor.Text, out numero))    //verificamos se a pessoa digitou um número, caso não tenha,
                MessageBox.Show("Você deve digitar um número"); //o método não será realizado e diremos a ela que ela deve inserir um valor numérico
            else
            {
                matriz1.Inserir(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value), numero);  
                matriz1.Listar(dgvMatrizUm);  //lista a matriz com o novo valor
            }
        }

        private void btnSomarMatrizes_Click(object sender, EventArgs e)   //chama método que Soma duas matrizes 
        {
            ListaCruzada resultado = matriz1.SomarMatrizes(matriz2);      //criamos uma terceira matriz que é a soma das duas já existentes
            resultado.Listar(dgvResultado);                                //listamos a matriz
            tbMatrizes.SelectedTab = tabResultados;                        //usuário é direcionada a tab com o resultado
        }

        private void btnRemover_Click(object sender, EventArgs e)           //chamamos o método remover que remove o valor de uma célula
        {
            matriz1.Remover(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value)); //parâmetros : coluna e linha do valor a ser removido
            matriz1.Listar(dgvMatrizUm);        //listamos a matriz agora sem o valor removido
        }           

        private void btnMultiplicarMatrizes_Click(object sender, EventArgs e)
        {
            ListaCruzada resultado = matriz1.MultiplicarMatrizes(matriz2);
            resultado.Listar(dgvResultado);                                //listamos a matriz
            tbMatrizes.SelectedTab = tabResultados;                        //usuário é direcionada a tab com o resultado
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
    }
}
