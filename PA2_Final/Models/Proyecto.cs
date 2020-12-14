using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PA2_Final.Models.PatronEstado;

namespace PA2_Final.Models
{
    public class Proyecto : Iniciador
    {
        public int ID { get; set; }
        [Required(ErrorMessage="El nombre del proyecto es requerido")]
        [MaxLength(50,ErrorMessage ="Limite de 50 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es necesaria.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio de venta es requerido.")]
        [Display(Name ="Precio de venta")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        [DataType(DataType.Currency,ErrorMessage ="Ingrese una cantidad correcta.")]
        public double Costo { get; set; }
        public EstadoProyecto Estado { get; set; } = EstadoProyecto.REGISTRADO;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public virtual ICollection<Sugerencia> Sugerencias { get; set; }
        public virtual ICollection<Error> Errores { get; set; }
        public virtual ICollection<Actualizacion> Actualizaciones { get; set; }
    }
}