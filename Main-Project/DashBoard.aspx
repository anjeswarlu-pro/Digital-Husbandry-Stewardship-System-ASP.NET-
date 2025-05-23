<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="Main_Project.DashBoard" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" />
    <style>
       /* Additional styles for the close button */
.close-btn-container {
    position: fixed;
    top: 10px;
    right: 10px;
    z-index: 999;
}

.content {
    margin-top: 40px;
    
}

body {
    margin: 0;
    height: 100vh;
     background: linear-gradient(147deg, #166d3b 0%, #000000 74%);
     overflow:hidden;
    
}
.container.emp-profile {
        border: 1px solid #00FF00; /* Green solid border */
        padding: 20px; /* Adjust padding as needed */
        margin-left: 20px; /* Left margin */
        margin-right: 40px; /* Right margin */
    }


.emp-profile {
    
    padding: 3%;
    margin-top: 3%;
    margin-bottom: 3%;
    border-radius: 0.5rem;
    background: #fff;
    height: 80%;
    width: 90%;
    overflow-y: auto;
}

.profile-img {
    text-align: center;
}

.profile-img img {
    width: 70%;
    height: auto;
    border-radius: 5%;
}

.profile-img .file {
    position: relative;
    overflow: hidden;
    margin-top: -20%;
    width: 40%;
    max-width: 200px;
    border: none;
    border-radius: 50px;
    font-size: 15px;
    background: #fff;
    color:#000000;
}

.profile-img .file input {
    position: absolute;
    opacity: 0;
    right: 0;
    top: 0;
}

.profile-head h5 {
    color: #333;
}

.profile-head h6 {
    color: #0062cc;
}

.profile-edit-btn {
    border: none;
    border-radius: 1.5rem;
    width: 70%;
    padding: 2%;
    font-weight: 600;
    color: #6c757d;
    cursor: pointer;
}



.profile-head .nav-tabs {
    margin-bottom: 5%;
}

.profile-head .nav-tabs .nav-link {
    font-weight: 600;
    border: none;
}

.profile-head .nav-tabs .nav-link.active {
    border: none;
    border-bottom: 2px solid #0062cc;
}

.profile-work {
    padding: 14%;
    margin-top: -15%;
}

.profile-work p {
    font-size: 12px;
    color: #818182;
    font-weight: 600;
    margin-top: 10%;
}

.profile-work a {
    text-decoration: none;
    color: #495057;
    font-weight: 600;
    font-size: 14px;
}

.profile-work ul {
    list-style: none;
}

.profile-tab label {
    font-weight: 600;
    
}

.profile-tab p {
    font-weight: 600;
    color: #0062cc;
}

.green-label {
    color:black; /* Green color */
}
.error-message {
    color: red; /* Define error message color */
}
.profile-tab .row {
    border-bottom: 1px solid #00FF00; /* Green border color */
    padding-bottom: 10px; /* Adjust padding as needed */
    margin-bottom: 10px; /* Adjust margin as needed */
}
.grid{
    color:white;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <!-- Your dashboard content here -->

            <!-- Close button -->
            <div class="close-btn-container">
                <!-- Use a span element to create the "X" symbol -->
                <span class="close-btn" onclick="closeDashboardPanel()">✖</span>
            </div>
        </div>

      
        <div class="container emp-profile">
            <div class="row">
    <div class="col-md-4">
        <div class="profile-img">
            <asp:Image ID="imgProfile" runat="server" CssClass="img-fluid" />
            <div class="file btn btn-lg btn-primary">
                Change Photo
                <asp:FileUpload ID="fileUpload" runat="server" />
            </div>
        </div>
    </div>
    <div class="col-md-2">
        <asp:Button ID="btnAddMore" runat="server" CssClass="profile-edit-btn" Text="Edit Profile" />
    </div>
</div>

            <div class="col-md-8">
                <div class="tab-content profile-tab" id="myTabContent">
                    <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                        <div class="row">
                            <div class="col-md-6">
                                <label>User Id</label>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblUserId" runat="server" Text="" CssClass="green-label">></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Name</label>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblName" runat="server" Text="" CssClass="green-label">></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Email</label>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblEmail" runat="server" Text="" CssClass="green-label">></asp:Label>
                            </div>
                            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error-message"></asp:Label>

                        </div>
                        <!-- You can add more rows for additional user details here -->
                    </div>
                </div>
            </div>
        </div>
        <div class="0rders">
                <asp:Button ID="MyOrdersButton" runat="server" Text="View My Orders" OnClick="MyOrdersButton_Click" />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="grid">
    <Columns>
        <asp:BoundField DataField="PaymentId" HeaderText="Payment ID" />
        <asp:BoundField DataField="Amount" HeaderText="Amount" />
        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
    </Columns>
</asp:GridView>

        </div>
    </form>
    

    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <!-- JavaScript to close the dashboard panel -->
    <script>
        function closeDashboardPanel() {
            // Send a message to the parent window to close the dashboard panel
            window.parent.postMessage('closeDashboardPanel', '*');
        }
    </script>
</body>
</html>
