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
        bool existe = ExisteColuna(linha, coluna, ref acima, ref abaixo);

        ExisteLinha(linha, coluna, ref esquerda, ref direita);

        return existe;
    }

    private bool ExisteLinha(int linha, int coluna, ref Celula esquerda, ref Celula direita)
    {
        Celula atual = cabeca;   //voltamos 'atual' para o no cabeca para assim nos posicionar na linha passada como parametro         
        for (int i = 1; i <= linha; i++)
            atual = atual.Abaixo;

        Celula cabecaLinha = atual;     //uma celula de cabeca de linha é criada e é posicionada na linha passada de parametro
        bool achouPosicao = false;
        bool existe = false;
        esquerda = atual;
        //agora procuraremos as células à esquerda e à direita da posição desejada
        while (!achouPosicao)
        {
            direita = esquerda.Direita;   // posicionamos a direita 
            if (direita == cabecaLinha)
                achouPosicao = true;
            else if (direita.Coluna > coluna)     //se a posição atual é maior que a desejada, a desejada está em uma posição antes
                achouPosicao = true;
            else if (direita.Coluna == coluna)  // caso a atual seja igual a desejada, encontramos a posição
                achouPosicao = true;

            if (!achouPosicao)    //caso não encontre a posição, segue para a próxima célula da linha
                esquerda = esquerda.Direita;
        }

        return existe;
    }

    private bool ExisteColuna(int linha, int coluna, ref Celula acima, ref Celula abaixo)
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

        return existe;
    }

    public void Listar(DataGridView dgv)
    {
        //limpa grid view para garantir que está vazio antes de listar
        dgv.Columns.Clear();
        dgv.Rows.Clear(); 
        
        //define quantidade de linhas e colunas do grid de acordo com os valores da matriz
        dgv.RowCount = qtasLinhas;
        dgv.ColumnCount = qtasColunas;

        //Celula que irá percorrer as colunas da matriz
        Celula coluna = cabeca;

        for (int c = 0; c < qtasColunas; c++) //percorre-se até acabar colunas (poderia usar while(coluna != cabeca) também)
        {
            coluna = coluna.Direita; // percorre para o próximo nó cabeça de coluna

            Celula cabecaLinha = coluna;
            Celula linha = coluna; // vai para a primeira linha da coluna

            for (int l = 0; l < qtasLinhas; l++) //percorre-se até acabar quantidade de linhas
            {
                if (linha.Abaixo != cabecaLinha && linha.Abaixo.Linha.CompareTo(l + 1) == 0) //se a linha não for igual à coluna, ou seja, 
                                                                                             //ela não ser a cabeca e se a linha da Celula que percorre as 
                                                                                             //linhas for a linha que se quer
                {
                    linha = linha.Abaixo; //vai para a próxima linha
                    dgv.Rows[l].Cells[c].Value = linha.Valor; //adiciona ao grid view o valor da linha
                }
                else
                    dgv.Rows[l].Cells[c].Value = 0; //se a linha for a cabeca ou não for igual a linha que se quer(l+1), quer dizer 
                                                    //que esta posição não foi guardada, ou seja, é 0
            }
        }
    }

    public double? Buscar(int linha, int coluna)
    {
        if (linha <= qtasLinhas && linha > 0 && coluna <= qtasColunas && coluna > 0) //verifica-se se linha e coluna fornecidos estão nos limites da matriz
        {
            Celula acima = null, abaixo = null;//celulas para método existeColuna

            if (ExisteColuna(linha, coluna, ref acima, ref abaixo)) //abaixo é o valor procurado
            {
                return abaixo.Valor;
            }
            return 0; //se não existir, valor é 0
        }
        return null; //retorna null se for fora dos limites da matriz
    }

    public bool Inserir(int linha, int coluna, double valor) 
    {
        if (linha <= qtasLinhas && coluna <= qtasColunas && valor != 0) //verifica se está dentro dos limites da matriz e o valor não é 0
        {
            Celula acima = null, abaixo = null, direita = null, esquerda = null;

            if (!ExisteColuna(linha, coluna, ref acima, ref abaixo)) //procura para saber se existe
            {
                ExisteLinha(linha, coluna, ref esquerda, ref direita); //para pegar posições esquerda e direita apenas se existe, deixando o processo mais rápido

                Celula nova = new Celula(null, null, linha, coluna, valor); //célula nova que será inserida
                esquerda.Direita = nova; //anterior na horizontal aponta para nova
                nova.Direita = direita; //nova aponta para posterior na horizontal
                acima.Abaixo = nova; //anterior na vertical aponta para nova
                nova.Abaixo = abaixo;  //nova aponta para anterior na vertical

                return true; //retorna true, pois inseriu
            }
            else
                return false; //retorna false, pois não inseriu
        }
        else
            return false; //retorna false, pois não inseriu
    }

    public bool Remover(int linha, int coluna)
    {
        if (linha > 0 && linha <= qtasLinhas && coluna > 0 && coluna <= qtasColunas)
        {
            Celula acima = null, abaixo = null, direita = null, esquerda = null;

            if (ExisteColuna(linha, coluna, ref acima, ref abaixo)) //verifica se a posição para remover está ocupada
            {
                ExisteLinha(linha, coluna, ref esquerda, ref direita); //para pegar posições esquerda e direita apenas se existe, deixando o processo mais rápido

                esquerda.Direita = direita.Direita; //anterior horizontal aponta para posterior na horizontal, ou seja, se exclui apontadores da celula do meio
                acima.Abaixo = abaixo.Abaixo; //anterior vertical aponta para posterior na vertical, ou seja, se exclui apontadores da celula do meio
            }
            return true; //retorna true, pois excluiu ou já não existia
        }
        else
            return false; //retorna false, pois posição era inválida
    }

    public void LimparMatriz() //nós cabeças voltam a apontar para si mesmos onde se tinham valores
    {
        for (Celula atual = cabeca.Abaixo; atual != cabeca; atual = atual.Abaixo)
        {
            atual.Direita = atual;
        }

        for (Celula atual = cabeca.Direita; atual != cabeca; atual = atual.Direita)
        {
            atual.Abaixo = atual;
        }
    }

    public void SomarConstanteK(int coluna, double k)
    {
        if (k != 0)
        {
            Celula atual = cabeca.Direita;
            for (int i = 2; i <= coluna; i++) //percorre-se por cabeças até a que corresponder à coluna desejada
                atual = atual.Direita;

            Celula atualCabeca = atual; //guarda-se a cabeça, pois atual percorrerá para baixo
            atual = atual.Abaixo; //primeira posição válida da coluna de nó cabeca "atualCabeca"

            int linha = 1;
            while (linha <= qtasLinhas) //enquanto não se percorrer todas as linhas
            {
                if (atual == atualCabeca || atual.Linha != linha) //se o atual tiver voltado a ser o cabeça mas ainda não se acabou a quantidade de linhas ou
                                                                  // se a próxima celula linha não corresponder à linha desejada, adiciona-se uma celula com o valor a ser somado
                    Inserir(linha, coluna, k);
                else
                {
                    if (atual.Valor + k == 0) //se a soma resultar em 0, apaga-se a célula
                        Remover(atual.Linha, atual.Coluna);
                    else
                        atual.Valor = atual.Valor + k; //se a soma tiver sucesso, soma-se os valores

                    atual = atual.Abaixo; //desce atual
                }

                linha++; //aumenta na contagem de linhas
            }
        }
    }

    public ListaCruzada SomarMatrizes(ListaCruzada outra) //método responsável por realizar a soma de duas matrizes
    {
        ListaCruzada matrizSoma = null;
        if (qtasLinhas == outra.qtasLinhas && qtasColunas == outra.qtasColunas)  //verificamos se as matrizes são de dimensões iguais   
        {
            matrizSoma = new ListaCruzada(qtasLinhas, qtasColunas); //instanciamos a matriz que será o resultado

            Celula colunaThis = cabeca.Direita, colunaOutra = outra.cabeca.Direita;  //criamos as celulas de cabeca de linha e coluna 
                                                                             //que serão utilizadas como parametro ao longo do método
            while (colunaThis != cabeca || colunaOutra != outra.cabeca)     //enquanto a coluna não tiver acabado
            {
                if (colunaThis != cabeca && colunaOutra != outra.cabeca)   //se as colunas não estiverem na cabeça da matriz 
                {
                    Celula linhaCabecaThis = colunaThis, linhaCabecaOutra = colunaOutra; //criamos cabecas de linha e as posicionamos

                    Celula linhaThis = colunaThis.Abaixo, linhaOutra = colunaOutra.Abaixo; // posicionamos a variavel na celula

                    while (linhaThis != linhaCabecaThis || linhaOutra != linhaCabecaOutra) //enquanto não percorrer toda a linha
                    {
                        if (linhaThis != linhaCabecaThis && linhaOutra != linhaCabecaOutra) //se a linha não estiver vazia
                        {
                            if (linhaThis.Linha == linhaOutra.Linha)  // se elas estiverem na mesma linha, significa que há valor 
                            {                                        //nas duas matrizes nesta posição
                                if (linhaThis.Valor + linhaOutra.Valor != 0) //se a soma dos valores for diferente de zero
                                    matrizSoma.Inserir(linhaThis.Linha, linhaThis.Coluna, linhaThis.Valor + linhaOutra.Valor); //inserimos na matriz a soma
                                linhaThis = linhaThis.Abaixo;   //descemos para a próxima linha
                                linhaOutra = linhaOutra.Abaixo;
                            }

                            //se a linha atual for menor, significa que na outra matriz
                            //não há nenhum valor na linha da matriz this
                            else if (linhaThis.Linha < linhaOutra.Linha) 
                            {
                                //portanto apenas inserimos ['this' na matriz e seguimos para a próxima linha
                                matrizSoma.Inserir(linhaThis.Linha, linhaThis.Coluna, linhaThis.Valor);
                                linhaThis = linhaThis.Abaixo;
                            }

                            //no caso abaixo não há nenhum valor nesta linha na this, mas há na outra
                            //portanto apenas inserimos a outra na nova matriz
                            else
                            {
                                matrizSoma.Inserir(linhaOutra.Linha, linhaOutra.Coluna, linhaOutra.Valor);
                                linhaOutra = linhaOutra.Abaixo;
                            }

                        }
                        //se só a this é diferente da cabeça da coluna
                        //inserimos a celula da this na nova matriz
                        //e seguimos para a próxima linha da this
                        else if (linhaThis != linhaCabecaThis)
                        {
                            matrizSoma.Inserir(linhaThis.Linha, linhaThis.Coluna, linhaThis.Valor); 
                            linhaThis = linhaThis.Abaixo;
                        }

                        //se só a outra é diferente da cabeça da coluna
                        //inserimos a celula da outra na nova matriz
                        //e seguimos para a próxima linha da outra
                        else
                        {
                            matrizSoma.Inserir(linhaOutra.Linha, linhaOutra.Coluna, linhaOutra.Valor);
                            linhaOutra = linhaOutra.Abaixo;
                        }
                    }

                    //seguimos para a próxima coluna
                    colunaThis = colunaThis.Direita;
                    colunaOutra = colunaOutra.Direita;
                }

                //caso só a coluna da this seja diferente da cabeca, significa que não tem mais nada na outra
                //apenas precisaremos inserir os valores da coluna da this
                //e por fim prosseguimos para a proxima coluna de this 
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

                //caso só a coluna da toutrahis seja diferente da cabeca, significa que não tem mais nada na this
                //apenas precisaremos inserir os valores da coluna da outra
                //e por fim prosseguimos para a proxima coluna de outra 
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
            return matrizSoma; //retornamos a matriz somada
        }
        return matrizSoma; //retorna null caso as matrizes não sejam de tamanho igual 
    }

    public ListaCruzada MultiplicarMatrizes(ListaCruzada outra)
    {
        ListaCruzada matrizMultiplicada = null;

        if (qtasColunas == outra.qtasLinhas) //para as matrizes serem compatíveis para multiplicação o numero de colunas de uma deve ser igual ao numero de linhas da outra
        {
            matrizMultiplicada = new ListaCruzada(qtasLinhas, outra.qtasColunas); //a matriz resultante possui o numero de linhas da primeira e de colunas da segunda

            Celula cabecaThis = cabeca.Abaixo; // cabecaThis representa as cabecas das linhas do this

            int linha = 1; //começa na linha 1
            while (cabecaThis != cabeca) //as cabecas das linhas do this são percorridas até que se retorne à cabeca
            {
                int coluna = 1; //começa na coluna 1
                Celula cabecaOutra = outra.cabeca.Direita; // cabecaOutra representa as cabecas das colunas da matriz outra 

                while (cabecaOutra != outra.cabeca) // as cabecas das colunas da outra são percorridas até que se retorne à cabeca desta
                {
                    Celula atualColunaOutra = cabecaOutra.Abaixo; //percorre as linhas referentes à coluna apontada pelo cabecaOutra
                    Celula atualLinhaThis = cabecaThis.Direita; //percorre as colunas referentes à linha apontada pelo cabecaThis

                    double resultado = 0; //armazena o resultado da multiplicação
                    while (atualColunaOutra != cabecaOutra && atualLinhaThis != cabecaThis) //percorre até que um dos atuais chegue à sua cabeça correspondente
                    {
                        if (atualLinhaThis.Coluna == atualColunaOutra.Linha) //na multiplicação a coluna da primeira matriz
                                                                             // será multiplicada à linha de numero correspondente da outra, por isso verificamos
                                                                             // se os seus valores correspondem
                        { 
                            resultado += atualLinhaThis.Valor * atualColunaOutra.Valor; //multiplica-se os elementos e se soma a resultado
                            atualColunaOutra = atualColunaOutra.Abaixo; //anda atualColunaOutra
                            atualLinhaThis = atualLinhaThis.Direita;    //anda atualLinhaThis
                        }

                        else if (atualLinhaThis.Coluna > atualColunaOutra.Linha) //se não corresponderem e a coluna do this for maior que a linha do outra, apenas a outra anda
                            atualColunaOutra = atualColunaOutra.Abaixo;

                        else //se o contrário dos anteriores ocorrer, apenas a linha anda
                            atualLinhaThis = atualLinhaThis.Direita;
                    }

                    matrizMultiplicada.Inserir(linha, coluna, resultado); //insere-se o resultado na matriz multiplicada, na linha e coluna contadas pelas variáveis linha e coluna

                    cabecaOutra = cabecaOutra.Direita; //anda para a próxima cabeça
                    coluna++; //aumenta coluna
                }

                cabecaThis = cabecaThis.Abaixo; //anda para a próxima cabeça
                linha++; //aumenta linha
            }
        }

        return matrizMultiplicada; //retorna a matriz multiplicada que, se os elementos não forem compatíveis, é null
    }


    //este método grava os valores e posições da matriz no próprio arquivo txt do qual ela foi lida
    public void Gravar(StreamWriter arq )   
    {
        //adotamos por padrão que a primeira linha indica a quantidade de linhas e colunas, portanto na primeira leitura salvamos
        //estes respectivos valores
        arq.WriteLine(qtasLinhas + " " + qtasColunas); 
        
        Celula atual = cabeca.Direita;
        int coluna = 1;
        while (atual != cabeca)
        {
            int linha = 1;
            Celula linhaCelula = atual.Abaixo;
            Celula cabecaLinha = atual;
            while (linha <= qtasLinhas)
            {
                if (linhaCelula != cabecaLinha && linhaCelula.Linha == linha)
                {
                    arq.WriteLine(linhaCelula.ParaArquivo());
                    linhaCelula = linhaCelula.Abaixo;
                }
                else
                    arq.WriteLine((new Celula(null, null, linha, coluna, 0)).ParaArquivo());


                linha++;
            }
            coluna++;
            atual = atual.Direita;
        }
        arq.Close();
    }

    public bool Alterar(int linha, int coluna, double valor)
    {
        Celula acima = null, abaixo = null;
        
        if (ExisteColuna(linha, coluna, ref acima, ref abaixo)) //procura-se apenas pela coluna
        {
            if (valor == 0)
            {
                Celula direita = null, esquerda = null;
                ExisteLinha(linha, coluna, ref esquerda, ref direita); //pega-se direita e esquerda para excluir, não chamamos método remover para não se procurar abaixo e acima novamente

                esquerda.Direita = direita.Direita;
                acima.Abaixo = abaixo.Abaixo;
                return true;
            }
            else
            {
                abaixo.Valor = valor;
                return true;
            }
        }
        else
        {
            Celula nova = new Celula(null, null, linha, coluna, valor);

            Celula direita = null, esquerda = null;
            ExisteLinha(linha, coluna, ref esquerda, ref direita); //pega-se direita e esquerda para incluir, não chamamos método inserir para não se procurar abaixo e acima novamente

            esquerda.Direita = nova;
            nova.Direita = direita;
            acima.Abaixo = nova;
            nova.Abaixo = abaixo;

            return true;
        }
    }
}


