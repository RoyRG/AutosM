using System;
using System.Collections.Generic;
using System.Text;

namespace API.Entidades.Modelos
{
    public class AutoModelo
    {
        public Guid Id_Auto { get; set; }
        public Guid Id_Estado { get; set; }
        public Guid Id_Modelo { get; set; }
        public Guid Id_Lote { get; set; }
        public string Modelo { get; set; }
        public string Estado { get; set; }
        public string Lote { get; set; }
        public DateTime Año { get; set; }
    }
}
