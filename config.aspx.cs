using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string extn = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            //string SaveLocation = Server.MapPath("upload") + "\\" + fn;
           
                FileUpload1.SaveAs(Server.MapPath("~/")+FileUpload1.PostedFile.FileName);
                try
                {
                    //FileUpload1.PostedFile.SaveAs(SaveLocation);
                    Label1.Text = "Status: The file '" + fn + "' has been uploaded.";
                }
                catch (Exception ex)
                {
                    Label1.Text = "Error: " + ex.Message;
                }
        }
    }
}
