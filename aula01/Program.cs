using System;

public class Produto
{
    private string Nome { get; set; }
    public double Preco { get; set; }

    public Produto(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public void exibiDados()
    {
        Console.WriteLine($"Produto: {Nome}, preço: R${Preco}");
    }
}

public class Venda
{
    private Produto[] produtos { get; set; }

    public Venda(Produto[] produtos)
    {
        this.produtos = produtos;
    }

    public double calcularTotal()
    {
        double total = 0;
        for (int i = 0; i < produtos.Length; i++)
        {
            total += produtos[i].Preco;
        }
        return total;
    }
}

class Program
{
    static void Main()
    {
        Produto p1 = new Produto("Água", 3.5);
        p1.exibiDados();
        Produto p2 = new Produto("Coca-cola", 5.0);
        Produto p3 = new Produto("Guaraná", 5.5);

        Produto[] listaDeProdutos = { p1, p2, p3 };


        Venda v1 = new Venda(listaDeProdutos);
        Console.WriteLine($"Total da venda {v1.calcularTotal()}");

    }
}