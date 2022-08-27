using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace WebApplication4
{
    public partial class cross : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
               
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                //string SaveLocation = Server.MapPath("upload") + "\\" + fn;
                FileUpload1.SaveAs("c:\\logs\\" + FileUpload1.PostedFile.FileName);
                try
                {
                    //FileUpload1.PostedFile.SaveAs(SaveLocation);
                    Label1.Text = "The file '" + fn + "' has been uploaded./////";
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
                    Label1.Text += oldTitle.ToString() + "|" + oldAuthors[0].ToString();
                   
                }
                else
                {
                    Label1.Text += "Empty!";
                }
            }
            else
            {
                Label1.Text = "Please select a file to upload.";
            }
        }

    }
}