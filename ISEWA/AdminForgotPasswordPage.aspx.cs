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
    public partial class Forgot_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            //Declare Variable which would ensure that the reset password link would be for one time use only
            string UniqueCode = string.Empty;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
                con.Open();
                // Get records matching the Email ID. Make sure it is case sensitive and accent sensitive        
                cmd = new SqlCommand("SELECT * FROM AdminLoginCredentials WHERE AdminEmail COLLATE Latin1_general_CS_AS=@AdminEmail", con);

                cmd.Parameters.AddWithValue("@AdminEmail", Convert.ToString(txtAdminEmail.Text.Trim()));
                dr = cmd.ExecuteReader();
                cmd.Dispose();
                if (dr.HasRows)
                {
                    dr.Read();
                    //Generate unique code
                    UniqueCode = Convert.ToString(System.Guid.NewGuid());
                    //Updating the AdminPassword column in the database for the Admin Email that the user has entered in the Textbox
                    cmd = new SqlCommand("UPDATE AdminLoginCredentials set AdminPassword=@UniqueCode WHERE AdminEmail=@AdminEmail", con);
                    cmd.Parameters.AddWithValue("@UniqueCode", UniqueCode);
                    cmd.Parameters.AddWithValue("@AdminEmail", txtAdminEmail.Text.Trim());

                    StringBuilder strBody = new StringBuilder();
                    strBody.Append("Please Find Your New Password written in the subject of this email. It is recommended that you change your password immediately.");
                    //                                                                      Sender Gmail          Reciever of the email       Subject          Body
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("isweathebot@gmail.com", dr["AdminEmail"].ToString(), UniqueCode, strBody.ToString());
                    //pasing the Gmail credentials to send the email
                    //                                                                                      Sender Gmail            Sender Password
                    System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("isweathebot@gmail.com", "ISWEAbotresetyourpassword");
                    //                                                                                   Port Number
                    System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    mailclient.EnableSsl = true;
                    mailclient.UseDefaultCredentials = false;
                    mailclient.Credentials = mailAuthenticaion;
                    mail.IsBodyHtml = true;
                    mailclient.Send(mail);
                    dr.Close();
                    dr.Dispose();
                    cmd.ExecuteReader();
                    cmd.Dispose();
                    con.Close();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Your New Password has been sent to your email!";
                    txtAdminEmail.Text = string.Empty;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Email ID does not exist in our database.";
                    txtAdminEmail.Text = string.Empty;
                    con.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "An Error Occured: " + ex.Message.ToString();
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
            Response.Redirect("AdminHomePage.aspx");
        }
    }
}