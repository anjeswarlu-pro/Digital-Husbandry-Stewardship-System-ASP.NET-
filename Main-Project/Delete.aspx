<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Main_Project.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: Roboto;
            background: linear-gradient(147deg, #166d3b 0%, #000000 74%);
            height: 100vh;
            display: flex;
            flex-direction: column;
        }

        .content .navbar,
        .content .image-link {
            background-color: black;
        }

        .navbar {
            position: fixed;
            top: 0;
            right: 0; /* Align to the right */
            display: flex;
            justify-content: flex-end;
            align-items: center;
            width: 100%;
            padding: 20px 10px; /* Adjust padding as needed */
            box-sizing: border-box;
            z-index: 1000;
        }

            .navbar a {
                color: #f2f2f2;
                text-align: center;
                padding: 10px 25px; /* Adjusted padding */
                text-decoration: none;
                font-size: 22px;
                position: relative;
                cursor: pointer;
                z-index: 1; /* Added z-index */
            }




                .navbar a::after {
                    content: "";
                    position: absolute;
                    bottom: -2px; /* Adjusted position to align with the bottom of the link */
                    left: 0;
                    width: 0;
                    height: 2px;
                    background-color: transparent;
                    transition: width 0.5s ease;
                }

                .navbar a:hover::after {
                    width: 100%;
                    background-color: red;
                }



        /* Centering the heading */
        .heading {
            display: flex;
            justify-content: center; /* Center horizontally */
            align-items: center;
            text-align: center;
            width: 100%; /* Make sure it takes full width */
            margin: auto; /* Center horizontally */
            position: absolute; /* Positioning */
            top: 50%; /* Place it at the vertical center */
            transform: translateY(-50%); /* Adjust for vertical centering */
            left: 0;
            right: 0;
        }

            .heading h1 {
                margin: 0;
                font-size: 28px;
                font-weight: bold;
                color: #f2f2f2;
            }

        /* Rainbow blink effect for the h1 */
        @keyframes rainbow {
            0% {
                color: #ff0000;
            }

            14% {
                color: #ff8000;
            }

            28% {
                color: #ffff00;
            }

            42% {
                color: #80ff00;
            }

            57% {
                color: #00ff00;
            }

            71% {
                color: #00ff80;
            }

            85% {
                color: #00ffff;
            }

            100% {
                color: #0080ff;
            }
        }

        .heading h1 {
            animation: rainbow 3s infinite alternate;
        }

        .DropDown {
            display: flex;
            flex-direction: row; /* Display items side by side */
            justify-content: center; /* Horizontally center items */
            align-items: center; /* Vertically center items */
            gap: 10px; /* Adjust space between items */
            margin: 15% auto; /* Vertical and horizontal centering */
            width: 400px; /* Adjust width as needed */
            padding: 5px;
            font-size: 20px;
            border: 1px solid #ccc;
            border-radius: 4px;
            background-color: #fff;
            color: #333;
            cursor: pointer;
        }


            .DropDown option {
                padding: 5px;
            }

            .DropDown:hover {
                border-color: #999;
            }

            .DropDown:focus {
                outline: none;
                border-color: #66afe9;
                box-shadow: 0 0 5px rgba(102, 175, 233, 0.6);
            }

        .panel {
            display: flex;
            align-items: center;
            justify-content: center;
            margin-top: 15vh;
            margin-left: 38%;
            /* Adjust margin-top to center vertically */
        }

            .panel input[type="text"] {
                padding: 10px;
                font-size: 16px;
                border: 1px solid #ccc;
                border-radius: 4px;
            }

        .delete-button {
            padding: 10px 20px;
            font-size: 16px;
            background-color: #f44336;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin-left: 10px; /* Adjust margin-left to create space between input and button */
        }

            .delete-button:hover {
                background-color: #d32f2f; /* Darker red on hover */
            }

        .labelStyle {
            /* Add your CSS styles here */
            font-weight: bold;
            color: white; /* Set text color to white */
            font-size: 30px;
            /* Add any other styles you want */
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="content">
            <!-- Navigation Bar -->
            <div class="navbar">
                <div>
                    <a href="#home">Home</a>
                    <a href="About.aspx">About</a>
                   
                </div>
                <div class="heading">
                    <h1>DIGITAL HUSBANDRY STEWARDSHIP SYSTEM</h1>
                </div>
            </div>
        </div>
        <div>
            <asp:DropDownList ID="ddlTables" runat="server" CssClass="DropDown" onchange="togglePanel()">
                <asp:ListItem Text="Select Table" Value=""></asp:ListItem>
                <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                <asp:ListItem Text="Cart" Value="Cart"></asp:ListItem>
                <asp:ListItem Text="infoimage" Value="infoimage"></asp:ListItem>
                <asp:ListItem Text="Information" Value="Information"></asp:ListItem>
                <asp:ListItem Text="Orders" Value="Orders"></asp:ListItem>
                <asp:ListItem Text="Registration" Value="Registration"></asp:ListItem>
                <asp:ListItem Text="Shop" Value="Shop"></asp:ListItem>
                <asp:ListItem Text="Shopimage" Value="Shopimage"></asp:ListItem>
            </asp:DropDownList>
        </div>



        <asp:Panel ID="pnlUserPanel" runat="server" CssClass="panel" Style="display: none;">
            <asp:Label ID="label1" runat="server" CssClass="labelStyle">Registration</asp:Label>
            <asp:TextBox ID="txtUserId" runat="server" placeholder="Enter User ID"></asp:TextBox>
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="delete-button" />

        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" CssClass="panel" Style="display: none;">
            <asp:Label ID="label2" runat="server" CssClass="labelStyle">Cart</asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter PID"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Delete" OnClick="BtnDelete_Click" CssClass="delete-button" />

        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" CssClass="panel" Style="display: none;">
            <asp:Label ID="label3" runat="server" CssClass="labelStyle">Info Image</asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Enter Product"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="InfoImage" CssClass="delete-button" />

        </asp:Panel>

        <asp:Panel ID="Panel3" runat="server" CssClass="panel" Style="display: none;">
            <asp:Label ID="label4" runat="server" CssClass="labelStyle">Information</asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Enter Product"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Information" CssClass="delete-button" />

        </asp:Panel>


        <asp:Panel ID="Panel4" runat="server" CssClass="panel" Style="display: none;">
            <asp:Label ID="label5" runat="server" CssClass="labelStyle">Orders</asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" placeholder="Enter Orders"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" Text="Delete" OnClick="Orders" CssClass="delete-button" />

        </asp:Panel>

        
        <asp:Panel ID="Panel5" runat="server" CssClass="panel" Style="display: none;">
            <asp:Label ID="label6" runat="server" CssClass="labelStyle">Shop</asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" placeholder="Enter Product"></asp:TextBox>
            <asp:Button ID="Button5" runat="server" Text="Delete" OnClick="Shop" CssClass="delete-button" />

        </asp:Panel>
         <asp:Panel ID="Panel6" runat="server" CssClass="panel" Style="display: none;">
     <asp:Label ID="label7" runat="server" CssClass="labelStyle">Shopimg</asp:Label>
     <asp:TextBox ID="TextBox6" runat="server" placeholder="Enter Product"></asp:TextBox>
     <asp:Button ID="Button6" runat="server" Text="Delete" OnClick="Shopimg" CssClass="delete-button" />

 </asp:Panel>

    </form>




    <script>
        function togglePanel() {
            var ddl = document.getElementById('<%= ddlTables.ClientID %>');
            var pnl1 = document.getElementById('<%= Panel1.ClientID %>');
            var pnl2 = document.getElementById('<%= Panel2.ClientID %>');
            var pnl3 = document.getElementById('<%= Panel3.ClientID %>');
            var pnl4 = document.getElementById('<%= Panel4.ClientID %>');
            var pnl5 = document.getElementById('<%= pnlUserPanel.ClientID %>');
            var pnl6 = document.getElementById('<%= Panel5.ClientID %>');
            var pnl7 = document.getElementById('<%= Panel6.ClientID %>');


            if (ddl.value === "Registration") {
                pnl5.style.display = "block";
            }


            else {
                pnl5.style.display = "none";
            }

            if (ddl.value === "Cart") {
                pnl1.style.display = "block";
            }


            else {
                pnl1.style.display = "none";
            }
            if (ddl.value === "infoimage") {
                pnl2.style.display = "block";
            }


            else {
                pnl2.style.display = "none";
            }

            if (ddl.value === "Information") {
                pnl3.style.display = "block";
            }


            else {
                pnl3.style.display = "none";
            }
            if (ddl.value === "Orders") {
                pnl4.style.display = "block";
            }


            else {
                pnl4.style.display = "none";
            }
            if (ddl.value === "Shop") {
                pnl6.style.display = "block";
            }


            else {
                pnl6.style.display = "none";
            }
            if (ddl.value === "Shopimage") {
                pnl7.style.display = "block";
            }


            else {
                pnl7.style.display = "none";
            }
        }

    </script>






</body>
</html>
