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
        bool existe = false;
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
            {
                achouPosicao = true;
                existe = true;
            }

            if (abaixo != null && !achouPosicao)
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

            if (direita != null)
                esquerda = esquerda.Direita;
        }

        return existe;
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
        dgv.Columns.Clear();
        dgv.Rows.Clear();
        dgv.RowCount = qtasLinhas;
        dgv.ColumnCount = qtasColunas;

        Celula coluna = cabeca;

        for (int c = 0; c < qtasColunas; c++)
        {
            coluna = coluna.Direita;
            Celula linha = coluna;

            for (int l = 0; l < qtasLinhas; l++)
            {
                if (linha.Abaixo != null && linha.Abaixo.Linha.CompareTo(l + 1) == 0)
                {
                    linha = linha.Abaixo;
                    dgv.Rows[l].Cells[c].Value = linha.Valor;
                }
                else
                    dgv.Rows[l].Cells[c].Value = 0;
            }
        }
    }

    public double Buscar(int linha, int coluna)
    {
        if (linha <= qtasLinhas && linha > 0 && coluna <= qtasColunas && coluna > 0)
        {
            Celula acima = null, abaixo = null, direita = null, esquerda = null;

            if (ExisteCelula(linha, coluna, ref esquerda, ref direita, ref acima, ref abaixo))
            {
                return abaixo.Valor;
            }
            return 0;
        }
        return default(double);
    }

    public void Inserir(int linha, int coluna, double valor)
    {
        if (linha <= qtasLinhas && coluna <= qtasColunas)
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
            else
            {
                MessageBox.Show("Já existe um valor nesta posição da matriz");
            }
        }
        else
        {
            MessageBox.Show("Digite um valor nos limites da matriz");
        }
    }

    public void Remover(int linha, int coluna)
    {
        if (linha <= qtasLinhas && coluna <= qtasColunas)
        {
            Celula acima = null, abaixo = null, direita = null, esquerda = null;


            if (ExisteCelula(linha, coluna, ref esquerda, ref direita, ref acima, ref abaixo))
            {
                if (direita != null)
                    esquerda.Direita = direita.Direita;
                if (abaixo != null)
                    acima.Abaixo = abaixo.Abaixo;
            }
        }
        else
        {
            MessageBox.Show("Digite um valor nos limites da matriz");
        }
    }

    public void LimparMatriz()
    {
        for (Celula atual = cabeca.Abaixo; atual!= cabeca ;atual = atual.Abaixo)
        {
            atual.Direita = null;
        }

        for(Celula atual = cabeca.Direita; atual!= cabeca; atual = atual.Direita)
        {
            atual.Abaixo = null;
        }
    }

    public void SomarConstanteK(int coluna, double k)
    {
        Celula atual = cabeca.Direita;
        for(int i = 2; i<=coluna;i++)
        {
            atual = atual.Direita;
        }

        atual = atual.Abaixo;
        while (atual != null)
        {
            atual.Valor = atual.Valor + k;
            atual = atual.Abaixo;
        }
    }

    public ListaCircular SomarMatrizes(ListaCircular outra)
    {
        int qtasLinhasNova = 0, qtasColunasNova;

        if (qtasLinhas > outra.qtasLinhas)
            qtasLinhasNova = qtasLinhas;
        else
            qtasLinhasNova = outra.qtasLinhas;

        if (qtasColunas > outra.qtasColunas)
            qtasColunasNova = qtasColunas;
        else
            qtasColunasNova = outra.qtasColunas;
            
        ListaCircular listaSoma = new ListaCircular(qtasLinhasNova, qtasColunasNova);
        
        Celula colunaThis = cabeca.Direita, colunaOutra = outra.cabeca.Direita;

        while (colunaThis != cabeca || colunaOutra != outra.cabeca)
        {
            if(colunaThis != cabeca && colunaOutra != outra.cabeca)
            {
                Celula linhaThis = colunaThis.Abaixo;
                Celula linhaOutra = colunaOutra.Abaixo;
                while(linhaThis != null || linhaOutra != null)
                {
                    if(linhaThis != null && linhaOutra != null)
                    {
                        if (linhaThis.Linha == linhaOutra.Linha)
                        {
                            listaSoma.Inserir(linhaThis.Linha, linhaThis.Coluna, linhaThis.Valor + linhaOutra.Valor);
                            linhaThis = linhaThis.Abaixo;
                            linhaOutra = linhaOutra.Abaixo;
                        }
                        else if(linhaThis.Linha<linhaOutra.Linha)
                        {
                            listaSoma.Inserir(linhaThis.Linha, linhaThis.Coluna, linhaThis.Valor);
                            linhaThis = linhaThis.Abaixo;
                        }
                        else
                        {
                            listaSoma.Inserir(linhaOutra.Linha, linhaOutra.Coluna, linhaOutra.Valor);
                            linhaOutra = linhaOutra.Abaixo;
                        }

                    }
                    else if(linhaThis != null)
                    {
                        listaSoma.Inserir(linhaThis.Linha, linhaThis.Coluna, linhaThis.Valor);
                        linhaThis = linhaThis.Abaixo;
                    }
                    else
                    {
                        listaSoma.Inserir(linhaOutra.Linha, linhaOutra.Coluna, linhaOutra.Valor);
                        linhaOutra = linhaOutra.Abaixo;
                    }
                }
                colunaThis = colunaThis.Direita;
                colunaOutra = colunaOutra.Direita;
            }
            else if(colunaThis != cabeca)
            {
                Celula linha = colunaThis.Abaixo;
                while (linha != null)
                {
                    listaSoma.Inserir(linha.Linha, linha.Coluna, linha.Valor);
                    linha = linha.Abaixo;
                }
                colunaThis = colunaThis.Direita;
            }
            else
            {
                Celula linha = colunaOutra.Abaixo;
                while (linha != null)
                {
                    listaSoma.Inserir(linha.Linha, linha.Coluna, linha.Valor);
                    linha = linha.Abaixo;
                }
                colunaOutra = colunaOutra.Direita;
            }
        }
        return listaSoma;
    }

    public ListaCircular MultiplicarMatrizes(ListaCircular outra)
    {
        int qtasLinhasNova = 0, qtasColunasNova;

        if (qtasLinhas < outra.qtasLinhas)
            qtasLinhasNova = qtasLinhas;
        else
            qtasLinhasNova = outra.qtasLinhas;

        if (qtasColunas < outra.qtasColunas)
            qtasColunasNova = qtasColunas;
        else
            qtasColunasNova = outra.qtasColunas;

        ListaCircular listaMultiplicada = new ListaCircular(qtasLinhasNova, qtasColunasNova);

        Celula colunaThis = cabeca.Direita, colunaOutra = outra.cabeca.Direita;

        while (colunaThis != cabeca && colunaOutra != outra.cabeca)
        {
            Celula linhaThis = colunaThis.Abaixo;
            Celula linhaOutra = colunaOutra.Abaixo;
            while (linhaThis != null && linhaOutra != null)
            {
                if (linhaThis.Linha == linhaOutra.Linha)
                {
                    listaMultiplicada.Inserir(linhaThis.Linha, linhaThis.Coluna, linhaThis.Valor * linhaOutra.Valor);
                    linhaThis = linhaThis.Abaixo;
                    linhaOutra = linhaOutra.Abaixo;
                }
                else if (linhaThis.Linha < linhaOutra.Linha)
                {
                    linhaThis = linhaThis.Abaixo;
                }
                else
                {
                    linhaOutra = linhaOutra.Abaixo;
                }
            }
                
            colunaThis = colunaThis.Direita;
            colunaOutra = colunaOutra.Direita;
        }
        
        return listaMultiplicada;
    }
}


