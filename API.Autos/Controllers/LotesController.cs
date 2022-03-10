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
    public class LotesController : ControllerBase
    { //Inyección de la interfaz
        private readonly IServicioLote _servicioLote;
        public LotesController(IServicioLote servicioLote)
        {
            _servicioLote = servicioLote;
        }
        //Método Get
        [HttpGet]
        public List<LoteModelo> Get()
        {
            var rLote = _servicioLote.Get();
            if (rLote == null)
            {
                return null;
            }
            else
            {
                return rLote;
            }
        }
        //Método Post
        [HttpPost]
        public string Post([FromBody] LoteModelo loteModelo)
        {
            _servicioLote.Post(loteModelo);
            if (_servicioLote == null)
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
        public string Put([FromBody] LoteModelo loteModelo)
        {
            _servicioLote.Put(loteModelo);
            if (_servicioLote == null)
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
            _servicioLote.Delete(Id);
            if (_servicioLote == null)
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
