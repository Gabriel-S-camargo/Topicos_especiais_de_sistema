using Microsoft.AspNetCore.Mvc;
using Loja.Models;
using Loja.Services;
using Loja.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona o serviço do ProductService
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<FornecedorService>();
builder.Services.AddScoped<UsuarioService>();

// Starta Conexão Com o BD 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LojaDbContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 37))));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Options =>
{
    Options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("abc"))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Métodos do usuário

// Mappost Para o Login e Fornecer o Token de autenticação para o usuário

app.MapPost("/login", async (UsuarioService usuarioService, Usuario usuario, HttpContext context) =>
{
    var user = await usuarioService.GetUsuarioByLoginAsync(usuario.Login);

    if (user != null)
    {
        if (user.Senha == usuario.Senha)
        {
            var token = GenerateToken(usuario.Login);

            return Results.Ok(new { message = $"Bem Vindo {usuario.Login}!", token = token });
        }
        else
        {
            return Results.BadRequest("Senha inválida");
        }
    }
    else
    {
        return Results.BadRequest("Usuário Inválido");
    }

    string GenerateToken(string data)
    {
        var tokenHanler = new JwtSecurityTokenHandler();
        var secretKey = Encoding.ASCII.GetBytes("asdcasdcasdcasdcasdcasdcasdcasdc");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(1), // o token expira em uma hora
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenHanler.CreateToken(tokenDescriptor);
        return tokenHanler.WriteToken(token);
    }
});
// Estabelecimento de Rota segura com a validação do token 

app.MapGet("/rotaSegura", async (HttpContext context) =>
{
    //Verificar se o token está presente
    if (!context.Request.Headers.ContainsKey("Authorization"))
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsync("Token não fornecido");
    }
    //Obter o token
    var token =
    context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
    //Validar o token
    /*Esta lógica será convertida em um método dentro de uma classe a ser
    reaproveitada*/
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes("abcabcabcabcabcabcabcabcabcabcabc");
    //Chave secreta (a mesma utilizada para gerar o token)
    var validationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
    SecurityToken validateToken;
    try
    {
        //Decodifica, verifica e valida o token
        tokenHandler.ValidateToken(token, validationParameters, out
        validateToken);
    }
    catch (Exception)
    {
        //Caso o token seja inválido
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsync("Token inválido");
    }
    //Se o token é válido: dar andamento na lógica do endpoint
    await context.Response.WriteAsync("Autorizado");
});

// Métodos do usuário 

app.MapGet("/rotaSegura/usuarios", async (UsuarioService usuarioService) =>
{
    var usuarios = await usuarioService.GetAllUsuariosAsync();
    if (usuarios != null)
    {

        return Results.Ok(usuarios);
    }

    return Results.BadRequest("Nenhum Usuário Cadastrado");
});

app.MapGet("/rotaSegura/usuario/{id}", async (UsuarioService usuarioService, int id) =>
{
    var usuario = await usuarioService.GetUsuarioByIdAsync(id);

    if (usuario != null)
    {
        return Results.Ok(usuario);
    }

    return Results.BadRequest($"Nenhum usuário com o ID {id} Localizado");
});

app.MapPost("/addUsuario", async (UsuarioService usuarioService, Usuario usuario) =>
{

    await usuarioService.AddUsuarioAsync(usuario);

    return Results.Created($"rotaSegura/Usuario/{usuario.Id}", usuario);

});

app.MapPut("/rotaSegura/updateUsuario/{id}", async (UsuarioService usuarioService, int id, Usuario usuario) =>
{
    var userFound = await usuarioService.GetUsuarioByIdAsync(id);

    if (userFound != null)
    {
        await usuarioService.UpdateUsuarioAsync(id, usuario);

        return Results.Created($"/rotaSegura/usuario/{id}", usuario);
    }
    else
    {
        return Results.BadRequest("Usuario não localizado no sistema");
    }
});

app.MapDelete("/rotaSegura/deleteUsuario/`{id}", async (UsuarioService usuarioService, int id) =>
{
    await usuarioService.DeleteUsuarioAsync(id);

    return Results.Ok($"Usuario com o ID{id} deletado");

});



// Novo MapGet pega todos os produtos usando o serviço ProductService
app.MapGet("/rotaSegura/produtos", async (ProductService productService) =>
{
    var produtos = await productService.GetAllProductsAsync();
    return Results.Ok(produtos);
});

// Novo MapGet pega produtos pelo ID usando o serviço ProductService
app.MapGet("/rotaSegura/produtos/{id}", async (int id, ProductService productService) =>
{
    var produto = await productService.GetProductByIdAsync(id);
    if (produto == null)
    {
        return Results.NotFound($"Product with ID {id} not found.");
    }
    return Results.Ok(produto);
});

// Novo MapPost cria um produto usando o serviço ProductService
app.MapPost("/rotaSegura/createProdutos", async (Produto produto, ProductService productService) =>
{
    await productService.AddProductAsync(produto);
    return Results.Created($"/produtos/{produto.Id}", produto);
});

// Novo MapPut atualiza um produto usando o serviço ProductService
app.MapPut("/rotaSegura/updateProdutos/{id}", async (int id, Produto produto, ProductService productService) =>
{
    if (id != produto.Id)
    {
        return Results.BadRequest("Product ID mismatch.");
    }
    await productService.UpdateProductAsync(produto);
    return Results.Ok();
});

// Novo MapDelete deleta um produto usando o serviço ProductService
app.MapDelete("/rotaSegura/deleteProdutos/{id}", async (int id, ProductService productService) =>
{

    await productService.DeleteProductAsync(id);
    return Results.Ok("Produto Deletado");
});

// Endpoint's Cliente

// End point de criação do Cliente
app.MapPost("/rotaSegura/createCliente", async (Cliente newCliente, ClienteService clienteService) =>
{
    await clienteService.AddClienteAsync(newCliente);
    return Results.Created($"createCliente/{newCliente.Id}", newCliente);
});

// EndPoint de mostrar todos Clientes cadastrados

app.MapGet("/rotaSegura/Clientes", async (ClienteService clienteService) =>
{

    var Cliente = await clienteService.GetAllClienteAsync();

    return Results.Ok(Cliente);

});

// EndPoint para pesquisar Cliente por ID

// Lembrar que para procurar voce so precisa do LojaDbContext dbContext para criação e update precisa Model newModel ou updateModel

app.MapGet("/rotaSegura/Clientes/{id}", async (int id, ClienteService clienteService) =>
{

    var Cliente = await clienteService.GetClienteAsync(id);

    if (Cliente == null)
    {
        return Results.NotFound($"Nenhum registro de cliente com o ID {id}");
    }


    return Results.Ok(Cliente);

});

// EndPoint para editar um Cliente

app.MapPut("/rotaSegura/clienteUpdate/{id}", async (int id, ClienteService clienteService, Cliente updateCliente) =>
{
    if (id != updateCliente.Id)
    {
        return Results.BadRequest("O ID nao corresponde a um ID ja cadastrado");
    }

    await clienteService.UpdateClienteAsync(updateCliente);
    return Results.Ok();

});

// EndPoint para deletar um cliente

app.MapDelete("/rotaSegura/clienteDelete/{id}", async (int id, ClienteService clienteService) =>
{
    await clienteService.DeleteClienteAsync(id);
    return Results.Ok("Cliente deletado");
});

// EndPoint's para o fornecedor

// EndPoint de criação de fornecedor

app.MapPost("/rotaSegura/createFornecedor", async (FornecedorService fornecedorService, Fornecedor newFornecedor) =>
{
    await fornecedorService.AddFornecedorAsync(newFornecedor);

    return Results.Created($"/createFornecedor/{newFornecedor.Id}", newFornecedor);
});

// EndPoint de Busca de todos os fornecedores

app.MapGet("/rotaSegura/Fornecedores", async (FornecedorService fornecedorService) =>
{

    var fornecedor = await fornecedorService.GetAllFornecedorAsync();
    return Results.Ok(fornecedor);

});

// EndPoint de busca de Fornecedor por ID

app.MapGet("/rotaSegura/Fornecedores/{id}", async (int id, FornecedorService fornecedorService) =>
{
    var fornecedor = await fornecedorService.GetFornecedorAsync(id);

    if (fornecedor == null)
    {
        return Results.NotFound($"Nenhum registro de cliente com o ID {id}");
    }

    return Results.Ok(fornecedor);

});

// EndPoint de alteração de dados de fornecedor por ID

app.MapPut("/rotaSegura/updateFornecedor/{id}", async (int id, FornecedorService fornecedorService, Fornecedor fornecedor) =>
{


    if (id != fornecedor.Id)
    {
        return Results.BadRequest("ID fornecedor não localizado nos registro");
    }

    await fornecedorService.UpdateFornecedorAsync(fornecedor);

    return Results.Ok(fornecedor);
});


// EndPoint para deletar fornecedor

app.MapDelete("/rotaSegura/deleteFornecedor/{id}", async (int id, FornecedorService fornecedorService) =>
{

    await fornecedorService.DeleteFornecedorAsync(id);

    return Results.Ok("Fornecedor Deletado com sucesso");

});

app.Run();


