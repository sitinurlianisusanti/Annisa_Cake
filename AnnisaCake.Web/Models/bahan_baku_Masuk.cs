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
    
    public partial class bahan_baku_Masuk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bahan_baku_Masuk()
        {
            this.bahan_baku_keluar = new HashSet<bahan_baku_keluar>();
        }
    
        public int id { get; set; }
        public System.DateTime tgl_pembelian { get; set; }
        public string bahan_baku { get; set; }
        public int jumlah { get; set; }
        public string satuan { get; set; }
        public int harga { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bahan_baku_keluar> bahan_baku_keluar { get; set; }
    }
}
