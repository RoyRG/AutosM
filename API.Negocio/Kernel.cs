using API.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Negocio
{
    public static class Kernel
    {
        public static IServiceCollection RegistrarNegocios(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<INegocioLote, NegocioLote>();
            //services.AddTransient<INegocioCarro, NegocioCarro>();
            //services.AddTransient<INegocioEstado, NegocioEstado>();
            //services.AddTransient<INegocioMarca, NegocioMarca>();
            //services.AddTransient<INegocioModelo, NegocioModelo>();
            services.RegistrarRepositorios<Contexto>();
            return services;
        }
    }
}
