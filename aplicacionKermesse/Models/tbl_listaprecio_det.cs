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
    
    public partial class tbl_listaprecio_det
    {
        public int id_listaprecio_det { get; set; }
        public int id_listaprecio { get; set; }
        public int id_producto { get; set; }
        public decimal precio_venta { get; set; }
    
        public virtual tbl_listaprecio tbl_listaprecio { get; set; }
        public virtual tbl_productos tbl_productos { get; set; }
    }
}
