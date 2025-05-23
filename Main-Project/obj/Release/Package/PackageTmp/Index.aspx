<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Main_Project.intro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        body {
            background: #333;
            display: flex;
            justify-content: center;
            align-items: center; /* Vertically centers the content */
            height: 100vh; /* Ensures the content takes up the full height of the viewport */
            background-color: #166d3b;
            background-image: linear-gradient(147deg, #166d3b 0%, #000000 74%);
        }

        main {
            text-align: center;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .typewriter {
            padding: 15px;
            color: #fff;
            font-family: monospace;
            overflow: hidden; /* Ensures the content is not revealed until the animation */
            white-space: nowrap; /* Keeps the content on a single line */
            margin: 0 auto; /* Centers the typewriter text */
            letter-spacing: .15em; /* Adjust as needed */
            animation: typing 3.5s steps(30, end);
        }

        /* The typing effect */
        @keyframes typing {
            from { width: 0 }
            to { width: 100% }
        }

        .centered-button {
            width: 170px;
          
            height: 50px;
            background-color: antiquewhite; /* Default button color */
            color: #000000; /* Text color */
            font-size:25px;
            border: none;
            border-radius: 15px;
            cursor: pointer;
        }

        .centered-button:hover {
            background-color: springgreen; /* Button color on hover */
        }

        .image-container {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 20px; /* Add some space between the images and the text */
        }

        .image-container img {
            width: 350px; /* Adjust width as needed */
            height: auto;
        }

        .welcome-text {
            color: whitesmoke;
            margin-bottom: 20px;
        }

        .text-block {
            margin-bottom: 20px;
        }

        /* Rainbow hover effect */
        .typewriter h1:hover {
            background: linear-gradient(to right, violet, indigo, blue, green, yellow, orange, red);
            -webkit-background-clip: text;
            background-clip: text;
            color: transparent;
        }
    </style>

    <main>
        <div class="image-container">
            <img alt="Left tree" src="imges/image2.gif">
            <div class="text-block">
    <h1 class="welcome-text">WELCOME</h1>
    <div class="typewriter">
        <h1>DIGITAL HUSBANDARY STEWARDSHIP SYSTEM</h1>
    </div>
</div>

            <img alt="Right tree" src="imges/image2.gif">
        </div>
        
<p>
    <asp:Button ID="Button1" runat="server" Text="-->Home<--" CssClass="centered-button" PostBackUrl="~/Login.aspx" />
</p>
        
    </main>
</asp:Content>
