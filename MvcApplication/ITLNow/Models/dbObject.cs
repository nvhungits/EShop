using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITLNow.Models
{
    public class tables
    {
        public int Id { set; get; }
        public string name { set; get; }
        public string title { set; get; }
        public bool active { set; get; }
        public DateTime created { set; get; }
        public DateTime updated { set; get; }
    }

    public class applications: tables{}
    public class modules
    {
        public string type;
        public tables table;
        public applications application_menu;
    }
}