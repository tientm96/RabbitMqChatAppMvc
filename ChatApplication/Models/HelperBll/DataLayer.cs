using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Configuration;
using System.Data;
using ChatApplication.Models.HelperBll;
using System.Data.SqlClient;

namespace ChatApplication.Models.HelperBll
{
    public class DataLayer
    {
        SqlConnection con = new SqlConnection();
        public DataLayer()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }
        public UserModel login(string email,string password)
        {
            UserModel user = new UserModel();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string sql = "select * from tbluser where email='" + email + "' and password='" + password + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                user.userid = Convert.ToInt32(row["userid"].ToString());
                user.email = row["email"].ToString();
                user.mobile = row["mobile"].ToString();
                user.password = row["password"].ToString();
            }
            return user;
        }
        public List<UserModel> getusers(int id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            List<UserModel> userlist = new List<UserModel>();
            string sql = "select * from tbluser where userid<>"+id;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                UserModel user = new UserModel();
                user.userid = Convert.ToInt32(row["userid"].ToString());
                user.email = row["email"].ToString();
                user.mobile = row["mobile"].ToString();
                user.password = row["password"].ToString();
                user.dob = DateTime.Now.ToString();
                userlist.Add(user);
            }
            return userlist;
        }

    }
}