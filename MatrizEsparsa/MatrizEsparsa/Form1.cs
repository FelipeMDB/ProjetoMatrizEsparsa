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
    public partial class Form1 : Form
    {

        ListaCircular listaCircular; 


        public Form1()
        {
            InitializeComponent();
        }

        private void btnSomarK_Click(object sender, EventArgs e)
        {
            //SomarConstanteK(Int32(txtK.Text));
        }

        private void btnLerMatriz_Click(object sender, EventArgs e)
        {
            FazerLeitura(listaCircular);
        }

        public void FazerLeitura(ref ListaCircular listaC)
        {
            listaC = new ListaCircular();
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                var arquivo = new StreamReader(dlgAbrir.FileName);
                while (!arquivo.EndOfStream)
                {
                    Celula lido = Celula.LerRegistro(arquivo);
                    listaC.AdicionarCelula();
                }
                arquivo.Close();
                listaC.Listar(dgvMatriz);

            }
        }

        private void btnLerInserir_Click(object sender, EventArgs e)
        {

        }
    }
}
