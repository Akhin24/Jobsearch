using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobsearch.Models
{
    public class stclass1
    {
        public int SID { get; set; }
        public string SNAME { get; set; }
    }
    public class disclass1
    {
        public int DID { get; set; }
        public string DNAME { get; set; }

    }
    public class userinsertcls
    {
        public int SID { get; set; }
        public string SNAME { get; set; }

        public int DID { get; set; }
        public string DNAME { get; set; }

        public int rid { set; get; }
        public string name { set; get; }
        public int age { set; get; }
        public string address { set; get; }
        public string email { set; get; }
        public int phone { set; get; }
        public string photo { set; get; }
        public string state { set; get; }
        public string district { set; get; }
        public string gender { set; get; }
        public string dob { set; get; }
        public string unam { set; get; }
        public string pass { set; get; }
        public string logtye { set; get; }
        public string status { set; get; }
        public string msg { set; get; }
    }
}