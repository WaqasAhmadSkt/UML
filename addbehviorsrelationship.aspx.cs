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

public partial class addbehviorsrelationship : System.Web.UI.Page
{
    public int Foreign_Key;

    private string connectionString = @"Data Source=.;Initial Catalog=UML;Integrated Security=True";

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

    private int behaviorID;

    private int entityID;

    protected void Page_Load(object sender, EventArgs e)
    {
        // get behavior name
        tb_behavior1.Text = Session["BehaviorName"].ToString();

        // get behavior id
        behaviorID = Convert.ToInt16(Session["BehaviorID"]);
        Label2.Text = behaviorID.ToString();
        Label2.Visible = false;

        // get entity id
        entityID = Convert.ToInt16(Session["entityID"]);
        Label3.Text = entityID.ToString();
        Label3.Visible = false;

        GridView1.DataBind();
    }
    protected void btn_addbehaviorsrelationship_Click(object sender, EventArgs e)
    {
        //check that the behavior relationship is already exist or not
        SqlConnection ObjConnection2 = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
        ObjConnection2.Open();
        string StringCmnd2 = @"SELECT Behavior.Behavior_Name, Behavior.Behavior_Type, Behavior.Behavior_As  FROM Behavior WHERE Behavior.Behavior_Name = '"+tb_behavior1.Text+"'AND Behavior.Behavior_Type = '"+BehaviorTypeDropDownList.Text+"' AND Behavior.Behavior_As = '"+tb_behavior2.Text+"'";
        SqlCommand SqlCmnd2 = new SqlCommand(StringCmnd2, ObjConnection2);
        SqlDataReader myDataReader2 = SqlCmnd2.ExecuteReader();
        if (myDataReader2.HasRows)
        {
            myDataReader2.Read();
            string myScriptValue = " {sweetAlert('Oops...', 'The Behavior Relationship You Entered is Already Exist' , 'error');}";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
            tb_behavior2.Text = "";
            ObjConnection2.Close();
        }
        else
        {
            SqlConnection ObjConnection1 = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
            ObjConnection1.Open();
            string StringCmnd1 = @"UPDATE [dbo].[Behavior] SET Behavior_Type = '" + BehaviorTypeDropDownList.Text + "' , Behavior_As = '" + tb_behavior2.Text + "' WHERE Behavior_Name = '" + tb_behavior1.Text + "' AND Behavior_ID = '" + behaviorID + "'";
            SqlCommand ObjCmnd1 = new SqlCommand(StringCmnd1, ObjConnection1);
            ObjCmnd1.ExecuteNonQuery();
            ObjConnection1.Close();
            tb_behavior2.Text = "";
            GridView1.DataBind();
            string myScriptValue = " { swal('Done', 'Behavior Relationship is Added', 'success');}";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
        }
       
    }
    protected void btn_showaddattributes_Click(object sender, EventArgs e)
    {
        Response.Redirect("addattributes.aspx");
    }
    protected void btn_showaddbehaviors_Click(object sender, EventArgs e)
    {
        Response.Redirect("addbehaviors.aspx");
    }
}