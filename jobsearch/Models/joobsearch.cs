using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobsearch.Models
{
    public class joobsearch
    {
        public joobsearch()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }
        public jsearch insertse { set; get; }
        public List<jsearch> selectjob { set; get; }

    }
    public class jsearch
    {

        public int jobid { set; get; }
        public int cmpnyid { set; get; }
        public string jobtitle { set; get; }
        public string jobdespn { set; get; }
        public string jobtype { set; get; }
        public string lastdate { set; get; }
        public string sts { set; get; }
        public string lcn { set; get; }
        public int experience { set; get; }
        public int sal { set; get; }
        public string skills { set; get; }
    }
}