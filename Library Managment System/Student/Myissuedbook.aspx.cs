using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Library_Managment_System.Student
{
    public partial class Myissuedbook : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\dante\documents\visual studio 2015\Projects\Library Managment System\Library Managment System\App_Data\LMS.mdf;Integrated Security=True");
        string penalty = "0";
        double noofdays = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }
            con.Open();

            if(Session["student"]==null)
            {
                Response.Redirect("Studentloging.aspx");
            }


            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from Penalty";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                penalty = dr2["Penalty"].ToString(); 

            }

                //this is for tempoary database

                DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("studentenrollment");
            dt.Columns.Add("bookisbn");
            dt.Columns.Add("bookissuedate");
            dt.Columns.Add("bookapproxreturndate");
            dt.Columns.Add("studentusername");
            dt.Columns.Add("isbookreturn");
            dt.Columns.Add("bookreturndate");
            dt.Columns.Add("latedays");
            dt.Columns.Add("Penalty");



            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from issuebook where studentusername='"+Session["student"].ToString()+"'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["studentenrollment"] = dr1["studentenrollment"].ToString();
                dr["bookisbn"] = dr1["bookisbn"].ToString(); 
                dr["bookissuedate"] = dr1["bookissuedate"].ToString();
                dr["bookapproxreturndate"] = dr1["bookapproxreturndate"].ToString();
                dr["studentusername"] = dr1["studentusername"].ToString();
                dr["isbookreturn"] = dr1["isbookreturn"].ToString();
                dr["bookreturndate"] = dr1["bookreturndate"].ToString();

                DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                DateTime d2 = Convert.ToDateTime(dr1["bookapproxreturndate"].ToString());




                if(d1>d2)
                {
                    TimeSpan t = d1 - d2;
                    noofdays = t.TotalDays;
                    dr["latedays"] = noofdays.ToString();

                }
                else
                {

                    dr["latedays"] = "0";
                }

                dr["Penalty"] = Convert.ToString(Convert.ToDouble(noofdays) * Convert.ToDouble(penalty));


                dt.Rows.Add(dr);

            }

            d1.DataSource = dt;
            d1.DataBind();

        }
    }
}