using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API.Entidades.Entidades
{
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fecha_Movimiento { get; set; }
        public string Usuario { get; set; }
        public DateTime? Fecha_Actualizacion { get; set; }
        public string Usuario_Activo { get; set; }
        public bool Activo { get; set; }
    }
}
