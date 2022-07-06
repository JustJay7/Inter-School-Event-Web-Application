using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISEWA
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageBody.Attributes.Add("bgcolor", "#101820FF");
        }
        protected void btnRegSchool_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolRegistrationPage.aspx");
        }

        protected void btnLogSchool_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolLoginPage.aspx");
        }

        protected void btnRegEventCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorRegistrationPage.aspx");
        }

        protected void btnLogEventCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorLoginPage.aspx");
        }

        protected void btnLogAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }
    }
}