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
    public partial class EventRegistration : System.Web.UI.Page
    {
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("FestName", typeof(string)));
            dt.Columns.Add(new DataColumn("EventName", typeof(string)));
            dt.Columns.Add(new DataColumn("ParticipantName", typeof(string)));
            dt.Columns.Add(new DataColumn("ParticipantGender", typeof(string)));
            dt.Columns.Add(new DataColumn("ParticipantGrade", typeof(string)));
            dr = dt.NewRow();
            dr["FestName"] = Session["FestName"].ToString();
            dr["EventName"] = Session["EventName"].ToString();
            dr["ParticipantName"] = string.Empty;
            dr["ParticipantGender"] = string.Empty;
            dr["ParticipantGrade"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            gvParticipant.DataSource = dt;
            gvParticipant.DataBind();
        }

        private void AddNewRowToGrid()
        {
            int rowIndex = 0;
            //Check if view state is not null 
            if (ViewState["CurrentTable"] != null)
            {                               
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];  //Retrieve datatable from view state
                DataRow drCurrentRow = null;
                int rowCount = dtCurrentTable.Rows.Count;
                int MaxParticipants = Convert.ToInt32(Session["MaximumParticipants"]);
                if (rowCount < MaxParticipants)
                {
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //Retrieve values inputted in textbox and dropdowns
                            TextBox txtpname = (TextBox)gvParticipant.Rows[rowIndex].Cells[2].FindControl("txtParticipantName");
                            DropDownList ddlpgender = (DropDownList)gvParticipant.Rows[rowIndex].Cells[3].FindControl("ddlParticipantGender");
                            DropDownList ddlpgrade = (DropDownList)gvParticipant.Rows[rowIndex].Cells[4].FindControl("ddlParticipantGrade");

                            drCurrentRow = dtCurrentTable.NewRow();  //Create new row and add each row into data table
                            drCurrentRow["FestName"] = Session["FestName"].ToString();
                            drCurrentRow["EventName"] = Session["EventName"].ToString();
                                                                                        
                            dtCurrentTable.Rows[i - 1]["FestName"] = Session["FestName"].ToString();
                            dtCurrentTable.Rows[i - 1]["EventName"] = Session["EventName"].ToString();
                            dtCurrentTable.Rows[i - 1]["ParticipantName"] = txtpname.Text;
                            dtCurrentTable.Rows[i - 1]["ParticipantGender"] = ddlpgender.SelectedValue;
                            dtCurrentTable.Rows[i - 1]["ParticipantGrade"] = ddlpgrade.SelectedValue;

                            rowIndex++;
                        }
                        dtCurrentTable.Rows.Add(drCurrentRow); //Add Created Rows to the DataTable
                        ViewState["CurrentTable"] = dtCurrentTable; //Save DataTable back to ViewState
                        gvParticipant.DataSource = dtCurrentTable; //Bind GridView with New Row
                        gvParticipant.DataBind();
                    }
                    SetPreviousData();
                }
                else
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Participant Limit Reached!";
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                int rowCount = dt.Rows.Count;
                int MaxParticipants = Convert.ToInt32(Session["MaximumParticipants"]) + 1;
                if (rowCount < MaxParticipants)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            TextBox txtpname = (TextBox)gvParticipant.Rows[rowIndex].Cells[2].FindControl("txtParticipantName");
                            DropDownList ddlpgender = (DropDownList)gvParticipant.Rows[rowIndex].Cells[3].FindControl("ddlParticipantGender");
                            DropDownList ddlpgrade = (DropDownList)gvParticipant.Rows[rowIndex].Cells[4].FindControl("ddlParticipantGrade");

                            lblFestName.Text = Session["FestName"].ToString();
                            lblEventName.Text = Session["EventName"].ToString();
                            txtpname.Text = dt.Rows[i]["ParticipantName"].ToString();
                            ddlpgender.SelectedValue = dt.Rows[i]["ParticipantGender"].ToString();
                            ddlpgrade.SelectedValue = dt.Rows[i]["ParticipantGrade"].ToString();

                            rowIndex++;
                        }
                    }
                }
            }
        }
        public void Page_Load(object sender, EventArgs e)
        {
            lblFestName.Text = Session["FestName"].ToString();
            lblEventName.Text = Session["EventName"].ToString();
            lblSchoolEmail.Text = Session["SchoolEmail"].ToString();
            if (!Page.IsPostBack)
            {
                SetInitialRow();
            }
        }
        protected void btnAddANewParticipant_Click(object sender, EventArgs e)
        {
            //Add validation
            AddNewRowToGrid();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bulk_Insert();
        }

        protected void Bulk_Insert()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            DataTable participantdetailstd = new DataTable();
            DataRow dr;

            participantdetailstd.Columns.Add(new DataColumn("FestName", typeof(string)));
            participantdetailstd.Columns.Add(new DataColumn("EventName", typeof(string)));
            participantdetailstd.Columns.Add(new DataColumn("ParticipantName", typeof(string)));
            participantdetailstd.Columns.Add(new DataColumn("ParticipantGender", typeof(string)));
            participantdetailstd.Columns.Add(new DataColumn("ParticipantGrade", typeof(string)));
            participantdetailstd.Columns.Add(new DataColumn("SchoolEmail", typeof(string)));

            /*foreach (TableCell cell in gvParticipant.HeaderRow.Cells)
            {
                participantdetailstd.Columns.Add(cell.Text);
            }

            participantdetailstd.Columns.Add(new DataColumn("SchoolEmail", typeof(string)));*/

            foreach (GridViewRow row in gvParticipant.Rows)
            {
                participantdetailstd.Rows.Add();
                int i = 0;
                for (i = 0; i < row.Cells.Count-1; i++)
                {
                    if (i == 2)
                    {
                        TextBox txtpname = (TextBox)gvParticipant.Rows[row.RowIndex].Cells[2].FindControl("txtParticipantName");
                        participantdetailstd.Rows[row.RowIndex][i] = txtpname.Text;
                    }
                    else if (i ==3)
                    {
                        DropDownList ddlpgender = (DropDownList)gvParticipant.Rows[row.RowIndex].Cells[3].FindControl("ddlParticipantGender");
                        participantdetailstd.Rows[row.RowIndex][i] = ddlpgender.SelectedValue;
                    }
                    else if (i == 4)
                    {
                        DropDownList ddlpgrade = (DropDownList)gvParticipant.Rows[row.RowIndex].Cells[4].FindControl("ddlParticipantGrade");
                        participantdetailstd.Rows[row.RowIndex][i] = ddlpgrade.SelectedValue;
                    }
                    else
                    {
                        participantdetailstd.Rows[row.RowIndex][i] = row.Cells[i].Text;
                    }
                }
                participantdetailstd.Rows[row.RowIndex][i] = lblSchoolEmail.Text;
            }

            try
            {
                con.Open();
                SqlBulkCopy objbulk = new SqlBulkCopy(con);
                objbulk.DestinationTableName = "ParticipantDetails";
                objbulk.ColumnMappings.Add("FestName", "FestName");
                objbulk.ColumnMappings.Add("EventName", "EventName");
                objbulk.ColumnMappings.Add("SchoolEmail", "SchoolEmail");
                objbulk.ColumnMappings.Add("ParticipantName", "ParticipantName");
                objbulk.ColumnMappings.Add("ParticipantGender", "ParticipantGender");
                objbulk.ColumnMappings.Add("ParticipantGrade", "ParticipantGrade");
                objbulk.WriteToServer(participantdetailstd);
                con.Close();
                lblErrorMessage.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "You have successfully added all participants!"; ;
            }

            catch (Exception e)
            {
                lblErrorMessage.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "Participant Registration Failed. Please try again!";
            }
        }

        protected void gvParticipant_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblErrorMessage.Visible = false;
            int index = Convert.ToInt32(e.RowIndex);

            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[index]);
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                gvParticipant.DataSource = dt;
                gvParticipant.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReturnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolEventDetailsPage.aspx");
        }

        protected void btnLogoutSchool_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchoolLoginPage.aspx");
        }

        protected void gvParticipant_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                string constr = ConfigurationManager.ConnectionStrings["mycon"].ToString(); 
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                var ddlGrade = (DropDownList)e.Row.FindControl("ddlParticipantGrade");

                string qry = "SELECT EligibleGrades FROM EventEligibleGrades WHERE EventName = '" + Session["EventName"].ToString() + "'";
                SqlCommand com = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                ddlGrade.DataSource = dt;
                ddlGrade.DataTextField = "EligibleGrades";
                ddlGrade.DataValueField = "EligibleGrades";
                ddlGrade.DataBind();
            }
        }
    }
}