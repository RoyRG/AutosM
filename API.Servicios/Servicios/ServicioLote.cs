using API.Entidades.Entidades;
using API.Entidades.Modelos;
using API.Negocio.Interfaces;
using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Servicios.Servicios
{
    public class ServicioLote : IServicioLote
    {
        private readonly INegocioLote _negocioLote;

        public ServicioLote(INegocioLote negocioLote)
        {
            _negocioLote = negocioLote;
        }

        public void Delete(Guid Id)
        {
            _negocioLote.Delete(Id);
        }

        public List<LoteModelo> Get()
        {
            var respuesta = new List<LoteModelo>();
            var rLot = _negocioLote.Get();
            foreach (var lot in rLot)
            {
                var Lot = new LoteModelo()
                {
                    Id = lot.Id,
                    Nombre = lot.Nombre,
                };
                respuesta.Add(Lot);
            }

            return respuesta;
        }

        public void Post(LoteModelo entidad)
        {
            var lot = new Lote
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Usuario_Activo = "Verdadero",
                Activo = true,
                Fecha_Actualizacion = null,
            };
            _negocioLote.Post(lot);
        }

        public void Put(LoteModelo entidad)
        {
            var lot = new Lote
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Fecha_Movimiento = DateTime.Now,
                Usuario = "Usuario1",
                Usuario_Activo = "Verdadero",
                Activo = true,
                Fecha_Actualizacion = null,
            };
            _negocioLote.Put(lot);
        }
    }
}
