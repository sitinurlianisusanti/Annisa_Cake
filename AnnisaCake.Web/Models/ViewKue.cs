using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnnisaCake.Web.Models
{
    public partial class ViewKue
    {
        public int id { get; set; }
        public string gambar { get; set; }
        public HttpPostedFileBase UploadFile { get; set; }
        public string nama_kue { get; set; }
        public int id_category { get; set; }
        public int harga { get; set; }
        public int stok { get; set; }
        
        [NotMapped]
        public List<category> Kategoris { get; set; }

       

    }
}