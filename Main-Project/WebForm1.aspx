<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Main_Project.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="nameTextBox">Name:</label>
            <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        </div>
      <div>
    <label for="image1Upload">Image 1:</label>
            <asp:FileUpload ID="image1Upload" runat="server" />
        </div>
       <!--   <div>
            <label for="image2Upload">Image 2:</label>
            <asp:FileUpload ID="image2Upload" runat="server" />
        </div>
        <div>
            <label for="image3Upload">Image 3:</label>
            <asp:FileUpload ID="image3Upload" runat="server" />
        </div> -->
        <div>
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
        </div>
    </form>
</body>
</html>
