using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobsearch.Models;

namespace jobsearch.Controllers
{
    public class companyinsertdbController : Controller
    {
        careerhunt_jobserachEntities1 dbobj = new careerhunt_jobserachEntities1();
        // GET: companyinsertdb
        public ActionResult companypageload()
        {
            return View();
        }
        public ActionResult CompanyInsert_Click(companyinsert clsobj)
        {

            if (ModelState.IsValid)
            {


                var getmaxregid = dbobj.sp_selmaxregid().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxregid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_companyinsert(regid, clsobj.cmpnynam, clsobj.cmpnyemil, Convert.ToInt64(clsobj.cmpnyphn), clsobj.cmpnyweb);
                dbobj.sp_logininsert(regid, clsobj.username, clsobj.password, "company", "Active");
                clsobj.msg = "succesfully inserted";
                return View("companypageload", clsobj);
            }
            else
            {
                return View("companypageload", clsobj);
            }


        }
    }
}