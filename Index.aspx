﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Carousel -->
    <div id="carousel-example-generic" class="carousel slide carousel-fade" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target='#carousel-example-generic' data-slide-to='0' class='active'>
                <asp:Image ID="Image1" runat="server" ImageUrl="img/12.jpg"
                    Width="50px" Height="50px" CssClass="img-circle" /></li>
            <li data-target='#carousel-example-generic' data-slide-to='1'>
                <asp:Image ID="Image2" runat="server" ImageUrl="img/13.jpg"
                    Width="50px" Height="50px" CssClass="img-circle" /></li>
          
            <li data-target='#carousel-example-generic' data-slide-to='2'>
                <asp:Image ID="Image3" runat="server" ImageUrl="img/14.jpg"
                    Width="50px" Height="50px" CssClass="img-circle" /></li>
        </ol>
        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active one">
                <!-- <img src="#" alt="" /> -->
                <div class="main-text hidden-xs">
                    <div class="col-md-12 text-center">
                        <h1>
                            Arise! Awake! and don't stop until you reached your goal.<br /> <span class="yellow">- Auto UML Team </span></h1>
                        <div class="">
                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Login</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Registration</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
            <div class="item two">
                <div class="main-text hidden-xs">
                    <div class="col-md-12 text-center">
                        <h1>
                            A <b class="yellow">Goal</b> without <b class="yellow">a plan</b><br />
                            <span class="span">is just a wish</span></h1>
                        <div class="">
                            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">learn More</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink4" runat="server" CssClass="btn btn-clear btn-sm btn-min-block                           ">Download</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
            <div class="item three">
                <div class="main-text hidden-xs">
                    <div class="col-md-12 text-center">
                        <h1>
                            You cannot<b class="yellow"> believe</b> in <b class="yellow">God</b><br />
                            <span class="span">until you believe in yourself.</span></h1>
                        <div class="">
                            <asp:HyperLink ID="HyperLink5" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Android</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink6" runat="server" CssClass="btn btn-clear btn-sm btn-min-block                           ">Apple</asp:HyperLink></div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Controls -->
        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span></a><a class="right carousel-control"
                href="#carousel-example-generic" role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right">
                </span></a>
    </div>
    <!-- Carousel -->
    <!-- Service Section -->
    <section id="services" class="padding100">
        <div class="container">
            <div class="row">
                <h2 class="background double animated wow fadeInUp" data-wow-delay="0.2s"><span><strong>F</strong>eatures</span></h2>
            </div>
            <!-- ./ end row -->
            <div class="row">
                <div class="col-md-4">
                    <i class="fa fa-laptop animated wow fadeInDown"></i>
                    <div class="sc-inner">
                        <h4>
                            Responsive Design</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-support animated wow fadeInDown" data-wow-delay="0.2s"></i>
                    <div class="sc-inner">
                        <h4>
                            Quick Support</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-paper-plane-o animated wow fadeInDown" data-wow-delay="0.4s"></i>
                    <div class="sc-inner">
                        <h4>
                            Mailchimp Newsletter</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
            </div>
            <!-- ./ end row -->
            <div class="row">
                <div class="col-md-4">
                    <i class="fa fa-pie-chart animated wow fadeInUp" data-wow-delay="0.6s"></i>
                    <div class="sc-inner">
                        <h4>
                            Awesome Stats</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-puzzle-piece animated wow fadeInUp" data-wow-delay="0.8s"></i>
                    <div class="sc-inner">
                        <h4>
                            Easy update</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-youtube-play animated wow fadeInUp" data-wow-delay="0.10s"></i>
                    <div class="sc-inner">
                        <h4>
                            Video Support</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
            </div>
            <!-- ./ end row -->
        </div>
        
    </section>
</asp:Content>

