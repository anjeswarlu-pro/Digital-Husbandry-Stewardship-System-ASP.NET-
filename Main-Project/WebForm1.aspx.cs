using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace Main_Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void submitButton_Click(object sender, EventArgs e)
        {
            string Pid = nameTextBox.Text;

            // Process each file upload control
            string imagePath1 = SaveImage(image1Upload);
           

            // Save the name and image paths to the database
            SaveToDatabase(Pid, imagePath1);
        }

        private string SaveImage(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string directoryPath = Server.MapPath("~/Shopimages/");
                string filePath = Path.Combine(directoryPath, fileName);

                // Ensure the directory exists
                Directory.CreateDirectory(directoryPath);

                fileUpload.SaveAs(filePath);
                return "~/Shopimages/" + fileName; // Return relative URL
            }
            return null;
        }

        private void SaveToDatabase(string Pid, string imagePath1)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Shopimage (Pid, Image1) VALUES (@Pid, @ImagePath1)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", Pid);
                command.Parameters.AddWithValue("@ImagePath1", imagePath1);
               
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
