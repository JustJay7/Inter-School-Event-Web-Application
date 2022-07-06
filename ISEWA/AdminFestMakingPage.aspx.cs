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
    public partial class AdminFestMakingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAdminEmail.Text = Session["AdminEmail"].ToString();
        }

        protected void btnNextScreen_Click(object sender, EventArgs e)
        {
            EventClass objEventClass = new EventClass(txtFestName.Text);

            bool Result = objEventClass.CheckFestExists();
            if (Result == false)
            {
                int Result2 = objEventClass.AddFestDetails();
                if (Result2 > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Gold;
                    lblMessage.Text = "You have successfully created a new Fest!";
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "The Fest was not created successfully. Please try again!";
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Fest Name already exists.";
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }

        protected void btnLogoutEventCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }
    }
}