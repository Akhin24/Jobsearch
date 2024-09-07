using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace jobsearch.Models
{
    public class statedistrictDB
    {
        string constring = ConfigurationManager.ConnectionStrings["testcon"].ConnectionString;
        SqlConnection con;
        public statedistrictDB()
        {
            con = new SqlConnection(constring);
        }
        public List<stclass1> selectstates()
        {
            var getdata = new List<stclass1>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_state", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var o = new stclass1()
                    {
                        SID = Convert.ToInt32(sdr["state_id"]),
                        SNAME = sdr["state_name"].ToString()
                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }

        public List<disclass1> selectdistrict(int stateid)
        {
            var getdata = new List<disclass1>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_district", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sid", stateid);
                con.Open();
                SqlDataReader ddr = cmd.ExecuteReader();
                while (ddr.Read())
                {
                    var o = new disclass1()
                    {
                        DID = Convert.ToInt32(ddr["district_id"]),
                        DNAME = ddr["dis_name"].ToString()
                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
    }
}
