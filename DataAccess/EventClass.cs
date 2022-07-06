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
    public class EventClass
    {
        //Declaring EventMakingPage Variables  
        private int _Id;
        private string _FestName;
        private string _EventName;
        private string _EventDescription;
        private string _EventCoordinator;
        private string _NumberOfParticipants;
        private string _EligibleGrades;
        private string _DateOfEvent;
        private string _TimeOfEvent;

        // Get and set values
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                
                _Id = value;
            }
        }
        public string FestName
        {
            get
            {
                return _FestName;
            }
            set
            {
                _FestName = value;
            }
        }
        public string EventName
        {
            get
            {
                return _EventName;
            }
            set
            {
                _EventName = value;
            }
        }
        public string EventDescription
        {
            get
            {
                return _EventDescription;
            }
            set
            {
                _EventDescription = value;
            }
        }
        public string EventCoordinator
        {
            get
            {
                return _EventCoordinator;
            }
            set
            {
                _EventCoordinator = value;
            }
        }
        public string NumberOfParticipants
        {
            get
            {
                return _NumberOfParticipants;
            }
            set
            {
                _NumberOfParticipants = value;
            }
        }
        public string EligibleGrades
        {
            get
            {
                return _EligibleGrades;
            }
            set
            {
                _EligibleGrades = value;
            }
        }
        public string DateOfEvent
        {
            get
            {
                return _DateOfEvent;
            }
            set
            {
                _DateOfEvent = value;
            }
        }
        public string TimeOfEvent
        {
            get
            {
                return _TimeOfEvent;
            }
            set
            {
                _TimeOfEvent = value;
            }
        }

        public EventClass()
        {

        }
        public EventClass(string festname)
        {
            this.FestName = festname;
        }

        public EventClass(string festname, string eventname, string eventdescription, string eventcoordinatoremail, string numberofparticipants, string dateofevent, string timeofevent)
        {
            this.FestName = festname;
            this.EventName = eventname;
            this.EventDescription = eventdescription;
            this.EventCoordinator = eventcoordinatoremail;
            this.NumberOfParticipants = numberofparticipants;
            this.DateOfEvent = dateofevent;
            this.TimeOfEvent = timeofevent;
        }
        public EventClass(int Id, string festname, string eventname, string eventdescription, string eventcoordinatoremail, string numberofparticipants, string dateofevent, string timeofevent)
        {
            this.Id = Id;
            this.FestName = festname;
            this.EventName = eventname;
            this.EventDescription = eventdescription;
            this.EventCoordinator = eventcoordinatoremail;
            this.NumberOfParticipants = numberofparticipants;
            this.DateOfEvent = dateofevent;
            this.TimeOfEvent = timeofevent;
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

        public int AddFestDetails() // passing Bussiness object Here  

        {
            try
            {
                string qry = "insert into FestNames values(@FestName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@FestName", this.FestName);

                con.Open();
                int Result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return Result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int AddEventDetails() 
        {
            try
            {
                string qry = "insert into EventDetails values(@FestName, @EventName, @EventDescription, @EventCoordinator, @NumberOfParticipants, @DateOfTheEvent, @TimeOfTheEvent)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@FestName", this.FestName);
                cmd.Parameters.AddWithValue("@EventName", this.EventName);
                cmd.Parameters.AddWithValue("@EventDescription", this.EventDescription);
                cmd.Parameters.AddWithValue("@EventCoordinator", this.EventCoordinator);
                cmd.Parameters.AddWithValue("@NumberOfParticipants", this.NumberOfParticipants);
                cmd.Parameters.AddWithValue("@DateOfTheEvent", this.DateOfEvent);
                cmd.Parameters.AddWithValue("@TimeOfTheEvent", this.TimeOfEvent);

                con.Open();
                int Result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return Result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int UpdateEventDetails()
        {
            try
            {
                string query = "UPDATE EventDetails SET FestName=@FestName, EventName=@EventName, EventDescription=@EventDescription, EventCoordinator=@EventCoordinator, NumberOfParticipants=@NumberOfParticipants, DateOfTheEvent=@DateOfTheEvent, TimeOfTheEvent=@TimeOfTheEvent WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", this.Id);
                cmd.Parameters.AddWithValue("@FestName", this.FestName);
                cmd.Parameters.AddWithValue("@EventName", this.EventName);
                cmd.Parameters.AddWithValue("@EventDescription", this.EventDescription);
                cmd.Parameters.AddWithValue("@EventCoordinator", this.EventCoordinator);
                cmd.Parameters.AddWithValue("@NumberOfParticipants", this.NumberOfParticipants);
                cmd.Parameters.AddWithValue("@DateOfTheEvent", this.DateOfEvent);
                cmd.Parameters.AddWithValue("@TimeOfTheEvent", this.TimeOfEvent);
                con.Open();
                int Result = cmd.ExecuteNonQuery();
                con.Close();
                return Result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public bool CheckFestExists()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT FestName FROM FestNames WHERE FestName = '" + this.FestName + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckEventExists()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT EventName FROM EventDetails WHERE EventName='" + this.EventName + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int AddEligibleGrades(string eventname, string[] eligiblegrades)
        {
            try
            {
                DataTable eligibletd = new DataTable();
                DataRow dr;
                eligibletd.Columns.Add(new DataColumn("event_name", typeof(string)));
                eligibletd.Columns.Add(new DataColumn("eligible_grades", typeof(string)));

                for (int i= 0; i < eligiblegrades.Length; i++)
                {
                    
                    eligibletd.Rows.Add(eventname, eligiblegrades[i]);
                }
                con.Open();
                SqlBulkCopy objbulk = new SqlBulkCopy(con);
                objbulk.DestinationTableName = "EventEligibleGrades";
                objbulk.ColumnMappings.Add("event_name", "EventName");
                objbulk.ColumnMappings.Add("eligible_grades", "EligibleGrades");
                objbulk.WriteToServer(eligibletd);
                con.Close();
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }
        }
    }
}