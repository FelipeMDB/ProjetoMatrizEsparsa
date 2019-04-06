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
            lista1 = new ListaCircular(2, 2);
            InitializeComponent();
        }

        private void btnSomarK_Click(object sender, EventArgs e)
        {
            //SomarConstanteK(int.Parse(txtK.Text));
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
            lista2.Listar(dgvMatrizUm);
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
            //LimparMatriz(lista1);
            //limparMatriz(lista2);
        }
    }
}
