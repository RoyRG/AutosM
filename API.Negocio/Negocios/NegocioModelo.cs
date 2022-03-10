using API.Data;
using API.Entidades.Entidades;
using API.Negocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Negocio.Negocios
{
    public class NegocioModelo : INegocioModelo
    {
        private readonly Contexto _db;
        public NegocioModelo(Contexto db)
        {
            _db = db;
        }

        public void Delete(Guid Id)
        {
            var rModelo = _db.Modelos.Where(c => c.Activo == true && c.Id == Id).FirstOrDefault();
            rModelo.Activo = false;
            _db.SaveChanges();
        }

        public List<Modelo> Get()
        {
            var rModelo = _db.Modelos.Include(i => i.Marca).Where(c => c.Activo == true && c.Marca.Activo == true)
               .Select(s => new Modelo { Id = s.Id, Id_Marca = s.Id_Marca, Nombre = s.Nombre, Marca = new Marca { Nombre = s.Marca.Nombre } })
               .ToList();
            return rModelo;
        }

        public void Post(Modelo entidad)
        {
            var modelo = new Modelo
            {
                Id = entidad.Id,
                Id_Marca = entidad.Id_Marca,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = null,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _db.Add(modelo);
            _db.SaveChanges();

        }

        public void Put(Modelo entidad)
        {
            var rModelo = _db.Modelos.Where(c => c.Activo == true & c.Id == entidad.Id).ToList().FirstOrDefault();
            rModelo.Id_Marca = entidad.Id_Marca;
            rModelo.Fecha_Actualizacion = DateTime.Now;
            rModelo.Nombre = entidad.Nombre;
            _db.Update(rModelo);
            _db.SaveChanges();
        }
    }
}
