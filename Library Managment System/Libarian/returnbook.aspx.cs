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
    public partial class returnbook : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\dante\documents\visual studio 2015\Projects\Library Managment System\Library Managment System\App_Data\LMS.mdf;Integrated Security=True");
        int id;
        string bookisbn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }
            con.Open();

            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update issuebook set isbookreturn='Yes',bookreturndate='"+DateTime.Now.ToString("yyyy/MM/dd")+"' where id="+id+"";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = " select * from Book where id="+id+"";
            cmd.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach(DataRow dr1 in dt1.Rows)
            {
                bookisbn = dr1["bookisbn"].ToString();


            }

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "update Book set avaibleqty=avaibleqty+1 where bookisbn='" + bookisbn.ToString()+"'";
            cmd2.ExecuteNonQuery();


            Response.Redirect("return_books.aspx");





        }
    }
}