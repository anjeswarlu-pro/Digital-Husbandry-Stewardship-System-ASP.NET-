<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Main_Project.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>
        function RemoveItem(productId) {
            var params = JSON.stringify({ productId: productId });
            $.ajax({
                type: "POST",
                url: "Cart.aspx/RemoveItem",
                data: params,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Handle success response
                    // For example, refresh the cart data
                    BindCartData();
                },
                error: function (xhr, status, error) {
                    // Handle error response
                    console.error(xhr.responseText);
                }
            });
        }
    </script>
    <script>
        function BuyItem(productId) {
            // Construct the URL for the new page with query parameters
            var url = "BuyPage.aspx?productId=" + productId;

            // Open a new window with the constructed URL
            window.open(url, "_blank");
        }
    </script>


    <style>
        .cart-item {
            border: 1px solid #ccc;
            padding: 10px;
            margin-bottom: 10px;
        }

        .product-image {
            max-width: 100px; /* Adjust the max-width as needed */
        }

        .product-id,
        .quantity,
        .total-amount {
            margin: 5px 0;
        }

        .remove-button,
        .buy-button {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 5px 10px;
            cursor: pointer;
            margin-right: 5px;
        }

            .remove-button:hover,
            .buy-button:hover {
                background-color: #0056b3;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <div>
            <!-- Use an ASP.NET Literal control to dynamically render the cart data -->
            <asp:Literal ID="cartDataLiteral" runat="server"></asp:Literal>
        </div>
    </form>

   

</body>
    </html>
