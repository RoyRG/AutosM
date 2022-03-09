using API.Negocio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Servicios
{
    public static class Kernel
    {
        public static IServiceCollection RegistrarServicios(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IServicioLote, ServicioLote>();
            //services.AddTransient<IServicioCarro, ServicioCarro>();
            //services.AddTransient<IServicioEstado, ServicioEstado>();
            //services.AddTransient<IServicioMarca, ServicioMarca>();
            //services.AddTransient<IServicioModelo, ServicioModelo>();
            services.RegistrarNegocios(configuration);
            return services;
        }
    }
}
