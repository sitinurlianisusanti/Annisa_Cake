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
    
    public partial class ukuran_kue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ukuran_kue()
        {
            this.kues = new HashSet<kue>();
        }
    
        public int id_ukuran { get; set; }
        public string ukuran { get; set; }
        public string deskripsi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kue> kues { get; set; }
    }
}
