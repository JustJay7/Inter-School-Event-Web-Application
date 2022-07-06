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

namespace ISEWA
{
    public partial class AdminViewEventScore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAdminEmail.Text = Session["AdminEmail"].ToString();
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            // connection string  
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //EVENT NAME
            //INCLUDE SCHOOL EMAIL
            string qry = "SELECT FestName, EventName, SchoolEmail, Score FROM SchoolEventScores";
            SqlCommand com = new SqlCommand(qry, con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            da.Fill(ds);  // fill dataset  
                          //gvInputScore.DataTextField = ds.Tables[0].Columns["SchoolName"].ToString(); // text field name of table dispalyed in dropdown       
                          // to retrive specific  textfield name   
            gvEventScores.DataSource = ds;      //assigning datasource to the dropdownlist  
            gvEventScores.DataBind();  //binding dropdownlist

            if (!this.IsPostBack)
            {
                string mycoon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using (SqlConnection coonn = new SqlConnection(mycoon))
                {
                    using (SqlCommand cmmd = new SqlCommand("SELECT DISTINCT FestName FROM FestNames"))
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

                string mycon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(mycon))
                ddlEventName.Items.Insert(0, new ListItem("All Events", "All Events"));

                string myconn = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using (SqlConnection connn = new SqlConnection(myconn))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT SchoolEmail FROM SchoolEventScores"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = connn;
                        connn.Open();
                        ddlSchoolEmail.DataSource = cmd.ExecuteReader();
                        ddlSchoolEmail.DataTextField = "SchoolEmail";
                        //ddlEventName.DataValueField = "CustomerId";
                        ddlSchoolEmail.DataBind();
                        connn.Close();
                    }
                }
                ddlSchoolEmail.Items.Insert(0, new ListItem("All Schools", "All Schools"));

                //this.Search();
            }
        }

        private void Search()
        {
            AdminClass objSearch = new AdminClass();
            DataSet ds = objSearch.FetchEventScores(ddlFestName.SelectedValue, ddlEventName.SelectedValue, ddlSchoolEmail.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvEventScores.DataSource = ds;
                gvEventScores.DataBind();
                gvEventScores.Visible = true;

                lblErrorMessage.Visible = false;
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "No Data was available for the selected search criteria.";
                gvEventScores.Visible = false;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }

        protected void btnLogoutAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }

        protected void ddlFestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myconn = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection connn = new SqlConnection(myconn))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT EventName FROM SchoolEventScores WHERE FestName = '" + ddlFestName.SelectedValue + "'");
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connn;
                    connn.Open();
                    ddlEventName.DataSource = cmd.ExecuteReader();
                    ddlEventName.DataTextField = "EventName";
                    //ddlEventName.DataValueField = "CustomerId";
                    ddlEventName.DataBind();
                    connn.Close();
                }
            }
            ddlEventName.Items.Insert(0, new ListItem("All Events", "All Events"));

            string mycon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(mycon))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT SchoolEmail FROM SchoolEventScores WHERE FestName = '" + ddlFestName.SelectedValue + "'");
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlSchoolEmail.DataSource = cmd.ExecuteReader();
                    ddlSchoolEmail.DataTextField = "SchoolEmail";
                    //ddlEventName.DataValueField = "CustomerId";
                    ddlSchoolEmail.DataBind();
                    con.Close();
                }
            }
            ddlSchoolEmail.Items.Insert(0, new ListItem("All Schools", "All Schools"));
        }

        protected void ddlEventName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mycon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(mycon))
            {
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT SchoolEmail FROM SchoolEventScores WHERE FestName = '" + ddlFestName.SelectedValue + "' AND EventName = '" + ddlEventName.SelectedValue + "'");
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlSchoolEmail.DataSource = cmd.ExecuteReader();
                    ddlSchoolEmail.DataTextField = "SchoolEmail";
                    //ddlEventName.DataValueField = "CustomerId";
                    ddlSchoolEmail.DataBind();
                    con.Close();
                }
            }
            ddlSchoolEmail.Items.Insert(0, new ListItem("All Schools", "All Schools"));
        }

        protected void ddlSchoolEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string mycoon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection coonn = new SqlConnection(mycoon))
            {
                using (SqlCommand cmmd = new SqlCommand("SELECT DISTINCT FestName FROM SchoolEventScores WHERE SchoolEmail = '" + ddlSchoolEmail.SelectedValue + "'"))
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
            ddlFestName.Items.Insert(0, new ListItem("All Fests", "All Fests"));*/
        }
    }
}