<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminViewSchoolFeedbackPage.aspx.cs" Inherits="ISEWA.AdminViewSchoolFeedbackPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {background-color: #343148;}
        .auto-style13 {
            margin-top: 0px;
            width: 1279px;
            height: 607px;
        }
        .auto-style2 {
            display: block;
            overflow: auto;
            background-color: #EFE2BA;
        }
        .auto-style11 {
            margin-top: 0px;
        }
        .auto-style10 {
            margin-left: 3px;
            margin-top: 4px;
        }
        .auto-style15 {
            margin-left: 40px;
            height: 359px;
        }
        .auto-style16 {
            margin-left: 0px;
            margin-top: 4px;
        }
        </style>
</head>
<body style="margin-left: 0px; margin-top: 0px">
    <form id="form2" runat="server" class="auto-style13">
        <div class="auto-style2" style="opacity: 1;" background-color: #343148>
            <asp:Panel ID="Panel5" runat="server" BackColor="#343148" CssClass="auto-style11">
                <br />
            </asp:Panel>
        </div>
            <asp:Panel ID="Panel7" BackColor="RoyalBlue" runat="server" Height="35px" Width="100%" CssClass="auto-style11">
                <asp:Button ID="btnHome" runat="server" Text="Home" Width="85px" CssClass="auto-style10" Font-Size="Small" Height="28px" BackColor="#D7C49E" OnClick="btnHome_Click" />
                <asp:Button ID="btnReturnToPreviousPage1" runat="server" CssClass="auto-style16" Font-Size="Small" Height="28px" Text="Return To The Previous Page" Width="225px" BackColor="#D7C49E" OnClick="btnReturnToPreviousPage1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label16" runat="server" ForeColor="Gold" Text="Logged In As - "></asp:Label>
                <asp:Label ID="lblAdminEmail" runat="server" ForeColor="Gold"></asp:Label>
                &nbsp;<asp:Button ID="btnLogoutAdmin" runat="server" CssClass="auto-style10" Font-Size="Small" Height="28px" Text="Logout" Width="90px" BackColor="#D7C49E" OnClick="btnLogoutAdmin_Click"/>
            </asp:Panel>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:Label ID="Label17" runat="server" ForeColor="Gold" Text="View School Feedback" Font-Size="Large"></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label13" runat="server" ForeColor="#ADEFD1" Text="Choose A Fest"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label20" runat="server" ForeColor="#ADEFD1" Text="Choose A School"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlFestName" runat="server">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlSchoolEmail" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            &nbsp;&nbsp;
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            <br />
            <br />
            <br />
            <div class="auto-style15">
        <asp:GridView ID="gvViewFeedback" runat="server" AutoGenerateColumns="False" Height="200px" Width="1124px" BorderColor="Tan" HorizontalAlign="Center" BackColor="LightGoldenrodYellow" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AllowSorting="True">
            <RowStyle HorizontalAlign="Center"></RowStyle>
            <AlternatingRowStyle BackColor="#7e6896" />
<Columns>
    <asp:BoundField DataField="FestName" HeaderText="Fest Name" />
    <asp:BoundField DataField="SchoolEmail" HeaderText="School Email" />
    <asp:BoundField DataField="FestRate" HeaderText="Rating Of The Fest (out of 5)" />
    <asp:BoundField DataField="OrganizationOfFestRate" HeaderText="Rating Of How Organized The Fest was (out of 5)" />
    <asp:BoundField DataField="ReturnRate" HeaderText="Will The School Be Willing to Return?" />
    <asp:BoundField DataField="LikesAboutFestOrEvent" HeaderText="What Did The School Like About The Fest/Event?" />
    <asp:BoundField DataField="DislikesAboutFestOrEvent" HeaderText="What Did The School Dislike About The Fest/Event?" />
    <asp:BoundField DataField="GeneralThoughts" HeaderText="Open Ended Feedback" />
</Columns>
            <FooterStyle BackColor="#ff9900" />
            <HeaderStyle BackColor="#ff9900" Font-Bold="True" />
            <PagerStyle BackColor="#7e6896" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        </div>
    </form>
            <br />
    </body>
</html>
