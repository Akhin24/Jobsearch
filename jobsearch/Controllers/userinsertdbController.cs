using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobsearch.Models;

namespace jobsearch.Controllers
{
    public class userinsertdbController : Controller
    {
        careerhunt_jobserachEntities1 dbobj = new careerhunt_jobserachEntities1();
        statedistrictDB ddlcls = new statedistrictDB();
        // GET: userinsertdb
        public ActionResult userpageload()
        {
            List<stclass1> stlist = ddlcls.selectstates();
            ViewBag.selstates = new SelectList(stlist, "SID", "SNAME");
            return View();
        }
        public JsonResult Getdistrics(int stateid)
        {
            var districts = GetdistrictBystateId(stateid);
            return Json(districts, JsonRequestBehavior.AllowGet);
        }
        private List<SelectListItem> GetdistrictBystateId(int stateid)
        {
            var getdistricts = ddlcls.selectdistrict(stateid);
            var districtbystste = getdistricts.Select(a => new SelectListItem() { Value = a.DID.ToString(), Text = a.DNAME }).ToList();
            return districtbystste;
        }
        public ActionResult user_click(userinsertcls clsobj, HttpPostedFileBase file, FormCollection form)
        {
            if (ModelState.IsValid)
            {


                if (file.ContentLength > 0)
                {
                    //fileupload
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~//PHS");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    

                    var fullpath = Path.Combine("~//PHS", fname);
                    clsobj.photo = fullpath;
                }
                //ddlist
                List<stclass1> stlist = ddlcls.selectstates();
                int selectedid = Convert.ToInt32(form["SID"]);
                stclass1 selecteditem = stlist.FirstOrDefault(c => c.SID == selectedid);
                clsobj.SID = selecteditem.SID;
                clsobj.SNAME = selecteditem.SNAME;//stste
                ViewBag.selstates = new SelectList(stlist, "SID", "SNAME");

                int disid = Convert.ToInt32(form["DistrictId"]);
                clsobj.DID = disid;
                //string dname = "";
                //clsobj.DNAME=dname;//district


                var maxid = dbobj.sp_selmaxregid().FirstOrDefault();
                int mid = Convert.ToInt32(maxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_userinsert(regid, clsobj.name, clsobj.age, clsobj.address, clsobj.email, clsobj.phone, clsobj.photo, clsobj.SNAME, clsobj.DID, clsobj.gender, clsobj.dob);
                dbobj.sp_logininsert(regid, clsobj.unam, clsobj.pass, "USER", "ACTIVE");
                clsobj.msg = "INSERTED SUCCESFULLY";
                return View("userpageload", clsobj);
            }
            else
            {
                List<stclass1> stlist = ddlcls.selectstates();
                ViewBag.selstates = new SelectList(stlist, "SID", "SNAME");
                return View("userpageload", clsobj);
            }


        }
    }
}