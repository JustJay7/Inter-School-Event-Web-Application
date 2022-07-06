using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // Required for using Dataset , Datatable and Sql  
using System.Data.SqlClient; // Required for Using Sql   
using System.Configuration; // for Using Connection From Web.config  


namespace DataAccess
{
    public class AdminClass : UserClass
    {
        public AdminClass()
        {

        }
        public AdminClass(string RegisteredEmailID, string CurrentPassword, string NewPassword)
        {
            this.UserEmail = RegisteredEmailID;
            this.CurrentPassword = CurrentPassword;
            this.NewPassword = NewPassword;
        }
        //Overides virtual int method in base class
        public override int LoginCheck()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM AdminLoginCredentials WHERE AdminEmail='" + this.UserEmail + "' and AdminPassword='" + this.UserPassword + "'", con);
            cmd.Parameters.AddWithValue("@AdminEmail", this.UserEmail);
            cmd.Parameters.AddWithValue("@AdminPassword", this.UserPassword);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //Copy this to Eventcoordinatorclass
        public override int ChangePassword()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("AdminChangePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RegisteredEmailID", this.UserEmail);
            cmd.Parameters.AddWithValue("@CurrentPassword", this.CurrentPassword);
            cmd.Parameters.AddWithValue("@NewPassword", this.NewPassword);

            cmd.Parameters.Add("@Status", SqlDbType.Int);
            cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            //read the return value (i.e status) from the stored procedure
            int retVal = Convert.ToInt32(cmd.Parameters["@Status"].Value);
            if (retVal == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public DataSet FetchEventScores(string SelectedFestName, string SelectedEventName, string SelectedSchoolEmail)
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            string sql;
                    if (SelectedFestName != "All Fests" && SelectedEventName != "All Events" && SelectedSchoolEmail != "All Schools")
                    {
                        sql = "SELECT FestName, EventName, SchoolEmail, Score FROM [dbo].[SchoolEventScores] WHERE (([FestName] = '" + SelectedFestName + "') AND ([EventName] = '" + SelectedEventName + "') AND ([SchoolEmail] = '" + SelectedSchoolEmail + "'))";
                    }
                    else if (SelectedFestName != "All Fests" && SelectedEventName == "All Events" && SelectedSchoolEmail == "All Schools")
                    {
                        sql = "SELECT FestName, EventName, SchoolEmail, Score FROM [dbo].[SchoolEventScores] WHERE ([FestName] = '" + SelectedFestName + "')";
                    }
                    else if (SelectedFestName == "All Fests" && SelectedEventName != "All Events" && SelectedSchoolEmail == "All Schools")
                    {
                        sql = "SELECT FestName, EventName, SchoolEmail, Score FROM [dbo].[SchoolEventScores] WHERE ([EventName] = '" + SelectedEventName + "')";
                    }
                    else if (SelectedFestName == "All Fests" && SelectedEventName == "All Events" && SelectedSchoolEmail != "All Schools")
                    {
                        sql = "SELECT FestName, EventName, SchoolEmail, Score FROM [dbo].[SchoolEventScores] WHERE ([SchoolEmail] = '" + SelectedSchoolEmail + "')";
                    }
                    else if (SelectedFestName != "All Fests" && SelectedEventName != "All Events" && SelectedSchoolEmail == "All Schools")
                    {
                        sql = "SELECT FestName, EventName, SchoolEmail, Score FROM [dbo].[SchoolEventScores] WHERE (([FestName] = '" + SelectedFestName + "') AND ([EventName] = '" + SelectedEventName + "'))";
                    }
                    else if (SelectedFestName == "All Fests" && SelectedEventName != "All Events" && SelectedSchoolEmail != "All Schools")
                    {
                        sql = "SELECT FestName, EventName, SchoolEmail, Score FROM [dbo].[SchoolEventScores] WHERE (([EventName] = '" + SelectedEventName + "') AND ([SchoolEmail] = '" + SelectedSchoolEmail + "'))";
                    }
                    else if (SelectedFestName != "All Fests" && SelectedEventName == "All Events" && SelectedSchoolEmail != "All Schools")
                    {
                        sql = "SELECT FestName, EventName, SchoolEmail, Score FROM [dbo].[SchoolEventScores] WHERE (([FestName] = '" + SelectedFestName + "') AND ([SchoolEmail] = '" + SelectedSchoolEmail + "'))";
                    }
                    else
                    {
                        sql = "SELECT FestName, EventName, SchoolEmail, Score FROM [dbo].[SchoolEventScores]";
                    }
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "SchoolEventScores");
                    con.Close();
                    return ds;
        }
        public DataSet FetchOverallScores(string ddlFestName)
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            string sql;

            sql = "SELECT SchoolEmail, SUM(Score) As OverallScore, COUNT (DISTINCT SchoolEventScores.EventName) As NumberOfEvents FROM SchoolEventScores WHERE [FestName] = '" + ddlFestName + "' GROUP BY SchoolEmail ORDER BY OverallScore DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "SchoolEventScores");
            con.Close();
            return ds;
        }

        public DataSet FetchSchoolFeedback(string SchoolEmail)
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            string sql;

            if (SchoolEmail != "All Schools")
            {
                sql = "SELECT * FROM [dbo].[SchoolFeedback] WHERE ([SchoolEmail] = '" + SchoolEmail + "'))";
            }
            else
            {
                sql = "SELECT * FROM SchoolFeedback WHERE ([SchoolEmail] = '" + SchoolEmail + "'))";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Schoolfeedback");
            con.Close();
            return ds;
        }
    }
}
