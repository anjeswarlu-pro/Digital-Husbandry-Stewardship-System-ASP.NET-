<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="Main_Project.Insert" %>

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
            margin-top: 5vh;
            margin-left: 38%;
            margin-bottom: 15vh;
            /* Adjust margin-top to center vertically */
        }

            .panel input[type="text"] {
                padding: 10px;
                font-size: 16px;
                border: 1px solid #ccc;
                border-radius: 4px;
            }
        /* Style for the label */
        label {
            color: white;
            display: block; /* This ensures each label appears on its own line */
            margin-bottom: 5px; /* Adds some space between labels */
        }

        /* Style for the text input */
        #nameTextBox {
            color: black;
            width: 200px; /* Adjust width as needed */
            padding: 5px; /* Adds some space inside the input */
            border: 1px solid #ccc; /* Add border */
        }

        /* Style for the file upload input */
        #image1Upload {
            color: white;
            padding: 5px; /* Adds some space inside the input */
            border: 1px solid #ccc; /* Add border */
        }

        /* Style for the submit button */
        #submitButton {
            padding: 10px 20px; /* Adds some padding around the button text */
            background-color: #007bff; /* Change background color */
            color: #fff; /* Change text color */
            border: none; /* Remove border */
            cursor: pointer; /* Show pointer on hover */
        }

            /* Style for hover effect on submit button */
            #submitButton:hover {
                background-color: #0056b3; /* Darker background color on hover */
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

                <asp:ListItem Text="infoimage" Value="infoimage"></asp:ListItem>
                <asp:ListItem Text="Information" Value="Information"></asp:ListItem>

                <asp:ListItem Text="Shop" Value="Shop"></asp:ListItem>
                <asp:ListItem Text="Shopimage" Value="Shopimage"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:Panel ID="Panel1" runat="server" CssClass="panel" Style="display: none;">
            <div>
                <label for="nameTextBox">Name:</label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="image1Upload">Image 1:</label>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <label for="image1Upload">Image 2:</label>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <label for="image1Upload">Image 3:</label>
                <asp:FileUpload ID="FileUpload3" runat="server" />
            </div>

            <div>
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="infoimage" />
            </div>
        </asp:Panel>



        <asp:Panel ID="Panel2" runat="server" CssClass="panel" Style="display: none;">
            <div>
                <label for="Name">Name:</label>
                <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                <label for="Category">Category:</label>
                <asp:TextBox ID="Category" runat="server"></asp:TextBox>
                <label for="Description">Description:</label>
                <asp:TextBox ID="Description" runat="server"></asp:TextBox>
                <label for="Pros">Pros:</label>
                <asp:TextBox ID="Pros" runat="server"></asp:TextBox>
                <label for="Cons">Cons:</label>
                <asp:TextBox ID="Cons" runat="server"></asp:TextBox>
                <label for="Period">Period:</label>
                <asp:TextBox ID="Period" runat="server"></asp:TextBox>
                <label for="Season">Season:</label>
                <asp:TextBox ID="Season" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Information_Click" />
            </div>
        </asp:Panel>



        <asp:Panel ID="Panel3" runat="server" CssClass="panel" Style="display: none;">
            <div>
                <label for="Pid">Pid:</label>
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                <label for="Name">Name:</label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <label for="Category">Category:</label>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <label for="Brand">Brand:</label>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <label for="Ratings">Ratings:</label>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <label for="Amount">Amount:</label>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <label for="Stock">Stock:</label>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Button ID="Button3" runat="server" Text="Submit" OnClick="Shop_Click" />
            </div>
        </asp:Panel>




        <asp:Panel ID="Panel4" runat="server" CssClass="panel" Style="display: none;">
            <div>
                <label for="nameTextBox">Name:</label>
                <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="image1Upload">Image 1:</label>
                <asp:FileUpload ID="image1Upload" runat="server" />
            </div>

            <div>
                <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
            </div>
        </asp:Panel>



    </form>



    <script>
        function togglePanel() {
            var ddl = document.getElementById('<%= ddlTables.ClientID %>');
            var pnl1 = document.getElementById('<%= Panel1.ClientID %>');
            var pnl2 = document.getElementById('<%= Panel2.ClientID %>');
            var pnl3 = document.getElementById('<%= Panel3.ClientID %>');
            var pnl4 = document.getElementById('<%= Panel4.ClientID %>');


            if (ddl.value === "infoimage") {
                pnl1.style.display = "block";
            }


            else {
                pnl1.style.display = "none";
            }
            if (ddl.value === "Information") {
                pnl2.style.display = "block";
            }


            else {
                pnl2.style.display = "none";
            }
            if (ddl.value === "Shop") {
                pnl3.style.display = "block";
            }


            else {
                pnl3.style.display = "none";
            }

            if (ddl.value === "Shopimage") {
                pnl4.style.display = "block";
            }


            else {
                pnl4.style.display = "none";
            }


        }

    </script>
</body>
</html>
