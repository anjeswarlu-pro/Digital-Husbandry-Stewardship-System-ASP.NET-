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
    public partial class Insert : System.Web.UI.Page
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
                string query = "INSERT INTO Shopimage (Pid, Image1) VALUES (@Pid, @ImagePath1)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", Pid);
                command.Parameters.AddWithValue("@ImagePath1", imagePath1);

                connection.Open();
                command.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Data saved successfully');", true);

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
                string query = "INSERT INTO infoimage (Name, image1, image2, image3) VALUES (@Name, @ImagePath1, @ImagePath2, @ImagePath3)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", Pid);
                command.Parameters.AddWithValue("@ImagePath1", imagePath1);
                command.Parameters.AddWithValue("@ImagePath2", imagePath2);
                command.Parameters.AddWithValue("@ImagePath3", imagePath3);

                connection.Open();
                command.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Data saved successfully');", true);
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
            if (IsNameExists(name))
            {
                Response.Write("<script>alert('Name already exists');</script>");
                return; // Exit method if name already exists
            }

            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Information (Name, Category, Description, Pros, Cons, Period, Season) " +
                               "VALUES (@Name, @Category, @Description, @Pros, @Cons, @Period, @Season)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Category", category);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Pros", pros);
                command.Parameters.AddWithValue("@Cons", cons);
                command.Parameters.AddWithValue("@Period", period);
                command.Parameters.AddWithValue("@Season", season);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Insertion successful, you can add any further logic or display a success message
                    Response.Write("<script>alert('Data inserted successfully');</script>");
                }
                catch (Exception ex)
                {
                    // Handle the exception, log it, or display an error message
                    Response.Write("<script>alert('An error occurred while inserting data');</script>");
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

            if (IsPidExists(pid))
            {
                Response.Write("<script>alert('Pid already exists');</script>");
                return; // Exit method if Pid already exists
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Shop (Pid, Name, Category, Brand, Ratings, Amount, Stock) 
                             VALUES (@Pid, @Name, @Category, @Brand, @Ratings, @Amount, @Stock)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", pid);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Category", category);
                command.Parameters.AddWithValue("@Brand", brand);
                command.Parameters.AddWithValue("@Ratings", ratings);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Stock", stock);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Insertion successful, you can add any further logic or display a success message
                    Response.Write("<script>alert('Data inserted successfully');</script>");
                }
                catch (Exception ex)
                {
                    // Handle the exception, log it, or display an error message
                    Response.Write("<script>alert('An error occurred while inserting data');</script>");
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