﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Celula : IGravarEmArquivo
{
    protected Celula abaixo;  //c
    protected Celula direita;
    protected double valor;
    protected int linha;
    protected int coluna;

    public Celula(Celula abaixo, Celula direita, int linha, int coluna, double valor)
    {
        Abaixo = abaixo;
        Direita = direita;
        Coluna = coluna;
        Linha = linha;
        Valor = valor;
    }

    public static Celula LerRegistro(StreamReader arq)
    {
        int li = 0, col = 0;
        double val=0;
        if(!arq.EndOfStream)
        {
            string[] linha = arq.ReadLine().Split();
            li = int.Parse(linha[0]);
            col = int.Parse(linha[1]);
            val = double.Parse(linha[2]);
        }
        return new Celula(null, null, li, col, val);
    }

    public override string ToString()
    {
        return $"({linha}, {coluna}, {valor})";
    }

    public string ParaArquivo()
    {
        return linha + " " + coluna + " " + valor;
    }

    public Celula Abaixo { get => abaixo; set => abaixo = value; }
    public Celula Direita { get => direita; set => direita = value; }
    public double Valor { get => valor; set => valor = value; }
    public int Coluna { get => coluna; set => coluna = value; }
    public int Linha { get => linha; set => linha = value; }
}

