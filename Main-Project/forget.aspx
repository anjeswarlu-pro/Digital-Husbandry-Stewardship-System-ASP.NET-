<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forget.aspx.cs" Inherits="Main_Project.forget" ViewStateMode="Enabled" EnableViewState="True" %>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Forgot Password</title>
<style>
  body {
    background-image: linear-gradient(147deg, #166d3b 0%, #000000 74%);
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh; /* Ensure the body covers the entire viewport height */
    margin: 0;
    padding: 0;
}
#form1 {
    width: 400px;
   
    padding: 20px;
    background-color: #fff;
    border-radius: 8px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    margin: auto; /* Center the form */
}
#emailTextBox{
    font-size:18px;
    color:#000000;
}

h2 {
    text-align: center;
    color: #000000;
     font-size:36px;

}

label {
    font-weight: bold;
    color: #000000;
    font-size:26px;
}

.form-control {
    width: 100%;
    padding: 10px;
    margin-top: 5px;
    margin-bottom: 15px;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-sizing: border-box;
}

#submitButton,
#changePasswordButton {
    width: 60%;
    padding: 10px;
    background-color: darkgray;
    color: #000000;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    font-size:18px;
}

#submitButton:hover,
#changePasswordButton:hover {
    background-color: mediumspringgreen;
}

.error-message {
    color: red;
    font-weight: bold;
    display: block; /* Ensure it's displayed as a block element */
}


</style>
</head>
<body>

<form id="form1" runat="server">
     <h2>Forgot Password</h2>

    <!-- Your form elements go here -->
    <asp:Label ID="userIdLabel" AssociatedControlID="userIdTextBox" runat="server">Enter your User ID:</asp:Label><br />
<asp:TextBox ID="userIdTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />

    <asp:Label ID="emailLabel" AssociatedControlID="emailTextBox" runat="server">Enter your email:</asp:Label><br />
    <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />
    <asp:Button ID="submitButton" Text="Submit" runat="server" OnClick="SendOTP_Click" AutoPostBack="true" />
     <asp:Label ID="errorMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>
    <!-- Fields for OTP and new password, initially hidden -->
    <asp:Panel ID="otpAndPasswordFields" runat="server" Visible="false">
        <asp:Label ID="otpLabel" AssociatedControlID="otpTextBox" runat="server">Enter the OTP sent to your email:</asp:Label><br />
        <asp:TextBox ID="otpTextBox" runat="server" CssClass="form-control" ></asp:TextBox><br />
        <asp:Label ID="newPasswordLabel" AssociatedControlID="newPasswordTextBox" runat="server">Enter your new password:</asp:Label><br />
        <asp:TextBox ID="newPasswordTextBox" TextMode="Password" runat="server" CssClass="form-control" ></asp:TextBox><br />
        <asp:Button ID="changePasswordButton" Text="Change" runat="server" OnClick="changePassword_Click" CssClass="btn btn-primary" />
       
    </asp:Panel>
</form>





  <!-- Script for sending OTP and changing password -->
 
</body>
</html>
