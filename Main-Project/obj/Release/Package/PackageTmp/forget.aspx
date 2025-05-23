﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="forget.aspx.cs" Inherits="Main_Project.forget" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<Style style="background-color: #99CCFF">
     .form-container {
    width: 325px; /* Set the width of the form */
    padding: 20px;
    border-radius: 5px;
    background-color:#99CCFF; /* Change the background color */
    border: 2px solid black; /* Change the border color */
    margin: 0 auto; /* Center the form horizontally */
}
       
    * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: "segoe ui", verdana, helvetica, arial, sans-serif;
            font-size: 16px;
            transition: all 500ms ease;
        }

        body {
            background-color:white;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
            text-rendering: optimizeLegibility;
            -moz-font-feature-settings: "liga" on;
        }

        .row {
            
            /*background-color: rgba(20, 120, 200, 0.6);*/
            color: #000; /* Change text color to black */
            text-align: center;
            padding: 2em 2em 0.5em;
            width: 90%;
            margin: 2em auto;
            border-radius: 5px;
        }
        .row h1 {
            font-size: 2.5em;
        }
        .row .form-group {
            margin: 0.5em 0;
        }
        .row .form-group label {
            display: block;
            color: #000; /* Change label text color to black */
            text-align: left;
            font-weight: 600;
        }
        .row .form-group input,
        .row .form-group button {
            display: block;
            padding: 0.5em 0;
            width: 100%;
            margin-top: 1em;
            margin-bottom: 0.5em;
            background-color: inherit;
            border: none;
            border-bottom: 1px solid #555;
            color: #000; /* Change input and button text color to black */
        }
        .row .form-group input:focus,
        .row .form-group button:focus {
            background-color: #fff;
            color: #000;
            border: none;
            padding: 1em 0.5em;
            animation: pulse 1s infinite ease;
        }
        .row .form-group button {
            background-color:lightgray;
            border: 1px solid #000000;
            border-radius: 5px;
            outline: none;
            -moz-user-select: none;
            user-select: none;
            color: #333;
            font-weight: 800;
            cursor: pointer;
            margin-top: 2em;
            padding: 1em;
        }
        .row .form-group button:hover,
        .row .form-group button:focus {
            background-color: #fff;
        }
        .row .form-group button.is-loading::after {
            animation: spinner 500ms infinite linear;
            content: "";
            position: absolute;
            margin-left: 2em;
            border: 2px solid #000;
            border-radius: 100%;
            border-right-color: transparent;
            border-left-color: transparent;
            height: 1em;
            width: 4%;
        }

    </Style>

    <html>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Forgot Password Page</title>
    </head>
    <body>
    <div class="row">
        <div class="form-container">
            <h1 style="text-decoration: underline; font-family: 'times New Roman', Times, serif;">Forgot Password</h1>
            <h6 class="information-text" style="font-family: 'times New Roman', Times, serif">Enter your registered email to reset your password.</h6>
            <form style="background-color:whitesmoke">
                <div class="form-group">
                    <input type="email" name="user_email" id="user_email" placeholder="Enter your email">
                    <input type="password" name="new_password" id="new_password" placeholder="Enter New Password" >
                    <input type="password" name="confirm_password" id="confirm_password" placeholder="Confirm Password">
                    <button onclick="showSpinner()" style="font-family: 'Times New Roman', Times, serif">Reset Password</button>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
</asp:Content>
