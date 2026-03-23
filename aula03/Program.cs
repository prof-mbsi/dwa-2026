using System;

enum DiasDaSemana
{
    Domingo,
    Segunda,
    Terca
}

public class Pessoa
{
    public string Nome;
    public int Idade;

    public static (string Nome, int Idade) CriarPessoa()
    {
        return ("Cidadão", 28);
    }
}


class Program
{
    static void Main()
    {

        Console.WriteLine("Teste!");
        //Var
        var numero = 10;
        var texto = "Uma string qualquer";
        Console.WriteLine($"numero: {numero}, texto: {texto}");

        //Cast explícito
        double x = 9.7;
        int y = (int)x;
        Console.WriteLine($"y: {y}");

        Console.WriteLine("Informe valor inteiro: ");
        //int valorInformado = int.Parse(Console.ReadLine());
        int.TryParse(Console.ReadLine(), out int valor);
        Console.WriteLine($"Valor informado: {valor}");

        //Tupla
        var pessoa = (Nome: "Carlos", Idade: 40);
        Console.WriteLine(pessoa.Nome);

        DiasDaSemana hoje = DiasDaSemana.Segunda;
        Console.WriteLine(hoje);

        string nome = "Marlon";
        Console.WriteLine(nome ?? "Sem nome");

        string mensagem = "Minha mensagem ...";
        mensagem ??= "Mensagem padrão";
        Console.WriteLine(mensagem);

        Pessoa p = null;
        Console.WriteLine(p?.Nome);

        int opcao = 2;

        string resultado = opcao switch
        {
            1 => "Um",
            2 => "Dois",
            _ => "Outro"
        };

        Console.WriteLine($"Resultado: {resultado}");

        for (int j = 0; j < 10; j++)
        {
            if (j == 5) continue;
            if (j == 8) break;
            Console.WriteLine(j);
        }

        var pessoa1 = Pessoa.CriarPessoa();
        Console.WriteLine($"{pessoa1.Nome}, idade: {pessoa1.Idade}");

        int[] valores = { 1, 2, 3, 4, 5 };
        var pares = valores.Where(v => v % 2 == 0);
        foreach (var par in pares)
        {
            Console.WriteLine(par);
        }
    }
}