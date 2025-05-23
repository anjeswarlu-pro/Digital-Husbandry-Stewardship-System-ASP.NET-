using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;

namespace Main_Project
{
    public partial class BuyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if productId query parameter exists
                if (!string.IsNullOrEmpty(Request.QueryString["productId"]))
                {
                    // Retrieve the productId from the query string
                    string productId = Request.QueryString["productId"];

                    // Fetch product details based on productId
                    DataTable productData = GetProductData(productId);

                    // Display product details on the page
                    DisplayProductDetails(productData);
                }
            }
        }

        protected void BtnBuy_Click(object sender, EventArgs e)
        {
            // Handle buy button click
            if (!string.IsNullOrEmpty(Request.QueryString["productId"]))
            {
                string productId = Request.QueryString["productId"];
                DataTable productData = GetProductData(productId);

                // Assuming order creation logic here
                string orderId = CreateRazorpayOrder(productData);
                if (!string.IsNullOrEmpty(orderId))
                {
                    // Redirect to the confirmation page with both order ID and product ID
                    Response.Redirect($"ConfirmationPage.aspx?orderId={orderId}&productId={productId}");
                }
                else
                {
                    lblMessage.Text = "Failed to create order.";
                }
            }
        }




        private DataTable GetProductData(string productId)
        {
            DataTable productData = new DataTable();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
                string query = "SELECT * FROM Cart WHERE Pid = @ProductId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", productId);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(productData);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                lblMessage.Text = "Error fetching product data: " + ex.Message;
            }

            return productData;
        }

        private void DisplayProductDetails(DataTable productData)
        {
            // Implement DisplayProductDetails method to display product details on the page
            // This method should set the text of appropriate labels with product information
            // Example implementation:
            if (productData != null && productData.Rows.Count > 0)
            {
                string imageUrl = productData.Rows[0]["ImagePath"].ToString();
                productImage.ImageUrl = imageUrl;
                productImage.AlternateText = "Product Image";
                lblProductId.Text = "<strong>Product ID:</strong> " + productData.Rows[0]["Pid"].ToString();
                lblQuantity.Text = "<strong>Quantity:</strong> " + productData.Rows[0]["Quantity"].ToString();
                lblTotalAmount.Text = "<strong>Total Amount:</strong> $" + productData.Rows[0]["TotalAmount"].ToString();
                string uid = Session["Uid"] as string;
                lblUserEmail.Text = "<strong>Email:</strong> " + GetUserEmail(uid);
            }
            else
            {
                lblMessage.Text = "Product details not found.";
            }
        }

        private string GetUserEmail(string uid)
        {
            string email = "";

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
                string query = "SELECT Email FROM Registration WHERE Uid = @Uid";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Uid", uid);
                        connection.Open();
                        email = command.ExecuteScalar() as string;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                lblMessage.Text = "Error fetching user email: " + ex.Message;
            }

            return email;
        }


        private string CreateRazorpayOrder(DataTable productData)
        {
            string orderId = "";

            try
            {
                string razorpayKeyId = ConfigurationManager.AppSettings["RazorpayKeyId"];
                string razorpayKeySecret = ConfigurationManager.AppSettings["RazorpayKeySecret"];

                // Prepare the product details
                string Pid = productData.Rows[0]["Pid"].ToString();
                int totalAmount = Convert.ToInt32(productData.Rows[0]["TotalAmount"]) ; // Convert total amount to paise

                // Prepare the data for order creation
                JObject orderData = new JObject();
                orderData.Add("amount", totalAmount);
                orderData.Add("currency", "INR");
                orderData.Add("receipt", Guid.NewGuid().ToString());
                orderData.Add("notes", new JObject { { "Pid", Pid } }); // Include product name in notes

                // Make a POST request to create the order
                string apiUrl = "https://api.razorpay.com/v1/orders";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "POST";
                request.ContentType = "application/json";
                string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{razorpayKeyId}:{razorpayKeySecret}"));
                request.Headers.Add("Authorization", $"Basic {auth}");

                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(orderData.ToString());
                    writer.Flush();
                    writer.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseData = new StreamReader(response.GetResponseStream()).ReadToEnd();

                // Parse the response to extract the order ID
                JObject jsonResponse = JObject.Parse(responseData);
                orderId = jsonResponse["id"].ToString();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                lblMessage.Text = "Error creating order: " + ex.Message;
            }

            return orderId;
        }

    }
}
