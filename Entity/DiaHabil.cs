//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ejercicio_Net_API.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class DiaHabil
    {
        public int id_habil { get; set; }
        public Nullable<int> id_negocio { get; set; }
        public Nullable<byte> dia { get; set; }
        public Nullable<int> id_horario { get; set; }
        public Nullable<bool> habilitado { get; set; }
    
        public virtual Horario Horario { get; set; }
        public virtual Negocio Negocio { get; set; }
    }
}
