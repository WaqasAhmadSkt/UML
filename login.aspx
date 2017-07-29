<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="padding100">
        <div class="container">
            <div id="loginbox" style="margin-top: 50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-default">
                    <div class="panel-heading panel-heading-custom">
                        <div class="panel-title">
                            Sign In</div>
                    </div>
                    <div style="padding-top: 30px" class="panel-body">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    </div>
                    <div style="padding-top: 30px" class="panel-body">
                        <div style="display: none" id="login-alert" class="alert alert-danger col-sm-12">
                        </div>
                        <div id="loginform" class="form-horizontal" role="form" style="float:left;">
                            <div style="margin-bottom: 25px" class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <asp:TextBox runat="server" ID="username" CssClass="form-control" placeholder="username or email"></asp:TextBox>
                            </div>
                            <div style="float:left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please add user name!" ForeColor="Red" SetFocusOnError="True" ControlToValidate="username" Display="Dynamic">*</asp:RequiredFieldValidator>
                            </div>
                             <div style="margin-bottom: 25px" class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <asp:TextBox runat="server" ID="password" CssClass="form-control" placeholder="password"
                                    TextMode="Password"></asp:TextBox>
                            </div>
                            <div>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please add the password!" ForeColor="Red" SetFocusOnError="True" ControlToValidate="password" Display="Dynamic">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="input-group">
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="CheckBox_Remember_me" runat="server" Text="Remember me" />
                                    </label>
                                </div>
                            </div>
                            <div style="margin-top: 10px" class="form-group">
                                <!-- Button -->
                                <div class="col-sm-12 controls">
                                    <a  href="#"><asp:Button ID="btnlogin" runat="server" Text="Login" CssClass="btn btn-success" OnClick="btnlogin_Click"/></a>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12 control">
                                    <div style="padding-top: 15px; font-size: 85%">
                                        Don't have an account! <a href="signup.aspx" runat="server">
                                            Sign Up Here </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
    </div>
</asp:Content>
