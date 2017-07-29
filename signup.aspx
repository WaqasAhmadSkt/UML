<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="padding100">
        <div class="container">
            <div id="signupbox" style=" margin-top: 50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-default">
                    <div class="panel-heading panel-heading-custom">
                        <div class="panel-title">
                            Sign Up</div>
                        <div style="float: right; font-size: 85%; position: relative; top: -10px">
                        </div>
                    </div>
                    <div style="padding-top: 30px" class="panel-body">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    </div>
                    <div class="panel-body">
                        <div id="signupform" class="form-horizontal" role="form">
                           
                            <div class="form-group">
                                <label for="firstname" class="col-md-3 control-label">
                                    First Name</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="FirstNameTextBox" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                                </div>
                                <div>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please add the first name!" ForeColor="Red" SetFocusOnError="True" ControlToValidate="FirstNameTextBox">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="lastname" class="col-md-3 control-label">
                                    Last Name</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="LastNameTextBox" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                                </div>
                                <div>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please add the last name!" ForeColor="Red" SetFocusOnError="True" ControlToValidate="LastNameTextBox">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                             <div class="form-group">
                                <label for="email" class="col-md-3 control-label">
                                    Email</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="EmailTextBox" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
                                </div>
                                 <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please add the email!" ForeColor="Red" SetFocusOnError="True" ControlToValidate="EmailTextBox">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter email in a correct formate! (E.g: abc@xyz.com)" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailTextBox">*</asp:RegularExpressionValidator>
                                 </div>
                            </div>
                            <div class="form-group">
                                <label for="password" class="col-md-3 control-label">
                                    Password</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="PasswordTextBox" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please add the password!" ForeColor="Red" SetFocusOnError="True" ControlToValidate="PasswordTextBox">*</asp:RequiredFieldValidator>
                                </div>
                            </div>    
                            <div class="form-group">
                                <label for="password" class="col-md-3 control-label">
                                    Confirm Password</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="ConfirmPasswordTextBox" CssClass="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                </div>
                                <div>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please add the confirm password!" ForeColor="Red" SetFocusOnError="True" ControlToValidate="ConfirmPasswordTextBox">*</asp:RequiredFieldValidator>
                                   <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="PasswordTextBox" ControlToValidate="ConfirmPasswordTextBox" ErrorMessage="Please enter the same passwords!" ForeColor="Red" SetFocusOnError="True">*</asp:CompareValidator>
                                </div>
                            </div>                       
                            <div class="form-group">
                                <!-- Button -->

                                <div class="col-md-offset-3 col-md-9">
                                  <a  href="#"><asp:Button ID="btnsignup" runat="server" Text="Sign Up" CssClass="btn btn-info" OnClick="btnsignup_Click"/></a>
                                </div>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

