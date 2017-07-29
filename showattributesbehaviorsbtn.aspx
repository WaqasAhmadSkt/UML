<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMasterPage.master" AutoEventWireup="true" CodeFile="showattributesbehaviorsbtn.aspx.cs" Inherits="showattributesbehaviorsbtn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div style="float: left; margin-left: 10px; width: 780px; margin-top: 20px;">
        <div style="float: left; margin-left: 80px;">
            <asp:Button CssClass="showbehaviorandattributebtns" ID="btn_showaddattributes" runat="server" Text="ADD ATTRIBUTES" OnClick="btn_showaddattributes_Click" />
        </div>
        <div style="float: left; margin-left: 10px;">
            <asp:Button CssClass="showbehaviorandattributebtns" ID="btn_showaddbehaviors" runat="server" Text="ADD BEHAVIORS" OnClick="btn_showaddbehaviors_Click" />
        </div>
    </div>
</asp:Content>

