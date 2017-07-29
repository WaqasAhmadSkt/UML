<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMasterPage.master" AutoEventWireup="true" CodeFile="showUMLdiagramsbtn.aspx.cs" Inherits="showUMLdiagramsbtn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <div style="float: left; margin-left: 10px; width: 780px; margin-top: 20px;">
        <div style="float: left; margin-left:20px;">
        <asp:Button CssClass="showUMLdaigrambtns" ID="btn_class" runat="server" Text="CLASS" OnClick="btn_addattributes_Click" />
        </div>
        <div style="float: left; margin-left:10px;" class="showUMLdaigrambtns">
        <asp:Button CssClass="showUMLdaigrambtns" ID="btn_usecase" runat="server" Text="USECASE" OnClick="btn_usecase_Click" />
        </div>
        <div style="float: left; margin-left:10px;" class="showUMLdaigrambtns">
        <asp:Button CssClass="showUMLdaigrambtns" ID="btn_object" runat="server" Text="OBJECT" OnClick="btn_object_Click" />
        </div>
        <div style="float: left; margin-left:10px;" class="showUMLdaigrambtns">
        <asp:Button CssClass="showUMLdaigrambtns" ID="btn_ERD" runat="server" Text="ERD" OnClick="btn_ERD_Click" />
        </div>

        <div style="margin-top:20%; margin-left:10%;">
            <asp:TextBox ID="TextBox1" runat="server" Height="197px" TextMode="MultiLine" Width="467px" BackColor="Black" ForeColor="White"></asp:TextBox>
            <br />
             <div class="allprojectlables">
                 <asp:Label  ID="Label1" runat="server" Text="Label"></asp:Label>
                 <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                 <asp:TextBox ID="TextBox2" runat="server" Height="200px" TextMode="MultiLine" Width="400px"></asp:TextBox>
             </div>
        </div>
         <div style="border:solid 1px black">
                    <canvas id="mycanvas" width="500" height="300"></canvas>
                    <script type="text/javascript">
                        // var source = document.getElementById('TextBox1').toString;
                        //   var source = '[nomnoml] is -> [awesome]';

                        // var source = "[<actor>hello]";
                        //  var canvas = document.getElementById('mycanvas');
                        //  nomnoml.draw(mycanvas, source);
                        var eventText = document.getElementById('<%=TextBox2.ClientID%>').value;
                        var canvas = document.getElementById('mycanvas');
                        nomnoml.draw(mycanvas, eventText);

                    </script>
                </div>
    </div>
    
</asp:Content>

