using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataAccess;

namespace ISEWA
{
    public partial class SchoolChangePasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            SchoolClass objChangePassword = new SchoolClass(txtSchoolEmail.Text.Trim(), txtCurrentPassword.Text.Trim(), txtNewPassword.Text.Trim());

            int Result = objChangePassword.ChangePassword();
            if (Result == 1)
            {
                lblMessage.Text = "Your password has been changed successfully!";
                // Or show in messagebox using: ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Password has been changed successfully');", true);
            }
            else
            {
                lblMessage.Text = "Current Email ID or Old Password is incorrect. Please try again.";
                // Or show in messagebox using: ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Wrong username/password. Please re-enter.');", true);
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolLoginPage.aspx");
        }
    }
}