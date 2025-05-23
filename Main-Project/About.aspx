<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Main_Project.About" %>

<!DOCTYPE html>

<html lang="en" dir="ltr">
<head>

    <style>
        /* Style for the main container */
        body {
            background: linear-gradient(147deg, #166d3b 0%, #000000 74%);
           height: 100vh;
            margin: 0;
            display: flex;
            justify-content: center; /* Center horizontally */
            align-items: center; /* Center vertically */
        }

        .container {
            max-width: 800px;
            padding: 20px;
        }


        /* Style for headings */
        h2 {
            color: white;
            font-size: 36px;
           
            margin-bottom: 10px;
        }

        /* Style for paragraphs */
        p {
            font-size: 28px;
            line-height: 1.5;
            color: white;
            margin-bottom: 20px;
        }
    </style>


</head>
<body>
    <div class="container">
        <h2>About Us</h2>
        <p>
            The agricultural industry confronts numerous challenges, including limited market access, unfair pricing, and the unpredictable impacts of climate change. In response to these challenges, our team harnesses the power of ASP.NET technology to provide innovative solutions.
        </p>
        <p>
            Our platform is designed to seamlessly integrate with farmers' existing tools, simplifying agricultural processes and bolstering productivity. At the heart of our solution lies Machine Learning, specifically the Random Forest algorithm. By analyzing historical data, our platform predicts optimal crop choices for farmers, facilitating informed decision-making.
        </p>
        <p>
            Our mission is to revolutionize farming practices by enhancing efficiency and sustainability. We believe in empowering farmers with comprehensive knowledge and user-friendly tools, enabling them to overcome obstacles and maximize agricultural productivity.
        </p>
        <p>
            Through strategic partnerships and the adoption of cutting-edge technologies, we envision a future where the agricultural sector not only survives but thrives. Together, we can ensure the sustenance and prosperity of communities for generations to come.
        </p>
    </div>
</body>
</html>
