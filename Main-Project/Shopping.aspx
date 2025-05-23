<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shopping.aspx.cs" Inherits="Main_Project.Shopping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>


    <link rel="stylesheet" href="Scripts/shop.css" />
    <script src="Scripts/WebForms/shopjs.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <!-- Navigation Bar -->
            <div class="navbar">
                <div>
                    <a href="#home">Home</a>
 <a href="About.aspx">About</a>

                    <div class="container">
                        <!-- Image acting as a button to toggle dashboard panel -->
                        <img class="image-link" src="imges/man.png" alt="Dashboard" onclick="toggleDashboardPanel()" />

                        <!-- Dashboard panel content -->
                        <div class="dashboard-panel" id="dashboardPanel">
                            <!-- Close button for the dashboard panel -->
                            <span class="close-button" onclick="toggleDashboardPanel()">&times;</span>

                            <!-- iframe to load Dashboard.aspx content -->
                            <iframe src="DashBoard.aspx" width="100%" height="100%" frameborder="1"></iframe>
                        </div>
                    </div>
                </div>
                <div class="heading">
                    <h1>DIGITAL HUSBANDRY STEWARDSHIP SYSTEM</h1>
                </div>
            </div>
        </div>
        <div class="cart">
            <asp:ImageButton ID="cartButton" runat="server" ImageUrl="imges/cart.png" AlternateText="Cart" CssClass="cartimg" OnClientClick="openCartPopup(); return false;" />
        </div>

        <!-- Container for the iframe -->
        <asp:Panel ID="iframeContainer" runat="server"></asp:Panel>


        <div class="shopping-section">
            <h2>Shopping Section</h2>
            <div class="coner">
                <div class="left-content">
                    <div class="sliding-container">
                        <div class="slides">
                            <img src="imges/1.jpg" class="slide active" alt="Image 1" />
                            <img src="imges/2.jpg" class="slide" alt="Image 2" />
                            <img src="imges/3.jpg" class="slide" alt="Image 3" />
                            <!-- Add more slides as needed -->
                        </div>
                        <button class="prev-slide">Previous</button>
                        <button class="next-slide">Next</button>
                    </div>
                </div>
                <div class="rightshop-content">
                    <!-- Dropdown Boxes and Search Bar Container -->
                    <div class="rightdropdown-and-search-container">
                        <div class="rightdropdown-box">
                            <label for="DropDownList1">Choose Category</label>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="custom-dropdown" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" EnableViewState="true" AppendDataBoundItems="true">
                                <asp:ListItem Text="Select Category" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>

                            <label for="DropDownList2">Choose the Name</label>
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" CssClass="custom-dropdown" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AppendDataBoundItems="true">
                                <asp:ListItem Text="Select Name" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>

                        </div>


                        <!-- Search Bar -->
                        <div class="rightsearch-bar">
                            <asp:TextBox ID="searchInput" runat="server" placeholder="Search by Name..."></asp:TextBox>
                            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="shopping-module" id="shoppingModule" runat="server">
            <!-- Content of shopping module goes here -->


            <div class="prodiv" id="product_info">
                <img src="imges/1.jpg" alt="Product Image 1" id="product_image" />

                
            </div>


            <div class="prodiv">
                <img src="imges/2.jpg" alt="Product Image 2" id="product_image1" />


            </div>
            <div class="prodiv">
                <img src="imges/3.jpg" alt="Product Image 2" id="product_image2" />


            </div>
        </div>


    </form>
    <footer style="background-color: #000000; color: white; padding: 20px; text-align: center;">
        <p>© 2024 Digital Husbandry Stewardship System</p>
    </footer>
</body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</html>
