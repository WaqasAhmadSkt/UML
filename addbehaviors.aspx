<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMasterPage.master" AutoEventWireup="true" CodeFile="addbehaviors.aspx.cs" Inherits="addbehaviors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <div style="float: left; margin-left: 10px; width: 780px; margin-top:20px;">
        <div style="float: left; margin-left: 80px;">
            <asp:Button CssClass="showbehaviorandattributebtns" ID="btn_showaddattributes" runat="server" Text="ADD ATTRIBUTES" OnClick="btn_showaddattributes_Click1" />
        </div>
        <div style="float: left; margin-left: 10px;">
            <asp:Button CssClass="showbehaviorandattributebtns" ID="btn_showaddbehaviors" runat="server" Text="ADD BEHAVIORS" OnClick="btn_showaddbehaviors_Click" />
        </div>
    </div>
    <div style="float: left; margin-left: 10px; width: 780px;">
        <div style="text-align: center; color: white; margin-left: 20%; margin-right: 20%;">
            <h3 class="allprojectlfirstheadingables">Add New Behaviors</h3>
        </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="behaviorpage" />
        </div>
        <div style="color: white; float: left; margin-top: 10px; width: 776px;">
            <div style="margin-left: 20%; margin-right: 20%;">
                <h3 style="margin-left: 10px;" class="allprojectlables">
                    <asp:Label ID="lbl_Entity_Name" runat="server">Add Behavior:</asp:Label>
                </h3>
            </div>
            <div style="margin-left: 20%; margin-right: 20%; padding-left: 10px;">
                <asp:TextBox CssClass="allprojecttextbox" ID="tb_addbehaviors" runat="server" Height="40px" Width="400px" OnTextChanged="tb_addbehaviors_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_addbehaviors" ValidationGroup="behaviorpage" ErrorMessage="Please add behavior!" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>   
            <div style="color: white; float:left; margin-left: 20%; margin-right: 20%; margin-top: 20px; margin-bottom:20px; padding-left: 290px;">
                <asp:Button CssClass="projectbtns" ID="btn_addbehaviors" runat="server" Height="45px" Text="ADD" Width="120px" OnClick="btn_addbehaviors_Click" ValidationGroup="behaviorpage" />
                <asp:Label CssClass="allprojectlables" ID="Label6" runat="server"></asp:Label>
            </div>

            <div style="margin-left:5%; margin-bottom:20px;" class="allprojectlables">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="472px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Behavior_Name" HeaderText="Behavior_Name" SortExpression="Behavior_Name" />
                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                        <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UMLConnectionString %>" SelectCommand="GetBehaviors" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label6" Name="EntityId" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>

</asp:Content>

