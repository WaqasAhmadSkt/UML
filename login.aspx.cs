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

public partial class login : System.Web.UI.Page
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
        if(Session["login"] != null)
        {
            Response.Redirect("projects.aspx");
        }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        SqlConnection ObjConnection2 = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
        ObjConnection2.Open();
        string StringCmnd2 = @"SELECT Registration.Email ,	Registration.Password FROM Registration WHERE Registration.Email = '"+username.Text+"' and Registration.Password = '"+password.Text+"'";
        SqlCommand SqlCmnd2 = new SqlCommand(StringCmnd2, ObjConnection2);
        SqlDataReader myDataReader2 = SqlCmnd2.ExecuteReader();
        if (myDataReader2.HasRows)
        {
            myDataReader2.Read();
            GerUserID();
            Session["login"] = 1;
            Response.Redirect("projects.aspx");
            
        }
        ObjConnection2.Close();
    }


    protected void GerUserID()
    {
        SqlConnection ObjConnection2 = new SqlConnection("Data Source=.;Initial Catalog=UML;Integrated Security=True");
        ObjConnection2.Open();
        string StringCmnd2 = @"SELECT Registration.User_ID FROM Registration WHERE Registration.Email = '" + username.Text + "' and Registration.Password = '" + password.Text + "'";
        SqlCommand SqlCmnd2 = new SqlCommand(StringCmnd2, ObjConnection2);
        SqlDataReader myDataReader2 = SqlCmnd2.ExecuteReader();
        if (myDataReader2.HasRows)
        {
            int UserID;
            myDataReader2.Read();
            UserID = Convert.ToInt16(myDataReader2[0]);
            Session["GetUSerID"] = UserID;
        }
        ObjConnection2.Close();
    }
}