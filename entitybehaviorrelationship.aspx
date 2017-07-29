<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMasterPage.master" AutoEventWireup="true" CodeFile="entitybehaviorrelationship.aspx.cs" Inherits="entitybehaviorrelationship" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <div style="float: left; margin-left: 10px; width: 780px; margin-top: 20px;">
        <div style="float: left; margin-left: 80px;">
            <asp:Button CssClass="showbehaviorandattributebtns" ID="btn_showaddattributes" runat="server" Text="ADD ATTRIBUTES" OnClick="btn_showaddattributes_Click" />
        </div>
        <div style="float: left; margin-left: 10px;">
            <asp:Button CssClass="showbehaviorandattributebtns" ID="btn_showaddbehaviors" runat="server" Text="ADD BEHAVIORS" OnClick="btn_showaddbehaviors_Click" />
        </div>
    </div>
    <div style="float: left; margin-left: 35px; width: 780px;">
                <div style="text-align: center; margin-top:50px; margin-bottom:30px;" class="allprojectlfirstheadingables">
                    <h3>Add Entity to Behaviors Relationship</h3>
                </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="entityrelationshippage"/>
        </div>
        <div style="float: left; width:140px;">
            <div style="float:left;">
                <div>
                    <h3 class="allprojectlables">
                        <asp:Label ID="lbl_FROM" runat="server">FROM:</asp:Label>
                    </h3>
                </div>
                <div>
                    <div class="allprojectlables">
                    <asp:DropDownList CssClass="allprojecttextbox" ID="dl_from" runat="server" Height="35px" Width="135px" DataSourceID="SqlDataSource2" DataTextField="Entity_Name" DataValueField="Entity_Name">
                        <asp:ListItem>From...</asp:ListItem>
                    </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UMLConnectionString %>" SelectCommand="GetEntities" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="Label4" Name="ProjectID" PropertyName="Text" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                </div>
                </div>
            </div>
        </div>
        <div style="float:left; width:140px;">
                <div>
                    <h3 class="allprojectlables">
                        <asp:Label ID="Label2" runat="server">Name:</asp:Label>
                    </h3>
                </div>
                <div>
                    <asp:TextBox CssClass="allprojecttextbox" ID="tb_name" runat="server" Height="35px" Width="135px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please add the relarionship name(E.g: Has, Have)" ControlToValidate="tb_name" ValidationGroup="entityrelationshippage" ForeColor="Red" SetFocusOnError="True" Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>
             <div style="float:left; width:140px;">
                <div>
                    <h3 class="allprojectlables">
                        <asp:Label ID="Label1" runat="server">Type:</asp:Label>
                    </h3>
                </div>
                <div>
                    <asp:DropDownList CssClass="allprojecttextbox" ID="dl_type" runat="server" Height="35px" Width="135px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>One to One</asp:ListItem>
                        <asp:ListItem>One to Many</asp:ListItem>
                        <asp:ListItem>Many to One</asp:ListItem>
                        <asp:ListItem>Many to Many</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select relationship type!" ControlToValidate="dl_type" Display="Dynamic" ForeColor="Red" ValidationGroup="entityrelationshippage">*</asp:RequiredFieldValidator>
                </div>
            </div>

        <div style="float:left; width:140px;">
                <div>
                    <h3 class="allprojectlables">
                        <asp:Label ID="Label5" runat="server">As:</asp:Label>
                    </h3>
                </div>
                <div>
                    <asp:DropDownList CssClass="allprojecttextbox" ID="dl_As" runat="server" Height="35px" Width="135px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Unary Association</asp:ListItem>
                        <asp:ListItem>Binary Association</asp:ListItem>
                        <asp:ListItem>Aggregation</asp:ListItem>
                        <asp:ListItem>Composition</asp:ListItem>
                        <asp:ListItem>Generalization</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select relationship as(E.g: association, generalization etc)" ControlToValidate="dl_As" Display="Dynamic" ForeColor="Red" ValidationGroup="entityrelationshippage">*</asp:RequiredFieldValidator>
                </div>
            </div>

        <div style="float: left; width:140px;">
            <div>
                <h3 class="allprojectlables">
                    <asp:Label ID="lbl_TO" runat="server">TO:</asp:Label>
                </h3>
            </div>
            <div>
                <div>
                    <asp:DropDownList CssClass="allprojecttextbox" ID="dl_to" runat="server" Height="35px" Width="135px" DataSourceID="SqlDataSource2" DataTextField="Entity_Name" DataValueField="Entity_Name">
                        <asp:ListItem>To...</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
         </div>

                <div style="float: left; padding-left:580px; margin-top: 20px; margin-bottom: 20px; width:760px;">
                    <asp:Button CssClass="projectbtns" ID="btn_addentitybehaviorrelationship" runat="server" Height="45px" Text="ADD" Width="120px" OnClick="btn_addentitybehaviorrelationship_Click" ControlToValidate="tb_name" ValidationGroup="entityrelationshippage" />
                    &nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </div>

        <div style="margin-left:10%; margin-top:20px; margin-bottom:20px;" class="allprojectlables">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Relationship_To" HeaderText="Relationship_To" SortExpression="Relationship_To" />
                    <asp:BoundField DataField="Relationship_Type" HeaderText="Relationship_Type" SortExpression="Relationship_Type" />
                    <asp:BoundField DataField="Relationship_Name" HeaderText="Relationship_Name" SortExpression="Relationship_Name" />
                    <asp:BoundField DataField="Relationship_From" HeaderText="Relationship_From" SortExpression="Relationship_From" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:UMLConnectionString %>" SelectCommand="GetRelationship" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label3" DefaultValue="" Name="EntityId" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>

    </div>
</asp:Content>

