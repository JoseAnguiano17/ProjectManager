using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PA2_Final.Models.PatronEstado
{
    public enum EstadoProyecto
    {
        REGISTRADO = 1,
        ENREVISION = 2,
        ENPAUSA = 3,
        ENTREGADO = 4,
        RESOLVIENDO_ERRORES = 5,
        PAGADO = 6
    }

    public class ProyectoColor
    {
        public static string Color(EstadoProyecto estado)
        {
            string res = "p-2 bg-";
            switch (estado)
            {
                case EstadoProyecto.ENPAUSA:
                    res += "light text-dark";
                    break;
                case EstadoProyecto.ENREVISION:
                    res += "warning";
                    break;
                case EstadoProyecto.ENTREGADO:
                    res += "primary";
                    break;
                case EstadoProyecto.PAGADO:
                    res += "success";
                    break;
                case EstadoProyecto.REGISTRADO:
                    res += "secondary";
                    break;
                case EstadoProyecto.RESOLVIENDO_ERRORES:
                    res += "danger";
                    break;
            }
            return res;
        }
    }
}