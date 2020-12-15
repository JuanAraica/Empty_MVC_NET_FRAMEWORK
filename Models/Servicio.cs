//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Plantilla.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Servicio
    {
        public short idServicio { get; set; }
        public Nullable<short> idCliente { get; set; }
        public Nullable<short> idTablaAtracciones { get; set; }
        public Nullable<short> idTablaToures { get; set; }
        public Nullable<short> idCupon { get; set; }
        public Nullable<short> idTablaDestinos { get; set; }
        public Nullable<short> idTablaActividades { get; set; }
        public Nullable<short> idGestionAdmin { get; set; }
        public string descripcionServicio { get; set; }
        public Nullable<decimal> precioTotalServicio { get; set; }
        public Nullable<decimal> impuesto { get; set; }
        public Nullable<decimal> comicion { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Cupon Cupon { get; set; }
        public virtual GestionAdmin GestionAdmin { get; set; }
        public virtual TablaAtracciones TablaAtracciones { get; set; }
        public virtual TablaActividades TablaActividades { get; set; }
        public virtual TablaDestinos TablaDestinos { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
