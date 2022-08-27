using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml.Linq;

namespace WebApplication4
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strcon = ConfigurationManager.ConnectionStrings["dbconfig"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM details;", con);
                Repeater1.DataSource = cmd.ExecuteReader();
                Repeater1.DataBind();
                con.Close();
            }
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconfig"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            //string connectionString = "";

            string f1 = fname1.Text;
            string f2 = lname1.Text;
            string f3 = addr1.Text;
            string f4 = addr21.Text;

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            sql = "Insert into details([fname],[lname],[addr],[addr2]) values ('" + f1 + "','" + f2 + "','" + f3 + "','" + f4 + "')";
            command = new SqlCommand(sql, con);
            adapter.InsertCommand = new SqlCommand(sql, con);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();

            SqlCommand cmd = new SqlCommand("SELECT * FROM details;", con);
            Repeater1.DataSource = cmd.ExecuteReader();
            Repeater1.DataBind();
            con.Close();
        }
    }
}