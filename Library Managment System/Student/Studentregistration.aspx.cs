using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net;
using System.IO;


namespace Library_Managment_System.Student
{
    public partial class Studentregistration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\dante\documents\visual studio 2015\Projects\Library Managment System\Library Managment System\App_Data\LMS.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }
            con.Open();
        }

        protected void B1_Click(object sender, EventArgs e)
        {

            int count = 0;
            int count2 = 0;
            if (IsReCaptchValid())
            {

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select * from Student where enrollmentno='"+enrollmentno.Text+"'";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.Fill(dt1);
                count = Convert.ToInt32(dt1.Rows.Count.ToString());

                if(count>0)
                {
                    Response.Write("<script>alert('Enrollment ID already exist');</script>");
                }
                else
                {
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select * from Student where username='" +Username.Text+ "'";
                    cmd2.ExecuteNonQuery();
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter();
                    da1.Fill(dt2);
                    count2 = Convert.ToInt32(dt2.Rows.Count.ToString());
                    if (count > 0)
                    {
                        Response.Write("<script>alert('User with username already exist');</script>");
                    }
                    else
                    {
                        string randomno = Class1.GetRandomPassword(10) + ".jpg";
                        string path = "";

                        F1.SaveAs(Request.PhysicalApplicationPath + "/Student/studentimage/" + randomno.ToString());
                        path = "Student/studentimage/" + randomno.ToString();





                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Student(Firstname,Lastname,enrollmentno,username,password,email,contact,studentimage,approved)values(@Firstname,@Lastname,@enrollmentno,@username,@password,@email,@contact,@studentimage,@approved)";
                        cmd.Parameters.AddWithValue("@Firstname", firstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Lastname", Lastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@enrollmentno", enrollmentno.Text.Trim());
                        cmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", Password.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact", Contact.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentimage", path);
                        cmd.Parameters.AddWithValue("@approved", "pending");
                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Record inserted successfully');</script>");
                    }

                        
                }
                
            }
            else
            {
                lblMessage1.Text = "this is invalid";
            }
            

        }

        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "secretkeyfromgoogle";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
    }
}