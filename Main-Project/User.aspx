<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Main_Project.User"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>USER</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Scripts/Style.css" />
   

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
        <div class="repage">
    <p >Click Here To Navigate to ---></p>
<asp:Button ID="btnShopping" runat="server" CssClass="rebutton" Text="Shopping" OnClick="btnShopping_Click" />
<button class="rebutton" id="informationBtn">Information</button>
</div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8">
                    <div class="carousel-container">
                        <div id="carouselExampleSlidesOnly" class="carousel slide carousel-fade" data-ride="carousel">
                            <div class="carousel-inner">
                                <div class="carousel-item active">
                                    <img src="imges/1.jpg" class="d-block" alt="Image 1" />
                                </div>
                                <div class="carousel-item">
                                    <img src="imges/2.jpg" class="d-block" alt="Image 2" />
                                </div>
                                <div class="carousel-item">
                                    <img src="imges/3.jpg" class="d-block" alt="Image 3" />
                                </div>
                                <div class="carousel-item">
                                    <img src="imges/4.jpg" class="d-block" alt="Image 4" />
                                </div>
                                <div class="carousel-item">
                                    <img src="imges/5.jpg" class="d-block" alt="Image 5" />
                                </div>
                                <div class="carousel-item">
                                    <img src="imges/6.jpg" class="d-block" alt="Image 6" />
                                </div>
                                <div class="carousel-item">
                                    <img src="imges/7.jpg" class="d-block" alt="Image 7" />
                                </div>
                                <!-- Add more carousel items as needed -->
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="farmers-container">
                        <div class="farmers-paragraph">
                            <p>Our heartfelt gratitude goes out to all the hardworking farmers who tirelessly cultivate the land, nurturing crops that sustain our communities and feed the world. Their dedication, resilience, and passion for agriculture are the backbone of our society, and we honor their invaluable contribution to humanity.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="information-section">
            <h2>Information Section</h2>
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
                <div class="right-content">
                    <!-- Dropdown Boxes and Search Bar Container -->
                    <div class="dropdown-and-search-container">
                        <div class="dropdown-box">
                            <label for="DropDownList1">Choose Category</label>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" EnableViewState="true" AppendDataBoundItems="true">
                                <asp:ListItem Text="Select Category" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>

                            <label for="DropDownList2">Choose the Name</label>
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AppendDataBoundItems="true">
                                <asp:ListItem Text="Select Name" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <!-- Search Bar -->
                        <div class="search-bar">
            <asp:TextBox ID="searchInput" runat="server" placeholder="Search by Name..."></asp:TextBox>
            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        </div>
                    </div>
                </div>
            </div>
        </div>
      
     
        



    </form>
<div class="predict-container">
   
    <form id="User" class="predict">
     <h1 class="main"><u>Crop Recommendation System</u></h1>
    <label for="N">Enter the value of Nitrogen in your soil (N):</label>
    <input type="text" id="N" name="N" placeholder="Enter the range between 5 to 150" min="5" max="150" required="required" /><br/>

    <label for="P">Enter the value of Phosphorus in your soil( P):</label>
    <input type="text" id="P" name="P" placeholder="Enter the range between 5 to 150" min="5" max="150" required="required"  /><br/>

    <label for="k">Enter the value of Potassium in your soil (K):</label>
    <input type="text" id="k" name="k" placeholder="Enter the range between 5 to 200" min="5" max="200" required="required"  /><br/>

    <label for="temperature">Temperature:</label>
    <input type="text" id="temperature" name="temperature" placeholder="Enter the range between 7 to 40" min="7" max="40" required="required"  /><br/>

    <label for="humidity">Enter the level of Humidity in the Atmosphere:</label>
    <input type="text" id="humidity" name="humidity" placeholder="Enter the range between 40 to 90" min="40" max="90" required="required"  /><br/>

    <label for="ph">Enter the PH value of the soil:</label>
    <input type="text" id="ph" name="ph" placeholder="Enter the range between 1 to 12" min="1" max="12" required="required"  /><br/>

    <label for="rainfall">Enter the average Rainfall of your AREA:</label>
    <input type="text" id="rainfall" name="rainfall" placeholder="Enter the range between 80 to 250" min="80" max="250" required="required"  /><br/>

   <input type="button" value="Predict" onclick="predict()" id="predictButton" />

        <div class="result" id="predictionResult"></div>
</form>

                        
   
    
    
        <div class="image">
        <!-- Your image tags can be placed here -->
    <img id="cropImage" src="imges/5.jpg";" alt="Crop Image" />
    </div>
   

    </div>  
           <footer style="color: #f2f2f2; padding: 20px; text-align: center;">
    <p>© 2024 Digital Husbandry Stewardship System</p>
</footer>
</body>
   
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
<script src="Scripts/WebForms/JavaScript.js"></script>
     <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
   
</html>
