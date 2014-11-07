<%@ Page Title="Wedding" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Wedding._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Adam Schaal Bootstrapped" />
    <meta name="author" content="Adam Schaal" />
    <link rel="shortcut icon" />
    <title>AdamSchaal.com</title>
    <link type="text/css" rel="stylesheet" href="/Styles/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <link type="text/css" rel="stylesheet" href="https://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <!-- Custom styles for this template -->
    <link href="/Styles/main.css" rel="stylesheet" />
    <link href="/Styles/icomoon.css" rel="stylesheet" />
    <link href="/Styles/animate-custom.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic'
        rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,300,700' rel='stylesheet'
        type='text/css' />
    <link rel="shortcut icon" href="/favicon (2).ico" type="image/x-icon" />
    <link rel="icon" href="/favicon (2).ico" type="image/x-icon" />
    <script type="text/javascript" src="/Scripts/Defaults/modernizr-2.6.2.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


    <!-- ==== BACKGROUND PICTURE ==== -->
    <div id="background">


        <!-- Stuff I need -->
        <!--
                We will need date, time, location and directions to church (plus the address).  
                We will need reception time, location and directions plus address.  
                For the hotel we will add the link they gave us for people to book their rooms and include the address.  
                Once we have our registries, we will add that.  
                We can include one of our engagement pictures. 
            -->

        <!-- ==== DATE INFORMATION ==== -->
        <div id="contentDate">
            <header class="clearfix">
                <h1><span class="/Styles/icon icon-heart"></span></h1>
                <h1>June 6th, 2015</h1>
            </header>
        </div>

        <!-- ==== CHURCH INFORMATION ==== -->
        <div id="contentChurch">
            <h2 style="margin-left: 30px; margin-top: 30px;">Church Information:</h2>
        </div>


        <!-- ==== HOTEL INFORMATION ==== -->
        <div id="contentHotel">
            <h2 style="margin-left: 30px; margin-top: 30px;">Hotel Information:</h2>
            <!-- Responsive iFrame -->
            <div class="Flexible-container" style="margin-left: 30px; margin-top: 10px;">
                <iframe width="425" height="350" frameborder="3" scrolling="no" marginheight="0" marginwidth="0"
                    src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2999.1960532740045!2d-96.07315190000001!3d41.261067!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8793f2ca01ea1c2d%3A0x349f94511f79c83f!2s10220+Regency+Cir%2C+Omaha%2C+NE+68114!5e0!3m2!1sen!2sus!4v1414995564722"></iframe>
            </div>
        </div>

        <!-- ==== PICTURES ==== -->
        <div id="contentPictures">
        </div>

    </div>


</asp:Content>
