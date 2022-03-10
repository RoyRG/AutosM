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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Autos>().HasKey(k => k.Id_Auto);
            //modelBuilder.Entity<Estado>().HasKey(k => k.Id_Estado);
            //modelBuilder.Entity<Lote>().HasKey(k => k.Id_Lote);
            modelBuilder.Entity<Marca>().HasKey(k => k.Id);
            modelBuilder.Entity<Modelo>().HasKey(k => k.Id);

            //modelBuilder.Entity<Autos>()
            //.HasOne(d => d.Modelo)
            //.WithOne()
            //.HasForeignKey<Autos>(c => new { c.Id_Modelo });
            //modelBuilder.Entity<Autos>()
            //.HasOne(d => d.Estado)
            //.WithOne()
            //.HasForeignKey<Autos>(c => new { c.Id_Estado });
            //modelBuilder.Entity<Autos>()
            //.HasOne(d => d.Lote)
            //.WithOne()
            //.HasForeignKey<Autos>(c => new { c.Id_Lote });
            modelBuilder.Entity<Modelo>()
            .HasOne(d => d.Marca)
            .WithOne()
            .HasForeignKey<Modelo>(c => new { c.Id_Marca });
        }
    }

}
