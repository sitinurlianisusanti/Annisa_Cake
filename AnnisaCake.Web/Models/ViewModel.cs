using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnisaCake.Web.Models
{
    public class ViewModel
    {
        public class MenuTree
        {
            public int id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
            public string icon { get; set; }
            public bool role { get; set; }
            public List<MenuTree> sub { get; set; }

        }

        public partial class pelanggan
        {

            public System.Guid id_pelanggan { get; set; }
            public string nama_pelanggan { get; set; }
            public string sandi { get; set; }
            public string sandi_confirm { get; set; }
            public string alamat { get; set; }
            public string rt { get; set; }
            public string rw { get; set; }
            public string desa { get; set; }
            public string kec { get; set; }
            public string kab { get; set; }
            public string provinsi { get; set; }
            public string no_hp { get; set; }
            public string email { get; set; }

        }
    }
}