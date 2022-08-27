using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace WebApplication4
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //XmlTextReader reader;
           
            try
            {
                if (FileUpload1.HasFile)
                {
                    XDocument doc = XDocument.Parse(FileUpload1.PostedFile.ToString());
                    XmlReader reader = doc.CreateReader();


                    Label2.Text = "1,";
                    //XDocument doc = XDocument.Parse(FileUpload1.PostedFile.ToString());
                    //Label2.Text += doc;
                    // Load the reader with the data file and ignore all white space nodes.         
                    //reader = new XmlTextReader(FileUpload1.PostedFile.InputStream);

                    Label2.Text = "0,";
                    //reader.WhitespaceHandling = WhitespaceHandling.None;

                    Label2.Text += "2,";
                    // Parse the file and display each of the nodes.
                    while (reader.Read())
                    {

                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            content.InnerHtml = reader.ReadElementContentAsString();

                            Label2.Text += "3,";
                            String aaaaa = reader.ReadElementContentAsString();
                            Label3.Text = aaaaa;
                        }

                    }
                    reader.Close();
                    Label2.Text += "4,";
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error: " + ex.Message;
            }
        }
    }
}