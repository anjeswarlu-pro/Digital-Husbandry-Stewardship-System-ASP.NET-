<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyPage.aspx.cs" Inherits="Main_Project.BuyPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
    margin: 0;
    padding: 0;
    font-family: Roboto;
          height: 100vh; /* Set height to cover the entire viewport height */;
    background: linear-gradient(147deg, #166d3b 0%, #000000 74%);
   
   
}
 .product-details-panel {
    border: 1px solid #ccc;
    font-size:24px;
    padding: 10px;
    margin: auto;
    background-color:lightblue;
    text-align: center;
    width: 30%; /* Adjust the width as needed */
    height: auto; /* Set height to auto for dynamic height based on content */
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center; /* Center horizontally */
    position: fixed; /* Fix the position */
    top: 50%; /* Move the top to the center */
    left: 50%; /* Move the left to the center */
    transform: translate(-50%, -50%); /* Adjust to center both horizontally and vertically */
}


    .product-details-panel img {
    max-width: 100%; /* Limit image width to the container width */
    max-height: 200px; /* Set maximum height for the image */
    margin: auto; /* Center the image horizontally */
    display: block; /* Ensure the image behaves as a block element */
}

    .product-details-panel h2 {
        font-size: 1.2em;
        color: #333;
        margin-bottom: 10px;
    }

    .product-details-panel p {
        margin: 5px 0;
    }

    .product-details-panel strong {
        font-weight: bold;
    }

    .form-control {
        width: 70%;
        padding: 6px 12px;
        font-size: 14px;
        line-height: 1.42857143;
        color: #555;
        
        background-image: none;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
        transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
    }

    .btn-primary {
        color: #fff;
        background-color: #337ab7;
        border-color: #2e6da4;
        text-decoration: none;
        display: inline-block;
        padding: 6px 12px;
        margin-bottom: 0;
        font-size: 14px;
        font-weight: 400;
        line-height: 1.42857143;
        text-align: center;
        white-space: nowrap;
        vertical-align: middle;
        cursor: pointer;
        border: 1px solid transparent;
        border-radius: 4px;
        transition: all .15s ease-in-out;
    }

    .btn-primary:hover,
    .btn-primary:focus,
    .btn-primary:active {
        color: #fff;
        background-color: #286090;
        border-color: #204d74;
        text-decoration: none;

    }
    .container {
    max-width: 1200px; /* Adjust the max-width as needed */
    margin: 0 auto; /* Center the container horizontally */
    padding: 0 15px; /* Add padding to the sides */
    box-sizing: border-box; /* Include padding and border in the element's total width and height */
}

</style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Panel ID="productDetailsPanel" runat="server" class="product-details-panel">
                <!-- Image -->
                <asp:Image ID="productImage" runat="server" ImageUrl="~/Images/product_image.jpg" AlternateText="Product Image" />

                <!-- Product details will be displayed here -->
                <asp:Label ID="lblProductId" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblQuantity" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label><br />
                <strong>Email:</strong> <asp:Label ID="lblUserEmail" runat="server" Text=""></asp:Label><br />
                <strong>Address:</strong> <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox><br />
                <asp:Button ID="btnBuy" runat="server" Text="Buy" CssClass="btn btn-primary" OnClick="BtnBuy_Click" />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <!-- Button to initiate payment -->
        </div>
    </form>


</body>
</html>
