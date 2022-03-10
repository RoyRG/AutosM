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
    public class MarcasController : ControllerBase
    {
        //Inyección de la interfaz
        private readonly IServicioMarca _servicioMarca;
        public MarcasController(IServicioMarca servicioMarca)
        {
            _servicioMarca = servicioMarca;
        }
        //Método Get
        [HttpGet]
        public List<MarcaModelo> Get()
        {

            var rMarca = _servicioMarca.Get();
            if (rMarca == null)
            {
                return null;

            }
            else
            {
                var respuesta = rMarca;
                return respuesta;
            }
        }
        //Método Post
        [HttpPost]
        public string Post([FromBody] MarcaModelo marcaModelo)
        {
            _servicioMarca.Post(marcaModelo);
            if (_servicioMarca == null)
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
        public string Put([FromBody] MarcaModelo marcaModelo)
        {
            _servicioMarca.Put(marcaModelo);
            if (_servicioMarca == null)
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
            _servicioMarca.Delete(Id);
            if (_servicioMarca == null)
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