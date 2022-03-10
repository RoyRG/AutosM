using API.Entidades.Entidades;
using API.Entidades.Modelos;
using API.Negocio.Interfaces;
using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Servicios.Servicios
{
    public class ServicioMarca : IServicioMarca
    {
        private readonly INegocioMarca _negocioMarca;
        public ServicioMarca(INegocioMarca negocioMarca)
        {
            _negocioMarca = negocioMarca;
        }

        public void Delete(Guid Id)
        {
            _negocioMarca.Delete(Id);
        }

        public List<MarcaModelo> Get()
        {
            var respuesta = new List<MarcaModelo>();
            var rMarca = _negocioMarca.Get();
            foreach (var marca in rMarca)
            {
                var Marca = new MarcaModelo()
                {
                    Id = marca.Id,
                    Nombre = marca.Nombre,
                };
                respuesta.Add(Marca);
            }
            return respuesta;
        }

        public void Post(MarcaModelo entidad)
        {
            var marca = new Marca
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = null,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _negocioMarca.Post(marca);
        }

        public void Put(MarcaModelo entidad)
        {
            var marca = new Marca
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Fecha_Actualizacion = DateTime.Now,
                Usuario_Activo = "Verdadero",
                Activo = true,
            };
            _negocioMarca.Put(marca);
        }
    }
}
