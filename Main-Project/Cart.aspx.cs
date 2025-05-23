using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web;

namespace Main_Project
{
   
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fetch cart data and construct HTML content
                BindCartData();
            }
        }

        [WebMethod]
        public static void RemoveItem(string productId)
        {
            string uid = HttpContext.Current.Session["Uid"] as string;
            if (string.IsNullOrEmpty(uid))
            {
                throw new ApplicationException("User session not found.");
            }

            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            string query = "DELETE FROM Cart WHERE Pid = @Pid AND Uid = @Uid";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Pid", productId);
                    command.Parameters.AddWithValue("@Uid", uid);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    // No need to check rowsAffected, as it will be 0 if the item wasn't found.
                }
            }
        }
       

        private void BindCartData()
        {
            // Check if user is logged in (UID is available in session)
            if (Session["Uid"] != null)
            {
                string uid = Session["Uid"].ToString();
                string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
                string query = "SELECT Pid, Quantity, TotalAmount, ImagePath FROM Cart WHERE Uid = @Uid";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for the UID
                        command.Parameters.AddWithValue("@Uid", uid);

                        try
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable cartDataTable = new DataTable();

                            connection.Open();
                            adapter.Fill(cartDataTable);

                            if (cartDataTable != null && cartDataTable.Rows.Count > 0)
                            {
                                // Construct HTML content for the cart data
                                string cartHtml = "<div class='cart-items'>";
                                foreach (DataRow row in cartDataTable.Rows)
                                {
                                    cartHtml += "<div class='cart-item'>";
                                    cartHtml += "<img class='product-image' src='" + ResolveUrl(row["ImagePath"].ToString()) + "' alt='Product Image' />";
                                    cartHtml += "<p class='product-id'>Product ID: " + row["Pid"] + "</p>";
                                    cartHtml += "<p class='quantity'>Quantity: " + row["Quantity"] + "</p>";
                                    cartHtml += "<p class='total-amount'>Total Amount: " + row["TotalAmount"] + "</p>";
                                    cartHtml += "<button class='remove-button' onclick='RemoveItem(\"" + row["Pid"] + "\")'>Remove</button>";

                                    cartHtml += "<button class='buy-button' onclick='BuyItem(\"" + row["Pid"] + "\")'>Buy</button>";
                                    cartHtml += "</div>";
                                }
                                cartHtml += "</div>";

                                // Set the HTML content to the Literal control
                                cartDataLiteral.Text = cartHtml;
                            }
                            else
                            {
                                // If cart is empty, display a message
                                cartDataLiteral.Text = "Your cart is empty.";
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception (e.g., log it or display an error message)
                            cartDataLiteral.Text = "An error occurred while retrieving cart data: " + ex.Message;
                        }
                    }
                }
            }
            else
            {
                // If user is not logged in, display a message asking the user to log in
                cartDataLiteral.Text = "Please log in to view your cart.";
            }
        }
       
    }
}
