using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Project
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the user ID from the text box
            string userId = txtUserId.Text;

            // Perform the deletion operation using the user ID
            bool deleted = DeleteUser(userId);

            // Generate an alert based on the deletion result
            if (deleted)
            {
                // User successfully deleted
                string message = "User with ID " + userId + " has been successfully deleted.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                // Failed to delete user
                string message = "Failed to delete user with ID " + userId + ". User not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }
       


        private bool DeleteUser(string userId)
        {
            // Assuming connectionString is defined in your web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                // Construct the SQL command to delete the user with the provided userId
                string query = "DELETE FROM Registration WHERE Uid = @UserId";

                // Create a SqlConnection object with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for UserId
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected (i.e., if deletion was successful)
                        if (rowsAffected > 0)
                        {
                            // If deletion was successful, return true
                            return true;
                        }
                        else
                        {
                            // If no rows were affected, return false
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine("Error occurred while deleting user: " + ex.Message);
                return false; // Return false indicating deletion failed
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            // Get the user ID from the text box
            string PId = TextBox1.Text;

            // Perform the deletion operation using the user ID
            bool deleted = DeleteCart(PId);

            // Generate an alert based on the deletion result
            if (deleted)
            {
                // User successfully deleted
                string message = "Prodcut with ID " + PId + " has been successfully deleted.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                // Failed to delete user
                string message = "Failed to delete Prodcut with ID " + PId + ". User not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }
        private bool DeleteCart(string userId)
        {
            // Assuming connectionString is defined in your web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                // Construct the SQL command to delete the user with the provided userId
                string query = "DELETE FROM Cart WHERE Pid = @userId";

                // Create a SqlConnection object with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for UserId
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected (i.e., if deletion was successful)
                        if (rowsAffected > 0)
                        {
                            // If deletion was successful, return true
                            return true;
                        }
                        else
                        {
                            // If no rows were affected, return false
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine("Error occurred while deleting user: " + ex.Message);
                return false; // Return false indicating deletion failed
            }
        }
        protected void InfoImage(object sender, EventArgs e)
        {
            // Get the user ID from the text box
            string Product = TextBox2.Text;

            // Perform the deletion operation using the user ID
            bool deleted = DeleteProduct(Product);

            // Generate an alert based on the deletion result
            if (deleted)
            {
                // User successfully deleted
                string message = "Prodcut with ID " + Product + " has been successfully deleted.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                // Failed to delete user
                string message = "Failed to delete Prodcut with ID " + Product + ". User not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }

        private bool DeleteProduct(string userId)
        {
            // Assuming connectionString is defined in your web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                // Construct the SQL command to delete the user with the provided userId
                string query = "DELETE FROM infoimage WHERE Name = @userId";

                // Create a SqlConnection object with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for UserId
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected (i.e., if deletion was successful)
                        if (rowsAffected > 0)
                        {
                            // If deletion was successful, return true
                            return true;
                        }
                        else
                        {
                            // If no rows were affected, return false
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine("Error occurred while deleting user: " + ex.Message);
                return false; // Return false indicating deletion failed
            }
        }




        protected void Information(object sender, EventArgs e)
        {
            // Get the user ID from the text box
            string Product = TextBox3.Text;

            // Perform the deletion operation using the user ID
            bool deleted = DeleteInformation(Product);

            // Generate an alert based on the deletion result
            if (deleted)
            {
                // User successfully deleted
                string message = "Prodcut with Name " + Product + " has been successfully deleted.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                // Failed to delete user
                string message = "Failed to delete Prodcut with Name " + Product + ". User not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }

        private bool DeleteInformation(string userId)
        {
            // Assuming connectionString is defined in your web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                // Construct the SQL command to delete the user with the provided userId
                string query = "DELETE FROM Information WHERE Name = @userId";

                // Create a SqlConnection object with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for UserId
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected (i.e., if deletion was successful)
                        if (rowsAffected > 0)
                        {
                            // If deletion was successful, return true
                            return true;
                        }
                        else
                        {
                            // If no rows were affected, return false
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine("Error occurred while deleting user: " + ex.Message);
                return false; // Return false indicating deletion failed
            }
        }


        protected void Orders(object sender, EventArgs e)
        {
            // Get the user ID from the text box
            string Order = TextBox4.Text;

            // Perform the deletion operation using the user ID
            bool deleted = DeleteOrders(Order);

            // Generate an alert based on the deletion result
            if (deleted)
            {
                // User successfully deleted
                string message = "Order with Name " + Order + " has been successfully deleted.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                // Failed to delete user
                string message = "Failed to delete Order with Name " + Order + ". User not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }

        private bool DeleteOrders(string userId)
        {
            // Assuming connectionString is defined in your web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                // Construct the SQL command to delete the user with the provided userId
                string query = "DELETE FROM Orders WHERE PaymentId = @userId";

                // Create a SqlConnection object with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for UserId
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected (i.e., if deletion was successful)
                        if (rowsAffected > 0)
                        {
                            // If deletion was successful, return true
                            return true;
                        }
                        else
                        {
                            // If no rows were affected, return false
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine("Error occurred while deleting user: " + ex.Message);
                return false; // Return false indicating deletion failed
            }
        }


        protected void Shop(object sender, EventArgs e)
        {
            // Get the user ID from the text box
            string Product = TextBox5.Text;

            // Perform the deletion operation using the user ID
            bool deleted = Deleteshop(Product);

            // Generate an alert based on the deletion result
            if (deleted)
            {
                // User successfully deleted
                string message = "Product with Name " + Product + " has been successfully deleted.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                // Failed to delete user
                string message = "Failed to delete Order with Name " + Product + ". User not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }

        private bool Deleteshop(string userId)
        {
            // Assuming connectionString is defined in your web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                // Construct the SQL command to delete the user with the provided userId
                string query = "DELETE FROM Shop WHERE Pid = @userId";

                // Create a SqlConnection object with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for UserId
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected (i.e., if deletion was successful)
                        if (rowsAffected > 0)
                        {
                            // If deletion was successful, return true
                            return true;
                        }
                        else
                        {
                            // If no rows were affected, return false
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine("Error occurred while deleting user: " + ex.Message);
                return false; // Return false indicating deletion failed
            }
        }
        protected void Shopimg(object sender, EventArgs e)
        {
            // Get the user ID from the text box
            string Product = TextBox6.Text;

            // Perform the deletion operation using the user ID
            bool deleted = Deleteshopimg(Product);

            // Generate an alert based on the deletion result
            if (deleted)
            {
                // User successfully deleted
                string message = "Product with Name " + Product + " has been successfully deleted.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                // Failed to delete user
                string message = "Failed to delete Order with Name " + Product + ". User not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }

        private bool Deleteshopimg(string userId)
        {
            // Assuming connectionString is defined in your web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                // Construct the SQL command to delete the user with the provided userId
                string query = "DELETE FROM Shopimage WHERE Pid = @userId";

                // Create a SqlConnection object with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for UserId
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected (i.e., if deletion was successful)
                        if (rowsAffected > 0)
                        {
                            // If deletion was successful, return true
                            return true;
                        }
                        else
                        {
                            // If no rows were affected, return false
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine("Error occurred while deleting user: " + ex.Message);
                return false; // Return false indicating deletion failed
            }
        }
    }
}

