using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PA2_Final.Models
{
    public class Actualizacion : Iniciador
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "La descripcion es necesaria.")]
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Indique el monto de comisión.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Costo de actualización")]
        [DataType(DataType.Currency, ErrorMessage = "Ingrese una cantidad correcta.")]
        public double Costo { get; set; }
    }
}