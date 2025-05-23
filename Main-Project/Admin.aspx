<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Main_Project.Admin" %>

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

       
  


.Buttons {
    display: flex;
    flex-direction: row; /* Display buttons side by side */
    justify-content: center; /* horizontally centers content */
    align-items: center;
    gap: 10px;
   
    cursor: pointer;
    border-radius: 8px;
    margin-top: 25%;
  
}

.button{
     color: black;
 padding: 15px 32px;
 text-align: center;
 text-decoration: none;
 font-size: 16px;
      background-color: lightgreen; /* Green */
     font-size:24px;
}


            .button:hover {
                background-color: cyan; /* Darker Green */
            }
    </style>
    <script>

</script>
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
        

        <div class="Buttons">
            <asp:Button ID="Button1" runat="server" CssClass="button" Text="Insert" BorderStyle="None" OnClick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server" CssClass="button" Text="Delete" BorderStyle="None" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" CssClass="button" Text="Update" BorderStyle="None" OnClick="Button3_Click"/>
            <asp:Button ID="Button4" runat="server" CssClass="button" Text="Display" BorderStyle="None" OnClick="Button4_Click" />

        </div>

    </form>
</body>
</html>
