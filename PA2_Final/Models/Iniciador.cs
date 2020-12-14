using PA2_Final.Models.PatronEstado;
using System;
using System.ComponentModel.DataAnnotations;

namespace PA2_Final.Models
{
    public interface Iniciador
    {
        int ID { get; set; }

        [Required(ErrorMessage = "Es necesario escribir una descripción.")]
        [MaxLength(200, ErrorMessage = "Limite de 200 caracteres.")]
        string Descripcion { get; set; }

        [Display(Name = "Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        DateTime FechaCreacion { get; set; }
    }
}