using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace Main_Project
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        // WebMethod to fetch product amount based on the product ID
        [WebMethod]
        public static decimal GetProductAmount(string productId)
        {
            decimal productAmount = -1; // Default value to indicate failure or no data found

            // Connection string to your database
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            string query = "SELECT TotalAmount FROM Cart WHERE Pid = @ProductId";

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command object with the SQL query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter for ProductId
                    command.Parameters.AddWithValue("@ProductId", productId);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the SQL query and read the result
                        object result = command.ExecuteScalar();

                        // Check if result is not null and convert it to decimal
                        if (result != null && decimal.TryParse(result.ToString(), out productAmount))
                        {
                            // Product amount retrieved successfully
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Log or handle any SQL exceptions
                        Console.WriteLine("SQL Error: " + ex.Message);
                    }
                }
            }

            return productAmount;
        }

        [WebMethod]
        public static string SavePaymentDetails(PaymentData paymentData)
        {
            try
            {
                // Retrieve UID from session
                string userId = HttpContext.Current.Session["UID"].ToString();

                // Check if the UID is null or empty
                if (string.IsNullOrEmpty(userId))
                {
                    return "User session expired. Please login again.";
                }

                string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Construct the SQL query to insert payment details into the Orders table
                    string query = @"INSERT INTO Orders (UserId, PaymentId, Amount,  ProductId, OrderDate) 
                 VALUES (@UserId, @PaymentId, @Amount,  @ProductId, @OrderDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@PaymentId", paymentData.PaymentId);
                        command.Parameters.AddWithValue("@Amount", paymentData.Amount);
                      
                        command.Parameters.AddWithValue("@ProductId", paymentData.ProductId);
                        command.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                        command.ExecuteNonQuery();
                    }



                }
                string userEmail = GetUserEmailFromRegistration(userId);

                // Send order confirmation email
                SendOrderConfirmationEmail(userEmail);

                return "Payment details saved successfully!";
            }
            catch (Exception ex)
            {
                return "Error saving payment details: " + ex.Message;
            }
        }

        public class PaymentData
    {
        public string PaymentId { get; set; }
        public int Amount { get; set; }
      
        public int ProductId { get; set; }
    }

        public static string GetUserEmailFromRegistration(string userId)
        {
            string email = string.Empty;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Construct the SQL query to select email from Registration table
                    string query = "SELECT Email FROM Registration WHERE UID = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            email = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., log the error)
                Console.WriteLine("Error retrieving user email: " + ex.Message);
            }

            return email;
        }


        public static void SendOrderConfirmationEmail(string userEmail)
        {
            try
            {
                // Set up SMTP client and credentials

                string smtpServer = "smtp.gmail.com";
                SmtpClient smtpClient = new SmtpClient(smtpServer);
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential("batch70000@gmail.com", "ceguabyeswjnampv");
                smtpClient.EnableSsl = true;

                // Create and configure the email message
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("batch70000@gmail.com");
                mailMessage.To.Add(new MailAddress(userEmail));
                mailMessage.Subject = "Order Confirmation";
                mailMessage.Body = "Your order has been successfully placed And for Order Details Kindly Check your Porfile .";

                // Send the email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., log the error)
                Console.WriteLine("Error sending email: " + ex.Message);
            }

        }
        }
}
