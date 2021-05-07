using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Library_Managment_System
{
    public partial class Student_display_book : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\dante\documents\visual studio 2015\Projects\Library Managment System\Library Managment System\App_Data\LMS.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }
            con.Open();

            if (Session["student"] == null)
            {
                Response.Redirect("Studentloging.aspx");
            }



            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Book  ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            r1.DataSource = dt;
            r1.DataBind();

        }

        public string checkvideo(object myvalue, object id)
        {
            if (myvalue == "")
            {

                return "Not Available";

            }
            else
            {
                myvalue = ".../Libarian/"+myvalue.ToString();
                return "<a href='" + myvalue.ToString() + "'style='color:green'>view video</a> ";
                


            }
        }

        public string checkpdf(object myvalue1, object id1)
        {
            if (myvalue1 == "")
            {

                return "Not Available";

            }
            else
            {
                myvalue1 = ".../Libarian/" + myvalue1.ToString();
                return "<a href='" + myvalue1.ToString() + "'style='color:green'>view pdf</a> ";

            }
        }
    }
}