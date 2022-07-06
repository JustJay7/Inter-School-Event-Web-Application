<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventCoordinatorRegistrationPage.aspx.cs" Inherits="ISEWA.EventCoordinatorsRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
    <script src="EventCoordinatorRegistrationPageValidation.js" type="text/javascript"></script>  
    <style type="text/css">
        body {background-color: #343148;}
        .auto-style10 {
            margin-left: 3px;
            margin-top: 4px;
        }
        .auto-style1 {
            width: 845px;
            height: 362px;
            margin-left: 206px;
        }
        .auto-style7 {
            margin-left: 120px;
        }
        .auto-style6 {
            height: 50px;
            margin-left: 200px;
        }
        .auto-style8 {
            margin-left: 29px;
        }
        .auto-style9 {
            margin-left: 578px;
            height: 35px;
        }
        .auto-style2 {
            margin-left: 535px;
            height: 35px;
        }
        .auto-style13 {
            width: 443px;
            height: 50px;
        }
        .auto-style14 {
            height: 50px;
        }
        .auto-style15 {
            margin-left: 0px;
        }
        .auto-style16 {
            margin-left: 17px;
        }
        </style>
</head>
<body style="height: 589px; margin-left: 0px; margin-bottom: 18px; width: 1279px; margin-top: 0px;">
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel2" runat="server" BackColor="#343148">
                <br />
            </asp:Panel>
            <asp:Panel ID="Panel1" BackColor="RoyalBlue" runat="server" Height="35px" Width="100%">
                <asp:Button ID="btnHomePage" runat="server" Text="Home" Width="85px" CssClass="auto-style10" Font-Size="Small" Height="28px" BackColor="#D7C49E" OnClick="btnHomePage_Click" />
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
    </div>  
               <table class="auto-style1">  
                <tr>  
                    <td colspan="2" style="background-color: royalblue; height: 30px; width: 100% ; color: White;" class="auto-style7">  
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label8" runat="server" Text="Event Coordinators Registration Page" Width="417px" Font-Size="Large" ForeColor="Black" CssClass="auto-style15"></asp:Label>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style13"> 
                        <asp:Label ID="Label1" runat="server" ForeColor="#D7C49E" Text="Event Coordinator Name" Font-Size="Large"></asp:Label>
                    </td>  
                    <td class="auto-style6">  
           &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
           <asp:TextBox ID="txtEventCoordinatorName" Width="264px" ValidationGroup="Validform" runat="server" CssClass="auto-style8"></asp:TextBox> 
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style13"> 
                        <asp:Label ID="Label2" runat="server" ForeColor="#D7C49E" Text="Event Coordinator Email" Font-Size="Large"></asp:Label>
                    </td>  
                    <td class="auto-style14">  
                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                        <asp:TextBox ID="txtEventCoordinatorEmail" runat="server" Width="264px" CssClass="auto-style8"></asp:TextBox>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style13"> 
                        <asp:Label ID="Label3" runat="server" ForeColor="#D7C49E" Text="Event Coordinator Phone Number" Font-Size="Large"></asp:Label>
                    </td>  
                    <td class="auto-style14">  
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtEventCoordinatorPhoneNumber" runat="server" Width="264px" CssClass="auto-style8"></asp:TextBox>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style13"> 
                        <asp:Label ID="Label6" runat="server" ForeColor="#D7C49E" Text="Create Password" Font-Size="Large"></asp:Label>
                    </td>  
             <td class="auto-style14">  
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
            <asp:TextBox ID="txtEventCoordinatorCreatePassword" Width="264px" runat="server" TextMode="Password" CssClass="auto-style8" ></asp:TextBox>  
                    </td>  
               </tr>  
               <tr>
                    <td class="auto-style13"> 
                        <asp:Label ID="Label7" runat="server" ForeColor="#D7C49E" Text="Confirm Pasword" Font-Size="Large"></asp:Label>
                    </td>  
              <td class="auto-style14">  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                    <asp:TextBox ID="txtEventCoordinatorConfirmPassword" Width="264px" runat="server" TextMode="Password" CssClass="auto-style8" ></asp:TextBox>
                    </td> 
                        &nbsp;  
               </tr>
               </table>
         <p class="auto-style9">
         &nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="BtnRegisterEventCoordinator" runat="server" Width="100px" Text="Register" OnClientClick="return EventCoordinatorRegistrationPageValidation();" OnClick="BtnRegisterEventCoordinator_Click" Height="28px" />  
                        </p>
        <p class="auto-style2">
            <asp:Label ID="lblErrorMessage" runat="server" Visible="False" Height="35px" Width="508px" ForeColor="Red" CssClass="auto-style16"></asp:Label>
                        </p>
         </form>
</body>
</html>
