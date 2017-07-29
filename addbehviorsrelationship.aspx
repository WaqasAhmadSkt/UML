<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMasterPage.master" AutoEventWireup="true" CodeFile="addbehviorsrelationship.aspx.cs" Inherits="addbehviorsrelationship" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div style="float: left; margin-left: 10px; width: 780px; margin-top: 20px;">
        <div style="float: left; margin-left: 80px;">
            <asp:Button CssClass="showbehaviorandattributebtns" ID="btn_showaddattributes" runat="server" Text="ADD ATTRIBUTES" OnClick="btn_showaddattributes_Click" />
        </div>
        <div style="float: left; margin-left: 10px;">
            <asp:Button CssClass="showbehaviorandattributebtns" ID="btn_showaddbehaviors" runat="server" Text="ADD BEHAVIORS" OnClick="btn_showaddbehaviors_Click" />
        </div>
    </div>
    <div style="float: left; margin-left: 10px; width: 780px;">
                <div style="text-align: center;" class="allprojectlfirstheadingables">
                    <h3>Add Behaviors to Behaviors Relationship</h3>
                </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="behaviorrelationshippage" />
        </div>
        <div style="float: left; width:250px;">
            <div style="float:left;">
                <div>
                    <h3 class="allprojectlables">
                        <asp:Label ID="lbl_behavior1" runat="server">Behavior:</asp:Label>
                    </h3>
                </div>
                <div>
                    <asp:TextBox CssClass="allprojecttextbox" ID="tb_behavior1" runat="server" Height="35px" Width="200px"></asp:TextBox>
                </div>
            </div>
        </div>
             <div style="float:left; width:250px;" class="allprojectlables">
                <div>
                    <h3 class="allprojectlables">
                        <asp:Label ID="Label1" runat="server">Type:</asp:Label>
                    </h3>
                </div>
                <div>
                    <asp:DropDownList CssClass="allprojecttextbox" ID="BehaviorTypeDropDownList" runat="server" Height="35px" Width="200px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Include</asp:ListItem>
                        <asp:ListItem>Extend</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="BehaviorTypeDropDownList" ValidationGroup="behaviorrelationshippage" Display="Dynamic" ErrorMessage="Please Select Relationship Type(E.g: Include, Extend etc)" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </div>
            </div>
        <div style="float: left; width:250px;">
            <div>
                <h3 class="allprojectlables">
                    <asp:Label ID="lbl_behavior2" runat="server">Behavior:</asp:Label>
                </h3>
            </div>
            <div>
                <asp:TextBox CssClass="allprojecttextbox" ID="tb_behavior2" runat="server" Height="35px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_behavior2" ValidationGroup="behaviorrelationshippage" ErrorMessage="Please add behavior!" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
         </div>

                <div style="float: left; padding-left:580px; margin-top: 93px; margin-bottom: 20px; width:760px;">
                    <asp:Button CssClass="projectbtns" ID="btn_addbehaviorsrelationship" runat="server" Height="45px" Text="ADD" Width="120px" OnClick="btn_addbehaviorsrelationship_Click" ValidationGroup="behaviorrelationshippage" />
                    <br />
                    <asp:Label CssClass="allprojectlables" ID="Label2" runat="server" Text="Label"></asp:Label>
                    <asp:Label CssClass="allprojectlables" ID="Label3" runat="server" Text="Label"></asp:Label>
                </div>
        <div style="margin-bottom:20px;">
            <asp:GridView CssClass="allprojectlables" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Width="665px">
                <Columns>
                    <asp:BoundField DataField="Behavior_Name" HeaderText="Behavior_Name" SortExpression="Behavior_Name" />
                    <asp:BoundField DataField="Behavior_Type" HeaderText="Behavior_Type" SortExpression="Behavior_Type" />
                    <asp:BoundField DataField="Behavior_As" HeaderText="Behavior_As" SortExpression="Behavior_As" />
                    <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:UMLConnectionString %>" SelectCommand="GetBehaviorsRelationship" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label3" Name="EntityId" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>


    </div>
</asp:Content>

