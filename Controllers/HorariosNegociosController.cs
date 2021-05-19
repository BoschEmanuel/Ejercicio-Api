

using Ejercicio_Net_API.Entity;
using Ejercicio_Net_API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Ejercicio_Net_API.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/horario")]
    public class HorarioController : ApiController
    {
        public IFormatProvider format { get; set; }

        public HorarioController()
        {
            format = new CultureInfo("es-ES");
        }
        //solo dejo la consulta  de los horarios para los negocios

             

        [Route("api/horario/{id:int}/{fecha:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]
        [ResponseType(typeof(HorarioNegocioDTO))]
        public IHttpActionResult Get(int id,DateTime fecha)
        {
            try
            {
                
                var resp = new HorarioNegocioDTO();
                using (var ctx = new PruebaEntities())
                {
                    var negocio = ctx.Negocios.FirstOrDefault(x => x.id_negocio == id);
                    if (negocio == null)
                    {
                        return NotFound();
                    }
                    var fechaByte = (byte)fecha.DayOfWeek;                
                    var diaHabil = ctx.DiaHabils.FirstOrDefault(x => x.id_negocio == id && x.dia == fechaByte);
                    if (diaHabil == null)
                    {
                        return NotFound();
                    }
                    var Horario = ctx.Horarios.FirstOrDefault(x => x.id_horario == diaHabil.id_horario);
                    resp.Habilitado = diaHabil.habilitado.Value;
                    resp.dia = fecha.ToString("dd/MM/yyyy");
                    resp.horarioAperura = Horario.horarioDesde.Value.ToString("HH:mm");
                    resp.horarioCierre = Horario.horarioHasta.Value.ToString("HH:mm");

                }
                return Ok(resp);
            }
            catch (Exception)
            {

                return  InternalServerError();
            }
            // ...
         


        
        }




    }
}
