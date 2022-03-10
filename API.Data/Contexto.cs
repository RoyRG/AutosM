using API.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data
{
    public class Contexto : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<Autos> Autos { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        protected Contexto()
        {
        }
        public Contexto(DbContextOptions<Contexto> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            _configuration = builder.Build();
            string connectionString = _configuration.GetConnectionString("DefaultConnection").ToString();
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
