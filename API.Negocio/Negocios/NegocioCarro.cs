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
    public class NegocioCarro : INegocioCarro
    {
        private readonly Contexto _db;
        public NegocioCarro(Contexto db)
        {
            _db = db;
        }

        public void Delete(Guid Id)
        {
            var rCarro = _db.Autos.Where(c => c.Id == Id && c.Activo == true).FirstOrDefault();
            rCarro.Activo = false;
            _db.SaveChanges();
        }

        public List<Autos> Get()
        {
            var rCarro = _db.Autos.Include(i => i.Lote).Include(i => i.Modelo).Include(i => i.Estado)/*.Where(c => c.Activo == true && c.Lote.Activo == true && c.Modelo.Activo == true && c.Estado.Activo == true)*/.Where(c => c.Activo == true)
               .Select(s => new Autos { Id = s.Id, Id_Estado = s.Id_Estado, Id_Modelo = s.Id_Modelo, Id_Lote = s.Id_Lote, Lote = new Lote { Nombre = s.Lote.Nombre }, Modelo = new Modelo { Nombre = s.Modelo.Nombre }, Estado = new Estado { Nombre = s.Estado.Nombre } })
               .ToList();
            return rCarro;
        }

        public void Post(Autos entidad)
        {
            var carro = new Autos()
            {
                Id = entidad.Id,
                Id_Estado = entidad.Id_Estado,
                Id_Lote = entidad.Id_Lote,
                Id_Modelo = entidad.Id_Modelo,
                Año = entidad.Año,
                Fecha_Ingreso = DateTime.Now,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Usuario_Activo = "Verdadero",
                Fecha_Actualizacion = null,
                Activo = true,
            };
            _db.Add(carro);
            _db.SaveChanges();
        }

        public void Put(Autos entidad)
        {
            var rCarro = _db.Autos.Where(c => c.Id == entidad.Id && c.Activo == true).ToList().FirstOrDefault();
            rCarro.Id_Estado = entidad.Id_Estado;
            rCarro.Id_Lote = entidad.Id_Lote;
            rCarro.Id_Modelo = entidad.Id_Modelo;
            rCarro.Año = entidad.Año;
            rCarro.Fecha_Actualizacion = DateTime.Now;
            _db.Update(rCarro);
            _db.SaveChanges();
        }
    }
}
