<%@ Page Title="" Language="C#" MasterPageFile="~/SecondMasterPage.master" AutoEventWireup="true" CodeFile="alerts.aspx.cs" Inherits="alerts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    
    
    <div>
    <asp:TextBox ID="TextBox2" runat="server" Height="200px" TextMode="MultiLine" Width="300px"></asp:TextBox>
    </div>

    <div>
    <asp:TextBox ID="TextBox1" runat="server" Height="200px" TextMode="MultiLine" Width="300px"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    
    
    
    <div style="border:solid 1px black">
                <script type="text/javascript">
			    var sb = new StringBuilder();
			    sb.append("String: ");
			    sb.append("blah blah");
			    sb.appendLine("Date: ");
			    sb.append(new Date());
			    sb.appendLine("Number: ");
			    sb.append(17);
			    alert(sb.toString());
		       </script>    
    </div>

</asp:Content>

