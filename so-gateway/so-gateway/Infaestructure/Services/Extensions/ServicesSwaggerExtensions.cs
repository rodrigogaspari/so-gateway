namespace so_gateway.Infaestructure.Services.Extensions
{
    public static class ServicesSwaggerExtensions
    {
        public static void ActivateSwaggerInDebug(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient();
        }
    }
}
