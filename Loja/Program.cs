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

    if (existingProduto == null)
    {
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


