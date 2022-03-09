using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Data
{
    public static class Kernel
    {
        public static IServiceCollection RegistrarRepositorios<TContexto>(this IServiceCollection services) where TContexto : DbContext
        {
            services.AddDbContext<Contexto>(
            /*options => options.UseSqlServer(cadenaConexion)*/);
            return services;
        }
    }
}
