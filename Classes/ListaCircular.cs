using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ListaCircular
{
    protected Celula cabeca;
    protected int qtasLinhas, qtasColunas;

    public ListaCircular(int linhas, int colunas)
    {
        cabeca = new Celula(null, null, -1, -1, 0);
        Celula primeira = cabeca;

        for (int i = 0; i < colunas; i++)
        {
            cabeca.Direita = new Celula(null, null, 0, -1, 0);
            cabeca = cabeca.Direita;
        }
        cabeca.Direita = primeira;
        cabeca = primeira;

        for (int i = 0; i < linhas; i++)
        {
            cabeca.Abaixo = new Celula(null, null, 0, -1, 0);
            cabeca = cabeca.Direita;
        }
        cabeca.Abaixo = primeira;
        cabeca = primeira;
    }

    public bool ExisteCelula(int linha, int coluna, ref Celula esquerda, ref Celula direita, ref Celula acima, ref Celula abaixo)
    {
        Celula atual = cabeca;

        Celula nova = new Celula(null, null, linha, coluna, 0);

        for (int i = 0; i <= coluna; i++)
            atual = atual.Direita;

        bool achouPosicao = false;
        acima = atual;
        while (!achouPosicao)
        {
            abaixo = atual.Abaixo;
            if (abaixo.Linha > nova.Linha)
                achouPosicao = true;

            else if (abaixo.Linha == nova.Linha)
                return true;

            acima = acima.Abaixo;
        }

        atual = cabeca;
        for (int i = 0; i <= linha; i++)
            atual = atual.Abaixo;

        achouPosicao = false;
        esquerda = atual;
        while (!achouPosicao)
        {
            direita = esquerda.Direita;
            if (direita.Linha > nova.Linha)
                achouPosicao = true;

            esquerda = esquerda.Direita;
        }

        return false;
    }

    public void AdicionarCelula(int linha, int coluna, int valor)
    {
        Celula acima = null, abaixo = null, direita = null, esquerda = null;

        Celula nova = new Celula(null, null, linha, coluna, valor);

        if(!ExisteCelula(linha, coluna, ref esquerda, ref direita, ref acima, ref abaixo))
        {
            esquerda.Direita = nova;
            nova.Direita = direita;
            acima.Abaixo = nova;
            nova.Abaixo = abaixo;
        }
    }
}

