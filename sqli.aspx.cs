using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string strcon = ConfigurationManager.ConnectionStrings["dbconfig"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                //string SaveLocation = Server.MapPath("upload") + "\\" + fn;

                string extn = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);

                if (extn == ".pdf" || extn == ".pptx" || extn == ".docx" || extn == ".csv" || extn == ".xlsx")
                {

                    FileUpload1.SaveAs("c:\\logs\\" + FileUpload1.PostedFile.FileName);
                    try
                    {
                        //FileUpload1.PostedFile.SaveAs(SaveLocation);
                        Label1.Text = "The file '" + fn + "' has been uploaded. | ";
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = "Error: " + ex.Message;
                    }
                    string filePath = @"C:\logs\" + FileUpload1.PostedFile.FileName;
                    var file = ShellFile.FromFilePath(filePath);
                    string[] oldAuthors = file.Properties.System.Author.Value;
                    string oldTitle = file.Properties.System.Title.Value;
                    if (oldTitle != null && oldAuthors != null)
                    {
                        //Label1.Text += oldTitle.ToString() + "|" + oldAuthors[0].ToString();
                        SqlCommand command;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        String sql = "";
                        sql = "Insert into filedetails([filename],[filepath],[fileprop1],[fileprop2]) values ('" + FileUpload1.PostedFile.FileName + "','c:\\logs\\" + FileUpload1.PostedFile.FileName + "','" + oldTitle.ToString() + "','" + oldAuthors[0].ToString() + "')";
                        command = new SqlCommand(sql, con);
                        adapter.InsertCommand = new SqlCommand(sql, con);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        con.Close();
                    }
                    else
                    {
                        Label1.Text += "No Properties in the file.";
                    }
                }
                else { Label1.Text += "Invalid File!"; }
            }
            else
            {
                Label1.Text = "Please select a file to upload.";
            }
        }
    }
}