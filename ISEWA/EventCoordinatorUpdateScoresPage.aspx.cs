using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ISEWA
{
    public partial class Update_Scores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblEventCoordinatorEmail.Text = Session["EventCoordinatorEmail"].ToString();
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            string sql = "SELECT * FROM SchoolEventScores WHERE FestName = '" + Session["ChosenFest"].ToString() + "' AND EventName = '" + Session["ChosenEvent"].ToString() + "'";
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvUpdateScores.DataSource = dt;
                        gvUpdateScores.DataBind();
                    }
                }
            }
        }
        protected void gvUpdateScores_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvUpdateScores.SelectedRow;
            lblId.Text = row.Cells[0].Text;
            txtFestName.Text = row.Cells[1].Text;
            txtEventName.Text = row.Cells[2].Text;
            txtSchoolEmail.Text = row.Cells[3].Text;
            ddlScore.SelectedValue = row.Cells[4].Text;
        }
        protected void EditScore(object sender, GridViewEditEventArgs e)
        {
            gvUpdateScores.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUpdateScores.EditIndex = -1;
            this.BindGrid();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "UPDATE SchoolEventScores SET Score = @Score WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", lblId.Text);
                    cmd.Parameters.AddWithValue("@Score", ddlScore.SelectedValue);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorHomePage.aspx");
        }

        protected void btnLogoutEventCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorChooseEventToUpdatePage.aspx");
        }
    }
}