<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMasterPage.master" AutoEventWireup="true" CodeFile="addattributes.aspx.cs" Inherits="addattributes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">

    <div style="float: left; margin-left: 10px; width: 780px; margin-top:20px;">
        <div style="float: left; margin-left: 80px;">
            <asp:Button CssClass="showbehaviorandattributebtns" ID="btn_showaddattributes" runat="server" Text="ADD ATTRIBUTES" OnClick="btn_showaddattributes_Click" />
        </div>
        <div style="float: left; margin-left: 10px;">
            <asp:Button CssClass="showbehaviorandattributebtns" ID="btn_showaddbehaviors" runat="server" Text="ADD BEHAVIORS" OnClick="btn_showaddbehaviors_Click" />
        </div>
    </div>
    <div style="float: left; margin-left: 10px; width: 780px;">
        <div style="text-align: center; margin-left: 20%; margin-right: 20%;"  class="allprojectlfirstheadingables">
            <h3>Add New Attributes</h3>
        </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummaryAddAttributes" runat="server" ValidationGroup="attributepage" />
        </div>
        <div style="color: white; float: left; margin-top: 10px; width: 776px;">
            <div style="margin-left: 20%; margin-right: 20%;">
                <h3 style="margin-left: 10px;" class="allprojectlables">
                    <asp:Label ID="lbl_Entity_Name" runat="server">Attributes Name:</asp:Label>
                </h3>
            </div>
            <div style="margin-left: 20%; margin-right: 20%; padding-left: 10px;">
                <asp:TextBox CssClass="allprojecttextbox" ID="tb_attributesname" runat="server" Height="40px" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Attribute name should not be empty!" ControlToValidate="tb_attributesname" ValidationGroup="attributepage" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
            <div style="margin-left: 20%; margin-right: 20%;">
                <h3 style="margin-left: 10px;" class="allprojectlables">
                    <asp:Label ID="Label1" runat="server">Attributes Type:</asp:Label>
                </h3>
            </div>
            <div style="color: white; float:left; margin-left: 20%; margin-right: 20%; margin-top: 10px; padding-left:10px; margin-bottom:20px;">
                <asp:DropDownList ID="dl_attributetype" CssClass="allprojecttextbox" runat="server" ForeColor="Black" Height="40px" Width="400px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>String</asp:ListItem>
                    <asp:ListItem>Integer</asp:ListItem>
                    <asp:ListItem>Float</asp:ListItem>
                    <asp:ListItem>Email</asp:ListItem>
                    <asp:ListItem>Date</asp:ListItem>
                    <asp:ListItem>Boolean</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select attribute type!" ForeColor="Red" ControlToValidate="dl_attributetype" ValidationGroup="attributepage">*</asp:RequiredFieldValidator>
            </div>

                <div style="color: white; float:left; margin-left: 20%; margin-right: 20%; padding-left: 10px;">
                    <div>
                        <h3 style="margin-left: 2px;" class="allprojectlables">
                            <asp:Label ID="Label2" runat="server">Set Key:</asp:Label>
                        </h3>
                    </div>
                    <div>
                        <asp:RadioButton CssClass="radiobtns" ID="RadioButton_Primary" runat="server" Text="Primary" AutoPostBack="True" GroupName="SetKey" OnCheckedChanged="RadioButton_CheckedChanged" />
                    </div>
                    <div>
                        <asp:RadioButton CssClass="radiobtns" ID="RadioButton_Foreign" runat="server" Text="Foreign" AutoPostBack="True" GroupName="SetKey" OnCheckedChanged="RadioButton_CheckedChanged" />
                    </div>
                    <div>
                        <asp:RadioButton CssClass="radiobtns" ID="RadioButton_Notnull" runat="server" Text="None" AutoPostBack="True" GroupName="SetKey" Checked="True" OnCheckedChanged="RadioButton_CheckedChanged" />
                    </div>
                 </div>


           
            <div style="color: white; float:left; margin-left: 20%; margin-right: 20%; padding-left: 10px;">
             <div>
                <h3 style="margin-left: 2px;" class="allprojectlables">
                    <asp:Label ID="lbl_attributeReference" runat="server" Visible="False">Foreign Key Reference:</asp:Label>
                </h3>
            </div>
                <div>
                  <asp:DropDownList CssClass="allprojecttextbox" ID="ddl_attributesReference" runat="server" Height="40px" Width="400px" DataSourceID="SqlDataSource3" DataTextField="Entity_Name" DataValueField="Entity_Name" Visible="False"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:UMLConnectionString %>" SelectCommand="GetEntities" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Label3" Name="ProjectID" PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </div>
             </div>

            <div style="color: white; float:left; margin-left: 20%; margin-right: 20%; margin-top: 20px; margin-bottom:20px; padding-left: 290px;">
                <asp:Button CssClass="projectbtns" ID="btn_addattributes" runat="server" Height="45px" Text="ADD" Width="120px" OnClick="btn_addattributes_Click" ValidationGroup="attributepage"/>
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </div>

             <div style= "margin-left: 20px; margin-right:5%; margin-top: 20px; margin-bottom:20px;">
                <asp:GridView ID="GridView1" CssClass="allprojectlables" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Width="661px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Attribute_Name" HeaderText="Attribute Name" SortExpression="Attribute_Name" />
                        <asp:BoundField DataField="Attribute_Type" HeaderText="Attribute Type" SortExpression="Attribute_Type" />
                        <asp:BoundField DataField="Attribute_Key" HeaderText="Key" SortExpression="Attribute_Key" />
                        <asp:BoundField DataField="Attribute_FK_Reference" HeaderText="FK Reference" SortExpression="Attribute_FK_Reference" />
                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                        <asp:CommandField ShowSelectButton="True" HeaderText="Select" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UMLConnectionString %>" SelectCommand="GetData" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label4" Name="EntityId" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>

</asp:Content>

