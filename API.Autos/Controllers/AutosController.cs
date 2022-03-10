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
    public class AutosController : ControllerBase
    {
        private readonly IServicioCarro _servicioCarro;
        public AutosController(IServicioCarro servicioCarro)
        {
            _servicioCarro = servicioCarro;
        }
        [HttpGet]
        //Método Get
        public List<AutoModelo> Get()
        {
            var rCarro = _servicioCarro.Get();
            if (rCarro == null)
            {
                return null;
            }
            else
            {
                return rCarro;
            }
        }
        //Método Post
        [HttpPost]
        public string Post([FromBody] AutoModelo autoModelo)
        {
            _servicioCarro.Post(autoModelo);
            if (_servicioCarro == null)
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
        public string Put([FromBody] AutoModelo autoModelo)
        {
            _servicioCarro.Put(autoModelo);
            if (_servicioCarro == null)
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
            _servicioCarro.Delete(Id);
            if (_servicioCarro == null)
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

