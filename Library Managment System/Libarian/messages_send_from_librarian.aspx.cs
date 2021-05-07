using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;

namespace Library_Managment_System.Libarian
{
    public partial class messages_send_from_librarian : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\dante\documents\visual studio 2015\Projects\Library Managment System\Library Managment System\App_Data\LMS.mdf;Integrated Security=True");
        string username = "";
        string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }
            con.Open();

            username = Request.QueryString["username"].ToString();
            msg = Request.QueryString["msg"].ToString();


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Messages (susername,dusername,msg,placed)values(@susername,@dusername,@msg,@placed)";
            cmd.Parameters.AddWithValue("@susername", "Libarian");
            cmd.Parameters.AddWithValue("@dusername", username.ToString());
            cmd.Parameters.AddWithValue("@msg", msg.ToString());
            cmd.Parameters.AddWithValue("@placed", "No");
            cmd.ExecuteNonQuery();
        }
    }
}