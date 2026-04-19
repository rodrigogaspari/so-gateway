using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Carregar config do Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Adicionar Ocelot
builder.Services.AddOcelot();

var app = builder.Build();

// Rastro de requisições para debug
app.Use(async (context, next) =>
{
    Console.WriteLine($"[Gateway] Requisição recebida: {context.Request.Method} {context.Request.Path}");

    await next.Invoke();

    Console.WriteLine($"[Gateway] Resposta enviada: {context.Response.StatusCode}");
});


// Usar Ocelot (middleware principal)
await app.UseOcelot();


app.Run();