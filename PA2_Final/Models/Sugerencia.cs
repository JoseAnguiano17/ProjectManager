using PA2_Final.Models.PatronEstado;
using System;
using System.ComponentModel.DataAnnotations;

namespace PA2_Final.Models
{
    public class Sugerencia : Iniciador
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "La descripcion es necesaria.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public EstadoSugerencia Estado { get; set; } = EstadoSugerencia.ENVIADA;
    }
}