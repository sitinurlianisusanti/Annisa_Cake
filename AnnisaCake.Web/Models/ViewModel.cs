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
    }
}