using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ListaCruzada
{
    protected Celula cabeca;
    protected int qtasLinhas, qtasColunas;

    public ListaCruzada(int linhas, int colunas)
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
            cabeca.Abaixo = cabeca;
        }
        cabeca.Direita = primeira;
        cabeca = primeira;

        for (int i = 1; i <= qtasLinhas; i++)
        {
            cabeca.Abaixo = new Celula(null, null, 0, -1, 0);
            cabeca = cabeca.Abaixo;
            cabeca.Direita = cabeca;
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

        Celula cabecaColuna = atual;
        bool achouPosicao = false;
        acima = atual;
        while (!achouPosicao)
        {
            abaixo = acima.Abaixo;
            if (abaixo == cabecaColuna)
                achouPosicao = true;

            else if (abaixo.Linha > nova.Linha)
                achouPosicao = true;

            else if (abaixo.Linha == nova.Linha)
            {
                achouPosicao = true;
                existe = true;
            }

            if (abaixo != cabecaColuna && !achouPosicao)
                acima = acima.Abaixo;
        }

        atual = cabeca;
        for (int i = 1; i <= linha; i++)
            atual = atual.Abaixo;

        Celula cabecaLinha = atual;
        achouPosicao = false;
        esquerda = atual;
        while (!achouPosicao)
        {
            direita = esquerda.Direita;
            if (direita == cabecaLinha)
                achouPosicao = true;
            else if (direita.Linha > nova.Linha)
                achouPosicao = true;
            else if (direita.Linha == nova.Linha)
                achouPosicao = true;

            if (direita != cabecaLinha && !achouPosicao)
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
            atual.Direita = atual;
        }

        for(Celula atual = cabeca.Direita; atual!= cabeca; atual = atual.Direita)
        {
            atual.Abaixo = atual;
        }
    }

    public void SomarConstanteK(int coluna, double k)
    {
        Celula atual = cabeca.Direita;
        for(int i = 2; i<=coluna;i++)
        {
            atual = atual.Direita;
        }

        Celula atualCabeca = atual;
        atual = atual.Abaixo;
        int linha = 0;
        while (linha != qtasLinhas)
        {
            linha++;
            if (atual == atualCabeca || atual.Linha != linha)
                Inserir(linha, coluna, k);
            else
            {
                if (atual.Valor + k == 0)
                    Remover(atual.Linha, atual.Coluna);
                else
                    atual.Valor = atual.Valor + k;

                atual = atual.Abaixo;
            }
        }
    }

    public ListaCruzada SomarMatrizes(ListaCruzada outra)
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
            
        ListaCruzada listaSoma = new ListaCruzada(qtasLinhasNova, qtasColunasNova);
        
        Celula colunaThis = cabeca.Direita, colunaOutra = outra.cabeca.Direita;

        while (colunaThis != cabeca || colunaOutra != outra.cabeca)
        {
            if(colunaThis != cabeca && colunaOutra != outra.cabeca)
            {
                Celula linhaCabecaThis = colunaThis, linhaCabecaOutra = colunaOutra;

                Celula linhaThis = colunaThis.Abaixo, linhaOutra = colunaOutra.Abaixo;

                while(linhaThis != linhaCabecaThis || linhaOutra != linhaCabecaOutra)
                {
                    if(linhaThis != linhaCabecaThis && linhaOutra != linhaCabecaOutra)
                    {
                        if (linhaThis.Linha == linhaOutra.Linha)
                        {
                            if(linhaThis.Valor + linhaOutra.Valor != 0)
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
                    else if(linhaThis != linhaCabecaThis)
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
                Celula linhaCabeca = colunaThis;
                Celula linha = colunaThis.Abaixo;
                while (linha != linhaCabeca)
                {
                    listaSoma.Inserir(linha.Linha, linha.Coluna, linha.Valor);
                    linha = linha.Abaixo;
                }
                colunaThis = colunaThis.Direita;
            }
            else
            {
                Celula linhaCabeca = colunaThis;
                Celula linha = colunaOutra.Abaixo;
                while (linha != linhaCabeca)
                {
                    listaSoma.Inserir(linha.Linha, linha.Coluna, linha.Valor);
                    linha = linha.Abaixo;
                }
                colunaOutra = colunaOutra.Direita;
            }
        }
        return listaSoma;
    }

    public ListaCruzada MultiplicarMatrizes(ListaCruzada outra)
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

        ListaCruzada listaMultiplicada = new ListaCruzada(qtasLinhasNova, qtasColunasNova);

        Celula colunaThis = cabeca.Direita, colunaOutra = outra.cabeca.Direita;

        while (colunaThis != cabeca && colunaOutra != outra.cabeca)
        {
            Celula linhaCabecaThis = colunaThis, linhaCabecaOutra = colunaOutra;

            Celula linhaThis = colunaThis.Abaixo, linhaOutra = colunaOutra.Abaixo;

            while (linhaThis != linhaCabecaThis && linhaOutra != linhaCabecaOutra)
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

    public void Gravar(StreamWriter arq)
    {
        arq.WriteLine(qtasLinhas + " " + qtasColunas);
        Celula atual = cabeca.Direita;
        int coluna = 1;
        while (atual != cabeca)
        {
            int linha = 0;
            Celula linhaCelula = atual.Abaixo;
            while (linha != qtasLinhas)
            {
                linha++;
                if (linhaCelula.Linha == linha)
                    arq.WriteLine(linhaCelula.ParaArquivo());
                else
                    arq.WriteLine((new Celula(null, null, linha, coluna, 0)).ParaArquivo());
                linhaCelula = linhaCelula.Abaixo;
            }
            coluna++;
            atual = atual.Direita;
        }
        arq.Close();
    }
}


