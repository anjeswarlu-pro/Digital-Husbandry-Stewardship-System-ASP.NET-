// ConfirmationPage.aspx.cs
using System;
using System.Configuration;
using Razorpay.Api; // Import Razorpay API library

namespace Main_Project
{
    public partial class ConfirmationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve order ID from query string
                string orderId = Request.QueryString["orderId"];

                if (!string.IsNullOrEmpty(orderId))
                {
                    // Load order details using the orderId
                    LoadOrderDetails(orderId);
                }
                else
                {
                    // Handle case where orderId is missing
                    lblOrderDetails.Text = "Order ID is missing.";
                }
            }
        }

        protected void LoadOrderDetails(string orderId)
        {
            try
            {
                // Retrieve Razorpay API key and secret from configuration
                string razorpayKeyId = ConfigurationManager.AppSettings["RazorpayKeyId"];
                string razorpayKeySecret = ConfigurationManager.AppSettings["RazorpayKeySecret"];

                // Initialize Razorpay client with retrieved API key and secret
                RazorpayClient client = new RazorpayClient(razorpayKeyId, razorpayKeySecret);

                // Fetch order details using orderId
                Order order = client.Order.Fetch(orderId);

                // Example: Display order details in a label
                lblOrderDetails.Text = $"Order ID: {order["id"]} - Amount: {order["amount"]} - Currency: {order["currency"]}";

                // Add your logic here to display more order details as needed
            }
            catch (Exception ex)
            {
                // Handle exceptions
                lblOrderDetails.Text = "Error fetching order details: " + ex.Message;
            }
        }


        protected void BtnProceedToPayment_Click(object sender, EventArgs e)
        {
            // Redirect to the checkout page for payment initiation
            Response.Redirect($"CheckoutPage.aspx?productId={Request.QueryString["productId"]}");
        }
    }
}
