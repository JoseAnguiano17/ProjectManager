using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PA2_Final.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "El Nombre del cliente es requerido.")]
        [MaxLength(50, ErrorMessage = "Limite de 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "El Apellido Paterno del cliente es requerido.")]
        [MaxLength(50, ErrorMessage = "Limite de 50 caracteres")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [MaxLength(50, ErrorMessage = "Limite de 50 caracteres")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Contacto")]
        [UIHint("(867)-123-12-12")]
        [RegularExpression(@"^\(\d{3}\)[.-]?\d{3}[.-]?\d{2}[.-]?\d{2}$", ErrorMessage = "Escriba el Numero de Telefono en el formato correcto.")]
        [MaxLength(30)]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "Escriba el Correo en un formato correcto.")]
        [MaxLength(40)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El RFC del cliente es requerido")]
        [RegularExpression(@"^([A-Z,Ñ,&]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[A-Z|\d]{3})$",
            ErrorMessage = "Escriba el RFC en un formato correcto.")]
        public string RFC { get; set; }

        [Display(Name = "Fecha de asociación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaAsoc { get; set; } = DateTime.Now;

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}