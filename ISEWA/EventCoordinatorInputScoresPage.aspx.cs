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
    public partial class ECInputScores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblEventCoordinatorEmail.Text = Session["EventCoordinatorEmail"].ToString();

                string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString();
                // connection string  
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string qry = "SELECT DISTINCT SchoolEmail, FestName, EventName FROM ParticipantDetails WHERE FestName = '" + Session["ChosenFest"].ToString() + "' " +
                    "AND EventName = '" + Session["ChosenEvent"].ToString() + "' ";
                SqlCommand com = new SqlCommand(qry, con);   
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                gvInputScore.DataSource = ds;   //assigning datasource to the GridView  
                gvInputScore.DataBind();  //binding GridView
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bulk_Insert();
        }
        protected void Bulk_Insert()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            DataTable ecinputscores = new DataTable();
            DataRow dr;

            ecinputscores.Columns.Add(new DataColumn("FestName", typeof(string)));
            ecinputscores.Columns.Add(new DataColumn("EventName", typeof(string)));
            ecinputscores.Columns.Add(new DataColumn("SchoolEmail", typeof(string)));
            ecinputscores.Columns.Add(new DataColumn("Score", typeof(string)));

            foreach (GridViewRow row in gvInputScore.Rows)
            {
                ecinputscores.Rows.Add();
                int i = 0;
                for (i = 0; i < row.Cells.Count; i++)
                {
                    if (i == 3)
                    {
                        DropDownList ddlScore = (DropDownList)gvInputScore.Rows[row.RowIndex].Cells[3].FindControl("ddlScore");
                        ecinputscores.Rows[row.RowIndex][i] = ddlScore.SelectedValue;
                    }
                    else
                    {
                        ecinputscores.Rows[row.RowIndex][i] = row.Cells[i].Text;
                    }
                }
            }

            try
            {
                con.Open();
                SqlBulkCopy objbulk = new SqlBulkCopy(con);
                objbulk.DestinationTableName = "SchoolEventScores";
                objbulk.ColumnMappings.Add("FestName", "FestName");
                objbulk.ColumnMappings.Add("EventName", "EventName");
                objbulk.ColumnMappings.Add("SchoolEmail", "SchoolEmail");
                objbulk.ColumnMappings.Add("Score", "Score");
                objbulk.WriteToServer(ecinputscores);
                con.Close();
                lblMessage.Visible = true;
                lblMessage.Text = "You have successfully added the scores for all schools!";
            }

            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Participant Registration Failed. Please try again!";
            }
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorChooseAnEventPage.aspx");
        }
        protected void btnLogoutEventCoordinator_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventCoordinatorLoginPage.aspx");
        }
    }
}