using API.Entidades.Entidades;
using API.Entidades.Modelos;
using API.Negocio.Interfaces;
using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Servicios.Servicios
{
    public class ServicioCarro : IServicioCarro
    {
        private readonly INegocioCarro _negocioCarro;
        public ServicioCarro(INegocioCarro negocioCarro)
        {
            _negocioCarro = negocioCarro;
        }

        public void Delete(Guid Id)
        {
            _negocioCarro.Delete(Id);
        }

        public List<AutoModelo> Get()
        {
            var respuesta = new List<AutoModelo>();
            var rCarro = _negocioCarro.Get();
            foreach (var car in rCarro)
            {
                var carro = new AutoModelo()
                {
                    Id_Auto = car.Id,
                    Id_Estado = car.Id_Estado,
                    Id_Lote = car.Id_Lote,
                    Id_Modelo = car.Id_Modelo,
                    Estado = car.Estado.Nombre,
                    Lote = car.Lote.Nombre,
                    Año = car.Año,
                    //Fecha_Ingreso = car.Fecha_Ingreso,
                    Modelo = car.Modelo.Nombre,
                };
                respuesta.Add(carro);
            }
            return respuesta;
        }

        public void Post(AutoModelo entidad)
        {
            var carro = new Autos()
            {
                Id= entidad.Id_Auto,
                Id_Estado = Guid.Parse(entidad.Estado),
                Id_Lote = Guid.Parse(entidad.Lote),
                Id_Modelo = Guid.Parse(entidad.Modelo),
                Fecha_Ingreso = DateTime.Now,
                Año = entidad.Año,
                Activo = true,
            };
        _negocioCarro.Post(carro);
        }

        public void Put(AutoModelo entidad)
        {
            var carro = new Autos()
            {
                Id = entidad.Id_Auto,
                Id_Estado = Guid.Parse(entidad.Estado),
                Id_Lote = Guid.Parse(entidad.Lote),
                Id_Modelo = Guid.Parse(entidad.Modelo),
                Fecha_Ingreso = DateTime.Now,
                Año = entidad.Año,
                Activo = true,
            };
            _negocioCarro.Put(carro);
        }
    }
}
