using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Project
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Call a method to populate dropdown with table names
                PopulateTableDropdown();
            }
        }

        private void PopulateTableDropdown()
        {
            // Fetch connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to get all table names from the database, sorted alphabetically
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // Add initial "Select" option
                        ddlTables.Items.Clear(); // Clear existing items
                        ddlTables.Items.Add(new ListItem("Select Table", ""));

                        // Bind the result to the dropdown list
                        while (reader.Read())
                        {
                            string tableName = reader["TABLE_NAME"].ToString();
                            ddlTables.Items.Add(new ListItem(tableName, tableName));
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                    }
                }
            }
        }
        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = ddlTables.SelectedValue;

            if (!string.IsNullOrEmpty(selectedTable))
            {
                // Fetch data from the selected table and display it
                FetchAndDisplayData(selectedTable);
            }
        }

        private void FetchAndDisplayData(string tableName)
        {
            // Fetch connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

            // Use the table name to construct your SQL query
            string query = "SELECT * FROM " + tableName;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Display data in a GridView or any other control
                        // For example, you can bind the data to a GridView
                        gridView.DataSource = dataTable;
                        gridView.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                    }
                }
            }
        }

    }
}