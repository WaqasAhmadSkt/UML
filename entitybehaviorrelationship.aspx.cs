using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

public partial class entitybehaviorrelationship : System.Web.UI.Page
{
    public int Foreign_Key;

   // private string connectionString = @"Data Source=VICKY;Initial Catalog=UML;Integrated Security=True";

    private string finalString = "";

    private string relationshipFinalString = "";

    private List<int> ids = new List<int>();

    private List<string> entities = new List<string>();

    private List<string> attributesSections = new List<string>();

    private List<string> BehaviorsSections = new List<string>();

    private List<string> packages = new List<string>();

    private List<string> ERDpackages = new List<string>();

    private List<SqlDataReader> readers = new List<SqlDataReader>();

    private List<SqlCommand> commands = new List<SqlCommand>();

    private List<string> relationship = new List<string>();

    private string ClassDiagram;

    private int entityID;

    private int ProjectID;

    protected void Page_Load(object sender, EventArgs e)
    {
        ProjectID = Convert.ToInt16(Session["ProjectID"]);
        Label4.Text = ProjectID.ToString();
        Label4.Visible = false;
        Label3.Text = "0";
        Label3.Visible = false;
        GridView1.DataBind();
       // dl_from.DataBind(); 
        //dl_to.DataBind();
    }
    protected void btn_addentitybehaviorrelationship_Click(object sender, EventArgs e)
    {
       SqlConnection ObjConnection = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
        ObjConnection.Open();
        string StringCmnd = @"Select Entity.Entity_ID From [dbo].[Entity] WHERE [Entity_Name] ='" + dl_from.Text + "'";
        SqlCommand SqlCmnd = new SqlCommand(StringCmnd, ObjConnection);
        SqlDataReader myDataReader = SqlCmnd.ExecuteReader();
        if (myDataReader.HasRows)
        {
            myDataReader.Read();
            entityID = Convert.ToInt16(myDataReader[0]);
            Label3.Text = entityID.ToString();
            ObjConnection.Close();
        }

        string RelationshipName = "";
        string StringCmnd1 = "";
        // Send data to the relationship table


        // Set Relationship when relation as Unary Association
        if (dl_type.Text == "One to One" && dl_As.Text == "Unary Association")
        {
            RelationshipName = "1->1";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";

        }
        else if (dl_type.Text == "One to Many" && dl_As.Text == "Unary Association")
        {
            RelationshipName = "1->*";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        else if (dl_type.Text == "Many to One" && dl_As.Text == "Unary Association")
        {
            RelationshipName = "*->1";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        else if (dl_type.Text == "Many to Many" && dl_As.Text == "Unary Association")
        {
            RelationshipName = "*->*";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }


        // Set Relationship when relation as Binary Association
        else if (dl_type.Text == "One to One" && dl_As.Text == "Binary Association")
        {
            RelationshipName = "1-1";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";

        }
        else if (dl_type.Text == "One to Many" && dl_As.Text == "Binary Association")
        {
            RelationshipName = "1-*";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        else if (dl_type.Text == "Many to One" && dl_As.Text == "Binary Association")
        {
            RelationshipName = "*-1";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        else if (dl_type.Text == "Many to Many" && dl_As.Text == "Binary Association")
        {
            RelationshipName = "*-*";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }



        // Set Relationship when relation as Aggregation
        else if (dl_type.Text == "One to One" && dl_As.Text == "Aggregation")
        {
            RelationshipName = "1o->1";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";

        }
        else if (dl_type.Text == "One to Many" && dl_As.Text == "Aggregation")
        {
            RelationshipName = "1o->*";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        else if (dl_type.Text == "Many to One" && dl_As.Text == "Aggregation")
        {
            RelationshipName = "*o->1";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        else if (dl_type.Text == "Many to Many" && dl_As.Text == "Aggregation")
        {
            RelationshipName = "*o->*";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }



        // Set Relationship when relation as Composition
        else if (dl_type.Text == "One to One" && dl_As.Text == "Composition")
        {
            RelationshipName = "1+-1";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";

        }
        else if (dl_type.Text == "One to Many" && dl_As.Text == "Composition")
        {
            RelationshipName = "1+-*";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        else if (dl_type.Text == "Many to One" && dl_As.Text == "Composition")
        {
            RelationshipName = "*+-1";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        else if (dl_type.Text == "Many to Many" && dl_As.Text == "Composition")
        {
            RelationshipName = "*+-*";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }



        // Set Relationship when relation as Generalization
        else if (dl_type.Text == "One to One" && dl_As.Text == "Generalization")
        {
            RelationshipName = "1-:>1";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";

        }
        else if (dl_type.Text == "One to Many" && dl_As.Text == "Generalization")
        {
            RelationshipName = "1-:>*";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        else if (dl_type.Text == "Many to One" && dl_As.Text == "Generalization")
        {
            RelationshipName = "*-:>1";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        else if (dl_type.Text == "Many to Many" && dl_As.Text == "Generalization")
        {
            RelationshipName = "*-:>*";
            StringCmnd1 = @"INSERT INTO [dbo].[Relationship]
           ([Relationship_Name]
           ,[Relationship_To]
           ,[Relationship_From]
           ,[Entity_ID]
           ,[Relationship_Type])
     VALUES
           ('" + RelationshipName + "','" + dl_from.Text + "' , '" + dl_to.Text + "' , '" + entityID + "','" + tb_name.Text + "')";
        }
        SqlConnection ObjConnection1 = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
        ObjConnection1.Open();
        SqlCommand ObjCmnd1 = new SqlCommand(StringCmnd1, ObjConnection1);
        ObjCmnd1.ExecuteNonQuery();
        ObjConnection1.Close();
        string myScriptValue = " { swal('Done', 'Relationship is Added', 'success');}";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
        GridView1.DataBind();
    }
    protected void btn_showaddattributes_Click(object sender, EventArgs e)
    {
        Response.Redirect("addattributes.aspx");
    }
    protected void btn_showaddbehaviors_Click(object sender, EventArgs e)
    {
        Response.Redirect("addbehaviors.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}