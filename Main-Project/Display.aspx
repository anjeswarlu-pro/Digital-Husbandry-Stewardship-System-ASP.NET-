<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="Main_Project.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

        .gridView {
            font-size: 18px;
            margin-top: 10px;
            max-width: 100%; /* Set maximum width */
            overflow-x: auto; /* Add horizontal scrolling */
            background-color: white;
        }

            .gridView th, .gridView td {
                border: 1px solid #ddd;
                color: black;
                margin: auto;
                padding: 10px;
                text-align: left;
            }

            .gridView th {
                font-size: 24px;
                background-color: #f2f2f2;
            }
    </style>
    <title></title>
</head>
<body>
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
    <form id="form1" runat="server">
        <div>


            <asp:DropDownList ID="ddlTables" runat="server" CssClass="DropDown" AutoPostBack="true" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                <asp:ListItem Text="Select Table" Value=""></asp:ListItem>

            </asp:DropDownList>
        </div>
        <div>
            <asp:GridView ID="gridView" runat="server" CssClass="gridView">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
