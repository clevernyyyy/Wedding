<%@ Page Title="Wedding" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Wedding._Default" %>

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
    <script type="text/javascript" src="/Scripts/Defaults/jquery-1.10.2.min.js"></script>    
    <script type="text/javascript" src="/Scripts/Site/Parallax.js"></script>
    <script type="text/javascript" src="/Scripts/Site/Maps.js"></script>
    <script type="text/javascript" src="/Scripts/Site/Main.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBIJ0NI0w1Na1FAOqhWt90sndpsRfCmNls"></script>   
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


    <!-- ==== BACKGROUND PICTURE ==== -->
    <div id="background" class="wrapper">
    </div>
    
    <div id="content">
        <!-- ==== DATE INFORMATION ==== -->
        <div id="spacerDate" class="col-lg-5 spacer"></div>
        <div id="contentDate" class="col-lg-6 info info1">
            <header class="clearfix">
                <img src="img/Menu/Wedding-alpha.png" style="max-width: 50%; height: auto;" />
                <h1>June 6th, 2015</h1>
            </header>
        </div>

        <!-- ==== CHURCH INFORMATION ==== -->
        <div id="spacerChurch" class="col-lg-5 spacer"></div>
        <div id="contentChurch" class="col-lg-6 info info2">
            <h1 style="margin-top: 30px;">Church</h1>
            <p>We are getting married at <a href="http://www.stgerald.org/">St. Gerald's Church</a> at 2:00 pm.</p>
            <div id="mapChurch" class="panel-group" runat="server">
                <button id="viewMapChurch" class="btn btn-primary">View Map</button>
                <div id="mapCanvasChurch"  style="width:80%; height:500px; margin-left:80px;"></div>
                <div id="addressChurch" style="background:white; border:2px solid black; width:180px; padding: 8px 0px 8px 0px; font-size:14px;">
                        St. Gerald's Catholic Church
                        <br />
                        9602 Q. St
                        <br />
                        (96th and Q. Street)
                        <br />
                        Omaha, NE
                </div>
             </div>
        </div>

        <!-- ==== RECEPTION INFORMATION ==== -->
        <div id="spacerReception" class="col-lg-5 spacer"></div>
        <div id="contentReception" class="col-lg-6 info info3">
            <h1 style="margin-top: 30px;">Reception</h1>
            <p>Our reception will be following our wedding at <a href="http://arborhallomaha.com/">Arbor Hall</a> at 5:00 pm.</p>
            <div id="mapReception" class="panel-group" runat="server">
                <button id="viewMapReception" class="btn btn-primary">View Map</button>
                <div id="mapCanvasReception"  style="width:80%; height:500px; margin-left:80px;"></div>
                <div id="addressReception" style="background:white; border:2px solid black; width:180px; padding: 8px 0px 8px 0px; font-size:14px;">
                        Arbor Hall
                        <br />
                        14040 Arbor Street
                        <br />
                        (140th and Center)
                        <br />
                        Omaha, NE
                </div>
             </div>
        </div>

        <!-- ==== HOTEL INFORMATION ==== -->
        <div id="spacerHotel" class="col-lg-5 spacer"></div>
        <div id="contentHotel" class="col-lg-6 info info4">
            <h1 style="margin-top: 30px;">Hotel</h1>
            <p>For our out-of-town guests we have reserved a block of 
                <br />
                rooms at 
                <a href="http://www.marriott.com/meeting-event-hotels/group-corporate-travel/groupCorp.mi?resLinkData=Morrissey%20-%20Schaal%20Wedding%5Eomawe%60MSWMSWA%60104.00%60USD%60false%605/30/15%606/8/15%605/15/15&app=resvlink&stop_mobi=yes">
                    Regency Marriott</a>.  To get our reserved rate click 
                <a href="http://www.marriott.com/meeting-event-hotels/group-corporate-travel/groupCorp.mi?resLinkData=Morrissey%20-%20Schaal%20Wedding%5Eomawe%60MSWMSWA%60104.00%60USD%60false%605/30/15%606/8/15%605/15/15&app=resvlink&stop_mobi=yes">
                    here</a>.
                <br />
                The hotel will have a complimentary shuttle to-and-from Arbor Hall.
            </p>
            <div id="mapHotel" class="panel-group" runat="server">
                <button id="viewMapHotel" class="btn btn-primary">View Map</button>
                <div id="mapCanvasHotel"  style="width:80%; height:500px; margin-left:80px; "></div>
                <div id="addressHotel" style="background:white; border:2px solid black; width:180px; padding: 8px 0px 8px 0px; font-size:14px;">
                        Regency Marriott
                        <br />
                        10220 Regency Circle
                        <br />
                        (102nd and Regency)
                        <br />
                        Omaha, NE
                </div>
             </div>
        </div>

        <!-- ==== REGISTRY INFO ==== -->
        <%--<div id="regScroll" class="info55" style="margin-bottom:45px;"></div>--%>
        <div id="spacerRegistry" class="col-lg-5 spacer"></div>
        <div id="contentRegistry" class="col-lg-6 info info5" style="margin-bottom:800px;">
            <h1 style="margin-top: 30px;">Registry</h1>
            <div id="contentRegistryLinks" class="registryLinks">
                <h2>Click on the logo below to be taken to our registry!</h2>
                <span id="bedBathBeyondLink" class="pointer">
                    <img src="img/PersonalPictures/Registries/BedBathAndBeyondLogo.jpg" 
                        style="max-width: 40%; margin-left:20px; margin-top:25px; height: auto;" />
                </span>
                <span id="targetLink" class="pointer">
                    <img src="img/PersonalPictures/Registries/TargetLogo.jpeg" style="max-width: 40%; height: auto;" />
                </span>
            </div>
        </div>

        <!-- ==== PICTURES ==== -->
<%--        <div id="spacerPictures" class="col-lg-5 spacer"></div>
        <div id="contentPictures" class="col-lg-6 info info6">
            <h1 style="margin-top: 30px;">Pictures</h1>
            <!-- slideshow -->
		    <div id="Masthead">&nbsp;</div>
		    <div id="OuterContainer">
			    <div id="Container">
				    <div id="LinkContainer">
				        <a href="#" id="PrevLink" title="Previous Photo"><span>Previous</span></a>
				        <a href="#" id="NextLink" title="Next Photo"><span>Next</span></a>
			        </div>
			        <div id="Loading"><img src="/Slideshow/img/loading_animated2.gif" width="48" height="47" alt="Loading..." /></div>
			    </div>
		    </div>
		
		    <div id="CaptionContainer">
		        <p><span id="Counter">&nbsp;</span> <span id="Caption">&nbsp;</span></p>
		    </div>
        </div>--%>

</asp:Content>
