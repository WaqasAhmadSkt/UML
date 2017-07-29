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


public partial class MasterPage : System.Web.UI.MasterPage
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


    protected void Page_Load(object sender, EventArgs e)
    {
        authentication(sender, e);
    }
    public void authentication(object sender, EventArgs e)
    {
        if(Session["login"] != null)
        {
            login.Visible = false;
            signup.Visible = false;
        }
        else
        {
            profile.Visible = false;
            logout.Visible = false;
            projects.Visible = false;
        }
    }
    public void session_control(object sender, EventArgs e)
    {
        Session["login"] = null;
        Response.Redirect("Index.aspx");
    }

}
