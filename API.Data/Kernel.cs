using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Data
{
    public static class Kernel
    {
        private static IConfiguration _configuration;
        //const string cadenaConexion = @" Data Source=DESKTOP-EIGQN0C; Initial Catalog=AutosFirstCode; User ID=sa; Password=royale681018";
        public static IServiceCollection RegistrarRepositorios<TContexto>(this IServiceCollection services) where TContexto : DbContext
        {
            services.AddDbContext<Contexto>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
