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

        private void btnSomarK_Click(object sender, EventArgs e)
        {
            matriz1.SomarConstanteK(Convert.ToInt32(nColuna.Value),double.Parse(txtValor.Text));
            matriz1.Listar(dgvMatrizUm);
        }

        public void FazerLeitura(ref ListaCruzada matrizM)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                arquivoMatriz1 = dlgAbrir.FileName;
                var arquivo = new StreamReader(arquivoMatriz1);
                while (!arquivo.EndOfStream)
                {
                    Celula lido = Celula.LerRegistro(arquivo);
                    matrizM.AdicionarCelula(lido.Linha, lido.Coluna, lido.Valor);
                }
                arquivo.Close();
            }
        }

        private void btnExibirMatrizDois_Click(object sender, EventArgs e)
        {
            matriz2.Listar(dgvMatrizDois);
        }

        private void btnLerMatrizDois_Click(object sender, EventArgs e)
        {
            FazerLeitura(ref matriz2);
        }

        private void btnLerMatrizUm_Click(object sender, EventArgs e)
        {
            FazerLeitura(ref matriz1);
        }

        private void btnExibirMatrizUm_Click_1(object sender, EventArgs e)
        {
            matriz1.Listar(dgvMatrizUm);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Valor da posição ({nLinha.Value}, {nColuna.Value}): {matriz1.Buscar(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value))}");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            matriz1.LimparMatriz();
            matriz1.Listar(dgvMatrizUm);
        }


        private void btnInserir_Click(object sender, EventArgs e)
        {
            double numero;

            if (!double.TryParse(txtValor.Text, out numero))
                MessageBox.Show("Você deve digitar um número");
            else
            {
                matriz1.Inserir(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value), numero);
                matriz1.Listar(dgvMatrizUm);
            }
        }

        private void btnSomarMatrizes_Click(object sender, EventArgs e)
        {
            ListaCruzada resultado = matriz1.SomarMatrizes(matriz2);
            resultado.Listar(dgvResultado);
            MessageBox.Show("Vá para a página resultados para visualizar a nova matriz");
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            matriz1.Remover(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value));
            matriz1.Listar(dgvMatrizUm);
        }

        private void btnMultiplicarMatrizes_Click(object sender, EventArgs e)
        {
            ListaCruzada resultado = matriz1.MultiplicarMatrizes(matriz2);
            resultado.Listar(dgvResultado);
            MessageBox.Show("Vá para a página resultados para visualizar a nova matriz");
        }

        private void Matrizes_Load(object sender, EventArgs e)
        {
            matriz1 = new ListaCruzada(2, 2);
            matriz2 = new ListaCruzada(2, 2);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            matriz1.Gravar(new StreamWriter(arquivoMatriz1));
        }
    }
}
