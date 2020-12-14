using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA2_Final.Models.PatronEstado
{
    public enum EstadoSugerencia
    {
        ENVIADA = 1,
        LEIDA = 2,
        ATENDIDA = 3,
        REALIZADA = 4,
        DECLINADA = 5
    }
    public class SugerenciaColor
    {
        public static string Color(EstadoSugerencia estado)
        {
            string res = "p-2 bg-";
            switch (estado)
            {
                case EstadoSugerencia.DECLINADA:
                    res += "light text-dark";
                    break;
                case EstadoSugerencia.LEIDA:
                    res += "warning";
                    break;
                case EstadoSugerencia.ENVIADA:
                    res += "secondary";
                    break;
                case EstadoSugerencia.ATENDIDA:
                    res += "primary";
                    break;
                case EstadoSugerencia.REALIZADA:
                    res += "success";
                    break;
            }
            return res;
        }
    }
}