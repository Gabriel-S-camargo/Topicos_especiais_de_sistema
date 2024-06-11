using Microsoft.EntityFrameworkCore;
using Loja.Data;
using Loja.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Starta Conexão Com o BD 

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LojaDbContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 37))));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Esse MapPost Cria um produto no Banco de Dados

app.MapPost("/criarproduto", async (LojaDbContext dbContext, Produto newProduto) =>
{
    dbContext.Produtos.Add(newProduto);
    await dbContext.SaveChangesAsync();

    return Results.Created($"/criarproduto/{newProduto.Id}", newProduto);
});

//Esse MapGet pega os registros na tabela Produtos

app.MapGet("/produtos", async (LojaDbContext dbContext) =>
{
    var produtos = await dbContext.Produtos.ToListAsync();
    return Results.Ok(produtos);
});

// Esse mapGet pega produtos pelo ID a partir da url e retorna mensagem de erro caso não se achado

app.MapGet("/produto/{id}", async (int id, LojaDbContext dbContext) =>
{
    var produto = await dbContext.Produtos.FindAsync(id);

    if (produto == null)
    {
        return Results.NotFound($"Produto com o ID {id} not found");
    }

    return Results.Ok(produto);
});

// Esse mapPut atualiza um registro no Banco de Dados com novas informações

app.MapPut("/produtos/{id}", async (int id, LojaDbContext dbContext, Produto updateProduto) =>
{
    //Verifica se o Produto passado na URL existe

    var existingProduto = await dbContext.Produtos.FindAsync(id);

    if(existingProduto == null){
        return Results.NotFound($"Produto com o ID {id} not found");
    }

    // Depois de testado ele vai fazer as alterações no Banco de Dados
    // Atualiza as infos a partir da requisição no Body do JSON
    // aqui ele pega o Objeto que é do produto existente e atualiza a partir dos valores dos atributos do updateProduto que esta recebendo os valores do JSON

    existingProduto.Nome = updateProduto.Nome;
    existingProduto.Preco = updateProduto.Preco;
    existingProduto.Fornecedor = updateProduto.Fornecedor;


    // Faz um await que salva as infos no BD
    await dbContext.SaveChangesAsync();

    // Retorna Pro Cliente que deu Boa

    return Results.Ok(existingProduto);


});

app.Run();


