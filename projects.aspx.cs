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
using System.ComponentModel;

public partial class projects : System.Web.UI.Page
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
        
        // For List View 
        /* DataTable dt = new DataTable();
         SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");

         string stringcmnd = @"SELECT [Project_Name] FROM [dbo].[Project]";
         SqlCommand cmnd = new SqlCommand(stringcmnd, con);
         SqlDataAdapter da = new SqlDataAdapter(cmnd);
         con.Open();
         da.Fill(dt);
         con.Close();
         ListView_Projects.DataSource = dt;
         ListView_Projects.DataBind(); */

        UserID = Convert.ToInt16(Session["GetUSerID"]);
        Label1.Text = UserID.ToString();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        string projectname = GridView1.SelectedRow.Cells[0].Text;
        SqlConnection ObjConnection = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
        ObjConnection.Open();
        string StringCmnd = @"Select Project.Project_ID From [dbo].[Project] WHERE [Project_Name] ='" + projectname + "'";
        SqlCommand SqlCmnd = new SqlCommand(StringCmnd, ObjConnection);
        SqlDataReader myDataReader = SqlCmnd.ExecuteReader();
        if (myDataReader.HasRows)
        {
            myDataReader.Read();
            int projectID = Convert.ToInt16(myDataReader[0]);
            ObjConnection.Close();
            Session["ProjectID"] = projectID;
        }
        Response.Redirect("mainform.aspx");
    }
}