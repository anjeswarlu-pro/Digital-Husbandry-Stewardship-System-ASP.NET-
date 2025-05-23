<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Main_Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
      /* General styles */
/* General styles */
body {
    background: #333;
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: #166d3b;
    background-image: linear-gradient(147deg, #166d3b 0%, #000000 74%);
    margin: 0;
    text-align: right; /* Align all text to the right */
}

/* Main content container */
.block {
    padding: 10px;
    margin: 20px auto; /* Centering the block */
    border: 3px solid black;
    background-color: white;
    text-align: center;
}

/* Header styles */
@keyframes rainbow {
    0% {
        color: red;
    }
    10% {
        color: orange;
    }
    20% {
        color: yellow;
    }
    30% {
        color: green;
    }
    40% {
        color: blue;
    }
    50% {
        color: indigo;
    }
    60% {
        color: violet;
    }
    70% {
        color: purple;
    }
    80% {
        color: pink;
    }
    90% {
        color: cyan;
    }
    100% {
        color: red; /* Return to red to complete the cycle */
    }
}


#aspnetTitle {
    color: #ffffff;
    font-family: 'Times New Roman', Times, serif;
    margin-bottom: 30px;
}

#aspnetTitle:hover {
    animation: rainbow 5.5s infinite;
}

/* Navbar styles */
.navbar {
    overflow: hidden;
    width: auto; /* Adjust width as needed */
    position: absolute;
    top: 20px;
    right: 20px;
}

.navbar a {
    display: inline-block;
    color: #f2f2f2;
    text-align: center;
    padding: 20px;
    text-decoration: none;
    font-size: 22px;
    position: relative;
}

.navbar a::after {
    content: "";
    position: absolute;
    left: 0;
    bottom: -2px;
    width: 0;
    height: 2px;
    background-color: transparent;
    transition: width 0.5s ease, left 0.5s ease;
}

.navbar a:hover::after {
    width: 100%;
    left: 0;
    background-color: red;
}

/* Login box styles */
.login-container {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
}

.login-box {
    width: 300px;
    height: auto;
    background-color: #fff;
    padding: 30px;
    border-radius: 5px;
    box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
    border: 2px solid #333;
    margin: 50px ; /* Centering the login box */
}

.login-box h2 {
    margin-bottom: 20px;
}

.login-input {
    margin-bottom: 15px;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 3px;
    font-size: 16px;
}

.login-button,
.forget-password {
    padding: 10px 20px;
    border-radius: 5px;
    font-size: 16px;
}

.login-button {
    background-color: #4caf50;
    color: #fff;
    border: none;
    cursor: pointer;
    height: 40px;
    min-width: 200px;
    margin-bottom: 10px;
}

        .pass {
            color: #2691d9;
            text-decoration: none;
            font-size: 18px;
            margin-left: 410px;
        }
            /* Additional styles for small screens */
            @media screen and (max-width: 600px) {
                .login-box {
                    width: 80%;
                }
            }


    </style>

    <main>
         <form id="nav">
        <div class="navbar">
            <a href="#">About</a>
            <a href="#">Services</a>
            <a href="#">Contact</a>
        </div>
    </form>
         
        <h1 id="aspnetTitle">WELCOME DIGITAL HUSBANDRY STEWARDSHIP SYSTEM</h1>
        <div class="block">
            <div class="login-container">
                <div class="login-box">
                    <h2 class="login-header">Admin Login</h2>
                    <form class="login-form" method="post" action="/login">
                        <label for="admin-username">Username</label>
                        <input type="text" id="admin-username" name="username" class="login-input">
                        <label for="admin-password">Password</label>
                        <input type="password" id="admin-password" name="password" class="login-input">
                        <button type="submit" class="login-button">Login</button>
                    </form>
                </div>
                <div class="login-box">
                    <h2 class="login-header">User Login</h2>
                    <form class="login-form" method="post" action="/login">
                        <label for="user-username">Username</label>
                        <input type="text" id="user-username" name="username" class="login-input">
                        <label for="user-password">Password</label>
                        <input type="password" id="user-password" name="password" class="login-input">
                        <button type="submit" class="login-button">Login</button>
                    </form>
                    <asp:HyperLink ID="ForgetPasswordLink" runat="server" NavigateUrl="~/forget.aspx">Forget Password</asp:HyperLink>
                </div>
            </div>
            <div class="pass">
               
                <p>
                    <asp:HyperLink ID="RegisterLink" runat="server" NavigateUrl="~/registeration.aspx">If New User Click Here To Register</asp:HyperLink>
                </p>
            </div>
        </div>
    </main>

</asp:Content>
