<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolFeedbackPage.aspx.cs" Inherits="ISEWA.School_Feedback_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
         body {background-color: #343148;}
        .auto-style1 {
            margin-top: 0px;
            width: 891px;
            margin-left: 188px;
        }
        .auto-style11 {
            margin-top: 0px;
        }
        .auto-style10 {
            margin-left: 3px;
            margin-top: 4px;
        }
        .auto-style6 {
            width: 1029px;
        }
        .auto-style12 {
            height: 30px;
            width: 1029px;
        }
        .auto-style13 {
            margin-top: 0px;
            height: 1209px;
            margin-left: 0px;
        }
        </style>
</head>
<body style="margin: 0px; height: 1209px; width: 1279px;">
    <form id="form1" runat="server">
        <div class="auto-style13">
            <asp:Panel ID="Panel4" runat="server" BackColor="#343148">
                <br />
            </asp:Panel>
            <asp:Panel ID="Panel1" BackColor="RoyalBlue" runat="server" Height="35px" Width="100%" CssClass="auto-style11">
                <asp:Button ID="btnHome" runat="server" Text="Home" Width="85px" CssClass="auto-style10" Font-Size="Small" Height="28px" BackColor="#D7C49E" OnClick="btnHome_Click" />
                <asp:Button ID="btnReturnToPreviousPage" runat="server" BackColor="#D7C49E" CssClass="auto-style10" Font-Size="Small" Height="28px" OnClick="btnReturnToPreviousPage_Click" Text="Return To The Previous Page" Width="225px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="Logged In As - " ForeColor="Gold"></asp:Label>
                <asp:Label ID="lblSchoolEmail" runat="server" ForeColor="Gold"></asp:Label>
                &nbsp;<asp:Button ID="btnLogoutSchool" runat="server" CssClass="auto-style10" Font-Size="Small" Height="28px" OnClick="btnLogoutSchool_Click" Text="Logout" Width="90px" BackColor="#D7C49E" />
            </asp:Panel>
            <br />
            <br />
            <br />
               <table class="auto-style1">  
                <tr>  
                    <td style="background-color: royalblue; color: black;" align="center" class="auto-style12">  
                        Feedback Form</td>  
                </tr>  
                <tr>  
                    <td class="auto-style6"> 
                        <br />
                        <asp:Label ID="Label8" runat="server" ForeColor="#D7C49E" Text="For Our General Knowledge"></asp:Label>
                        <br />
                        <br />
                        <br />
                    </td>  
                </tr>  
                   <tr>
                    <td class="auto-style6"> 
                        <asp:Label ID="lblFestName" runat="server" ForeColor="#D7C49E" Text="Please select the Fest that you would like to give feedback for"></asp:Label>
&nbsp;<br />
                        <asp:DropDownList ID="ddlFestName" runat="server">
                        </asp:DropDownList>
                    </td>  
                   </tr>
                <tr>  
                    <td class="auto-style6"> 
                        <asp:Label ID="Label7" runat="server" ForeColor="#D7C49E" Text="Overall, how much would you rate the Fest?"></asp:Label>
&nbsp;<br />
                        <asp:Label ID="Label11" runat="server" ForeColor="#D7C49E" Text="1 = Very Poor"></asp:Label>
&nbsp;&nbsp;&nbsp; 
                        <asp:Label ID="Label12" runat="server" ForeColor="#D7C49E" Text="2 = Poor"></asp:Label>
&nbsp;&nbsp;&nbsp; 
                        <asp:Label ID="Label13" runat="server" ForeColor="#D7C49E" Text="3 = Good"></asp:Label>
&nbsp;&nbsp;&nbsp; 
                        <asp:Label ID="Label14" runat="server" ForeColor="#D7C49E" Text="4 = Very Good"></asp:Label>
&nbsp;&nbsp;&nbsp; 
                        <asp:Label ID="Label15" runat="server" ForeColor="#D7C49E" Text="5 = Excellent"></asp:Label>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style6">  
                        <asp:RadioButtonList ID="rblRateFest" runat="server" RepeatDirection="Horizontal" ForeColor="#ADEFD1" Width="764px">
                            <asp:ListItem>1</asp:ListItem>  
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem> 
                            <asp:ListItem>5</asp:ListItem> 
                        </asp:RadioButtonList>
                    </td>   
                </tr>  
                <tr>  
                    <td class="auto-style6">  
                        <br />
                        <asp:Label ID="Label5" runat="server" ForeColor="#D7C49E" Text="How organized was the fest?"></asp:Label>
                        <br />
                        <asp:Label ID="Label16" runat="server" ForeColor="#D7C49E" Text="1 = Not at all Organized"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label17" runat="server" ForeColor="#D7C49E" Text="2 = Poorly Organized"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label18" runat="server" ForeColor="#D7C49E" Text="3 = Somewhat Organized"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label19" runat="server" ForeColor="#D7C49E" Text="4 = Very Organized"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label20" runat="server" ForeColor="#D7C49E" Text="5 = Extremely Organized"></asp:Label>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style6"> 
                        <asp:RadioButtonList ID="rblOrganizedFest" runat="server" RepeatDirection="Horizontal" ForeColor="#ADEFD1" Width="764px">
                            <asp:ListItem>1</asp:ListItem>  
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem> 
                            <asp:ListItem>5</asp:ListItem> 
                        </asp:RadioButtonList>
                    </td>  
               </tr>  
                <tr>  
                    <td class="auto-style6"> 
                        <br />
                        <asp:Label ID="Label4" runat="server" ForeColor="#D7C49E" Text="Will you be willing to return to our school for future fests?"></asp:Label>
                    </td>
               </tr>  
                <tr>  
                    <td class="auto-style6"> 
                        <asp:RadioButtonList ID="rblFutureFests" runat="server" RepeatDirection="Horizontal" ForeColor="#ADEFD1" Width="764px">
                            <asp:ListItem>Yes</asp:ListItem>  
                            <asp:ListItem>No</asp:ListItem>
                            <asp:ListItem>Maybe</asp:ListItem>
                        </asp:RadioButtonList>
                    </td> 
               </tr>  
                   <tr>
                    <td class="auto-style6">  
                        <br />
                        <asp:Label ID="Label2" runat="server" ForeColor="#D7C49E" Text="What did you like about the fest/events?"></asp:Label>
                       </td>  
                   </tr>
                   <tr>
                    <td class="auto-style6">  
                        <asp:TextBox ID="txtSchoolLikes" runat="server" Height="40px" Width="877px"></asp:TextBox>
                       </td>  
                   </tr>
                   <tr>
                   <td class="auto-style6">  
                        <br />
                        <asp:Label ID="Label" runat="server" ForeColor="#D7C49E" Text="What did you dislike about the fest/events?"></asp:Label>
                       </td> 
                   </tr>
                   <tr>
                    <td class="auto-style6">  
                        <asp:TextBox ID="txtSchoolDislikes" runat="server" Height="40px" Width="877px"></asp:TextBox>
                       </td>  
                   </tr>
                   <tr>
                   <td class="auto-style6">  
                        <br />
                        <asp:Label ID="Label3" runat="server" ForeColor="#D7C49E" Text="Is there anything else that you'd like to share about the fest/events?"></asp:Label>
                       </td> 
                   </tr>
                   <tr>
                    <td class="auto-style6">  
                        <asp:TextBox ID="txtSchoolThoughts" runat="server" Height="40px" Width="877px"></asp:TextBox>
                       </td>  
                   </tr>
               </table>  
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmitFeedback" runat="server" OnClick="btnSubmitFeedback_Click" Text="Submit Feedback" Width="200px" Height="28px" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMessage" runat="server" ForeColor="Gold" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
