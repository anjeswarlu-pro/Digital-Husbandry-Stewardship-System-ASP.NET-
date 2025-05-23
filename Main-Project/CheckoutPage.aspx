<!-- CheckoutPage.aspx -->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="Main_Project.CheckoutPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout Page</title>
</head>
<body>
   
   
      <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
       <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <script>
              // Get the product ID from the query string
        var productId = "<%= Request.QueryString["productId"] %>";

        // Call getProductData function with the retrieved product ID
        getProductData(productId); 

        function getProductData(productId) {
            $.ajax({
                url: 'CheckoutPage.aspx/GetProductAmount', // URL of the server-side method
                type: 'POST', // Use POST method for WebMethod
                contentType: 'application/json; charset=utf-8', // Specify content type
                dataType: 'json', // Expect JSON response
                data: JSON.stringify({ productId: productId }), // Pass product ID as JSON string
                success: function (response) {
                    console.log('Product amount:', response.d);
                    // Convert amount to integer
                    var amount = parseInt(response.d);
                    if (!isNaN(amount)) {
                        // Call the function to initiate Razorpay with integer amount
                        initiateRazorpay(amount, productId);
                    } else {
                        console.error('Invalid amount:', response.d);
                    }
                },
                error: function (xhr, status, error) {
                    console.error('Error fetching product amount:', error);
                }
            });

            // For demonstration purposes, let's log the retrieved product ID
            console.log("Product ID:", productId);
        }



        // Function to initiate Razorpay with product data
        function initiateRazorpay(productData, productId) {
            // Call Razorpay checkout function with product data
            var options = {
                "key": "rzp_test_abQjxfUxQSUNMV",
                "amount": productData * 100, // Amount in paise or smallest currency unit
                "currency": "INR",
                "name": "DIGITAL HUSBANDRY",
                "description": "Product Purchase",
                "image": "https://example.com/logo.png",
                "handler": function (response) {
                    var paymentData = {
                        paymentId: response.razorpay_payment_id,
                        amount: productData,
                        productId: productId 
                    };

                    // Send payment data to server for database insertion
                    savePaymentDetails(paymentData);
                    alert("Payment successful! Payment ID: " + response.razorpay_payment_id);
                    window.location.href = 'Shopping.aspx';

                   
                },
                "prefill": {
                    "name": "Your Name",
                    "email": "your.email@example.com"
                },
                "theme": {
                    "color": "#3399cc"
                }
            };

            var rzp = new Razorpay(options);
            rzp.open();
        }


        function savePaymentDetails(paymentData) {
            $.ajax({
                url: 'CheckoutPage.aspx/SavePaymentDetails',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({
                    paymentData: paymentData,
                   
                    PaymentId: paymentData.paymentId,
                    Amount: paymentData.amount,
                 
                   
                    ProductId: paymentData.productId,
                    OrderDate: new Date().toISOString()
                }),
                success: function (response) {
                    console.log('Payment details saved successfully:', response);
                },
                error: function (xhr, status, error) {
                    console.error('Error saving payment details:', error);
                }
            });
        }

    </script>
</body>

</html>
