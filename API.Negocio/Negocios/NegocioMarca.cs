using API.Data;
using API.Entidades.Entidades;
using API.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Negocio.Negocios
{
    internal class NegocioMarca : INegocioMarca
    {
        private readonly Contexto _db;
        public NegocioMarca(Contexto db)
        {
            _db = db;
        }

        public void Delete(Guid Id)
        {
            var rMarca = _db.Marcas.Where(c => c.Id == Id && c.Activo == true).FirstOrDefault();
            rMarca.Activo = false;
            _db.SaveChanges();
        }

        public List<Marca> Get()
        {
            var rMarca = _db.Marcas.Where(c => c.Activo == true).ToList();
            return rMarca;
        }

        public void Post(Marca entidad)
        {
            var marca = new Marca()
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Fecha_Actualizacion = null,
                Usuario = "Usuario1",
                Usuario_Activo = "Verdadero",
                Activo = true
            };
            _db.Marcas.Add(marca);
            _db.SaveChanges();
        }

        public void Put(Marca entidad)
        {
            var rMarca = _db.Marcas.Where(c => c.Id== entidad.Id && c.Activo == true).ToList().FirstOrDefault();
            rMarca.Nombre = entidad.Nombre;
            rMarca.Fecha_Actualizacion = DateTime.Now;
            _db.Update(rMarca);
            _db.SaveChanges();
        }
    }
}
