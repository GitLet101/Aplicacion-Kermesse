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
    
    public partial class tbl_productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_productos()
        {
            this.tbl_ingreso_com = new HashSet<tbl_ingreso_com>();
            this.tbl_listaprecio_det = new HashSet<tbl_listaprecio_det>();
        }
    
        public int id_producto { get; set; }
        public int id_comunidad { get; set; }
        public int id_cat_producto { get; set; }
        public string nombre { get; set; }
        public string desc_presentacion { get; set; }
        public int cantidad { get; set; }
        public decimal precio_venta { get; set; }
        public int estado { get; set; }
    
        public virtual tbl_cat_producto tbl_cat_producto { get; set; }
        public virtual tbl_comunidad tbl_comunidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ingreso_com> tbl_ingreso_com { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_listaprecio_det> tbl_listaprecio_det { get; set; }
    }
}
