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
    public partial class tbl_cat_gastos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_cat_gastos()
        {
            this.tbl_gastos = new HashSet<tbl_gastos>();
        }
    
        public int id_cat_gasto { get; set; }
        [Display(Name = "Nombre de la Categoria")]
        [Required(ErrorMessage = "Escriba un nombre valido!")]
        [StringLength(50, ErrorMessage = "ha excedido el numero de caracteres permitidos para este campo")]
        public string nombre_cat { get; set; }
        [Display(Name = "Descripcion de la categoria")]
        [Required(ErrorMessage = "introduzca una descripcion valida!")]
        [StringLength(100, ErrorMessage = "ha excedido el numero de caracteres permitidos para este campo")]
        public string desc_cat { get; set; }
        public int estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_gastos> tbl_gastos { get; set; }
    }
}
