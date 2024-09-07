using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jobsearch.Models;

namespace jobsearch.Controllers
{
    public class searchjobController : Controller
    {
        careerhunt_jobserachEntities1 dbobj = new careerhunt_jobserachEntities1();
        // GET: searchjob
        public ActionResult searchjob_pageload()
        {
            return View(getdata());
        }

        private joobsearch getdata()
        {
            var joblist = new joobsearch();
            List<string> lst = new List<string>();
            var job = dbobj.sp_jobs().ToList();
            foreach (var e in job)
            {
                var jobcls = new jsearch();
                jobcls.jobid = e.job_id;
                jobcls.cmpnyid = e.company_id;
                jobcls.jobtitle = e.job_title;
                jobcls.jobdespn = e.job_description;
                jobcls.jobtype = e.job_type;
                jobcls.lastdate = e.lastdate;
                jobcls.sts = e.status;
                jobcls.lcn = e.location;
                jobcls.experience = e.experiance_in_years;
                jobcls.sal = Convert.ToInt32(e.salary);
                jobcls.skills = e.skills;

                joblist.selectjob.Add(jobcls);
                //var s = jobcls.skills;
                //lst.Add(s);
                //TempData["skills"] = string.Join(" ", lst);

            }
            return joblist;
        }
        public ActionResult searchjob_click(joobsearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.experience.ToString()))
            {
                qry += " and experiance_in_years like '%" + clsobj.insertse.experience + "'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.skills))
            {
                qry += " and skills like '%" + clsobj.insertse.skills + "'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.lcn))
            {
                qry += " and location like '%" + clsobj.insertse.lcn + "'";
            }
            return View("searchjob_pageload", getdata1(clsobj, qry));
        }

        public joobsearch getdata1(joobsearch clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["testcon"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new joobsearch();
                while (dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.cmpnyid = Convert.ToInt32(dr["company_id"].ToString());
                    jobcls.skills = dr["skills"].ToString();
                    jobcls.experience = Convert.ToInt32(dr["experiance_in_years"].ToString());
                    jobcls.sts = dr["status"].ToString();
                    jobcls.lastdate = dr["lastdate"].ToString();
                    jobcls.lcn = dr["location"].ToString();
                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }
    }
}