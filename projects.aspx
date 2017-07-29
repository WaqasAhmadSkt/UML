<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="projects.aspx.cs" Inherits="projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center; background-color: #eaf1f1; margin-top:40px;">
        <div  class="allprojectlfirstheadingables">
             <h1 style="padding-top:60px; text-align:center;">My Projects</h1>
        </div>

            <div style ="margin-left:40%; margin-top:50px;" class="allprojectlables">
            <asp:GridView CssClass="allprojecttextbox" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="400px" Height="90px">
                <Columns>
                    <asp:BoundField DataField="Project_Name" HeaderText="Project Name" SortExpression="Project_Name" >
                    <ItemStyle BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:UMLConnectionString %>" SelectCommand="GetUserProjects" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="UserID" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UMLConnectionString %>" SelectCommand="GetUserProjects" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="UserID" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UMLConnectionString %>" SelectCommand="SELECT * FROM [Project]"></asp:SqlDataSource>
         
        
         <!--  <asp:ListView ID="ListView_Projects" runat="server" >
                <ItemTemplate >
                        <table style="float:left;" >
                           
                            <tr>
                                <td >
                                    <h3 style="color:white;">
                                           <a href="mainform.aspx" style="margin-left:30px;"
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Eval("Project_Name") %>'></asp:LinkButton>
                                            </a>
                                    </h3>
                                </td>
                            </tr>
                            
                        </table>
                </ItemTemplate>
            </asp:ListView> -->
        </div>
</asp:Content>

