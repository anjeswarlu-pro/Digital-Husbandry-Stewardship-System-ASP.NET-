using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


namespace Main_Project
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Check if it's the initial page load
            {

                // Populate the first dropdown with categories

                PopulateDropdown("SELECT DISTINCT Category FROM Information", DropDownList1);

                // Initially, fetch and display data for the selected value



            }
        }

        [WebMethod]
        public static string predict(double N, double P, double k, double temperature, double humidity, double ph, double rainfall)
        {
            try
            {
                var prediction = MLIntegration.MakePrediction(N, P, k, temperature, humidity, ph, rainfall);
                Console.WriteLine($"Predicted Crop: {prediction}");

                // You can return the prediction or perform any other actions with it
                return prediction;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MakePrediction: {ex.Message}");
                return JsonConvert.SerializeObject(new { error = $"Error: {ex.Message}" }); // Include error details in the response
            }
        }


        public static class MLIntegration
        {
            public static string MakePrediction(double N, double P, double k, double temperature, double humidity, double ph, double rainfall)
            {
                using (var client = new HttpClient())
                {
                    var url = "http://localhost:5000/predict";   // Replace with the actual URL where your Flask app is running
                    var input = new
                    {
                        N,
                        P,
                        k,
                        temperature,
                        humidity,
                        ph,
                        rainfall
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    var response = client.PostAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    else
                    {
                        return "Error";
                    }
                }
            }
        }

   

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the selected category changes, repopulate the second dropdown with names based on the selected category
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
            // Clear existing items in the dropdown
            dropdown.Items.Clear();

            // Add a label as the first item in the dropdown
            dropdown.Items.Add(new ListItem("Select a Name", ""));

            // Populate the dropdown with names based on the selected category
            string query = $"SELECT Name FROM Information WHERE Category = @Category";
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameter for the selected category
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
                // Handle SQL exception (e.g., log error, display message)
                // For now, we'll just throw the exception again to halt execution and see the error message
                throw ex;
            }
        }


        // Event handler for dropdown list selection change
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = DropDownList2.SelectedValue;
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Information WHERE Name = @Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", selectedValue);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            string category = reader["Category"].ToString();
                            string description = reader["Description"].ToString();
                            string pros = reader["Pros"].ToString();
                            string cons = reader["Cons"].ToString();
                            string season = reader["Season"].ToString();
                            string period = reader["Period"].ToString();

                            // Store the data in session variables
                            Session["Name"] = name;
                            Session["Category"] = category;
                            Session["Description"] = description;
                            Session["Pros"] = pros;
                            Session["Cons"] = cons;
                            Session["Season"] = season;
                            Session["Period"] = period;

                            // Redirect to data.aspx
                            Response.Write("<script>window.open('" + ResolveClientUrl("~/data.aspx") + "','_blank');</script>");

                        }
                        else
                        {
                            // The selected name does not exist in the database
                            // Show an alert to the user
                            ScriptManager.RegisterStartupScript(this, GetType(), "NotFoundAlert", "alert('Selected name not found in the database.');", true);
                        }
                    }
                }
            }

        }


        protected void searchButton_Click(object sender, EventArgs e)
        {
            string searchValue = searchInput.Text.Trim(); // Get the search input value

            // Your connection string retrieval remains the same
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Information WHERE Name LIKE @Name"; // Use LIKE for partial matches

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", "%" + searchValue + "%"); // Adjust parameter for partial matches

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            string category = reader["Category"].ToString();
                            string description = reader["Description"].ToString();
                            string pros = reader["Pros"].ToString();
                            string cons = reader["Cons"].ToString();
                            string season = reader["Season"].ToString();
                            string period = reader["Period"].ToString();

                            // Store the data in session variables
                            Session["Name"] = name;
                            Session["Category"] = category;
                            Session["Description"] = description;
                            Session["Pros"] = pros;
                            Session["Cons"] = cons;
                            Session["Season"] = season;
                            Session["Period"] = period;

                            // Redirect to data.aspx
                            Response.Write("<script>window.open('" + ResolveClientUrl("~/data.aspx") + "','_blank');</script>");
                        }
                        else
                        {
                            // The searched name does not exist in the database
                            // Show an alert to the user
                            ScriptManager.RegisterStartupScript(this, GetType(), "NotFoundAlert", "alert('Searched name not found in the database.');", true);
                        }
                    }

                }



            }
        }
        protected void btnShopping_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('" + ResolveClientUrl("~/Shopping.aspx") + "','_blank');</script>");
        }
    }
}
