using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Project
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
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
                // Check if the record with the given Pid exists
                string checkQuery = "SELECT COUNT(*) FROM Shopimage WHERE Pid = @Pid";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Pid", Pid);

                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // If the record exists, perform the update
                    string updateQuery = "UPDATE Shopimage SET Image1 = @ImagePath1 WHERE Pid = @Pid";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@Pid", Pid);
                    command.Parameters.AddWithValue("@ImagePath1", imagePath1);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Data updated successfully');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Failed to update data');", true);
                    }
                }
                else
                {
                    // If the record doesn't exist, display a message
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Pid does not exist, cannot update data');", true);
                }
            }
        }




        protected void infoimage(object sender, EventArgs e)
        {
            string Pid = TextBox1.Text;

            // Process each file upload control
            string imagePath1 = Save(FileUpload1);
            string imagePath2 = Save(FileUpload2); // Assuming you have two more FileUpload controls named image2Upload and image3Upload
            string imagePath3 = Save(FileUpload3);

            // Save the name and image paths to the database
            SaveTo(Pid, imagePath1, imagePath2, imagePath3);
        }

        private string Save(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string directoryPath = Server.MapPath("~/Images/");
                string filePath = Path.Combine(directoryPath, fileName);

                // Ensure the directory exists
                Directory.CreateDirectory(directoryPath);

                fileUpload.SaveAs(filePath);
                return "~/Images/" + fileName; // Return relative URL
            }
            return null;
        }

        private void SaveTo(string Pid, string imagePath1, string imagePath2, string imagePath3)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Check if the record with the given name exists
                string checkQuery = "SELECT COUNT(*) FROM infoimage WHERE Name = @Name";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Name", Pid);

                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // If the record exists, perform the update
                    string updateQuery = "UPDATE infoimage SET image1 = @ImagePath1, image2 = @ImagePath2, image3 = @ImagePath3 WHERE Name = @Name";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@Name", Pid);
                    command.Parameters.AddWithValue("@ImagePath1", imagePath1);
                    command.Parameters.AddWithValue("@ImagePath2", imagePath2);
                    command.Parameters.AddWithValue("@ImagePath3", imagePath3);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Data updated successfully');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Failed to update data');", true);
                    }
                }
                else
                {
                    // If the record doesn't exist, display a message
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Name does not exist, cannot update data');", true);
                }
            }
        }


        protected void Information_Click(object sender, EventArgs e)
        {
            // Retrieve values from TextBox controls
            string name = Name.Text;
            string category = Category.Text;
            string description = Description.Text;
            string pros = Pros.Text;
            string cons = Cons.Text;
            string period = Period.Text;
            string season = Season.Text;

            // Insert data into database
            InsertData(name, category, description, pros, cons, period, season);
        }
        private bool IsNameExists(string name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Information WHERE Name = @Name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                // If count is greater than 0, it means the name exists in the table
                return count > 0;
            }
        }
        private void InsertData(string name, string category, string description, string pros, string cons, string period, string season)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Check if the name already exists in the database
                if (IsNameExists(name))
                {
                    // If the name exists, perform an update
                    string updateQuery = "UPDATE Information SET Category = @Category, Description = @Description, Pros = @Pros, Cons = @Cons, Period = @Period, Season = @Season WHERE Name = @Name";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@Name", name);
                    updateCommand.Parameters.AddWithValue("@Category", category);
                    updateCommand.Parameters.AddWithValue("@Description", description);
                    updateCommand.Parameters.AddWithValue("@Pros", pros);
                    updateCommand.Parameters.AddWithValue("@Cons", cons);
                    updateCommand.Parameters.AddWithValue("@Period", period);
                    updateCommand.Parameters.AddWithValue("@Season", season);

                    try
                    {
                        connection.Open();
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Update successful
                            Response.Write("<script>alert('Data updated successfully');</script>");
                        }
                        else
                        {
                            // No rows affected, handle the case if necessary
                            Response.Write("<script>alert('No rows affected, data not updated');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception, log it, or display an error message
                        Response.Write("<script>alert('An error occurred while updating data');</script>");
                    }
                }
                else
                {
                    // If the name does not exist, handle the case here
                    Response.Write("<script>alert('Name does not exist, cannot update data');</script>");
                }
            }
        }



        protected void Shop_Click(object sender, EventArgs e)
        {
            string pid = TextBox9.Text;
            string name = TextBox2.Text;
            string category = TextBox3.Text;
            string brand = TextBox4.Text;
            string ratings = TextBox5.Text;
            string amount = TextBox6.Text;
            string stock = TextBox7.Text;

            InsertDataShop(pid, name, category, brand, ratings, amount, stock);
        }

        private void InsertDataShop(string pid, string name, string category, string brand, string ratings, string amount, string stock)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Check if the Pid already exists in the database
                if (IsPidExists(pid))
                {
                    // If the Pid exists, perform an update
                    string updateQuery = @"UPDATE Shop SET Name = @Name, Category = @Category, Brand = @Brand, Ratings = @Ratings, Amount = @Amount, Stock = @Stock WHERE Pid = @Pid";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@Pid", pid);
                    updateCommand.Parameters.AddWithValue("@Name", name);
                    updateCommand.Parameters.AddWithValue("@Category", category);
                    updateCommand.Parameters.AddWithValue("@Brand", brand);
                    updateCommand.Parameters.AddWithValue("@Ratings", ratings);
                    updateCommand.Parameters.AddWithValue("@Amount", amount);
                    updateCommand.Parameters.AddWithValue("@Stock", stock);

                    try
                    {
                        connection.Open();
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Update successful
                            Response.Write("<script>alert('Data updated successfully');</script>");
                        }
                        else
                        {
                            // No rows affected, handle the case if necessary
                            Response.Write("<script>alert('No rows affected, data not updated');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception, log it, or display an error message
                        Response.Write("<script>alert('An error occurred while updating data');</script>");
                    }
                }
                else
                {
                    // If the name does not exist, handle the case here
                    Response.Write("<script>alert('Name does not exist, cannot update data');</script>");
                }
            }
            }
        private bool IsPidExists(string pid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Shop WHERE Pid = @Pid";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", pid);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                // If count is greater than 0, it means the Pid exists in the table
                return count > 0;
            }
        }

    }
}