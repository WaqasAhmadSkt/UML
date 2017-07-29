<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="contact padding100">
        <div class="container">
            <div class="row">
                <div class="col-md-7">
                    <div id="main-contact-form" class="contact-form">
                        <!-- form -->
                        <form role="form" action="contact.php" method="post">
                        <div class="form-group">
                            <label class="sr-only" for="contact-name">
                                Name</label>
                            <input type="text" name="name" placeholder="Name..." class="contact-name form-control"
                                id="contact-name">
                        </div>
                        <div class="form-group">
                            <label class="sr-only" for="contact-email">
                                Email</label>
                            <input type="text" name="email" placeholder="Email..." class="contact-email form-control"
                                id="contact-email">
                        </div>
                        <div class="form-group">
                            <label class="sr-only" for="contact-subject">
                                Subject</label>
                            <input type="text" name="subject" placeholder="Subject..." class="contact-subject form-control"
                                id="contact-subject">
                        </div>
                        <div class="form-group">
                            <label class="sr-only" for="contact-message">
                                Message</label>
                            <textarea name="message" placeholder="Message..." class="contact-message form-control"
                                id="contact-message" style="height: 150px"></textarea>
                        </div>
                        <button type="submit" class="btn btn-success">
                            Send message</button>
                        </form>
                        <!-- ./form -->
                    </div>
                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

