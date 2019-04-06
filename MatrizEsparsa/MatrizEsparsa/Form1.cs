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

        ListaCircular lista1;
        ListaCircular lista2;


        public Matrizes()
        {
            InitializeComponent();
        }

        private void btnSomarK_Click(object sender, EventArgs e)
        {
            lista1.SomarConstanteK(Convert.ToInt32(nColuna.Value),double.Parse(txtValor.Text));
            lista1.Listar(dgvMatrizUm);
        }

        public void FazerLeitura(ref ListaCircular listaC)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                var arquivo = new StreamReader(dlgAbrir.FileName);
                while (!arquivo.EndOfStream)
                {
                    Celula lido = Celula.LerRegistro(arquivo);
                    listaC.AdicionarCelula(lido.Linha, lido.Coluna, lido.Valor);
                }
                arquivo.Close();
            }
        }

        private void btnExibirMatrizDois_Click(object sender, EventArgs e)
        {
            lista2.Listar(dgvMatrizDois);
        }

        private void btnLerMatrizDois_Click(object sender, EventArgs e)
        {
            FazerLeitura(ref lista2);
        }

        private void btnLerMatrizUm_Click(object sender, EventArgs e)
        {
            FazerLeitura(ref lista1);
        }

        private void btnExibirMatrizUm_Click_1(object sender, EventArgs e)
        {
            lista1.Listar(dgvMatrizUm);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Valor da posição ({nLinha.Value}, {nColuna.Value}): {lista1.Buscar(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value))}");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lista1.LimparMatriz();
            lista1.Listar(dgvMatrizUm);
        }


        private void btnInserir_Click(object sender, EventArgs e)
        {
            double numero;

            if (!double.TryParse(txtValor.Text, out numero))
                MessageBox.Show("Você deve digitar um número");
            else
            {
                lista1.Inserir(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value), numero);
                lista1.Listar(dgvMatrizUm);
            }
        }

        private void btnSomarMatrizes_Click(object sender, EventArgs e)
        {
            ListaCircular resultado = lista1.SomarMatrizes(lista2);
            resultado.Listar(dgvResultado);
            MessageBox.Show("Vá para a página resultados para visualizar a nova matriz");
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            lista1.Remover(Convert.ToInt32(nLinha.Value), Convert.ToInt32(nColuna.Value));
            lista1.Listar(dgvMatrizUm);
        }

        private void btnMultiplicarMatrizes_Click(object sender, EventArgs e)
        {

        }

        private void Matrizes_Load(object sender, EventArgs e)
        {
            lista1 = new ListaCircular(2, 2);
            lista2 = new ListaCircular(2, 2);
        }
    }
}
