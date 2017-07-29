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

    private string Nomnoml = "";
   // private string  hello= "[nomnoml] is -> [awesome]";
    protected void Page_Load(object sender, EventArgs e)
    { 
    }

    protected void btn_usecase_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";

        ProjectID();

        LoadEntities();

        //LoadPlantUML();

         LoadPackagesFromDB();
       /* string plantStart = @"@startuml
        left to right direction
        skinparam packageStyle rectangle " + "\r\n";

        string plantEnd = @"}
        @enduml";

        string plantMid = @" rectangle {" + "\r\n";

        TextBox1.Text += plantStart;

        foreach (var item in entities)
        {
            TextBox1.Text += "actor " + item + "\r\n";
        }
        TextBox1.Text += plantMid;*/
         TextBox1.Text += "[<frame>;";
        foreach (var item in packages)
        {
           // TextBox1.Text += "[<frame>";
            TextBox1.Text += item + "\r\n";
          //  TextBox1.Text += "]\r\n";
           // TextBox1.Text += "#direction: right";

        }
        TextBox1.Text += "]\r\n";
        TextBox1.Text += "#direction: right \r\n";
        //TextBox1.Text += plantEnd;
        TextBox2.Text = TextBox1.Text;
    }

    // Load data from DB for Generate the Use Case Diagram String for www.nomnoml.com
    private void LoadPackagesFromDB()
    {
        string package = "";

        Boolean empty = true;

        using (var con = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "usp_GetAllRecords";
                cmd.Parameters.Add("@ProjectID", System.Data.SqlDbType.Int).Value = projectID;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Behavior_Type"].ToString() == "Include")
                    {
                        package += "[<actor>" + reader[0].ToString() + "]-[<usecase>" + reader[1].ToString() + "];[<usecase>" + reader[1].ToString() + "]--<<include>>[<usecase>" + reader[3].ToString() + "];[<usecase>" + reader[3].ToString() + "]-[<database> Server];";
                        empty = false;
                    }
                    else if (reader["Behavior_Type"].ToString() == "Extend")
                    {
                        package += "[<actor>" + reader[0].ToString() + "]-[<usecase>" + reader[1].ToString() + "];[<usecase>" + reader[1].ToString() + "]--<<Extend>>[<usecase>" + reader[3].ToString() + "];";
                        empty = false;
                    }
                    else
                    {
                        package += "[<actor>" + reader[0].ToString() + "]-[<usecase>" + reader[1].ToString() + "];";
                        empty = false;
                    }
                }
                if (empty == false)
                {
                    // Label7.Text = attributeSection;
                    package = package.Substring(0, package.Length - 1);
                    packages.Add(package);
                    package = "";
                }

                   
               
            }
        }
    }

    // Load data from DB for Generate the Use Case Diagram String for www.plantuml.com
    private void LoadPlantUML()
    {
        string package = "";

        using (var con = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "usp_GetAllRecords";
                cmd.Parameters.Add("@ProjectID", System.Data.SqlDbType.Int).Value = projectID;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    package += reader[0].ToString() + "--" + "(" + reader[1].ToString() + ")";

                    packages.Add(package);

                    package = "";
                }
            }
        }
    }
    protected void btn_object_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        LoadDataForObjectDiagram();
    }

    private void LoadDataForObjectDiagram()
    {
        ProjectID();

        LoadEntityIds();

        LoadEntities();

        LoadAttributes();

        LoadRelationship();

        GetPackagesForObjectDiagram();
    }

    // Load Get Packages for Object Diagram
    private void GetPackagesForObjectDiagram()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            finalString += "[" + entities[i] + " | ";

            finalString += attributesSections[i] ;

            finalString += "];";

            ClassDiagram = ClassDiagram + finalString.ToString();
            TextBox1.Text = ClassDiagram;
            finalString = "";
        }
        ClassDiagram = "";
        for (int i = 0; i < relationship.Count; i++)
        {
            relationshipFinalString += relationship[i];
            ClassDiagram = ClassDiagram + relationshipFinalString.ToString();

            relationshipFinalString = "";
        }
        TextBox1.Text += ClassDiagram;
        Nomnoml = TextBox1.Text;
        Nomnoml = Nomnoml.Substring(0, Nomnoml.Length - 1);
        TextBox2.Text = Nomnoml;
    }


    protected void btn_ERD_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";

        ProjectID();

        LoadEntityIds();

        LoadERDPackagesFromDB();

        LoadERDRelationship();

        foreach (var item in ERDpackages)
        {
            TextBox1.Text += item;
        }

        foreach (var item in relationship)
        {
            TextBox1.Text += item ;
        }
        Nomnoml = TextBox1.Text;
        Nomnoml = Nomnoml.Substring(0, Nomnoml.Length - 1);
        TextBox2.Text = Nomnoml;
    }

    // Load ERD Packages From DB
    private void LoadERDPackagesFromDB()
    {
        string package = "";

        using (var con = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetERD";
                cmd.Parameters.Add("@ProjectID", System.Data.SqlDbType.Int).Value = projectID;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Attribute_Key"].ToString() == "PRIMARY KEY")
                    {
                        package += "[" + reader[0].ToString() + "]-[<usecase>" + reader[1].ToString()+"(P.K)" + "];";
                    }
                    else if (reader["Attribute_Key"].ToString() == "FOREIGN KEY")
                    {
                        package += "[" + reader[0].ToString() + "]-[<usecase>" + reader[1].ToString() + "(F.K)" + "];";
                    }
                    else
                    {
                        package += "[" + reader[0].ToString() + "]-[<usecase>" + reader[1].ToString() + "];";
                    }

                    ERDpackages.Add(package);

                    package = "";
                }
            }
        }
    }

    // Load ERD Relationship From DBs
    private void LoadERDRelationship()
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
                    cmd.CommandText = "GetRelationship";

                    cmd.Parameters.Add("@EntityId", System.Data.SqlDbType.Int).Value = item;

                    readers.Add(cmd.ExecuteReader());

                    using (SqlDataReader reader = readers.Last())
                    {
                        Boolean empty = true;
                        string Relation = "";
                        while (reader.Read())
                        {
                            if (reader["Relationship_Name"].ToString() == "1->1" || reader["Relationship_Name"].ToString() == "1-1" || reader["Relationship_Name"].ToString() == "1o->1" || reader["Relationship_Name"].ToString() == "1+-1" || reader["Relationship_Name"].ToString() == "1-:>1")
                            {
                                Relation += "[" + reader[0].ToString() + "]" + "1-" + "[<choice>" + reader[3].ToString() + "];" + "[<choice>" + reader[3].ToString() + "]" + "-1" + "[" + reader[2].ToString() + "];;";
                                empty = false;
                            }
                            else if (reader["Relationship_Name"].ToString() == "1->*" || reader["Relationship_Name"].ToString() == "1-*" || reader["Relationship_Name"].ToString() == "1o->*" || reader["Relationship_Name"].ToString() == "1+-*" || reader["Relationship_Name"].ToString() == "1-:>*")
                            {
                                Relation += "[" + reader[0].ToString() + "]" + "1-" + "[<choice>" + reader[3].ToString() + "];" + "[<choice>" + reader[3].ToString() + "]" + "-*" + "[" + reader[2].ToString() + "];;";
                                empty = false;
                            }
                            else if (reader["Relationship_Name"].ToString() == "*->1" || reader["Relationship_Name"].ToString() == "*-1" || reader["Relationship_Name"].ToString() == "*o->1" || reader["Relationship_Name"].ToString() == "*+-1" || reader["Relationship_Name"].ToString() == "*-:>1")
                            {
                                Relation += "[" + reader[0].ToString() + "]" + "*-" + "[<choice>" + reader[3].ToString() + "];" + "[<choice>" + reader[3].ToString() + "]" + "-1" + "[" + reader[2].ToString() + "];;";
                                empty = false;
                            }
                            else if (reader["Relationship_Name"].ToString() == "*->*" || reader["Relationship_Name"].ToString() == "*-*" || reader["Relationship_Name"].ToString() == "*o->*" || reader["Relationship_Name"].ToString() == "*+-*" || reader["Relationship_Name"].ToString() == "*-:>*")
                            {
                                Relation += "[" + reader[0].ToString() + "]" + "*-" + "[<choice>" + reader[3].ToString() + "];" + "[<choice>" + reader[3].ToString() + "]" + "-*" + "[" + reader[2].ToString() + "];;";
                                empty = false;
                            }
                        }
                        if (empty == false)
                        {
                            // Label7.Text = attributeSection;
                            Relation = Relation.Substring(0, Relation.Length - 1);
                            relationship.Add(Relation);
                            Relation = "";
                        }
                        
                    }
                }
            }
        }

        commands.Clear();
        readers.Clear();
    }


    protected void btn_addattributes_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        LoadData();
    }
    private void LoadData()
    {
        ProjectID();

        LoadEntityIds();

        LoadEntities();

        LoadAttributes();

        LoadBehaviors();

        LoadRelationship();

        GetPackages();
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


    // Load the Attributes
    private void LoadAttributes()
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
                            attributeSection += reader[0].ToString() + ": " + reader[1] + ";";
                            empty = false;
                        }

                        if (empty == false)
                        {
                            // Label7.Text = attributeSection;
                            attributeSection = attributeSection.Substring(0, attributeSection.Length - 1);
                            attributesSections.Add(attributeSection);
                        }
                    }
                }
            }
        }

        commands.Clear();
        readers.Clear();
    }


    // Load the Behaviors
    private void LoadBehaviors()
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
                    cmd.CommandText = "GetBehaviors";

                    cmd.Parameters.Add("@EntityId", System.Data.SqlDbType.Int).Value = item;

                    readers.Add(cmd.ExecuteReader());

                    using (SqlDataReader reader = readers.Last())
                    {
                        Boolean empty = true;
                        string BehaviorsSection = "";
                        while (reader.Read())
                        {
                            BehaviorsSection += reader[0].ToString() + "( )" + ";";
                            empty = false;
                        }

                        if (empty == false)
                        {
                            // Label7.Text = attributeSection;
                            BehaviorsSection = BehaviorsSection.Substring(0, BehaviorsSection.Length - 1);
                            BehaviorsSections.Add(BehaviorsSection);
                        }
                    }

                }
            }
        }

        commands.Clear();
        readers.Clear();
    }

    // Load Relationships
    private void LoadRelationship()
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
                    cmd.CommandText = "GetRelationship";

                    cmd.Parameters.Add("@EntityId", System.Data.SqlDbType.Int).Value = item;

                    readers.Add(cmd.ExecuteReader());

                    using (SqlDataReader reader = readers.Last())
                    {
                        string Relation = "";
                        Boolean empty = true;
                        while (reader.Read())
                        {
                            Relation += "[" + reader[0].ToString() + "]" + reader[1].ToString() + "[" + reader[2].ToString() + "]"+";;";
                            empty = false;
                        }
                            if (empty == false)
                            {
                                // Label7.Text = attributeSection;
                                Relation = Relation.Substring(0, Relation.Length - 1);
                                relationship.Add(Relation);
                            }
                        

                        //relationship.Add(Relation);

                        //Label7.Text = LastIndex.ToString();
                    }
                }
            }
        }

        commands.Clear();
        readers.Clear();
    }

    // Load Get Packages for Class Diagram String
    private void GetPackages()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            finalString += "[" + entities[i] + " | ";

            finalString += attributesSections[i] + " | ";

            finalString += BehaviorsSections[i];

            finalString += "];" + "\r\n";

            ClassDiagram = ClassDiagram + finalString.ToString();
            TextBox1.Text = ClassDiagram;
            finalString = "";
        }
        ClassDiagram = "";
        for (int i = 0; i < relationship.Count; i++)
        {
            relationshipFinalString += relationship[i];
            ClassDiagram = ClassDiagram + relationshipFinalString.ToString();

            relationshipFinalString = "";
        }
        TextBox1.Text += ClassDiagram;

        Nomnoml = TextBox1.Text;
        Nomnoml = Nomnoml.Substring(0, Nomnoml.Length - 1);
        TextBox2.Text = Nomnoml;
    }

}