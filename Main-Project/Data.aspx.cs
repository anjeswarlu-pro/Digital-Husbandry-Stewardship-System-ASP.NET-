using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Main_Project
{
    public partial class Data : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve data from session
                string name = Session["Name"] as string;
                string category = Session["Category"] as string;
                string description = Session["Description"] as string;
                string pros = Session["Pros"] as string;
                string cons = Session["Cons"] as string;
                string season = Session["Season"] as string;
                string period = Session["Period"] as string;

                // Populate textboxes with retrieved data
                TextBox0.Text = name;
                TextBox1.Text = category;
                TextBox2.Text = description;
                TextBox3.Text = pros;
                TextBox4.Text = cons;
                TextBox5.Text = season;
                TextBox6.Text = period;

                // Load images for slideshow
                LoadImagesForSlideshow();
            }
        }

        private void LoadImagesForSlideshow()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT image1, image2, image3 FROM infoimage WHERE Name = @Name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", TextBox0.Text); // Assuming Name corresponds to TextBox0.Text

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Retrieve image paths from the database
                    string imagePath1 = reader["image1"].ToString();
                    string imagePath2 = reader["image2"].ToString();
                    string imagePath3 = reader["image3"].ToString();

                    // Dynamically add images to the slideshow
                    AddImageToSlideshow(imagePath1);
                    AddImageToSlideshow(imagePath2);
                    AddImageToSlideshow(imagePath3);
                }

                reader.Close();
            }
        }

        private void AddImageToSlideshow(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                // Dynamically create Image control and set its properties
                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                img.ImageUrl = imagePath;
                img.AlternateText = "Image";
                img.CssClass = "slides";

                // Add the image to the slides div
                slides.Controls.Add(img);
            }
        }


    }
}
