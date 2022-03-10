using API.Data;
using API.Entidades.Entidades;
using API.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Negocio.Negocios
{
    public class NegocioEstado : INegocioEstado
    {
        private readonly Contexto _db;
        public NegocioEstado(Contexto db)
        {
            _db = db;
        }

        public void Delete(Guid Id)
        {
            var rEstado = _db.Estado.Where(c => c.Activo == true && c.Id == Id).FirstOrDefault();
            rEstado.Activo = false;
            _db.SaveChanges();
        }

        public List<Estado> Get()
        {
            var rEstado = _db.Estado.Where(c => c.Activo == true).ToList();
            return rEstado;
        }

        public void Post(Estado entidad)
        {
            var estado = new Estado
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = null,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _db.Add(estado);
            _db.SaveChanges();
        }

        public void Put(Estado entidad)
        {
            var rEstado = _db.Estado.Where(c => c.Activo == true && c.Id == entidad.Id).ToList().FirstOrDefault();
            rEstado.Nombre = entidad.Nombre;
            rEstado.Fecha_Actualizacion = DateTime.Now;
            _db.Update(rEstado);
            _db.SaveChanges();
        }
    }
}
