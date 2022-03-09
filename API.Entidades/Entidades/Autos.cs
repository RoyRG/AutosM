using System;
using System.Collections.Generic;
using System.Text;

namespace API.Entidades.Entidades
{
    public class Autos
    {
        public Guid Id { get; set; }
        public Guid Id_Modelo { get; set; }
        public DateTime Año { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public Guid Id_Estado { get; set; }
        public Guid Id_Lote { get; set; }
        public DateTime? Fecha_Movimiento { get; set; }
        public string Usuario { get; set; }
        public DateTime? Fecha_Actualizacion { get; set; }
        public string Usuario_Activo { get; set; }
        public bool Activo { get; set; }
        public Modelo Modelo { get; set; }
        public Estado Estado { get; set; }
        public Lote Lote { get; set; }
    }
}
