<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMasterPage.master" AutoEventWireup="true" CodeFile="addnewentity.aspx.cs" Inherits="addnewentity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div style="float: left; margin-left: 10px; width: 780px; margin-top: 10px;">
        <div style="text-align: center; margin-left: 20%; margin-right: 20%;" class="allprojectlfirstheadingables">
            <h1>Add New Entity</h1>

        </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="entitypage" />
        </div>
        <div style="float: left; margin-top:30px; width:776px;">
            <div style="margin-left:20%; margin-right:20%;">
                <h3 style="margin-left:10px;" class="allprojectlables">
                    <asp:Label ID="lbl_Entity_Name" runat="server">Entity Name:</asp:Label>
                </h3>
            </div>

            <div style="margin-left:20%; margin-right:20%; margin-top:10px; padding-left:10px;">
                <asp:TextBox CssClass="allprojecttextbox" ID="tb_entityname" runat="server" Height="50px" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_entityname" ValidationGroup="entitypage" Display="Dynamic" ErrorMessage="Entity name should not be empty!" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
            <div style="margin-left:20%; margin-right:20%; margin-top:20px; padding-left:290px;">
                <asp:Button CssClass="projectbtns" ID="btn_addentity" runat="server" Height="45px" Text="ADD" Width="120px" OnClick="btn_addentity_Click" ValidationGroup="entitypage"/>
                <asp:Label CssClass="allprojectlables" ID="Label4" runat="server"></asp:Label>
            </div>
            <div style="margin-left:40px; margin-top:10px;" class="allprojectlables">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="517px">
                    <Columns>
                        <asp:BoundField DataField="Entity_Name" HeaderText="Entity_Name" SortExpression="Entity_Name" />
                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                        <asp:CommandField ShowSelectButton="True" HeaderText="Select" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UMLConnectionString %>" SelectCommand="GetEntities" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label4" Name="ProjectID" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
            </div>
        </div>
    </div>

</asp:Content>

