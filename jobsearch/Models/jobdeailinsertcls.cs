using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobsearch.Models
{
    public class jobdeailinsertcls
    {
        public int compnyid { set; get; }
        public string jobtil { set; get; }
        public string jobdespn { set; get; }
        public string jobtype { set; get; }
        public string lastdate { set; get; }
        public string sts { set; get; }
        public string location { set; get; }
        public int expinyears { set; get; }
        public int salary { set; get; }
        public string skills { set; get; }
        public string msg { set; get; }
    }
}