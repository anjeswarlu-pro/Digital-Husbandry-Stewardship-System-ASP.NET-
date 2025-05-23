using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Main_Project
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

     

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Display.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Insert.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");
        }
    }
}
