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

public partial class showUMLdiagramsbtn : System.Web.UI.Page
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

    private int projectID;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_addattributes_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        LoadSQLData();
    }

    private void LoadSQLData()
    {
        ProjectID();

        LoadEntityIds();

        LoadEntities();

        LoadSQLAttributes();

        GetSQLPackages();

       // GenerateMsWordDoc();
    }

    // Load the Project ID 
    private void ProjectID()
    {
        projectID = Convert.ToInt16(Session["ProjectID"]);
        Label1.Text = projectID.ToString();
        Label1.Visible = false;
    }

    // Load the Entities IDs
    private void LoadEntityIds()
    {
        using (var con = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetEntityIDS";
                cmd.Parameters.Add("@ProjectID", System.Data.SqlDbType.Int).Value = projectID;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ids.Add(Convert.ToInt32(reader[0]));
                }
            }
        }
    }

    // Load the Entities 
    private void LoadEntities()
    {
        using (var con = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetEntities";
                cmd.Parameters.Add("@ProjectID", System.Data.SqlDbType.Int).Value = projectID;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    entities.Add((reader[0].ToString()));
                }
            }
        }
    }


    // Load the SQL Attributes
    private void LoadSQLAttributes()
    {
        using (var con = new SqlConnection(connectionString))
        {
            con.Open();

            foreach (var item in ids)
            {
                commands.Add(new SqlCommand());

                using (SqlCommand cmd = commands.Last())
                {

                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetData";

                    cmd.Parameters.Add("@EntityId", System.Data.SqlDbType.Int).Value = item;

                    readers.Add(cmd.ExecuteReader());

                    using (SqlDataReader reader = readers.Last())
                    {
                        Boolean empty = true;
                        string attributeSection = "";
                        while (reader.Read())
                        {
                            if (reader["Attribute_Key"].ToString() == "PRIMARY KEY")
                            {
                                attributeSection += "[" + reader[0].ToString() + "] " + "[" + reader[1] + "] " + reader[2] + "\r\n " + ",";
                                empty = false;
                            }

                            else if (reader["Attribute_Key"].ToString() == "FOREIGN KEY")
                            {
                                attributeSection += "[" + reader[0].ToString() + "] " + "[" + reader[1] + "] " + reader[2] + " REFERENCES " + "["+ reader[3] +"]" + "([" + reader[4] + "])" + "\r\n " + ",";
                                empty = false;
                            }

                            else
                            {
                                attributeSection += "[" + reader[0].ToString() + "] " + "[" + reader[1] + "]" + "\r\n " + ",";
                                empty = false;
                            }
                        }

                        if (empty == false)
                        {
                            attributeSection = attributeSection.Substring(0, attributeSection.Length - 2);
                            attributesSections.Add(attributeSection);
                        }
                    }
                }
            }
        }

        commands.Clear();
        readers.Clear();
    }

    private void GetSQLPackages()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            finalString += "CREATE TABLE [dbo].";
            finalString += "[" + entities[i] + "]" + "\r\n";

            finalString += "(" + attributesSections[i] + ")" + "\r\n\r\n";

            ClassDiagram = ClassDiagram + finalString.ToString();
            TextBox1.Text = ClassDiagram;

            finalString = "";
        }
        ClassDiagram = "";
    }

    private void GenerateMsWordDoc()
    {
        string strBody = "<html>" +
            "<body>" +
                "<div>" + TextBox1.Text + "</div>" +
                "</body>" +
            "</html>";
        string fileName = "MsWordSample.doc";
        // You can add whatever you want to add as the HTML and it will be generated as Ms Word docs
        Response.AppendHeader("Content-Type", "application/msword");
        Response.AppendHeader("Content-disposition", "attachment; filename=" + fileName);
        Response.Write(strBody);
    }
  
}