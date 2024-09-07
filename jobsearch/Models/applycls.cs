using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobsearch.Models
{
    public class applycls
    {
        public int usid { set; get; }
        public int cmpnyid { set; get; }
        public int jobid { set; get; }
        public string cv { set; get; }
        public string date { set; get; }
        public string sts { set; get; }
        public string msg { set; get; }
    }
}