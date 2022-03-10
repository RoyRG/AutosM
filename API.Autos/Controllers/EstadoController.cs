using API.Entidades.Modelos;
using API.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Autos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        //Inyección de la interfaz
        private readonly IServicioEstado _servicioEstado;
        public EstadoController(IServicioEstado servicioEstado)
        {
            _servicioEstado = servicioEstado;
        }
        //Método Get
        [HttpGet]
        public List<EstadoModelo> Get()
        {
            var rEstado = _servicioEstado.Get();
            if (rEstado == null)
            {
                return null;
            }
            else
            {
                return rEstado;
            }
        }
        //Método Post
        [HttpPost]
        public string Post([FromBody] EstadoModelo estadoModelo)
        {
            _servicioEstado.Post(estadoModelo);
            if (_servicioEstado == null)
            {
                return "Hubo un error";
            }
            else
            {
                return "Ok";
            }
        }
        //Método Put
        [HttpPut]
        public string Put([FromBody] EstadoModelo estadoModelo)
        {
            _servicioEstado.Put(estadoModelo);
            if (_servicioEstado == null)
            {
                return "Hubo un error";
            }
            else
            {
                return "Ok";
            }
        }
        //Método Delete
        [HttpDelete]
        public string Delete([FromQuery] Guid Id)
        {
            _servicioEstado.Delete(Id);
            if (_servicioEstado == null)
            {
                return "Hubo un error";
            }
            else
            {
                return "Ok";
            }
        }
    }
}
