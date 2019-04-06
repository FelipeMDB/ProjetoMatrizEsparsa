using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ListaCircular
{
    protected Celula cabeca;
    protected int qtasLinhas, qtasColunas;

    public ListaCircular(int linhas, int colunas)
    {
        cabeca = new Celula(null, null, -1, -1, 0);
        Celula primeira = cabeca;
        qtasLinhas = linhas;
        qtasColunas = colunas;

        if (qtasLinhas <= 0 || qtasColunas <= 0)
            throw new Exception("quantidade de linhas ou colunas inválida");

        for (int i = 1; i <= qtasColunas; i++)
        {
            cabeca.Direita = new Celula(null, null, 0, -1, 0);
            cabeca = cabeca.Direita;
        }
        cabeca.Direita = primeira;
        cabeca = primeira;

        for (int i = 1; i <= qtasLinhas; i++)
        {
            cabeca.Abaixo = new Celula(null, null, 0, -1, 0);
            cabeca = cabeca.Abaixo;
        }
        cabeca.Abaixo = primeira;
        cabeca = primeira;
    }

    public bool ExisteCelula(int linha, int coluna, ref Celula esquerda, ref Celula direita, ref Celula acima, ref Celula abaixo)
    {
        Celula atual = cabeca;

        Celula nova = new Celula(null, null, linha, coluna, 0);

        for (int i = 1; i <= coluna; i++)
            atual = atual.Direita;

        bool achouPosicao = false;
        acima = atual;
        while (!achouPosicao)
        {
            abaixo = acima.Abaixo;
            if (abaixo == null)
                achouPosicao = true;

            else if (abaixo.Linha > nova.Linha)
                achouPosicao = true;

            else if (abaixo.Linha == nova.Linha)
                return true;
            
            if(abaixo != null)
                acima = acima.Abaixo;
        }

        atual = cabeca;
        for (int i = 1; i <= linha; i++)
            atual = atual.Abaixo;

        achouPosicao = false;
        esquerda = atual;
        while (!achouPosicao)
        {
            direita = esquerda.Direita;
            if (direita == null)
                achouPosicao = true;
            else if (direita.Linha > nova.Linha)
                achouPosicao = true;

            if(direita != null)
                esquerda = esquerda.Direita;
        }

        return false;
    }

    public void AdicionarCelula(int linha, int coluna, double valor)
    {
        if (valor != 0)
        {
            Celula acima = null, abaixo = null, direita = null, esquerda = null;

            Celula nova = new Celula(null, null, linha, coluna, valor);

            if (!ExisteCelula(linha, coluna, ref esquerda, ref direita, ref acima, ref abaixo))
            {
                esquerda.Direita = nova;
                nova.Direita = direita;
                acima.Abaixo = nova;
                nova.Abaixo = abaixo;
            }
        }
    }

    public void Listar(DataGridView dgv)
    {
        dgv.RowCount = qtasLinhas;
        dgv.ColumnCount = qtasColunas;

        Celula coluna = cabeca;

        for (int c = 0; c < qtasColunas; c++)
        {
            coluna = coluna.Direita;
            Celula linha = coluna;

            for (int l = 0; l < qtasLinhas; l++)
            {
                if(linha.Abaixo != null && linha.Abaixo.Linha.CompareTo(l+1) == 0)
                {
                    linha = linha.Abaixo;
                    dgv.Rows[l].Cells[c].Value = linha.Valor;
                }
                else
                    dgv.Rows[l].Cells[c].Value = 0;
            }
        }
    }
}

