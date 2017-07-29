using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

public partial class createproject : System.Web.UI.Page
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

    private int UserID;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserID = Convert.ToInt16(Session["GetUSerID"]);
    }
    protected void btn_Create_Click(object sender, EventArgs e)
    {
        if (tb_Create.Text.Length >= 1)
        {
            // check weather the project is already exist or not
            SqlConnection ObjConnection2 = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
            ObjConnection2.Open();
            string StringCmnd2 = @"SELECT Project.Project_Name FROM Project WHERE Project.Project_Name = '" + tb_Create.Text + "' AND Project.User_ID = '" + UserID + "'";
            SqlCommand SqlCmnd2 = new SqlCommand(StringCmnd2, ObjConnection2);
            SqlDataReader myDataReader2 = SqlCmnd2.ExecuteReader();
            if (myDataReader2.HasRows)
            {
                myDataReader2.Read();
                string myScriptValue = " {sweetAlert('Oops...', 'The Project You Entered is Already Exist. Please Try Different Name' , 'error');}";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
                tb_Create.Text = "";
                ObjConnection2.Close();
            }
            else
            {
                SqlConnection ObjConnection = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
                ObjConnection.Open();
                string StringCmnd = @"INSERT INTO [dbo].[Project]
           ([Project_Name]
           ,[User_ID])
            VALUES
           ('" + tb_Create.Text + "', '" + UserID + "')";
                SqlCommand ObjCmnd = new SqlCommand(StringCmnd, ObjConnection);
                ObjCmnd.ExecuteNonQuery();
                string myScriptValue1 = " { swal('Here is a message!', 'It's pretty, is not it');}";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue1, true);
                ObjConnection.Close();
                tb_Create.Text = "";
               // showsuccessms();
                Response.Redirect("projects.aspx");
            }
            
        }
        else
        {
            string myScriptValue = " {sweetAlert('Oops...', 'Project Name Should Not Be Empty...!', 'error');}";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
        }
        }

    protected void showsuccessms()
    {
        string myScriptValue = " { swal('Done', 'Project is Added', 'success');}";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
    }
        
       /* SqlConnection con = new SqlConnection("Data Source=DESKTOP-0TKBN92;Initial Catalog=Registration;Integrated Security=True");
        con.Open();
        string stringcmnd = @"INSERT INTO [dbo].[Create_Project]
    ([Name])
     VALUES('" + tb_Create.Text + "')";
        SqlCommand cmnd = new SqlCommand(stringcmnd, con);
        cmnd.ExecuteNonQuery();
        con.Close();
        Label1.Text = "Project Created Successful!";*/
        
    }