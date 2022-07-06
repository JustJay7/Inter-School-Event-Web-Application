using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISEWA
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAdminEmail.Text = Session["AdminEmail"].ToString();
        }
        protected void btnCreateFest_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminFestMakingPage.aspx");
        }

        protected void btnViewScore_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewScoresPage.aspx");
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnLogoutAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }

        protected void btnCreateEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminEventMakingPage.aspx");
        }

        protected void btnUpdateDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateDetailsPage.aspx");
        }

        protected void btnViewFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewSchoolFeedbackPage.aspx");
        }

        protected void btnViewSchoolPastData_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewSchoolPastDataPage.aspx");
        }
    }
}