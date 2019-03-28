using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Celula
{
    protected Celula abaixo;
    protected Celula direita;
    protected int valor;
    protected int linha;
    protected int coluna;

    public Celula(Celula abaixo, Celula direita, int linha, int coluna, int valor)
    {
        Abaixo = abaixo;
        Direita = direita;
        Coluna = coluna;
        Linha = linha;
        Valor = valor;
    }

    public override string ToString()
    {
        return $"({linha}, {coluna}, {valor})";
    }

    public Celula Abaixo { get => abaixo; set => abaixo = value; }
    public Celula Direita { get => direita; set => direita = value; }
    public int Valor { get => valor; set => valor = value; }
    public int Coluna { get => coluna; set => coluna = value; }
    public int Linha { get => linha; set => linha = value; }
}

