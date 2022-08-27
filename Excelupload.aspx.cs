using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Microsoft.WindowsAPICodePack.Shell;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Elastic.Apm.NetCoreAll;

namespace WebApplication4
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconfig"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string connectionString = "";
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string extn = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileLocation = "c:\\logs\\";
                //string SaveLocation = Server.MapPath("upload") + "\\" + fn;
                if (extn == ".xlsx")
                {
                    FileUpload1.SaveAs("c:\\logs\\" + FileUpload1.PostedFile.FileName);
                    fileLocation += FileUpload1.PostedFile.FileName;
                    try
                    {
                        //FileUpload1.PostedFile.SaveAs(SaveLocation);
                        Label1.Text = "Status: The file '" + fn + "' has been uploaded.";
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = "Error: " + ex.Message;
                    }

                    if (extn == ".xls")
                    {
                        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    else if (extn == ".xlsx")
                    {
                        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }

                    //Create OleDB Connection and OleDb Command

                    OleDbConnection con2 = new OleDbConnection(connectionString);
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = con2;
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                    DataTable dtExcelRecords = new DataTable();
                    con2.Open();
                    DataTable dtExcelSheetName = con2.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                    cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = cmd;
                    dAdapter.Fill(dtExcelRecords);
                    con2.Close();
                    GridView1.DataSource = dtExcelRecords;
                    GridView1.DataBind();


                    string filePath = @"C:\logs\" + FileUpload1.PostedFile.FileName;
                    var file = ShellFile.FromFilePath(filePath);
                    string[] oldAuthors = file.Properties.System.Author.Value;
                    string oldTitle = file.Properties.System.Title.Value;
                    if (oldTitle != null && oldAuthors != null)
                    {
                        Label4.Text = "File Details:";
                        Label2.Text = "Subject: " + oldTitle.ToString();
                        Label3.Text = "Uploaded By: " + oldAuthors[0].ToString();
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
                        Label4.Text = "No Properties in the file.";
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