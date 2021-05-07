using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Library_Managment_System.Libarian
{
    public partial class DisplayBook : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\dante\documents\visual studio 2015\Projects\Library Managment System\Library Managment System\App_Data\LMS.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }
            con.Open();

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
            if(myvalue=="")
            {

                return myvalue.ToString();

            }
            else
            {
                return "<a href ='deletefiles.aspx?id="+id+"'style='color:red'>delete video<a/>";

            }
        }

        public string checkpdf(object myvalue1, object id1)
        {
            if (myvalue1 == "")
            {

                return myvalue1.ToString();

            }
            else
            {
                return "<a href ='deletefiles.aspx?id1=" + id1 + "'style='color:red'>delete pdf<a/>";

            }
        }
    }
}