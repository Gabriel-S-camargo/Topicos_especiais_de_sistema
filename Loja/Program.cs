using Microsoft.AspNetCore.Mvc;
using Loja.Models;
using Loja.Services;
using Loja.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona o serviço do ProductService
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<FornecedorService>();

// Starta Conexão Com o BD 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LojaDbContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 37))));

var app = builder.Build();

// Configurar as requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();


// Novo MapGet pega todos os produtos usando o serviço ProductService
app.MapGet("/produtos", async (ProductService productService) =>
{
    var produtos = await productService.GetAllProductsAsync();
    return Results.Ok(produtos);
});

// Novo MapGet pega produtos pelo ID usando o serviço ProductService
app.MapGet("/produtos/{id}", async (int id, ProductService productService) =>
{
    var produto = await productService.GetProductByIdAsync(id);
    if (produto == null)
    {
        return Results.NotFound($"Product with ID {id} not found.");
    }
    return Results.Ok(produto);
});

// Novo MapPost cria um produto usando o serviço ProductService
app.MapPost("/createProdutos", async (Produto produto, ProductService productService) =>
{
    await productService.AddProductAsync(produto);
    return Results.Created($"/produtos/{produto.Id}", produto);
});

// Novo MapPut atualiza um produto usando o serviço ProductService
app.MapPut("/updateProdutos/{id}", async (int id, Produto produto, ProductService productService) =>
{
    if (id != produto.Id)
    {
        return Results.BadRequest("Product ID mismatch.");
    }
    await productService.UpdateProductAsync(produto);
    return Results.Ok();
});

// Novo MapDelete deleta um produto usando o serviço ProductService
app.MapDelete("/deleteProdutos/{id}", async (int id, ProductService productService) =>
{

    await productService.DeleteProductAsync(id);
    return Results.Ok("Produto Deletado");
});

// Endpoint's Cliente

// End point de criação do Cliente
app.MapPost("/createCliente", async (Cliente newCliente, ClienteService clienteService) =>
{
    await clienteService.AddClienteAsync(newCliente);
    return Results.Created($"createCliente/{newCliente.Id}", newCliente);
});

// EndPoint de mostrar todos Clientes cadastrados

app.MapGet("/Clientes", async (ClienteService clienteService) =>
{

    var Cliente = await clienteService.GetAllClienteAsync();

    return Results.Ok(Cliente);

});

// EndPoint para pesquisar Cliente por ID

// Lembrar que para procurar voce so precisa do LojaDbContext dbContext para criação e update precisa Model newModel ou updateModel

app.MapGet("Clientes/{id}", async (int id, ClienteService clienteService) =>
{

    var Cliente = await clienteService.GetClienteAsync(id);

    if (Cliente == null)
    {
        return Results.NotFound($"Nenhum registro de cliente com o ID {id}");
    }


    return Results.Ok(Cliente);

});

// EndPoint para editar um Cliente

app.MapPut("clienteUpdate/{id}", async (int id, ClienteService clienteService, Cliente updateCliente) =>
{
    if (id != updateCliente.Id)
    {
        return Results.BadRequest("O ID nao corresponde a um ID ja cadastrado");
    }

    await clienteService.UpdateClienteAsync(updateCliente);
    return Results.Ok();

});

// EndPoint para deletar um cliente

app.MapDelete("clienteDelete/{id}", async (int id, ClienteService clienteService) =>
{
    await clienteService.DeleteClienteAsync(id);
    return Results.Ok("Cliente deletado");
});

// EndPoint's para o fornecedor

// EndPoint de criação de fornecedor

app.MapPost("/createFornecedor", async (FornecedorService fornecedorService, Fornecedor newFornecedor) =>
{
    await fornecedorService.AddFornecedorAsync(newFornecedor);

    return Results.Created($"/createFornecedor/{newFornecedor.Id}", newFornecedor);
});

// EndPoint de Busca de todos os fornecedores

app.MapGet("/Fornecedores", async (FornecedorService fornecedorService) =>
{

    var fornecedor = await fornecedorService.GetAllFornecedorAsync();
    return Results.Ok(fornecedor);

});

// EndPoint de busca de Fornecedor por ID

app.MapGet("/Fornecedores/{id}", async (int id, FornecedorService fornecedorService) =>
{
    var fornecedor = await fornecedorService.GetFornecedorAsync(id);

    if (fornecedor == null)
    {
        return Results.NotFound($"Nenhum registro de cliente com o ID {id}");
    }

    return Results.Ok(fornecedor);

});

// EndPoint de alteração de dados de fornecedor por ID

app.MapPut("updateFornecedor/{id}", async (int id, FornecedorService fornecedorService, Fornecedor fornecedor) =>
{


    if (id != fornecedor.Id)
    {
        return Results.BadRequest("ID fornecedor não localizado nos registro");
    }

    await fornecedorService.UpdateFornecedorAsync(fornecedor);

    return Results.Ok(fornecedor);
});


// EndPoint para deletar fornecedor

app.MapDelete("deleteFornecedor/{id}", async (int id, FornecedorService fornecedorService) =>
{

    await fornecedorService.DeleteFornecedorAsync(id);

    return Results.Ok("Fornecedor Deletado com sucesso");

});

app.Run();


