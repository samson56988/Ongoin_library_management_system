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
    public partial class Addbooks : System.Web.UI.Page
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

        protected void btnadd_Click(object sender, EventArgs e)
        {

            string book_image_name = Class1.GetRandomPassword(10) + ".jpg";
            string books_pdf = "";
            string book_video = "";

            string path = "";
            string path2 = "";
            string path3 = "";
            F1.SaveAs(Request.PhysicalApplicationPath + "/Libarian/bookimages/" + book_image_name.ToString());
            path = "bookimages/" + book_image_name.ToString();


            if (F2.FileName.ToString() != "")


           {
             books_pdf = Class1.GetRandomPassword(10) + ".pdf";

            
            F1.SaveAs(Request.PhysicalApplicationPath + "/Libarian/book_pdf/" + books_pdf.ToString());
            path2 = "book_pdf/" + books_pdf.ToString();
            }


            if (F3.FileName.ToString() != "")
            {
                book_video = Class1.GetRandomPassword(10) + ".mp4";

               
                F1.SaveAs(Request.PhysicalApplicationPath + "/Libarian/book_video/" + book_video.ToString());
                path3 = "book_video/" + book_video.ToString();

            }
               


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Book(bookstitle,booksimage, bookspdf,booksvideo, booksauthor,bookisbn,avaibleqty)values(@bookstitle,@booksimage, @bookspdf,@booksvideo,@booksauthor,@bookisbn,@avaibleqty)";
            cmd.Parameters.AddWithValue("@bookstitle", Booktitle.Text.Trim());
            cmd.Parameters.AddWithValue("@booksimage", path);
            cmd.Parameters.AddWithValue("@bookspdf", books_pdf);
            cmd.Parameters.AddWithValue("@booksvideo", book_video);

            cmd.Parameters.AddWithValue("@booksauthor",Bookauthor.Text.Trim());
            cmd.Parameters.AddWithValue("@bookisbn", bookisbn.Text.Trim() );
            cmd.Parameters.AddWithValue("@avaibleqty", bookquantity.Text.Trim());
            cmd.ExecuteNonQuery();
            msg.Style.Add("display", "block");

        }
    }
}