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
    
    public partial class pelanggan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pelanggan()
        {
            this.kranjangs = new HashSet<kranjang>();
        }
    
        public int id { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
        public string rt { get; set; }
        public string rw { get; set; }
        public string desa { get; set; }
        public string kec { get; set; }
        public string kab { get; set; }
        public string provinsi { get; set; }
        public string no_hp { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kranjang> kranjangs { get; set; }
    }
}
