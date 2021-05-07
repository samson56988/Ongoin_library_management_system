<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="Library_Managment_System.Session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <link rel="stylesheet" href="Landing.css" />
    
</head>
<body>
    <section>
            <input type="checkbox" id="check" />
            <header>
                <h2><a href="#" class="logo">GrailTech</a></h2>
                <div class="navigation">

                    <a href="#">Home</a>
                    <a href="#">About</a>
                    <a href="#">Info</a>
                    <a href="#">Services</a>
                </div>

                <label for="">
                    <i class="fas fa-bars menu-btn"></i>
                    <i class="fas fa-times close-btn"></i>
                </label>
                </header>
            <div class="content">
                <div class="info">
                    <h2>Library Management System<br /><span>Grail Technology</span></h2>
                    <p style="font-weight:400">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book</p>
                    <a href="Libarian/Login.aspx" class="info-btn">Admin</a>
                    <a href="Student/Studentloging.aspx" class="info-btn">Student</a>
                </div>
            </div>
            <div class="media-icons">
                <a href="#"><i class="fab fa-facebook-f"></i></a>
                <a href="#"><i class="fab fa-twitter"></i></a>
                <a href="#"><i class="fab fa-instagram"></i></a>

            </div>
        </section>
    </body>
    
</body>
</html>
