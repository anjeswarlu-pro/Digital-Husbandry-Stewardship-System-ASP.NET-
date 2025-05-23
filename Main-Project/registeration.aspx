<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registeration.aspx.cs" Inherits="Main_Project.registeration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: Roboto;
            background: linear-gradient(147deg, #166d3b 0%, #000000 74%);
            height: 100vh;
            display: flex;
            margin-top: 8%;
        }

        main {
            display: flex;
            align-items: center;
            justify-content: space-around;
            width: 150%;
            left: 0px;
        }

        .left {
            flex: 1;
            display: flex;
            align-items: center;
            justify-content: center;
            /* Adjust margin-right if needed */
            margin-right: 50px;
        }

            .left img {
                max-width: 200%; /* Adjust as needed */
                max-height: 200%; /* Adjust as needed */
                border-radius: 10px;
                box-shadow: 0 0 100px rgba(0, 0, 0, 0.2);
                margin-left:100px;
            }

        .center {
            flex: 1;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            background: white;
            border-radius: 10px;
            padding: 40px;
            box-sizing: border-box;
            /* Increase the max-width for a wider form */
            max-width: 800px;
            font-size: 20px;
        }

            .center h1 {
                text-align: center;
                padding: 0 0 20px 0;
                border-bottom: 1px solid silver;
            }

        .txt_field {
            position: relative;
            margin: 20px 0; /* Adjust margin for spacing between form fields */
            width: 100%; /* Ensure form fields take the full width */
        }

            .txt_field input {
                width: 100%;
                padding: 5px;
                height: 40px;
                font-size: 16px;
                border: none;
                background: none;
                outline: none;
                border-bottom: 2px solid #adadad;
            }

            .txt_field label {
                position: absolute;
                top: 50%;
                left: 5px;
                color: #adadad;
                transform: translateY(-50%);
                font-size: 16px;
                pointer-events: none;
            }

            .txt_field span::before {
                content: '';
                position: absolute;
                top: 40px;
                left: 0;
                width: 0px;
                height: 2px;
                background: #2691d9;
                transition: .5s;
            }

            .txt_field input:focus ~ label,
            .txt_field input:valid ~ label {
                top: -5px;
                color: #2691d9;
            }

            .txt_field input:focus ~ span::before,
            .txt_field input:Valid ~ span::before {
                width: 100%;
            }

        input[type="submit"] {
            display: block;
            width: 70%;
            height: 50px;
            border: 1px solid;
            border-radius: 25px;
            font-size: 18px;
            font-weight: 700;
            cursor: pointer;
        }

            input[type="submit"]:hover {
                background: #10ef1b;
                color: #e9f4fb;
                transition: .5s;
            }

        .signup_link {
            margin-top: 120px; /* Adjust margin for spacing between form and signup link */
            text-align: center;
            font-size: 16px;
            color: #666666;
        }

            .signup_link a {
                color: #2691d9;
                text-decoration: none;
            }

                .signup_link a:hover {
                    text-decoration: underline;
                }


        .navbar {
            position: fixed;
            top: 0;
            right: 0;
            padding: 20px;
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
    </style>

    <main>
        <div class="left">
            <img alt="Left tree" src="imges/image3.gif">
        </div>
        <div class="navbar">
 <a href="About.aspx">About</a>           
        </div>

        <<div class="center">
            <h1>Register</h1>
            <asp:Label ID="lblUid" runat="server" AssociatedControlID="uid" Text="User ID"></asp:Label>
            <asp:TextBox ID="uid" runat="server" CssClass="txt_field" required="required"></asp:TextBox>

            <asp:Label ID="lblUsername" runat="server" AssociatedControlID="username" Text="Name"></asp:Label>
            <asp:TextBox ID="username" runat="server" CssClass="txt_field" required="required"></asp:TextBox>

            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="email" Text="Email"></asp:Label>
            <asp:TextBox ID="email" runat="server" CssClass="txt_field" required="required"></asp:TextBox>

            <asp:Label ID="lblPassword" runat="server" AssociatedControlID="password" Text="Password"></asp:Label>
            <asp:TextBox ID="password" runat="server" CssClass="txt_field" TextMode="Password" required="required"></asp:TextBox>

            <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="cpassword" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="cpassword" runat="server" CssClass="txt_field" TextMode="Password" required="required"></asp:TextBox>

            <asp:Label ID="lblImageUpload" runat="server" AssociatedControlID="imageUpload" Text="Profile Image"></asp:Label>
            <asp:FileUpload ID="imageUpload" runat="server" CssClass="txt_field" />
            <asp:Button ID="btnSignUp" runat="server" Text="SignUp" OnClick="registrationForm_Submit" OnClientClick="return validateForm();" />
        </div>



        

        <script>
            function validateForm() {
                // Validate UID (must be a 6-digit number)
                var uid = document.getElementById("<%= uid.ClientID %>").value;
                if (!/^\d{6}$/.test(uid)) {
                    alert("UID must be a 6-digit number.");
                    return false;
                }

                // Validate passwords
                var password = document.getElementById("<%=password.ClientID%>").value;
                var confirmPassword = document.getElementById("<%=cpassword.ClientID%>").value;

                // Check if password fields are empty
                if (password === "" || confirmPassword === "") {
                    alert("Please fill in both Password and Confirm Password fields.");
                    return false;
                }

                // Check if passwords match
                if (password !== confirmPassword) {
                    alert("Password and Confirm Password must match.");
                    return false;
                }

                // Check if password is greater than 6 characters
                if (password.length < 6) {
                    alert("Password must be at least 6 characters long.");
                    return false;
                }

                // Check if other fields are filled
                var username = document.getElementById("<%=username.ClientID%>").value;
                var email = document.getElementById("<%=email.ClientID%>").value;

                if (username === "" || email === "") {
                    alert("Please fill in all fields.");
                    return false;
                }

                // Password strength check can be added here if needed

                return true;
            }
        </script>






    </main>









</asp:Content>
