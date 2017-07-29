<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMasterPage.master" AutoEventWireup="true" CodeFile="CreateSqlTables.aspx.cs" Inherits="showUMLdiagramsbtn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <div style="float: left; margin-left: 10px; width: 780px; margin-top: 20px;">
        <div style="float: left; margin-left:20px;">
        <asp:Button CssClass="projectbtns" ID="btn_create_sql" runat="server" Text="CREATE SQL" Height="50px" Width="175px" OnClick="btn_addattributes_Click" />
        </div>

        <div style="margin-top:20%; margin-left:10%;">
            <asp:TextBox ID="TextBox1" runat="server" Height="197px" TextMode="MultiLine" Width="467px" BackColor="Black" ForeColor="White"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>

