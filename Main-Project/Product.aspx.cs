using Microsoft.Scripting.Interpreter;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Main_Project
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the ProductId query string parameter exists
                if (!string.IsNullOrEmpty(Request.QueryString["Pid"]))
                {
                    // Get the ProductId from the query string
                    string productId = Request.QueryString["Pid"];

                    // Display product details
                    DisplayProductDetails(productId);

                    // Populate the dropdown list with available quantity options
                    PopulateQuantityDropDown();
                }
                else
                {
                    // Handle the case when ProductId is not provided
                    // For example, you can redirect the user to an error page
                    Response.Redirect("ErrorPage.aspx");
                }
            }
        }
        protected void PopulateQuantityDropDown()
        {
            // Retrieve available stock for the product
            int availableStock = GetAvailableStock(Request.QueryString["Pid"]);

            // Clear existing items in the dropdown list
            quantityDropDown.Items.Clear();

            // Populate the dropdown list with quantity options
            for (int i = 1; i <= availableStock; i++)
            {
                quantityDropDown.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        protected void quantityDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected quantity from the dropdown list
            int selectedQuantity = int.Parse(quantityDropDown.SelectedValue);

            // Retrieve the price per item from the displayed amount label
            decimal pricePerItem = decimal.Parse(amountLabel.Text.Replace("Amount: ₹", ""));

            // Calculate the total amount
            decimal totalAmount = selectedQuantity * pricePerItem;

            // Update the total amount label
            totalAmountLabel.Text = "Total Amount: ₹" + totalAmount.ToString();
            totalAmountLabel.Visible = true; // Ensure the label is visible after updating
        }

        private void DisplayProductDetails(string productId)
        {
            // Fetch product details based on the selected productId
            string query = "SELECT * FROM Shop WHERE Pid = @Pid"; // Assuming Pid is the parameter for ProductId

            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameter for the selected productId
                        cmd.Parameters.AddWithValue("@Pid", productId); // Ensure that the parameter name matches the one in the query

                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Retrieve product details from the reader
                            string productName = reader["Name"].ToString();
                            string category = reader["Category"].ToString();
                            string brand = reader["Brand"].ToString();
                            double ratings = Convert.ToDouble(reader["Ratings"]);
                            decimal amount = Convert.ToDecimal(reader["Amount"]);
                            string stockStatus = reader["Stock"].ToString();
                            string imageUrl = "Shopimages/" + reader["Pid"].ToString() + ".jpg"; // Assuming Pid is the image file name

                            // Set the product details to the corresponding controls on the page
                            productNameLabel.Text = "Name: " + productName;
                            categoryLabel.Text = "Category: " + category;
                            brandLabel.Text = "Brand: " + brand;
                            ratingsLabel.Text = "Ratings: " + ratings.ToString();
                            amountLabel.Text = "Amount: ₹" + amount.ToString();
                            stockLabel.Text = "Stock: " + stockStatus;

                            // Set the product image URL
                            productImage.ImageUrl = imageUrl;
                        }
                        else
                        {
                            // Handle case where product with given ID is not found
                            // Display appropriate message or take necessary action
                        }

                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exception
                // Log the exception or display error message to the user
                // For now, rethrowing the exception to halt execution and see the error message
                throw ex;
            }
        }


        protected void addToCartButton_Click(object sender, EventArgs e)
        {
            // Retrieve the product ID from the query string
            string productId = Request.QueryString["Pid"];

            // Retrieve the selected quantity from the dropdown list
            int selectedQuantity = int.Parse(quantityDropDown.SelectedValue);

            // Retrieve available stock for the product
            int availableStock = GetAvailableStock(productId);

            if (selectedQuantity <= availableStock)
            {
                // Calculate the total amount (assuming each product has a fixed price)
                decimal productPrice = GetProductPrice(productId);
                decimal totalAmount = selectedQuantity * productPrice;

                // Get the Uid from the session
                string uid = Session["Uid"] as string;

                // Add the product to the cart
                string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Insert command
                    string insertQuery = "INSERT INTO Cart (Pid, Quantity, TotalAmount, ImagePath, Uid) VALUES (@Pid, @Quantity, @TotalAmount, @ImagePath, @Uid)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Pid", productId);
                    command.Parameters.AddWithValue("@Quantity", selectedQuantity);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@ImagePath", GetProductImagePath(productId)); // Assuming you have a method to retrieve the image path
                    command.Parameters.AddWithValue("@Uid", uid);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Cart updated successfully
                            // Redirect to the shopping page with success flag
                            Response.Redirect("Shopping.aspx?addedToCart=true");
                        }
                        else
                        {
                            // Error occurred while updating cart
                            errorMessageLabel.Text = "Error: Failed to add item to cart.";
                            errorMessageLabel.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any database-related exceptions
                        errorMessageLabel.Text = "Error: " + ex.Message;
                        errorMessageLabel.Visible = true;
                    }
                }
            }
            else
            {
                // Display an error message indicating insufficient stock
                errorMessageLabel.Text = "Error: Selected quantity exceeds available stock.";
                errorMessageLabel.Visible = true;
            }
        }

        protected int GetAvailableStock(string productId)
        {
            int availableStock = 0;
            string query = "SELECT Stock FROM Shop WHERE Pid = @Pid";

            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Pid", productId);

                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            availableStock = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exception
                // Log the exception or display error message to the user
                // For now, rethrowing the exception to halt execution and see the error message
                throw ex;
            }

            return availableStock;
        }

        private string GetProductImagePath(string productId)
        {
            // You need to provide the logic to retrieve the image path based on the product ID
            // For example, if your image paths are stored in the database, you can fetch it from there
            // Assuming you have a table named "ProductImages" with columns "ProductId" and "ImagePath"
            // Modify this method according to your database schema and logic
            string query = "SELECT Image1 FROM Shopimage WHERE Pid = @Pid";
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Pid", productId);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }

            // Return a default image path if no image found for the product
            return "default.jpg"; // Provide the default image path here
        }

        private decimal GetProductPrice(string productId)
        {
            // You need to provide the logic to retrieve the product price based on the product ID
            // For example, if your product prices are stored in the database, you can fetch it from there
            // Assuming you have a table named "Products" with columns "ProductId" and "Price"
            // Modify this method according to your database schema and logic
            string query = "SELECT Amount FROM Shop WHERE Pid = @Pid";
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Pid", productId);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToDecimal(result);
                    }
                }
            }

            // Return a default price if no price found for the product
            return 0; // Provide the default price here
        }

    }
}
