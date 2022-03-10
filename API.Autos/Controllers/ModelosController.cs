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
    public class ModelosController : ControllerBase
    {//Inyección de la interfaz
        private readonly IServicioModelo _servicioModelo;
        public ModelosController(IServicioModelo servicioModelo)
        {
            _servicioModelo = servicioModelo;
        }
        //Método Get
        [HttpGet]
        public List<ModeloModelo> Get()
        {
            var rModelo = _servicioModelo.Get();
            if (rModelo == null)
            {
                return null;
            }
            else
            {
                return rModelo;
            }
        }
        //Método Post
        [HttpPost]
        public string Post([FromBody] ModeloModelo modeloModelo)
        {
            _servicioModelo.Post(modeloModelo);
            if (_servicioModelo == null)
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
        public string Put([FromBody] ModeloModelo modeloModelo)
        {
            _servicioModelo.Put(modeloModelo);
            if (_servicioModelo == null)
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
            _servicioModelo.Delete(Id);
            if (_servicioModelo == null)
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
