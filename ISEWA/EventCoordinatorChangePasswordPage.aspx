<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventCoordinatorChangePasswordPage.aspx.cs" Inherits="ISEWA.EventCoordinatorChangePasswordPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {background-color: #343148;}
        .auto-style12 {
            height: 589px;
        }
        .auto-style10 {
            margin-left: 3px;
            margin-top: 4px;
        }
        .auto-style1 {
            width: 915px;
            height: 143px;
            margin-bottom: 15px;
            margin-left: 181px;
            margin-right: 0px;
        }
        .auto-style5 {
            height: 74px;
            width: 356px;
        }
        .auto-style4 {
            height: 74px;
        }
        .auto-style11 {
            margin-top: 19px;
        }
        .auto-style18 {
            margin-left: 0px;
            margin-top: 4px;
        }
        </style>
</head>
<body style="height: 679px; width: 1279px; margin-left: 0px; margin-top: 0px">
    <form id="form1" runat="server" class="auto-style12">
            <asp:Panel ID="Panel4" runat="server" BackColor="#343148">
                <br />
            </asp:Panel>
            <asp:Panel ID="Panel3" BackColor="RoyalBlue" runat="server" Height="35px" Width="100%">
                <asp:Button ID="btnHomePage" runat="server" Text="Home" Width="85px" CssClass="auto-style10" Font-Size="Small" Height="28px" BackColor="#D7C49E" OnClick="btnHomePage_Click" />
                <asp:Button ID="btnReturnToPreviousPage" runat="server" BackColor="#D7C49E" CssClass="auto-style18" Font-Size="Small" Height="28px" OnClick="btnReturnToPreviousPage_Click" Text="Return To The Previous Page" Width="225px" />
            </asp:Panel>
            <asp:Panel ID="Panel6" runat="server" Height="503px">
                <table class="auto-style1">
                    <tr>
                        <td colspan="2" style="background-color: #4169e1; height: 30px;color: White;" align="center">
                            <asp:Label ID="Label6" runat="server" Text="Change Your Password"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="Label2" runat="server" ForeColor="Gold" Text="Registered Email ID"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtEventCoordinatorEmail" runat="server" Width="264px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ForeColor="#CC0000"
                        ValidationGroup="Validform" ControlToValidate="txtEventCoordinatorEmail" runat="server" ErrorMessage="Please Enter Your Current EmailID" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="Label1" runat="server" ForeColor="Gold" Text="Current Password"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtCurrentPassword" Width="264px" ValidationGroup="Validform" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ForeColor="#CC0000"
                        ValidationGroup="Validform" ControlToValidate="txtCurrentPassword" runat="server" ErrorMessage="Please Enter Your Current Password" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="Label4" runat="server" ForeColor="Gold" Text="New Password"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtNewPassword" Width="264px" ValidationGroup="Validform" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ForeColor="#CC0000"
                        ValidationGroup="Validform" ControlToValidate="txtNewPassword" runat="server" ErrorMessage="Please Enter A New Password" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="Label5" runat="server" ForeColor="Gold" Text="Confirm Password"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtConfirmPassword" Width="264px" ValidationGroup="Validform" runat="server" TextMode="Password" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" ForeColor="#CC0000"
                        ValidationGroup="Validform" ControlToValidate="txtConfirmPassword" runat="server" ErrorMessage="Please Re-Enter Your New Password" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" Display="Dynamic" ForeColor="#CC0000" 
                        ValidationGroup="Validform" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" runat="server" ErrorMessage="The Passwords Are Not The Same. Please Try Again" SetFocusOnError="True"></asp:CompareValidator>
                        </td>
                    </tr>
                    <caption>
                        &nbsp;
                        </tr>
                        <br />
                        <br />
                        <br />
                        <br />
                    </caption>
                </table>
                <asp:Panel ID="Panel8" runat="server" Width="1277px" CssClass="auto-style11">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Button ID="BtnResetPassword" runat="server" OnClick="BtnChangePassword_Click" Text="Change Password" Width="147px" Height="31px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </asp:Panel>
                <asp:Panel ID="Panel9" runat="server">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Gold"></asp:Label>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </asp:Panel>
            </asp:Panel>
            <br />
    </form>
</body>
</html>
