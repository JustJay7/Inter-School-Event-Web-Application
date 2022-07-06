using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace ISEWA
{
    public partial class ForgotPasswordSchool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnSendEmail_Click(object sender, EventArgs e)
        {
            string UniqueCode = string.Empty;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
                //if (con.State == ConnectionState.Closed)
                //{
                con.Open();
                //
                //
                //}
                // get the records matching the supplied username or email id.         
                cmd = new SqlCommand("SELECT * FROM SchoolCredentials WHERE SchoolEmail COLLATE Latin1_general_CS_AS=@SchoolEmail", con);

                cmd.Parameters.AddWithValue("@SchoolEmail", Convert.ToString(txtSchoolEmail.Text.Trim()));
                dr = cmd.ExecuteReader();
                cmd.Dispose();
                if (dr.HasRows)
                {
                    dr.Read();
                    //generate unique code
                    UniqueCode = Convert.ToString(System.Guid.NewGuid());
                    //Updating an unique random code in then UniquCode field of the database table
                    cmd = new SqlCommand("UPDATE SchoolCredentials set SchoolPassword=@UniqueCode WHERE SchoolEmail=@SchoolEmail", con);
                    cmd.Parameters.AddWithValue("@UniqueCode", UniqueCode);
                    cmd.Parameters.AddWithValue("@SchoolEmail", txtSchoolEmail.Text.Trim());

                    StringBuilder strBody = new StringBuilder();
                    strBody.Append("Please Find Your New Password written in the subject of this email. It is recommended that you change your password immediately.");
                    //Passing emailid,username and generated unique code via querystring. For testing pass your localhost number and while making online pass your domain name instead of localhost path.
                    //strBody.Append("<a href=https://localhost:44361/SchoolResetPasswordPage.aspx?emailId=" + txtSchoolEmail.Text + "&uCode=" + UniqueCode + ">Click here to change your password</a>");
                    //sbody.Append("&uCode=" + uniqueCode + "&uName=" + txtUserName.Text + ">Click here to change your password</a>");

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("isweathebot@gmail.com", dr["SchoolEmail"].ToString(), UniqueCode, strBody.ToString());
                    //pasing the Gmail credentials to send the email

                    System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("isweathebot@gmail.com", "ISWEAbotresetyourpassword");

                    System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    mailclient.EnableSsl = true;
                    mailclient.UseDefaultCredentials = false;
                    mailclient.Credentials = mailAuthenticaion;
                    mailclient.EnableSsl = true;
                    mail.IsBodyHtml = true;
                    mailclient.Send(mail);
                    dr.Close();
                    dr.Dispose();
                    cmd.ExecuteReader();
                    cmd.Dispose();
                    con.Close();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Your New Password has been sent to your email!";
                    txtSchoolEmail.Text = string.Empty;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please enter valid email address";
                    txtSchoolEmail.Text = string.Empty;
                    con.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Error Occured: " + ex.Message.ToString();
            }
            finally
            {
                cmd.Dispose();
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToThePreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolLoginPage.aspx");
        }
    }
}