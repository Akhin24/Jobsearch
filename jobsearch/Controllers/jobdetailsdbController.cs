using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobsearch.Models;

namespace jobsearch.Controllers
{
    public class jobdetailsdbController : Controller
    {
        careerhunt_jobserachEntities1 dbobj = new careerhunt_jobserachEntities1();
        // GET: jobdetailsdb
        public ActionResult jobdetailpageload()
        {
            return View();
        }
        public ActionResult jobdetailinsertclick(jobdeailinsertcls clsobj)
        {
            if (ModelState.IsValid)
            {

                clsobj.sts = "AVAILABLE";
                clsobj.compnyid = Convert.ToInt32(Session["uid"]);
                dbobj.sp_jobdetails(clsobj.compnyid, clsobj.jobtil, clsobj.jobdespn, clsobj.jobtype, clsobj.lastdate, clsobj.sts, clsobj.location, clsobj.expinyears, clsobj.salary, clsobj.skills);
                clsobj.msg = "successfully inserted";
                return View("jobdetailpageload", clsobj);
            }
            else
            {
                return View("jobdetailpageload", clsobj);

            }
        }
    }
}