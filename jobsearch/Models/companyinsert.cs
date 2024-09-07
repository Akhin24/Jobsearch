using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobsearch.Models
{
    public class companyinsert
    {
       public int rid { set; get; }
        public int cmpnyid { set; get; }
       [Required(ErrorMessage ="Enter company name")]
        public string cmpnynam { set; get; }
       [EmailAddress(ErrorMessage ="Enter a email ddress")]
        public string cmpnyemil { set; get; }
     [Phone(ErrorMessage ="Enter phone number")]
        public string cmpnyphn { set; get; }
        public string cmpnyweb { set; get; }
       
        public string username { set; get; }

        public string password { set; get; }
       
        public string compassword { set; get; }
        public string msg { set; get; }

    }
}