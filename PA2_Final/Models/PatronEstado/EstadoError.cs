using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA2_Final.Models.PatronEstado
{
    public enum EstadoError
    {
        REGISTRADO = 1,
        ATENDIDO = 2,
        RESUELTO = 3
    }
    public class ErrorColor
    {
        public static string Color(EstadoError estado)
        {
            string res = "p-2 bg-";
            switch (estado)
            {
                case EstadoError.REGISTRADO:
                    res += "secondary";
                    break;
                case EstadoError.ATENDIDO:
                    res += "warning";
                    break;
                case EstadoError.RESUELTO:
                    res += "success";
                    break;
            }
            return res;
        }
    }
}