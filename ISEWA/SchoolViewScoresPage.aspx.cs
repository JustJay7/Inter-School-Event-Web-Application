using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; // Required for using Dataset , Datatable and Sql  
using System.Data.SqlClient; // Required for Using Sql   
using System.Configuration;
using DataAccess;

namespace ISEWA
{
    public partial class PastDataOfSchools : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string sql = "SELECT FestName, EventName, Score FROM [dbo].[SchoolEventScores] WHERE SchoolEmail = '" + Session["SchoolEmail"].ToString() + "'";
                gvPastData.DataSource = this.GetData(sql);
                gvPastData.DataBind();

                string mycon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(mycon))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT FestName FROM FestNames"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        conn.Open();
                        ddlFestName.DataSource = cmd.ExecuteReader();
                        ddlFestName.DataTextField = "FestName";
                        ddlFestName.DataBind();
                        conn.Close();
                    }
                }
                ddlFestName.Items.Insert(0, new ListItem("All Fests", "All Fests"));
            }

            if (!IsPostBack)
            {
                lblSchoolEmail.Text = Session["SchoolEmail"].ToString();
            }
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
        private void Search()
        {
            SchoolClass objFestSearch = new SchoolClass();
            DataSet ds = objFestSearch.ViewScores(ddlFestName.SelectedValue, lblSchoolEmail.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblErrorMessage.Visible = false;
                gvPastData.Visible = true;
                gvPastData.DataSource = ds;
                gvPastData.DataBind();
            }
            else
            {
                lblErrorMessage.Visible = true;
                gvPastData.Visible = false;
                lblErrorMessage.Text = "No Data was available for the selected search criteria.";
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvPastData.PageIndex = e.NewPageIndex;
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