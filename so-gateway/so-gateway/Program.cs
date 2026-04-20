using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using so_gateway.Infaestructure.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Carregar config do Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Adiciona serviços do Swagger
builder.Services.ActivateSwaggerInDebug();

// Adicionar Ocelot
builder.Services.AddOcelot();

var app = builder.Build();

// Rastro de requisições para debug
app.RegistraLogConsole();

// Usar Ocelot (middleware principal)
await app.UseOcelot();

app.Run();