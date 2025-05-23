<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Main_Project.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Details</title>
    <style>
        body {
            background: linear-gradient(147deg, #166d3b 0%, #000000 74%);
            height: 100vh;
        }

        .productDiv {
            border: 1px solid #ccc;
            padding: 10px;
            max-width: 500px;
            margin: 0 auto;
        }

        .product-image {
            max-width: 200px; /* Adjust as needed */
            max-height: 200px; /* Adjust as needed */
            display: block;
            margin-bottom: 10px; /* Adjust as needed */
        }

        .product-label {
            color: white; /* Border for separation */

            display: block;
            margin-bottom: 5px; /* Adjust as needed */
            font-size: 26px; /* Adjust as needed */
        }

        .product-dropdown {
            margin-bottom: 10px; /* Adjust as needed */
        }

        .error-message {
            color: red;
            margin-top: 10px; /* Adjust as needed */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="productPanel" runat="server" CssClass="productDiv">
            <asp:Image ID="productImage" runat="server" CssClass="product-image" />
            <div class="product-details">
                <asp:Label ID="productNameLabel" runat="server" CssClass="product-label" />
                <asp:Label ID="categoryLabel" runat="server" CssClass="product-label" />
                <asp:Label ID="brandLabel" runat="server" CssClass="product-label" />
                <asp:Label ID="ratingsLabel" runat="server" CssClass="product-label" />
                <asp:Label ID="amountLabel" runat="server" CssClass="product-label" />
                <asp:Label ID="stockLabel" runat="server" CssClass="product-label" />
                <asp:DropDownList ID="quantityDropDown" runat="server" CssClass="product-dropdown" AutoPostBack="True" OnSelectedIndexChanged="quantityDropDown_SelectedIndexChanged"></asp:DropDownList>
                <asp:Label ID="Label1" runat="server" CssClass="product-label" Visible="false"></asp:Label>
                <asp:Button ID="addToCartButton" runat="server" Text="Add to Cart" OnClick="addToCartButton_Click" />
                <asp:Label ID="errorMessageLabel" runat="server" CssClass="error-message" Visible="false" />

                <!-- Add the total amount label -->
                <asp:Label ID="totalAmountLabel" runat="server" CssClass="product-label" Visible="false"></asp:Label>
            </div>
        </asp:Panel>

    </form>
</body>
</html>
