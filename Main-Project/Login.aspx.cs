using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Main_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is already logged in, if yes, redirect to some other page
                if (Session["username"] != null)
                {
                    Response.Redirect("User.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Uid = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            // Establish connection to the database
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to check if the username and password exist in the database
                string query = "SELECT Aid,Password FROM Admin WHERE Aid = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", Uid);
                command.Parameters.AddWithValue("@Password", password);

                // Open the connection and execute the query
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // If a matching record is found, login successful
                if (reader.Read())
                {
                    // Retrieve additional information from the database
                  
                  

                    // Store user information in session variables for later use
                    Session["UID"] = Uid;
                    Session["Password"] = password;
                   

                    // Redirect to welcome page or some other authenticated page
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    // Invalid credentials, display error message
                    Label1.Text = "Invalid username or password";
                }
            }
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string Uid = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Establish connection to the database
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to check if the username and password exist in the database
                string query = "SELECT UID,Password FROM Registration WHERE UID = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", Uid);
                command.Parameters.AddWithValue("@Password", password);

                // Open the connection and execute the query
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // If a matching record is found, login successful
                if (reader.Read())
                {
                    // Retrieve additional information from the database



                    // Store user information in session variables for later use
                    Session["UID"] = Uid;
                    Session["Password"] = password;


                    // Redirect to welcome page or some other authenticated page
                    Response.Redirect("User.aspx");
                }
                else
                {
                    // Invalid credentials, display error message
                    lblMessage.Text = "Invalid username or password";
                }
            }
        }
    }
}
