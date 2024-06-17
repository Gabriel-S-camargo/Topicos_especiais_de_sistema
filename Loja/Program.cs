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
    return Results.Ok();
});

app.Run();


// Endpoint's Cliente

// End point de criação do Cliente
app.MapPost("/createCliente", async (LojaDbContext dbContext, Cliente newCliente) =>
{
    dbContext.Clientes.Add(newCliente);
    await dbContext.SaveChangesAsync();
    return Results.Created($"createCliente/{newCliente.Id}", newCliente);
});

// EndPoint de mostrar todos Clientes cadastrados

app.MapGet("/Clientes", async (LojaDbContext dbContext) =>
{

    var Cliente = await dbContext.Clientes.ToListAsync();

    return Results.Ok(Cliente);

});

// EndPoint para pesquisar Cliente por ID

// Lembrar que para procurar voce so precisa do LojaDbContext dbContext para criação e update precisa Model newModel ou updateModel

app.MapGet("Clientes/{id}", async (int id, LojaDbContext dbContext) =>
{

    var Cliente = await dbContext.Clientes.FindAsync(id);

    if (Cliente == null)
    {
        return Results.NotFound($"Nenhum registro de cliente com o ID {id}");
    }


    return Results.Ok(Cliente);

});

// EndPoint para editar um Cliente

app.MapPut("ClientesUpdate/{id}", async (int id, LojaDbContext dbContext, Cliente updateCliente) =>
{

    var existingCliente = await dbContext.Clientes.FindAsync(id);

    if (existingCliente == null)
    {
        return Results.NotFound($"Nenhum registro de Cliente com o ID{id}");
    }

    existingCliente.Nome = updateCliente.Nome;
    existingCliente.Cpf = updateCliente.Cpf;
    existingCliente.Email = updateCliente.Email;

    await dbContext.SaveChangesAsync();

    return Results.Ok(existingCliente);

});

// EndPoint's para o fornecedor

// EndPoint de criação de fornecedor

app.MapPost("/createFornecedor", async (LojaDbContext dbContext, Cliente newFornecedor) =>
{
    dbContext.Add(newFornecedor);
    await dbContext.SaveChangesAsync();

    return Results.Created($"/createFornecedor/{newFornecedor.Id}", newFornecedor);
});

// EndPoint de Busca de todos os fornecedores

app.MapGet("/Fornecedores", async (LojaDbContext dbContext) =>
{
    var Fornedores = await dbContext.Fornecedores.ToListAsync();

    return Results.Ok(Fornedores);
});

// EndPoint de busca de Fornecedor por ID

app.MapGet("/Fornecedores/{id}", async(int id, LojaDbContext dbContext) =>{
    var Fornecedor = await dbContext.Fornecedores.FindAsync(id);

    if(Fornecedor == null){
        return Results.NotFound($"Nenhum fornecedor com o ID {id} encontrado");
    }

    return Results.Ok(Fornecedor);
});

// EndPoint de alteração de dados de fornecedor por ID

app.MapPut("updateFornecedor/{id}", async(int id, LojaDbContext dbContext, Fornecedor updateFornecedor)=>{
    var existingFornecedor = await dbContext.Fornecedores.FindAsync(id);

    if(existingFornecedor == null){
        return Results.NotFound($"Nenhum fornecedor com o ID {id} encontrado");
    }

    existingFornecedor.Nome = updateFornecedor.Nome;
    existingFornecedor.Cnpj = updateFornecedor.Cnpj;
    existingFornecedor.Endereco = updateFornecedor.Endereco;
    existingFornecedor.Email = updateFornecedor.Email;
    existingFornecedor.Telefone = updateFornecedor.Telefone;

    await dbContext.SaveChangesAsync();

    return Results.Ok(existingFornecedor);
});

app.Run();


