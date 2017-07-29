<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createproject.aspx.cs" Inherits="createproject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center; background-color: #eaf1f1; color:black; height:400px; margin-left:15%; margin-right:15%; margin-top:70px; margin-bottom:20px;">
        <table style="width:100%; margin-top:20px; margin-bottom:20px;">
        <tr>
            <td style="text-align:center; padding-top:40px;" colspan="2"  class="allprojectlfirstheadingables">
                <h1>Create New Project</h1>
            </td>
        </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="createprojectpage"/>
                </td>
            </tr>
        <tr>
            <td></td>
            <td style="width: 664px; text-align:left; padding-left:20px; padding-top:50px;">
                <asp:TextBox CssClass="allprojecttextbox" ID="tb_Create" runat="server" Height="50px" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_Create" ErrorMessage="Please enter the Project Name." ValidationGroup="createprojectpage" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td style="width: 664px; text-align:left; padding-left:260px; padding-top:10px;">
                <asp:Button CssClass="projectbtns" ID="btn_Create" runat="server" Height="41px" Text="Create" Width="111px" OnClick="btn_Create_Click" ValidationGroup="createprojectpage" />
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            </td>
        </tr>
        </table>
    </div>
</asp:Content>

