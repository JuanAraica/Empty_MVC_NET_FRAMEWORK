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
    using System.ComponentModel.DataAnnotations;

    public partial class Colaborador
    {
        public short idColaborador { get; set; }
        public string CedColaborador { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string idiomas { get; set; }
        public string nacionalidad { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string licencia { get; set; }
        public string tipoColaborador { get; set; }
        [DataType(DataType.Upload)]
        public byte[] fotoPerfil { get; set; }

    }
}
