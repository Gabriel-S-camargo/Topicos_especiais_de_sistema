var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{

    Console.WriteLine("foi");

    return "Hello Word!";
});

app.MapGet("/seunome", () =>
{

    Console.WriteLine("foi");

    return "Fala Gabriel";
});

app.MapPost("/criarConta",async (HttpContext context) =>
{
    // receber a request do Body
    using var reader = new System.IO.StreamReader(context.Request.Body);

    // Transformou todo o Código JSON na var 'BODY'
    var body = await reader.ReadToEndAsync();
    // Desserializar o objeto JSON
    var Json = System.Text.Json.JsonDocument.Parse(body);
    var userName = Json.RootElement.GetProperty("nome");

    return "Recebido nome: " + userName;

});



app.Run();
