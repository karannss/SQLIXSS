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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "c:\\Windows\\win.ini";
            int idx = s.LastIndexOf('\\');
            string fname2 = s.Substring(idx);
            Label1.Text = fname2;
        }

       
    }
}