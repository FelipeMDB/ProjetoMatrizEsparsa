using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ListaCruzada
{
                                    //declaracao dos atributos da classe
    protected Celula cabeca;       //celulas cabeca são as células que apontão para a primeira posição da lista Ligada                               
    protected int qtasLinhas, qtasColunas;

    public ListaCruzada(int linhas, int colunas)              // instanciacao da classe
    {                                                        //parametros: linhas e colunas da matriz
        cabeca = new Celula(null, null, -1, -1, 0); 
        Celula primeira = cabeca;
        qtasLinhas = linhas;
        qtasColunas = colunas;

        if (qtasLinhas <= 0 || qtasColunas <= 0)        //verificamos se o usuario passou os parâmetros corretos
            throw new Exception("quantidade de linhas ou colunas inválida");

        for (int i = 1; i <= qtasColunas; i++)           //criamos as colunas e as celulas cabecas das colunas 
        {
            primeira.Direita = new Celula(null, null, 0, -1, 0);
            primeira = primeira.Direita;
            primeira.Abaixo = primeira;
        }
        primeira.Direita = cabeca;
        primeira = cabeca;

        for (int i = 1; i <= qtasLinhas; i++)        //criamos as linhas e as celulas cabecas das linhas 
        {
            primeira.Abaixo = new Celula(null, null, 0, -1, 0);
            primeira = primeira.Abaixo;
            primeira.Direita = primeira;
        }
        primeira.Abaixo = cabeca;       //posicionamos as cabecas na primeira posicao
    }


    //método booleano que verifica a existencia de uma celula da matriz
    //parâmetros: linha, coluna 
    private bool ExisteCelula(int linha, int coluna, ref Celula esquerda, ref Celula direita, ref Celula acima, ref Celula abaixo)
    {
        bool existe = false;             
        Celula atual = cabeca;

        for (int i = 1; i <= coluna; i++)   //posicionamos o atual na coluna desejada
            atual = atual.Direita;

        Celula cabecaColuna = atual;
        bool achouPosicao = false;
        acima = atual;      //posicionamos 'acima' na coluna desejada
        while (!achouPosicao)                
        {
            abaixo = acima.Abaixo;        //saimos da cabeca da coluna e vamos para a posicao abaixo
            if (abaixo == cabecaColuna)  //caso sejam iguais, 'achouPosicao' recebe true  
                achouPosicao = true;    

            else if (abaixo.Linha > linha)  //caso a posicao atual seja maior que a desejada, significa que a desejada se encontra
                achouPosicao = true;            //antes da atual, mas não existe uma celula nesta posicao

            else if (abaixo.Linha == linha) //caso a linha da atual seja igual a da desejada
            {                                   //retornamos true, pois se ja temos a coluna e encontramos a linha
                achouPosicao = true;           //significa que estamos na posição requsitada
                existe = true;                //também retornamos que há uma célula nesta posição 
            }

            if (!achouPosicao)  //caso não tenhamos encontrado a posicao desejada e não estejamos na cabeca 
                acima = acima.Abaixo;                    //da coluna, descemos para a próxima posição
        }
        //ao final deste método você acha a posicao das celulas que estão acima e abaixo da posição procurada 

        atual = cabeca;   //voltamos 'atual' para o no cabeca para assim nos posicionar na linha passada como parametro         
        for (int i = 1; i <= linha; i++) 
            atual = atual.Abaixo;

        Celula cabecaLinha = atual;     //uma celula de cabeca de linha é criada e é posicionada na linha passada de parametro
        achouPosicao = false;          
        esquerda = atual;
        //agora procuraremos as células à esquerda e à direita da posição desejada
        while (!achouPosicao)
        {
            direita = esquerda.Direita;   // posicionamos a direita 
            if (direita == cabecaLinha)  
                achouPosicao = true;    
            else if (direita.Linha > linha)     //se a posição atual é maior que a desejada, a desejada está em uma posição antes
                achouPosicao = true;                
            else if (direita.Linha == linha)  // caso a atual seja igual a desejada, encontramos a posição
                achouPosicao = true;

            if (!achouPosicao)    //caso não encontre a posição, segue para a próxima célula da linha
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

            Celula cabecaLinha = coluna;
            Celula linha = coluna;

            for (int l = 0; l < qtasLinhas; l++)
            {
                if (linha.Abaixo != cabecaLinha && linha.Abaixo.Linha.CompareTo(l + 1) == 0)
                {
                    linha = linha.Abaixo;
                    dgv.Rows[l].Cells[c].Value = linha.Valor;
                }
                else
                    dgv.Rows[l].Cells[c].Value = 0;
            }
        }
    }

    public double? Buscar(int linha, int coluna)
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
        return null;
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
                esquerda.Direita = direita.Direita;
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
        if (qtasLinhas == outra.qtasLinhas && qtasColunas == outra.qtasColunas)
        {
            ListaCruzada matrizSoma = new ListaCruzada(qtasLinhas, qtasColunas);

            Celula colunaThis = cabeca.Direita, colunaOutra = outra.cabeca.Direita;

            while (colunaThis != cabeca || colunaOutra != outra.cabeca)
            {
                if (colunaThis != cabeca && colunaOutra != outra.cabeca)
                {
                    Celula linhaCabecaThis = colunaThis, linhaCabecaOutra = colunaOutra;

                    Celula linhaThis = colunaThis.Abaixo, linhaOutra = colunaOutra.Abaixo;

                    while (linhaThis != linhaCabecaThis || linhaOutra != linhaCabecaOutra)
                    {
                        if (linhaThis != linhaCabecaThis && linhaOutra != linhaCabecaOutra)
                        {
                            if (linhaThis.Linha == linhaOutra.Linha)
                            {
                                if (linhaThis.Valor + linhaOutra.Valor != 0)
                                    matrizSoma.Inserir(linhaThis.Linha, linhaThis.Coluna, linhaThis.Valor + linhaOutra.Valor);
                                linhaThis = linhaThis.Abaixo;
                                linhaOutra = linhaOutra.Abaixo;
                            }
                            else if (linhaThis.Linha < linhaOutra.Linha)
                            {
                                matrizSoma.Inserir(linhaThis.Linha, linhaThis.Coluna, linhaThis.Valor);
                                linhaThis = linhaThis.Abaixo;
                            }
                            else
                            {
                                matrizSoma.Inserir(linhaOutra.Linha, linhaOutra.Coluna, linhaOutra.Valor);
                                linhaOutra = linhaOutra.Abaixo;
                            }

                        }
                        else if (linhaThis != linhaCabecaThis)
                        {
                            matrizSoma.Inserir(linhaThis.Linha, linhaThis.Coluna, linhaThis.Valor);
                            linhaThis = linhaThis.Abaixo;
                        }
                        else
                        {
                            matrizSoma.Inserir(linhaOutra.Linha, linhaOutra.Coluna, linhaOutra.Valor);
                            linhaOutra = linhaOutra.Abaixo;
                        }
                    }
                    colunaThis = colunaThis.Direita;
                    colunaOutra = colunaOutra.Direita;
                }
                else if (colunaThis != cabeca)
                {
                    Celula linhaCabeca = colunaThis;
                    Celula linha = colunaThis.Abaixo;
                    while (linha != linhaCabeca)
                    {
                        matrizSoma.Inserir(linha.Linha, linha.Coluna, linha.Valor);
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
                        matrizSoma.Inserir(linha.Linha, linha.Coluna, linha.Valor);
                        linha = linha.Abaixo;
                    }
                    colunaOutra = colunaOutra.Direita;
                }
            }
            return matrizSoma;
        }
        return null;
    }

    public ListaCruzada MultiplicarMatrizes(ListaCruzada outra, String triste)
    {
        ListaCruzada matrizMultiplicada = new ListaCruzada(qtasLinhas, outra.qtasColunas);

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

    public void Alterar(int linha, int coluna, double valor)
    {
        Celula acima = null, abaixo = null, direita = null, esquerda = null;
        
        if (ExisteCelula(linha, coluna, ref esquerda, ref direita, ref acima, ref abaixo))
        {
            if (valor == 0)
            {
                esquerda.Direita = direita.Direita;
                acima.Abaixo = abaixo.Abaixo;
            }
            else
                direita.Valor = valor;
        }
        else
        {
            Celula nova = new Celula(null, null, linha, coluna, valor);

            esquerda.Direita = nova;
            nova.Direita = direita;
            acima.Abaixo = nova;
            nova.Abaixo = abaixo;
        }
    }
}


