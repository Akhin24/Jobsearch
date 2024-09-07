using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobsearch.Models;

namespace jobsearch.Controllers
{
    public class logindbController : Controller
    {
        careerhunt_jobserachEntities1 dbobj = new careerhunt_jobserachEntities1();
        // GET: logindb
        public ActionResult loginpageload()
        {
            return View();
        }

        public ActionResult companyhome()
        {
            return View();
        }

        public ActionResult userhome()
        {
            return View();
        }

        public ActionResult loginclick(logincls clsobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_LOGINCOUNTID(clsobj.uname, clsobj.passwd, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_logingetid(clsobj.uname, clsobj.passwd).FirstOrDefault();
                    Session["uid"] = uid;
                    var logtype = dbobj.sp_Logtype(clsobj.uname, clsobj.passwd).FirstOrDefault();
                    if (logtype == "company")
                    {
                        return View("companyhome");
                    }
                    else if (logtype == "USER")
                    {
                        return View("userhome");
                    }
                }
            }
            else
            {
                ModelState.Clear();
                clsobj.msg = "INVALID USername and password";
                return View("loginpageload", clsobj);
            }
            return View("loginpageload", clsobj);
        }
    }
}