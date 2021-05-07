using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Library_Managment_System.Libarian
{
    public partial class Editbooks : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\dante\documents\visual studio 2015\Projects\Library Managment System\Library Managment System\App_Data\LMS.mdf;Integrated Security=True");
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }
            con.Open();

            id = Convert.ToInt32(Request.QueryString["Id"].ToString());
            if (IsPostBack) return;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *  from Book where Id =" + id + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Booktitle.Text = dr["bookstitle"].ToString();
                Bookauthor.Text = dr["booksauthor"].ToString();
                bookisbn.Text = dr["bookisbn"].ToString();
                bookquantity.Text = dr["avaibleqty"].ToString();
                bookspdf.Text = dr["bookspdf"].ToString();
                booksimage.Text = dr["booksimage"].ToString();
                booksvideo.Text = dr["booksvideo"].ToString();



            }


        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string book_image_name = "";
            string books_pdf = "";
            string book_video = "";

            string path = "";
            string path2 = "";
            string path3 = "";
            


            if (F1.FileName.ToString() !="")
            {
                book_image_name = Class1.GetRandomPassword(10) + ".jpg";
                F1.SaveAs(Request.PhysicalApplicationPath + "/Libarian/bookimages/" + book_image_name.ToString());
                path = "bookimages/" + book_image_name.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Book SET bookstitle=@bookstitle ,booksimage=@booksimage,booksauthor=@booksauthor,bookisbn = @bookisbn,avaibleqty=@avaibleqty WHERE ID='" + id + "' ";
                cmd.Parameters.AddWithValue("@bookstitle", Booktitle.Text.Trim());
                cmd.Parameters.AddWithValue("@booksimage", path);
                cmd.Parameters.AddWithValue("@booksauthor", Bookauthor.Text.Trim());
                cmd.Parameters.AddWithValue("@bookisbn", bookisbn.Text.Trim());
                cmd.Parameters.AddWithValue("@avaibleqty", bookquantity.Text.Trim());
                cmd.ExecuteNonQuery();
            }
               
            
            

            if (F2.FileName.ToString() != "")


            {
                books_pdf = Class1.GetRandomPassword(10) + ".pdf";


                F1.SaveAs(Request.PhysicalApplicationPath + "/Libarian/book_pdf/" + books_pdf.ToString());
                path2 = "book_pdf/" + books_pdf.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Book SET bookstitle=@bookstitle ,bookspdf=@bookspdf,booksauthor=@booksauthor,bookisbn = @bookisbn,avaibleqty=@avaibleqty WHERE ID='" + id + "' ";
                cmd.Parameters.AddWithValue("@bookstitle", Booktitle.Text.Trim());
                cmd.Parameters.AddWithValue("@bookspdf", path2);
               
                cmd.Parameters.AddWithValue("@booksauthor", Bookauthor.Text.Trim());
                cmd.Parameters.AddWithValue("@bookisbn", bookisbn.Text.Trim());
                cmd.Parameters.AddWithValue("@avaibleqty", bookquantity.Text.Trim());
                cmd.ExecuteNonQuery();
            }


            if (F3.FileName.ToString() != "")
            {
                book_video = Class1.GetRandomPassword(10) + ".mp4";


                F1.SaveAs(Request.PhysicalApplicationPath + "/Libarian/book_video/" + book_video.ToString());
                path3 = "book_video/" + book_video.ToString();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Book SET bookstitle=@bookstitle ,booksvideo=@booksvideo,booksauthor=@booksauthor,bookisbn = @bookisbn,avaibleqty=@avaibleqty WHERE ID='" + id + "' ";
                cmd.Parameters.AddWithValue("@bookstitle", Booktitle.Text.Trim());
                cmd.Parameters.AddWithValue("@booksvideo", book_video);
                cmd.Parameters.AddWithValue("@booksauthor", Bookauthor.Text.Trim());
                cmd.Parameters.AddWithValue("@bookisbn", bookisbn.Text.Trim());
                cmd.Parameters.AddWithValue("@avaibleqty", bookquantity.Text.Trim());
                cmd.ExecuteNonQuery();

            }

            if(F1.FileName.ToString()=="" && F2.FileName.ToString() == "" && F3.FileName.ToString() == "")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Book SET bookstitle=@bookstitle,booksauthor=@booksauthor,bookisbn = @bookisbn,avaibleqty=@avaibleqty WHERE ID='" + id + "' ";
                cmd.Parameters.AddWithValue("@bookstitle", Booktitle.Text.Trim());
                cmd.Parameters.AddWithValue("@booksauthor", Bookauthor.Text.Trim());
                cmd.Parameters.AddWithValue("@bookisbn", bookisbn.Text.Trim());
                cmd.Parameters.AddWithValue("@avaibleqty", bookquantity.Text.Trim());
                cmd.ExecuteNonQuery();
            }



            Response.Redirect("DisplayBook.aspx");

        }
    }
  }
