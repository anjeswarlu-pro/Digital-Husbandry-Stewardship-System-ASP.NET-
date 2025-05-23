using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Main_Project
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is logged in
                if (Session["UID"] != null)
                {
                    // Retrieve the user ID from the session variable
                    string userId = Session["UID"].ToString();

                    try
                    {
                        // Establish connection to the database
                        string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Define SQL query to fetch user details
                            string query = "SELECT UID, Name, Email, Image FROM Registration WHERE UID = @UserId";

                            // Prepare SQL command with parameters
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@UserId", userId);

                                // Execute SQL command and read the result
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // Populate labels with fetched data
                                        lblUserId.Text = reader["UID"].ToString();
                                        lblName.Text = reader["Name"].ToString();
                                        lblEmail.Text = reader["Email"].ToString();

                                        // Retrieve binary image data
                                        byte[] imageData = (byte[])reader["Image"];

                                        // Convert binary data to Base64 string
                                        string base64Image = Convert.ToBase64String(imageData);
                                        string imageUrl = $"data:image/jpeg;base64,{base64Image}";

                                        // Set image URL to the ASP.NET Image control
                                        imgProfile.ImageUrl = imageUrl; // Assuming imgProfile is your ASP.NET Image control
                                    }
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions (e.g., database connection errors)
                        lblMessage.Text = "An error occurred: " + ex.Message;
                    }
                }

            }
        }
        protected void MyOrdersButton_Click(object sender, EventArgs e)
        {
            // Retrieve the connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            // Get the user ID from session
            string userId = Session["UID"] as string;

            if (!string.IsNullOrEmpty(userId))
            {
                // Define the query to select orders for the current user
                string query = "SELECT * FROM Orders WHERE UserId = @UserId";

                // Create a SqlConnection object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a SqlCommand object with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Open the connection
                        connection.Open();

                        // Execute the query and get a SqlDataReader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Bind the data to GridView
                            GridView1.DataSource = reader;
                            GridView1.DataBind();
                        }
                    }
                }
            }
            else
            {
                // Handle case when user ID is not found in session
                // For example, display an error message or redirect the user
                // Response.Redirect("Login.aspx"); // Redirect to login page
                // lblMessage.Text = "User ID not found. Please log in again."; // Display error message
            }
        }
    }
}
