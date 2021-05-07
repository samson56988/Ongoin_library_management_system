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

    public partial class Issuebooks : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\dante\documents\visual studio 2015\Projects\Library Managment System\Library Managment System\App_Data\LMS.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }
            con.Open();

            if (IsPostBack) return;

            enronoDROP.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select enrollmentno from Student";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                enronoDROP.Items.Add(dr["enrollmentno"].ToString());

            }


            ISBNDROP.Items.Clear();
            ISBNDROP.Items.Add("Select");
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select bookisbn from Book";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                ISBNDROP.Items.Add(dr2["bookisbn"].ToString());

            }



        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

        }

        protected void ISBNDROP_SelectedIndexChanged(object sender, EventArgs e)
        {
              i1.ImageUrl = "";
              booksname.Text = "";
              instock.Text = "";

            
            
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
             
            cmd2.CommandText = "select * from Book where bookisbn = @bookisbn";
            cmd2.Parameters.AddWithValue("@bookisbn", ISBNDROP.SelectedItem.ToString());
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                i1.ImageUrl = dr2["booksimage"].ToString();
                booksname.Text = dr2["bookstitle"].ToString();
                instock.Text = dr2["avaibleqty"].ToString();

            }

        }

        protected void btnissuebook_Click(object sender, EventArgs e)
        {

            //this is to check if book has been selected
            if (ISBNDROP.SelectedItem.ToString() == "Select")
            {
                Response.Write("<script>alert('Please select book');</script>");
            }

            else
            {
                //this is to check if student has this book
                int found = 0;
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                cmd0.CommandText = "select * from issuebook where studentenrollment='" + enronoDROP.SelectedItem.ToString() + "' and bookisbn='" + ISBNDROP.SelectedItem.ToString() + "' and isbookreturn= 'no'";
                cmd0.ExecuteNonQuery();
                DataTable dt0 = new DataTable();
                SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
                da0.Fill(dt0);
                found = Convert.ToInt32(dt0.Rows.Count.ToString());

                if (found > 0)
                {
                    Response.Write("<script>alert('This book is already available with student');</script>");
                }
                else
                {
                    if (instock.Text == "0")
                    {
                        msg2.Style.Add("display", "block");
                    }
                    else
                    {

                        string book_issue_date = DateTime.Now.ToString("yyyy/MM/dd");
                        string approx_return_date = DateTime.Now.AddDays(10).ToString("yyyy/MM/dd");
                        string username = "";

                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;

                        cmd2.CommandText = "select * from Student where enrollmentno = @enrollmentno";
                        cmd2.Parameters.AddWithValue("@enrollmentno", enronoDROP.SelectedItem.ToString());
                        cmd2.ExecuteNonQuery();
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        da2.Fill(dt2);
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            username = dr2["username"].ToString();

                        }

                        SqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "insert into issuebook(studentenrollment,bookisbn, bookissuedate,bookapproxreturndate,studentusername,isbookreturn,bookreturndate)values(@studentenrollment,@bookisbn, @bookissuedate,@bookapproxreturndate,@studentusername,@isbookreturn,@bookreturndate)";
                        cmd3.Parameters.AddWithValue("@studentenrollment", enronoDROP.SelectedItem.ToString());
                        cmd3.Parameters.AddWithValue("@bookisbn", ISBNDROP.SelectedItem.ToString());
                        cmd3.Parameters.AddWithValue("@bookissuedate", book_issue_date.ToString());
                        cmd3.Parameters.AddWithValue("@bookapproxreturndate", approx_return_date.ToString());
                        cmd3.Parameters.AddWithValue("@studentusername", username.ToString());
                        cmd3.Parameters.AddWithValue("@isbookreturn", "no");
                        cmd3.Parameters.AddWithValue("@bookreturndate", "no");
                        cmd3.ExecuteNonQuery();


                        SqlCommand cmd4 = con.CreateCommand();
                        cmd4.CommandType = CommandType.Text;
                        cmd4.CommandText = "update Book set avaibleqty = avaibleqty-1 where bookisbn='" + ISBNDROP.SelectedItem.ToString() + "'";
                        cmd4.ExecuteNonQuery();

                        Response.Write("<script>alert('Book Issued Successfully ');</script>");


                    }


                }


            }

            










        }
    }
}