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

public partial class addnewentity : System.Web.UI.Page
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

    private int ProjectID;

    protected void Page_Load(object sender, EventArgs e)
    {
        ProjectID = Convert.ToInt16(Session["ProjectID"]);
        Label4.Text = ProjectID.ToString();
        Label4.Visible = false;
    }
    protected void btn_addentity_Click(object sender, EventArgs e)
    {
        if (tb_entityname.Text.Length >= 1)
        {
            // check weather the entity is already exist or not
            SqlConnection ObjConnection2 = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
            ObjConnection2.Open();
            string StringCmnd2 = @"SELECT Entity.Entity_Name FROM Entity WHERE Entity.Entity_Name = '" + tb_entityname.Text + "' AND Entity.Project_ID = '" + ProjectID + "'";
            SqlCommand SqlCmnd2 = new SqlCommand(StringCmnd2, ObjConnection2);
            SqlDataReader myDataReader2 = SqlCmnd2.ExecuteReader();
            if (myDataReader2.HasRows)
            {
                myDataReader2.Read();
                string myScriptValue = " {sweetAlert('Oops...', 'The Entity You Entered is Already Exist' , 'error');}";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
                tb_entityname.Text = "";
                ObjConnection2.Close();
            }

            else
            {
            // add new entity
            SqlConnection ObjConnection = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
            ObjConnection.Open();
            string StringCmnd = @"INSERT INTO [dbo].[Entity]
           ([Entity_Name]
           ,[Project_ID])
            VALUES
           ('" + tb_entityname.Text + "' , '" + ProjectID + "')";
            SqlCommand ObjCmnd = new SqlCommand(StringCmnd, ObjConnection);
            ObjCmnd.ExecuteNonQuery();
            ObjConnection.Close();
            tb_entityname.Text = "";
            string myScriptValue = " { swal('Done', 'Entity is Added', 'success');}";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
            }

        }
        else
        {
            string myScriptValue = " {sweetAlert('Oops...', 'Entity Name Should Not Be Empty...!', 'error');}";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
            
        }
        GridView1.DataBind();
       // Response.Redirect("showattributesbehaviorsbtn.aspx");   
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string entityname = GridView1.SelectedRow.Cells[0].Text;
        SqlConnection ObjConnection = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
        ObjConnection.Open();
        string StringCmnd = @"Select Entity.Entity_ID from Entity where Entity.Entity_Name = '" + entityname + "' AND Entity.Project_ID ='" + ProjectID + "'";
        SqlCommand SqlCmnd = new SqlCommand(StringCmnd, ObjConnection);
        SqlDataReader myDataReader = SqlCmnd.ExecuteReader();
        if (myDataReader.HasRows)
        {
            myDataReader.Read();
            int entityID = Convert.ToInt16(myDataReader[0]);
            ObjConnection.Close();
            Session["entityID"] = entityID;
        }
        Response.Redirect("showattributesbehaviorsbtn.aspx");
    }
}