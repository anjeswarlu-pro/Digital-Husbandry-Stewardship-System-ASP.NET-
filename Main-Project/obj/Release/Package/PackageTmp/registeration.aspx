<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registeration.aspx.cs" Inherits="Main_Project.registeration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: Roboto;
            background: linear-gradient(147deg, #166d3b 0%, #000000 74%);
            height: 100vh;
            overflow: hidden;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        main {
            display: flex;
            align-items: center;
            justify-content: space-around;
            width: 100%;
        }

.left {
    flex: 1;
    display: flex;
    align-items: center;
    justify-content: center;
    margin-right: 500px; /* Adjust margin-right as needed */
}

.left img {
    max-width: 550%; /* Ensure the image doesn't exceed its container */
    max-height: 550%; /* Ensure the image doesn't exceed its container */
    border-radius: 10px; /* Optional: Add border-radius for rounded corners */
    box-shadow: 0 0 100px rgba(0, 0, 0, 0.2); /* Optional: Add shadow effect */
}

.center {
    flex: 1;
    display: flex;
    flex-direction: column; /* Align items vertically */
    align-items: center;
    justify-content: center;
    background: white;
    border-radius: 10px;
    padding: 40px;
    box-sizing: border-box;
    /* Ensure the form takes the full width of its container */
    max-width: 700px; /* Adjust the maximum width of the form as needed */
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
    padding: 0 5px;
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
    background: #2691d9;
    color: #e9f4fb;
    transition: .5s;
}

.signup_link {
    margin-top: 20px; /* Adjust margin for spacing between form and signup link */
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
    
        <div class="center">
            <h1>Register</h1>
            <form id="registrationForm" method="POST" action="">
                <div class="txt_field">
                    <input type="text" name="name" required>
                    <span></span>
                    <label>Name</label>
                </div>
                <div class="txt_field">
                    <input type="email" name="email" required>
                    <span></span>
                    <label>Email</label>
                </div>
                <div class="txt_field">
                    <input type="password" name="password" required>
                    <span></span>
                    <label>Password</label>
                </div>
                <div class="txt_field">
                    <input type="password" name="cpassword" required>
                    <span></span>
                    <label>Confirm Password</label>
                </div>
                <input type="submit" value="SignUp">
            </form>
            <div class="signup_link">
                Have an Account ? <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Login Here</asp:HyperLink>
            </div>
        </div>
   
    <div class="navbar">
        <a href="#">About</a>
        <a href="#">Services</a>
        <a href="#">Contact</a>
    </div>
</main>

</asp:Content>
