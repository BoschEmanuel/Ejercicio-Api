using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio_Net_API.Models
{
    public class HorarioNegocioDTO
    {

        public string horarioAperura { get; set; }
        public string horarioCierre { get; set; }

        public string dia { get; set; }
        public bool Habilitado { get; set; }
    }
}