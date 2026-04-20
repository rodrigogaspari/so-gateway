namespace so_gateway.Infaestructure.Services.Extensions
{
    public static class WebApplicationGatewayExtensions
    {
        public static void RegistraLogConsole(this WebApplication app) 
        {
            app.Use(async (context, next) =>
            {
                Console.WriteLine($"[Gateway] Requisição recebida: {context.Request.Method} {context.Request.Path}");

                await next.Invoke();

                Console.WriteLine($"[Gateway] Resposta enviada: {context.Response.StatusCode}");
            });
        }
    }
}
