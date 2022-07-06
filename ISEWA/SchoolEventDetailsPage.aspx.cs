using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; // Required for using Dataset , Datatable and Sql  
using System.Data.SqlClient; // Required for Using Sql   
using System.Configuration; // for Using Connection From Web.config  
using DataAccess;
using System.Drawing;


namespace ISEWA
{
    public partial class EventsHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string sql = "SELECT * FROM [dbo].[EventDetails]";
                gvEventDetails.DataSource = this.GetData(sql);
                gvEventDetails.DataBind();

                string mycoon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using (SqlConnection coonn = new SqlConnection(mycoon))
                {
                    using (SqlCommand cmmd = new SqlCommand("SELECT FestName FROM FestNames"))
                    {
                        cmmd.CommandType = CommandType.Text;
                        cmmd.Connection = coonn;
                        coonn.Open();
                        ddlFestName.DataSource = cmmd.ExecuteReader();
                        ddlFestName.DataTextField = "FestName";
                        ddlFestName.DataBind();
                        coonn.Close();
                    }
                }
                ddlFestName.Items.Insert(0, new ListItem("All Fests", "All Fests"));
            }

            if (!IsPostBack)
            {
                lblSchoolEmail.Text = Session["SchoolEmail"].ToString();
            }
            gvEventDetails.Visible = true;
        }
        private DataTable GetData(string sql)
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection = con;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected void btnRegisterForThisEvent_Click(object sender, EventArgs e)
        {
            Session["EventName"] = gvEventDetails.SelectedRow.Cells[2].Text;
            SchoolClass objRegisteredEvent = new SchoolClass(Session["EventName"].ToString(), lblSchoolEmail.Text);
            bool Result = objRegisteredEvent.RegisteredEvent();
            if (Result == false)
            {
                Send();
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "You have already registered for this event.";
            }
        }

        public void Send()
        {
            if (gvEventDetails.SelectedRow != null)
            {
                Session["FestName"] = gvEventDetails.SelectedRow.Cells[1].Text;
                Session["EventName"] = gvEventDetails.SelectedRow.Cells[2].Text;
                Session["SchoolEmail"] = lblSchoolEmail.Text;
                Session["MaximumParticipants"] = gvEventDetails.SelectedRow.Cells[4].Text;
                Response.Redirect("~/SchoolEventRegistrationPage.aspx");
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Please Select A Row.";
            }
        }
        private void Search()
        {
            SchoolClass objFestSearch = new SchoolClass();
            DataSet ds = objFestSearch.FetchEventDetails(ddlFestName.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblErrorMessage.Visible = false;
                gvEventDetails.Visible = true;
                gvEventDetails.DataSource = ds;
                gvEventDetails.DataBind();
            }
            else
            {
                gvEventDetails.Visible = false;
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "No Data was available for the selected search criteria.";
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvEventDetails.PageIndex = e.NewPageIndex;
            this.Search();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolHomePage.aspx");
        }

        protected void btnLogoutSchool_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolLoginPage.aspx");
        }
    }
}