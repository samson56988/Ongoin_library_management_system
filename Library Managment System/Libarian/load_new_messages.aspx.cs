﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Library_Managment_System.Libarian
{
    public partial class load_new_messages : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\dante\documents\visual studio 2015\Projects\Library Managment System\Library Managment System\App_Data\LMS.mdf;Integrated Security=True");
        string username = "";
        int count = 0;
        string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }
            con.Open();


            username = Request.QueryString["username"].ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Messages where dusername='Libarian' and placed='no'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {

                count = count + 1;

                if(count == 1)
                {
                    msg = dr["susername"].ToString() + ":" + dr["msg"].ToString();

                }
                else
                {

                    msg = msg + "[|abcd|]" + dr["susername"].ToString() + ":" + dr["msg"].ToString();


                }

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update Messages set placed='yes' where id=" + dr["id"].ToString() + "";
                cmd1.ExecuteNonQuery();

            }

            if(count==0)
            {
                Response.Write("0");
            }

            else
            {
                Response.Write(msg.ToString());
            }

        }
    }
}