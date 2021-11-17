//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aplicacionKermesse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class tbl_arqueocaja_det
    {
        public int id_arqueocaja_det { get; set; }
        public int id_arqueocaja { get; set; }
        public int id_moneda { get; set; }
        public int id_denominacion { get; set; }
        public decimal cantidad { get; set; }
        public decimal subtotal { get; set; }

        [Display(Name = "Arqueo Maestro")]
        public virtual tbl_arqueocaja tbl_arqueocaja { get; set; }
        [Display(Name = "Denominacion")]
        [Required(ErrorMessage = "Seleccion una denominacion valida")]
        public virtual tbl_denominacion tbl_denominacion { get; set; }
        [Display(Name = "Moneda")]
        [Required(ErrorMessage = "Seleccione una moneda valida")]
        public virtual tbl_moneda tbl_moneda { get; set; }
    }
}
