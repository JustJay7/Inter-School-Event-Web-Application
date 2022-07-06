<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEventMakingPage.aspx.cs" Inherits="ISEWA.AdminEventMakingPage" Culture = "en-GB"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="AdminEventMakingPageValidations.js" type="text/javascript"></script>
    <style type="text/css">
        body {background-color: #343148;}
        .auto-style1 {
            width: 840px;
            height: 420px;
            margin-left: 222px;
            margin-right: 0px;
        }
        .auto-style7 {
            margin-left: 530px;
            height: 34px;
            margin-top: 0px;
            width: 707px;
        }
        .auto-style8 {
            margin-top: 0px;
        }
        .auto-style9 {
            margin-left: 620px;
            margin-top: 43px;
        }
        .auto-style11 {
            margin-top: 0px;
        }
        .auto-style10 {
            margin-left: 3px;
            margin-top: 4px;
        }
        .auto-style12 {
            margin-left: 0px;
        }
        .auto-style14 {
            width: 553px;
        }
        .auto-style15 {
            width: 422px;
        }
        .auto-style16 {
            margin-left: 1px;
        }
        .auto-style17 {
            height: 589px;
            width: 1270px;
        }
        .auto-style18 {
            margin-left: 0px;
            margin-top: 4px;
        }
    </style>
</head>
<body style="height: 589px; margin-left: 0px; margin-bottom: 18px; width: 1270px; margin-top: 0px;">
    <form id="form1" runat="server" class="auto-style17">
        <div>
        <div>
            <asp:Panel ID="Panel4" runat="server" BackColor="#343148" CssClass="auto-style11">
                <br />
            </asp:Panel>
            <asp:Panel ID="Panel1" BackColor="RoyalBlue" runat="server" Height="35px" Width="100%" CssClass="auto-style8">
                <asp:Button ID="btnHome" runat="server" Text="Home" Width="85px" CssClass="auto-style10" Font-Size="Small" Height="28px" BackColor="#D7C49E" OnClick="btnHome_Click" />
                <asp:Button ID="btnReturnToPreviousPage" runat="server" CssClass="auto-style18" Font-Size="Small" Height="28px" Text="Return To The Previous Page" Width="225px" BackColor="#D7C49E" OnClick="btnReturnToPreviousPage_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label11" runat="server" ForeColor="Gold" Text="Logged In As - "></asp:Label>
                <asp:Label ID="lblAdminEmail" runat="server" ForeColor="Gold"></asp:Label>
                <asp:Button ID="btnLogoutAdmin" runat="server" CssClass="auto-style10" Font-Size="Small" Height="28px" Text="Logout" Width="90px" BackColor="#D7C49E" OnClick="btnLogoutAdmin_Click" />
            </asp:Panel>
            <br />
            <br />
    </div>
    </div>
               <table class="auto-style1">  
                <tr>  
                    <td colspan="2" style="background-color: royalblue; height: 30px;color: Black;" align="center">  
                        Create An Event</td>  
                </tr>  
                <tr>  
                    <td class="auto-style14"> 
                        <asp:Label ID="Label8" runat="server" ForeColor="#D7C49E" Text="Fest Name"></asp:Label>
                    </td>  
                    <td class="auto-style15">  
                        &nbsp;<asp:DropDownList ID="ddlFestName" runat="server" Width="270px" CssClass="auto-style12">
                        </asp:DropDownList>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style14"> 
                        <asp:Label ID="Label7" runat="server" ForeColor="#D7C49E" Text="Event Name"></asp:Label>
&nbsp;</td>  
                    <td class="auto-style15">  
           &nbsp;<asp:TextBox ID="txtEventName" Width="264px" ValidationGroup="Validform" runat="server" CssClass="auto-style12"></asp:TextBox> 
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style14">  
                        <asp:Label ID="Label6" runat="server" ForeColor="#D7C49E" Text="Event Description"></asp:Label>
                    </td>  
                    <td class="auto-style15">  
            &nbsp;<asp:TextBox ID="txtEventDescription" Width="264px" ValidationGroup="Validform" runat="server" CssClass="auto-style12"></asp:TextBox>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style14">  
                        <asp:Label ID="Label5" runat="server" ForeColor="#D7C49E" Text="Event Coordinator"></asp:Label>
                    </td>  
                    <td class="auto-style15">  
                        &nbsp;<asp:DropDownList ID="ddlEventCoordinatorEmail" runat="server" Width="270px" CssClass="auto-style16">
                        </asp:DropDownList>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style14"> 
                        <asp:Label ID="Label9" runat="server" ForeColor="#D7C49E" Text="Event Criteria"></asp:Label>
                    </td>  
             <td class="auto-style15">  
                 &nbsp;</td>  
               </tr>  
                <tr>  
                    <td class="auto-style14"> 
                        <asp:Label ID="Label4" runat="server" ForeColor="#D7C49E" Text="Number Of Participants"></asp:Label>
                    </td>  
             <td class="auto-style15">  
                 &nbsp;<asp:DropDownList ID="ddlNumberOfParticipants" runat="server" CssClass="auto-style12" Width="270px">
                     <asp:ListItem>Select</asp:ListItem>
                     <asp:ListItem>1</asp:ListItem>
                     <asp:ListItem>2</asp:ListItem>
                     <asp:ListItem>3</asp:ListItem>
                     <asp:ListItem>4</asp:ListItem>
                     <asp:ListItem>5</asp:ListItem>
                 </asp:DropDownList>
                    </td>  
               </tr>  
                <tr>  
                    <td class="auto-style14"> 
                        <asp:Label ID="Label3" runat="server" ForeColor="#D7C49E" Text="Eligible Grades"></asp:Label>
                    </td>  
             <td class="auto-style15">  
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                 <asp:CheckBoxList ID="cblEligibleGrades" runat="server" ForeColor="#ADEFD1" Width="202px" CssClass="auto-style12">
                     <asp:ListItem>Grade 6</asp:ListItem>
                     <asp:ListItem>Grade 7</asp:ListItem>
                     <asp:ListItem>Grade 8</asp:ListItem>
                     <asp:ListItem>Grade 9</asp:ListItem>
                     <asp:ListItem>Grade 10</asp:ListItem>
                     <asp:ListItem>Grade 11</asp:ListItem>
                     <asp:ListItem>Grade 12</asp:ListItem>
                 </asp:CheckBoxList>
                </td>  
               </tr>  
                   <tr>
                    <td class="auto-style14">  
                        <asp:Label ID="Label2" runat="server" ForeColor="#D7C49E" Text="Date Of The Event"></asp:Label>
                       </td>  
                    <td class="auto-style15">  
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                 <asp:Calendar ID="Calendar1" runat="server" BackColor="#FF9912" OnSelectionChanged="Calendar1_SelectionChanged" CssClass="auto-style12" Width="314px">
                     <SelectedDayStyle BackColor="#343148" Font-Bold="True" />  
            <SelectorStyle BackColor="#FFCC66" />  
            <TodayDayStyle BackColor="#03A89E" ForeColor="Black" />  
            <OtherMonthDayStyle ForeColor="#006B38" />  
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />  
                 </asp:Calendar>
                        <asp:RangeValidator ID="RangeValidator" runat="server" EnableClientScript="true" Display="Dynamic" ControlToValidate="txtDateOfTheEvent" ForeColor="Red" SetFocusOnError="True" Visible="False">The Event has to be registered 1 to 3 months in advance.</asp:RangeValidator>
                        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                        <br />
                        &nbsp;<asp:TextBox ID="txtDateOfTheEvent" runat="server" Width="252px" ReadOnly="True"></asp:TextBox>
                    </td>  
                   </tr>
                   <tr>
                    <td class="auto-style14">  
                        <asp:Label ID="Label1" runat="server" ForeColor="#D7C49E" Text="Time Of The Event"></asp:Label>
                        <br />
                       </td>  
                    <td class="auto-style15">  
                        &nbsp;<asp:DropDownList ID="ddlTimeOfTheEvent" runat="server" CssClass="auto-style12" Width="259px">
                            <asp:ListItem>8 am - 10 am</asp:ListItem>
                            <asp:ListItem>10 am - 12 pm</asp:ListItem>
                            <asp:ListItem>12 pm - 2 pm</asp:ListItem>
                            <asp:ListItem>2 pm - 4 pm</asp:ListItem>
                        </asp:DropDownList>
                    </td>  
                   </tr>
               </table>  
        <p class="auto-style9">
             <asp:Button ID="BtnAddEvent" runat="server" Text="Add an Event" OnClientClick="return AdminEventMakingPageValidation();" OnClick="BtnAddEvent_Click" CssClass="auto-style8" BackColor="White" Font-Size="Medium" />
        </p>
         <div class="auto-style7">
             <asp:Label ID="lblMessage" runat="server" ForeColor="Gold"></asp:Label>
        </div>
         </form>
</body>
</html>
