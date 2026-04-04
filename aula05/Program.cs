using System;

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
}

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        //Primeiro endpoint:
        app.MapGet("/api/teste", () => "API funcionando!");

        //Endpoint recebendo objeto Pessoa
        app.MapPost("/api/pessoa", (Pessoa pessoa) =>
        {
            return $"Recebi {pessoa.Nome} com {pessoa.Idade} anos";
        });

        //Endpoint checando idade do objeto Pessoa
        app.MapPost("/api/pessoa/idade", (Pessoa pessoa) =>
        {
            if (pessoa.Idade >= 18)
                return "Maior de idade";
            return "Menor de idade";
        });

        //Endpoint retornando JSON:
        app.MapPost("/api/pessoa/resumo", (Pessoa pessoa) =>
        {
            return new
            {
                pessoa.Nome,
                pessoa.Idade,
                Status = pessoa.Idade >= 18 ? "Adulto" : "Jovem"
            };
        });

        //Endpoints de Produto:
        var produtos = new List<Produto>();
        int idProduto = 1;

        //Adiciona novo Produto
        app.MapPost("/api/produtos", (Produto produto) =>
        {
            produto.Id = idProduto++;
            produtos.Add(produto);
            return produto;
        });

        //Retorna lista de produtos
        app.MapGet("/api/produtos", () => produtos);

        app.Run();
    }
}