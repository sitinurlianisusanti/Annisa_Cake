//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnnisaCake.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class transaksi
    {
        public int id_transaksi { get; set; }
        public System.DateTime tgl_transaksi { get; set; }
        public int id_pesanan { get; set; }
        public string status { get; set; }
    
        public virtual pesanan pesanan { get; set; }
    }
}
