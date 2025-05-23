using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Main_Project
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string excelFilePath = Server.MapPath("~/Project Data.xlsx"); // Change to your Excel file path
                string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";

                using (OleDbConnection excelConnection = new OleDbConnection(excelConnectionString))
                {
                    excelConnection.Open();
                    DataTable dt = new DataTable();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", excelConnection))
                    {
                        adapter.Fill(dt);
                    }

                    // Assuming you have a connection string for your SQL Server
                    string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        foreach (DataRow row in dt.Rows)
                        {
                            // Check if the "Name" column is null or empty
                            if (!string.IsNullOrEmpty(row["Name"].ToString()))
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Shop] ([Pid], [Name], [Category], [Brand], [Ratings], [Amount], [Stock]) VALUES (@Pid,@Name, @Category, @Brand, @Ratings, @Amount, @Stock)", sqlConnection);
                                cmd.Parameters.AddWithValue("@Pid", row["Pid"]);
                                cmd.Parameters.AddWithValue("@Name", row["Name"]);
                                cmd.Parameters.AddWithValue("@Category", row["Category"]);
                                cmd.Parameters.AddWithValue("@Brand", row["Brand"]);
                                cmd.Parameters.AddWithValue("@Ratings", row["Ratings"]);
                                cmd.Parameters.AddWithValue("@Amount", row["Amount"]);
                                cmd.Parameters.AddWithValue("@Stock", row["Stock"]);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                // Handle empty or null "Name" value (e.g., log error, skip insertion, etc.)
                            }
                        }
                    }
                }
            }
        }
    }
}
