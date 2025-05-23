using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Project
{
    public partial class forget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendOTP_Click(object sender, EventArgs e)
        {
            try
            {
                string email = emailTextBox.Text.Trim();
                string userId = userIdTextBox.Text.Trim();
                string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(userId))
                {
                    // Display error message if email or user ID is empty
                    errorMessage.Text = "Please enter your email and user ID.";
                    errorMessage.Visible = true;
                    return;
                }

                if (IsEmailBelongsToUserId(connectionString, email, userId))
                {
                    int otp = GenerateOTP();
                    SendOTPByEmail(email, otp); // Send OTP to the email address

                    // Store the OTP in session
                    Session["OTP"] = otp;

                    // Show OTP and password fields
                    otpAndPasswordFields.Visible = true;
                }
                else
                {
                    // Email does not belong to the provided user ID
                    errorMessage.Text = "The email does not belong to the provided user ID.";
                    errorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                // Show alert with the exception message
                string script = "alert('" + ex.Message + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }


        private int GenerateOTP()
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        private void SendOTPByEmail(string email, int otp)
        {
            try
            {

                string smtpServer = "smtp.gmail.com";
                string smtpUsername = "batch70000@gmail.com"; // Replace with your Gmail address
                string smtpPassword = "ceguabyeswjnampv"; // Replace with your App Password
                string subject = "Your OTP for Password Change";
                string body = "Your OTP is: " + otp;

                SmtpClient client = new SmtpClient(smtpServer);
                client.Port = 587; // SMTP port for Gmail
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                MailMessage mail = new MailMessage(smtpUsername, email, subject, body);
                client.Send(mail);

                // Optional: You can add success message or log here
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                errorMessage.Text = "Error sending OTP: " + ex.Message;
                errorMessage.Visible = true;
            }
        }

        protected void changePassword_Click(object sender, EventArgs e)
        {
            string otp = otpTextBox.Text.Trim();
            string newPassword = newPasswordTextBox.Text.Trim();
            string userId = userIdTextBox.Text.Trim();

            if (string.IsNullOrEmpty(otp) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(userId))
            {
                // Display error message if OTP, new password, or user ID is empty
                errorMessage.Text = "Please enter OTP, new password, and user ID.";
                errorMessage.Visible = true;
                return;
            }

            // Verify OTP
            if (!VerifyOTP(otp))
            {
                // If OTP verification fails, show message
                errorMessage.Text = "Invalid OTP. Please enter the correct OTP.";
                errorMessage.Visible = true;
                return;
            }

            // Ensure the password meets the length requirement
            if (newPassword.Length < 6)
            {
                // Display error message if the password is too short
                errorMessage.Text = "Password must be at least 6 characters long.";
                errorMessage.Visible = true;
                return;
            }

            // If OTP verification is successful and password meets the length requirement, update the password
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Registration SET Password = @Password WHERE UID = @UserId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Password", newPassword);
                        command.Parameters.AddWithValue("@UserId", userId);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Password updated successfully
                            errorMessage.Text = "Password changed successfully.";
                            errorMessage.Visible = true;

                            // Show alert that password is changed
                            string script = "alert('Password changed successfully.');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "alert", script, true);

                            // Redirect to Login.aspx
                            Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            // No rows affected, possibly due to incorrect user ID
                            errorMessage.Text = "Failed to change password. User ID may be incorrect.";
                            errorMessage.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show alert with the exception message
                string script = "alert('" + ex.Message + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }


        private bool VerifyOTP(string otp)
        {
            // Retrieve the stored OTP from session
            int storedOTP = Convert.ToInt32(Session["OTP"]);

            // Compare the stored OTP with the entered OTP
            if (storedOTP == Convert.ToInt32(otp))
            {
                // OTP verification successful
                Session.Remove("OTP"); // Clear the OTP from session
                return true;
            }

            // If OTP does not match or is not found, return false
            return false;
        }


        private bool IsEmailBelongsToUserId(string connectionString, string email, string userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Registration WHERE UID = @UserId AND Email = @Email";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Email", email);
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                errorMessage.Text = "An error occurred while checking if the email belongs to the user ID.";
                errorMessage.Visible = true;
                return false;
            }
        }

      

    }
}
