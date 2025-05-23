<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="Main_Project.Data" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>INFORMATION PAGE</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-image: linear-gradient(147deg, #166d3b 0%, #000000 74%);
            height: 100vh;
        }

        nav {
            background-color: #000; /* Background color of the navbar */
            color: #fff; /* Text color of the navbar */
            padding: 25px 0; /* Adjust padding as needed */
            text-align: center; /* Center align text */
            font-size: 24px;
        }

        * {
            box-sizing: border-box;
            margin: 0;
            padding: 3px;
        }

        .label {
            color: white;
            font-size: 22px;
            border: 1px solid white; /* Add a white border */
            padding: 20px; /* Adjust the padding as needed */
            width: 150px; /* Set a fixed width for the labels */
            display: inline-block; /* Ensure consistent width */
            text-align: left; /* Align text to the right */
            margin-right: 10px; /* Add some space between label and text */
        }

        .container {
            border: 1px solid rgba(204, 204, 204, 0.1);
            padding: 10px;
            color: white;
            margin: 50px auto; /* Center the container horizontally with equal margin */
            font-size: 22px;
            border: 2px solid white; /* Add a white border */
            display: flex; /* Use flexbox */
            align-items: center; /* Center vertically */
            margin-bottom: 10px;
        }

            .container .label {
                margin-right: 30px; /* Reset margin-right for labels in container */
            }

        .custom-container {
            border: 2px solid #ccc;
            padding: 10px;
            color: white;
            margin: 50px auto; /* Center the container horizontally with equal margin */
            font-size: 22px;
            border: 2px solid white; /* Add a white border */
            display: flex; /* Use flexbox */
            align-items: center; /* Center vertically */
            margin-bottom: 10px;
        }

            .custom-container .content {
                padding: 10px;
            }

            .custom-container .custom-label {
                color: white;
                font-size: 22px;
                border: 1px solid white; /* Add a white border */
                padding: 20px; /* Adjust the padding as needed */
                width: 150px; /* Set a fixed width for the labels */
                display: inline-block; /* Ensure consistent width */
                text-align: left; /* Align text to the right */
                margin-right: 10px;
                margin-top: 0px;
                margin-bottom: 20px; /* Add some space between label and text */
            }




        .slideshow-container {
            width: 50%; /* Adjust the width of the slideshow container */
        }

        .slides {
            display: flex;
            align-items: center; /* Align items vertically */
            font-size: 0; /* Set font-size to 0 to remove whitespace */
            width: 80%;
             width: 90%;/* Ensure images maintain their original size */
            height: auto; /* Maintain aspect ratio */
            display: block;
            margin-right: 10px; /* Add margin between images */ /* width: 50%; Remove width from .slides to inherit from .slideshow-container */
        }

            .slides img {
                 
            }

        .right-css {
        }

        .custom-textbox {
            padding: 20px;
            font-family: 'Times New Roman', Times, serif;
        }
    </style>
</head>
<body>
    <nav>   
        <h1>Information Page</h1>
    </nav>
    <form id="form1" runat="server">
        <asp:Panel ID="panelContainer" runat="server" CssClass="container">
            <asp:Label ID="lblMessage" runat="server" Text="Name:" CssClass="label"></asp:Label>

            <asp:TextBox ID="TextBox0" runat="server" TextMode="MultiLine" Rows="2" Columns="50" Font-Size="22" BorderColor="Black" BorderStyle="Solid" ReadOnly="True" CssClass="custom-textbox"></asp:TextBox>
        </asp:Panel>

        <asp:Panel ID="panel2" runat="server" CssClass="container">
            <asp:Label ID="Label1" runat="server" Text="Category:" CssClass="label"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="2" Columns="50" Font-Size="22" ReadOnly="True" BorderColor="Black" BorderStyle="Solid" CssClass="custom-textbox"></asp:TextBox>
        </asp:Panel>


        <asp:Panel ID="panel5" runat="server" CssClass="container">
            <asp:Label ID="Label5" runat="server" Text="Season" CssClass="label"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" Rows="2" Columns="50" Font-Size="22" ReadOnly="True" BorderColor="Black" BorderStyle="Solid" CssClass="custom-textbox"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panel6" runat="server" CssClass="container">
            <asp:Label ID="Label6" runat="server" Text="Period" CssClass="label"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" Rows="2" Columns="50" Font-Size="22" ReadOnly="True" BorderColor="Black" BorderStyle="Solid" CssClass="custom-textbox"></asp:TextBox>
        </asp:Panel>

        <asp:Panel ID="panel3" runat="server" CssClass="container">

            <asp:Label ID="Label3" runat="server" Text="Pros:" CssClass="label"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Rows="10" Columns="50" Font-Size="22" ReadOnly="True" CssClass="custom-textbox" Height="182px" Width="1057px"></asp:TextBox>

        </asp:Panel>
        <asp:Panel ID="panel4" runat="server" CssClass="container">

            <asp:Label ID="Label4" runat="server" Text="Cons:" CssClass="label"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Rows="10" Columns="50" Font-Size="22" ReadOnly="True" CssClass="custom-textbox" Height="183px" Width="1062px"></asp:TextBox>


        </asp:Panel>

        <asp:Panel ID="panel1" runat="server" CssClass="custom-container">

            <div class="content">
                <asp:Label ID="Label2" runat="server" Text="Description:" CssClass="custom-label"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Rows="10" Columns="50" Font-Size="22" ReadOnly="True" CssClass="custom-textbox"></asp:TextBox>
            </div>
            <div class="slideshow-container">
                <asp:Panel ID="slides" runat="server" CssClass="slides">
                    <!-- Images will be dynamically added here -->
                </asp:Panel>
            </div>

        </asp:Panel>

    </form>
            <footer style="background-color: #f2f2f2; padding: 20px; text-align: center;">
    <p>© 2024 Digital Husbandry Stewardship System</p>
</footer>
</body>

<script>
    // JavaScript for simple image slideshow

    let slideIndex = 0;

    showSlides();

    function showSlides() {
        let slides = document.getElementsByClassName("slides")[0].getElementsByTagName("img");

        for (let i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        slideIndex++;
        if (slideIndex > slides.length) {
            slideIndex = 1;
        }

        slides[slideIndex - 1].style.display = "block";

        setTimeout(showSlides, 4000); // Change image every 2 seconds
    }


</script>




</html>
