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
    
    public partial class bahan_baku_keluar
    {
        public int id { get; set; }
        public System.DateTime tgl_keluar { get; set; }
        public int id_bbmasuk { get; set; }
        public int jumlah { get; set; }
        public string satuan { get; set; }
        public string deskripsi { get; set; }
    
        public virtual bahan_baku_Masuk bahan_baku_Masuk { get; set; }
    }
}
