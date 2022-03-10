using API.Data;
using API.Entidades.Entidades;
using API.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Negocio.Negocios
{
    public class NegocioLote : INegocioLote
    {
        private readonly Contexto _db;
        public NegocioLote(Contexto db)
        {
            _db = db;
        }

        public void Delete(Guid Id)
        {
            var rLote = _db.Lote.Where(c => c.Id == Id && c.Activo == true).FirstOrDefault();
            rLote.Activo = false;
            _db.SaveChanges();
        }

        public List<Lote> Get()
        {
            var rLote = _db.Lote.Where(c => c.Activo == true).ToList();
            return rLote;
        }

        public void Post(Lote entidad)
        {
            var lote = new Lote()
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = null,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _db.Add(lote);
            _db.SaveChanges();
        }

        public void Put(Lote entidad)
        {
            var rLote = _db.Lote.Where(c => c.Id == entidad.Id && c.Activo == true).ToList().FirstOrDefault();
            rLote.Nombre = entidad.Nombre;
            rLote.Fecha_Actualizacion = DateTime.Now;
            _db.Update(rLote);
            _db.SaveChanges();
        }
    }
}
