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

public partial class addbehaviors : System.Web.UI.Page
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

    private int entityID;

    protected void Page_Load(object sender, EventArgs e)
    {
        entityID = Convert.ToInt16(Session["entityID"]);
        Label6.Text = entityID.ToString();
        Label6.Visible = false;
        GridView1.DataBind();
    }
    protected void btn_addbehaviors_Click(object sender, EventArgs e)
    {
        if (tb_addbehaviors.Text.Length >= 1)
        {
            // select the behavior names of a specific entity to check the repeatation of data
            SqlConnection ObjConnection2 = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
            ObjConnection2.Open();
            string StringCmnd2 = @"SELECT Behavior.Behavior_Name FROM Behavior WHERE Behavior.Behavior_Name = '" + tb_addbehaviors.Text + "' AND Behavior.Entity_ID ='" + entityID + "'";
            SqlCommand SqlCmnd2 = new SqlCommand(StringCmnd2, ObjConnection2);
            SqlDataReader myDataReader2 = SqlCmnd2.ExecuteReader();
            if (myDataReader2.HasRows)
            {
                myDataReader2.Read();
                ObjConnection2.Close();
                tb_addbehaviors.Text = "";
                string myScriptValue = " {sweetAlert('Oops...', 'Behavior is Already Exist in This Entity...!', 'error');}";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
            }


            else
            {
                SqlConnection ObjConnection1 = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
                ObjConnection1.Open();
                string StringCmnd1 = @"INSERT INTO [dbo].[Behavior]
           ([Behavior_Name]
           ,[Entity_ID])
     VALUES
           ('" + tb_addbehaviors.Text + "','" + entityID + "')";
                SqlCommand ObjCmnd1 = new SqlCommand(StringCmnd1, ObjConnection1);
                ObjCmnd1.ExecuteNonQuery();
                ObjConnection1.Close();
                tb_addbehaviors.Text = "";
                string myScriptValue = " { swal('Done', 'Behavior is Added', 'success');}";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
            }
        }
        else
        {
            string myScriptValue = " {sweetAlert('Oops...', 'Behavior Name Should Not Be Empty...!', 'error');}";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
        }
        GridView1.DataBind();
    }
    protected void btn_showaddattributes_Click(object sender, EventArgs e)
    {
        Response.Redirect("addattributes.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string BehaviorName = GridView1.SelectedRow.Cells[0].Text;
        SqlConnection ObjConnection = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
        ObjConnection.Open();
        string StringCmnd = @"Select Behavior.Behavior_ID from Behavior where Behavior.Behavior_Name ='" + BehaviorName + "'AND Behavior.Entity_ID ='" + entityID + "'";
        SqlCommand SqlCmnd = new SqlCommand(StringCmnd, ObjConnection);
        SqlDataReader myDataReader = SqlCmnd.ExecuteReader();
        if (myDataReader.HasRows)
        {
            myDataReader.Read();
            int BehaviorID = Convert.ToInt16(myDataReader[0]);
            ObjConnection.Close();
            Session["BehaviorID"] = BehaviorID;
            Session["BehaviorName"] = BehaviorName;
        }
        Response.Redirect("addbehviorsrelationship.aspx");
    }
    protected void tb_addbehaviors_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btn_showaddbehaviors_Click(object sender, EventArgs e)
    {
        Response.Redirect("addbehaviors.aspx");
    }
    protected void btn_showaddattributes_Click1(object sender, EventArgs e)
    {
        Response.Redirect("addattributes.aspx");
    }
}