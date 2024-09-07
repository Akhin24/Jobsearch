using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobsearch.Models;

namespace jobsearch.Controllers
{
    public class applaycvController : Controller
    {
        careerhunt_jobserachEntities1 dbobj = new careerhunt_jobserachEntities1();

        // GET: applaycv
        public ActionResult applay_pageload(int cid, int jid)
        {
            TempData["CID"] = cid;
            TempData["JID"] = jid;
          
            return View();
        }
        public ActionResult apply_click(applycls clsobj, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                //fileupload
                string fname = Path.GetFileName(file.FileName);
                var s = Server.MapPath("~//PHS");
                string pa = Path.Combine(s, fname);
                file.SaveAs(pa);

                var fullpath = Path.Combine("~//PHS", fname);
                clsobj.cv = fullpath;
            }

            clsobj.date = DateTime.Now.ToString("yyyy-MM-dd");
            clsobj.usid = Convert.ToInt32(Session["uid"]);
            clsobj.sts = "APPLIED";
            byte[] cvbybtes = System.Text.Encoding.UTF8.GetBytes(clsobj.cv);
            dbobj.sp_apply(clsobj.usid, Convert.ToInt32(TempData["CID"]), Convert.ToInt32(TempData["JID"]), cvbybtes, clsobj.date, "applied");
            clsobj.msg = "INSERTED SUCCESFULLY";
            return View("applay_pageload", clsobj);
        }
    }
}