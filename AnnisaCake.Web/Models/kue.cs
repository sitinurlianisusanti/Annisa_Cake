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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    using System.Web.Mvc;

    public partial class kue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kue()
        {
            this.kranjangs = new HashSet<kranjang>();
        }
    
        public int id { get; set; }
        public string gambar { get; set; }
        public HttpPostedFileBase UploadFile { get; set; }
        public string nama_kue { get; set; }
        public int id_category { get; set; }
        public int harga { get; set; }
        public int stok { get; set; }
        //public IEnumerable<SelectListItem> CategoriList { get; set; }
        [NotMapped]
        public List<category> Kategoris { get; set; }


        public virtual category category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kranjang> kranjangs { get; set; }
    }
}
