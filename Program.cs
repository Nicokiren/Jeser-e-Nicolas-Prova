using API.Models;
using Microsoft.AspNetCore.Mvc;
using Nicolas;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

List<Funcionario>funcionarios = new List<Funcionario>();

//Funcionario

app.MapPost("/funcionario/cadastrar", ([FromBody] Funcionario funcionario,
    [FromServices] AppDataContext ctx) =>
{
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

app.MapGet("/funcionario/listar", ([FromServices] AppDataContext ctx) =>
{

    if (ctx.Funcionarios.Any())
    {
        return Results.Ok(ctx.Funcionarios.ToList());
    }
    return Results.NotFound();
});

//Folha

app.MapPost("/folha/cadastrar", ([FromBody] Folha folha,
    [FromServices] AppDataContext ctx) =>
{
    ctx.Folhas.Add(folha);
    ctx.SaveChanges();
    return Results.Created("", folha);
});

app.MapGet("/folha/listar", ([FromServices] AppDataContext ctx) =>
{

    if (ctx.Folhas.Any())
    {
        return Results.Ok(ctx.Folhas.ToList());
    }
    return Results.NotFound();
});

app.MapGet("/folha/buscar/{FolhaID}", ([FromRoute] int FolhaID,
    [FromServices] AppDataContext ctx) =>
{
    //Expressão lambda em C#
    // Produto? produto = ctx.Produtos.FirstOrDefault(x => x.Nome == "Variável com o nome do produto");
    // List<Produto> lista = ctx.Produtos.Where(x => x.Quantidade > 10).ToList();
    Folha? folhas = ctx.Folhas.Find(FolhaID);
    if (folhas == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(folhas);
});


app.Run();
