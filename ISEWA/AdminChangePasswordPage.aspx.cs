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
    public partial class AdminChangePasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            AdminClass objChangePassword = new AdminClass(txtAdminEmail.Text.Trim(), txtCurrentPassword.Text.Trim(), txtNewPassword.Text.Trim());

            int Result = objChangePassword.ChangePassword();
            if (Result == 1)
            {
                lblMessage.Text = "Your password has been changed successfully!";
                // Or show in messagebox using: ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Password has been changed successfully');", true);
            }
            else
            {
                lblMessage.Text = "Current Email ID or Password is incorrect. Please try again.";
                // Or show in messagebox using: ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Wrong username/password. Please re-enter.');", true);
            }
            /*try
            {SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
                SqlCommand cmd = new SqlCommand("AdminChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CurrentEmail", txtAdminEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@OldPassword", txtOldPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@NewPassword", txtNewPassword.Text.Trim());

                cmd.Parameters.Add("@Status", SqlDbType.Int);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                //read the return value (i.e status) from the stored procedure
                int retVal = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                if (retVal == 1)
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
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert(The following error occured : " + ex.Message.ToString() + "');", true);
                // Response.Write("Oops!! following error occured: " +ex.Message.ToString());           
            }*/
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }
    }
}