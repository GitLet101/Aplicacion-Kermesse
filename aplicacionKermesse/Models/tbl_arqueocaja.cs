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
    public partial class tbl_arqueocaja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_arqueocaja()
        {
            this.tbl_arqueocaja_det = new HashSet<tbl_arqueocaja_det>();
        }
    
        public int id_arqueocaja { get; set; }
        [Display(Name = "Kermesse")]
        [Required(ErrorMessage = "Seleccione una kermesse valida")]
        public int idkermesse { get; set; }
        [Display(Name = "Fecha de Arqueo")]
        [Required(ErrorMessage = "Introduzca una fecha valida!")]
        public System.DateTime fecha_arqueo { get; set; }
        [Display(Name = "Total del Arqueo")]
        public decimal gran_total { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_eliminacion { get; set; }
        public Nullable<int> usuario_creacion { get; set; }
        public Nullable<int> usuario_modificacion { get; set; }
        public Nullable<int> usuario_eliminacion { get; set; }
        public int estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_arqueocaja_det> tbl_arqueocaja_det { get; set; }
        public virtual tbl_kermesse tbl_kermesse { get; set; }
        public virtual tbl_usuario tbl_usuario { get; set; }
        public virtual tbl_usuario tbl_usuario1 { get; set; }
        public virtual tbl_usuario tbl_usuario2 { get; set; }
    }
}
