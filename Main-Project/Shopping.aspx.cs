using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static IronPython.Modules.PythonIterTools;

namespace Main_Project
{
    public partial class Shopping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropdown("SELECT DISTINCT Category FROM Shop", DropDownList1);
              
                    // Check if the "addedToCart" query string parameter exists
                    if (!string.IsNullOrEmpty(Request.QueryString["addedToCart"]) && Request.QueryString["addedToCart"] == "true")
                    {
                        // Display an alert indicating that the product was added to the cart successfully
                        ScriptManager.RegisterStartupScript(this, GetType(), "addToCartSuccess", "alert('Product added to cart successfully!');", true);
                    }
                

            }
        }
       

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateNamesByCategory(DropDownList1.SelectedValue, DropDownList2);
        }

        private void PopulateDropdown(string query, DropDownList dropdown)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string value = reader.GetString(0);
                            dropdown.Items.Add(new ListItem(value, value));
                        }
                    }
                }
            }
        }

        private void PopulateNamesByCategory(string category, DropDownList dropdown)
        {
            dropdown.Items.Clear();
            dropdown.Items.Add(new ListItem("Select a Name", ""));

            string query = $"SELECT DISTINCT Name FROM Shop WHERE Category = @Category";
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Category", category);

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string value = reader.GetString(0);
                                dropdown.Items.Add(new ListItem(value, value));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public class Product
        {
            public string ImageUrl { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Brand { get; set; }
            public double Ratings { get; set; }
            public decimal Amount { get; set; }
            public string StockStatus { get; set; }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = DropDownList2.SelectedValue;
            DisplayProductDetails(selectedName);


        }

        private void DisplayProductDetails(string selectedName)
        {
            // Clear existing content in the shopping module
            shoppingModule.InnerHtml = "";

            // Fetch product details based on the selected name
            string query = "SELECT * FROM Shop WHERE Name = @Name";
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameter for the selected name
                        cmd.Parameters.AddWithValue("@Name", selectedName);

                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            // Create a div for each product
                            var productDiv = new HtmlGenericControl("div");
                            productDiv.Attributes["class"] = "prodiv";

                            // Populate product details
                            var img = new HtmlGenericControl("img");

                            // Set the source and alt attributes
                            img.Attributes["src"] = "Shopimages/" + reader["Pid"] + ".jpg"; // Assuming Pid is the image file name
                            img.Attributes["alt"] = "Product Image";

                            // Set the CSS class
                            img.Attributes["class"] = "prodiv img ";

                            var namePara = new HtmlGenericControl("p");
                            namePara.InnerText = "Name: " + reader["Name"];

                            var categoryPara = new HtmlGenericControl("p");
                            categoryPara.InnerText = "Category: " + reader["Category"];

                            var brandPara = new HtmlGenericControl("p");
                            brandPara.InnerText = "Brand: " + reader["Brand"];

                            var ratingsPara = new HtmlGenericControl("p");
                            ratingsPara.InnerText = "Ratings: " + reader["Ratings"];

                            var amountPara = new HtmlGenericControl("p");
                            amountPara.InnerText = "Amount: ₹" + reader["Amount"];

                            var stockPara = new HtmlGenericControl("p");
                            stockPara.InnerText = "Stock: " + reader["Stock"];

                            // Create a button for redirecting to product page

                            var viewProductLink = new HyperLink();
                            viewProductLink.Text = "View Product";
                            viewProductLink.CssClass = "view-product-link";
                            viewProductLink.NavigateUrl = "Product.aspx?Pid=" + reader["PId"].ToString();
                            viewProductLink.Attributes["target"] = "_blank";

                            // Add the link to product div

                            // Add elements to product div
                            productDiv.Controls.Add(img);
                            productDiv.Controls.Add(namePara);
                            productDiv.Controls.Add(categoryPara);
                            productDiv.Controls.Add(brandPara);
                            productDiv.Controls.Add(ratingsPara);
                            productDiv.Controls.Add(amountPara);
                            productDiv.Controls.Add(stockPara);
                            productDiv.Controls.Add(viewProductLink);
                            shoppingModule.Controls.Add(productDiv);




                            shoppingModule.Controls.Add(productDiv);
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exception
                // For now, throwing the exception to halt execution and see the error message
                throw ex;
            }
        }


      
        protected void searchButton_Click(object sender, EventArgs e)
        {
            // Implement search functionality here if needed
        }
    }
}
