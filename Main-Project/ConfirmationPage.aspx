<!-- ConfirmationPage.aspx -->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmationPage.aspx.cs" Inherits="Main_Project.ConfirmationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Confirmation Page</title>
     <style>
    body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f2f2f2;
        }

        .container {
            width: 80%;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .order-details {
            margin-bottom: 20px;
        }

        .order-details label {
            font-weight: bold;
        }

        .btn-proceed {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn-proceed:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="order-details">
                <!-- Display order details here -->
                <asp:Label ID="lblOrderDetails" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button ID="btnProceedToPayment" runat="server" Text="Proceed to Payment" CssClass="btn-proceed" OnClick="BtnProceedToPayment_Click" />
        </div>
    </form>
</body>
</html>
