using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ISEWA
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void BtnLoginAdmin_Click(object sender, EventArgs e)
        {
            UserClass objAdminLogin = new AdminClass();
            objAdminLogin.UserEmail = txtAdminEmail.Text;
            objAdminLogin.UserPassword = txtAdminPassword.Text;

            int Result = objAdminLogin.LoginCheck();
            if (Result == 1)
            {
                lblErrorMessage.Visible = false;
                Session["AdminEmail"] = txtAdminEmail.Text;
                Response.Redirect("AdminHomePage.aspx");
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Login Credentials Invalid. Please try again!";
            }
        }
        protected void LinkbtnChangePasswordAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminChangePasswordPage.aspx");
        }

        protected void LinkbtnForgotPasswordAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminForgotPasswordPage.aspx");
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}