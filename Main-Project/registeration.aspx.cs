using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;

namespace Main_Project
{
    public partial class registeration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize the image upload control
            HtmlInputFile imageUpload = (HtmlInputFile)FindControl("imageUpload");
        }

        protected void registrationForm_Submit(object sender, EventArgs e)
        {
            // Retrieve connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                // Check if controls are initialized
                if (uid != null && username != null && email != null && password != null && imageUpload != null && imageUpload.PostedFile != null && imageUpload.PostedFile.ContentLength > 0)
                {
                    // Check if the username already exists in the database
                    if (IsUsernameExists(uid.Text, connectionString))
                    {
                        // Username already exists, display an alert message
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Username already exists. Please choose another username.');", true);
                        return;
                    }

                    // Convert uploaded file to byte array
                    byte[] imageData = null;
                    using (BinaryReader br = new BinaryReader(imageUpload.PostedFile.InputStream))
                    {
                        imageData = br.ReadBytes(imageUpload.PostedFile.ContentLength);
                    }

                    // Insert new registration with image data
                    string query = "INSERT INTO Registration (UID, Name, Email, Password, Image) VALUES (@UID, @Name, @Email, @Password, @Image)";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@UID", uid.Text);
                        command.Parameters.AddWithValue("@Name", username.Text);
                        command.Parameters.AddWithValue("@Email", email.Text);
                        command.Parameters.AddWithValue("@Password", password.Text);
                        command.Parameters.AddWithValue("@Image", imageData); // Assuming "Image" is the name of the column in your database
                        command.ExecuteNonQuery();
                    }

                    // Optionally, redirect the user to a different page after successful registration
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    // Handle case where one or more controls are not initialized
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Some form fields are not initialized.');", true);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, display an error message
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An error occurred: " + ex.Message + "');", true);
            }
        }

        // Method to check if the UID already exists in the database
        private bool IsUsernameExists(string uid, string connectionString)
        {
            string query = "SELECT COUNT(*) FROM Registration WHERE UID = @UID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UID", uid);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
