<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolRegistrationPage.aspx.cs" Inherits="ISEWA.RegisterYourSchool" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
    <script src="SchoolUserValidation.js" type="text/javascript"></script>  
    <style type="text/css">
         body {background-color: #343148;}
        .auto-style1 {
            width: 845px;
            height: 362px;
            margin-left: 206px;
        }
        .auto-style7 {
            margin-left: 120px;
        }
        .auto-style5 {
            width: 443px;
            height: 41px;
        }
        .auto-style6 {
            height: 41px;
            margin-left: 200px;
        }
        .auto-style4 {
            width: 443px;
        }
        .auto-style2 {
            margin-left: 470px;
            height: 35px;
            margin-top: 0px;
        }
        .auto-style8 {
            margin-left: 29px;
        }
        .auto-style9 {
            margin-left: 578px;
            height: 36px;
        }
        .auto-style10 {
            margin-left: 3px;
            margin-top: 4px;
        }
        .auto-style11 {
            margin-top: 0px;
        }
        .auto-style12 {
            margin-left: 45px;
        }
        </style>
</head>
<body style="height: 589px; margin-left: 0px; margin-bottom: 18px; width: 1279px; margin-top: 0px;">
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Panel ID="Panel1" BackColor="RoyalBlue" runat="server" Height="35px" Width="100%" CssClass="auto-style11">
                <asp:Button ID="btnHome" runat="server" Text="Home" Width="85px" CssClass="auto-style10" Font-Size="Small" Height="28px" BackColor="#D7C49E" OnClick="btnHome_Click" />
            </asp:Panel>
            <br />
            <br />
            <br />
    </div>  
               <table class="auto-style1">  
                <tr>  
                    <td colspan="2" style="background-color: royalblue; height: 30px; width: 100% ; color: White;" class="auto-style7">  
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label8" runat="server" Text="Register Your School" Width="244px" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style5"> 
                        <asp:Label ID="Label1" runat="server" ForeColor="#D7C49E" Text="School Name" Font-Size="Large"></asp:Label>
                    </td>  
                    <td class="auto-style6">  
           &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
           <asp:TextBox ID="txtSchoolName" Width="264px" ValidationGroup="Validform" runat="server" CssClass="auto-style8"></asp:TextBox> 
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style4"> 
                        <asp:Label ID="Label2" runat="server" ForeColor="#D7C49E" Text="School Address" Font-Size="Large"></asp:Label>
                    </td>  
                    <td>  
                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                        <asp:TextBox ID="txtSchoolAddress" runat="server" Width="264px" CssClass="auto-style8"></asp:TextBox>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style4"> 
                        <asp:Label ID="Label3" runat="server" ForeColor="#D7C49E" Text="School Phone Number" Font-Size="Large"></asp:Label>
                    </td>  
                    <td>  
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSchoolPhoneNumber" runat="server" Width="264px" CssClass="auto-style8"></asp:TextBox>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style4">  
                        <asp:Label ID="Label4" runat="server" ForeColor="#D7C49E" Text="School Contact Person's Name" Font-Size="Large"></asp:Label>
                    </td>  
                    <td>  
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                        <asp:TextBox ID="txtSchoolContactPersonName" runat="server" Width="264px" CssClass="auto-style8"></asp:TextBox>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style4">  
                        <asp:Label ID="Label5" runat="server" ForeColor="#D7C49E" Text="School Contact Email" Font-Size="Large"></asp:Label>
                    </td>  
                    <td>  
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
            <asp:TextBox ID="txtSchoolContactEmail" Width="264px" ValidationGroup="Validform" runat="server" CssClass="auto-style8"></asp:TextBox>
                    </td>  
                </tr>  
                <tr>  
                    <td class="auto-style4"> 
                        <asp:Label ID="Label6" runat="server" ForeColor="#D7C49E" Text="Create Password" Font-Size="Large"></asp:Label>
                    </td>  
             <td>  
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
            <asp:TextBox ID="txtCreatePassword" Width="264px" runat="server" TextMode="Password" CssClass="auto-style8" ></asp:TextBox>  
                    </td>  
               </tr>  
               <tr>
                    <td class="auto-style4"> 
                        <asp:Label ID="Label7" runat="server" ForeColor="#D7C49E" Text="Confirm Pasword" Font-Size="Large"></asp:Label>
                    </td>  
              <td>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                    <asp:TextBox ID="txtConfirmPassword" Width="264px" runat="server" TextMode="Password" CssClass="auto-style8" ></asp:TextBox>
                    </td> 
                        &nbsp;  
               </tr>
               </table>
         <p class="auto-style9">
         &nbsp;
         <asp:Button ID="BtnRegister" runat="server" Width="100px" Text="Register" 
             OnClientClick="return SchoolUserValidation();" OnClick="BtnRegister_Click" Height="35px" />  
                        </p>
        <p class="auto-style2">
            <asp:Label ID="lblErrorMessage" runat="server" Visible="False" Height="35px" Width="564px" ForeColor="Red" CssClass="auto-style12"></asp:Label>
                        </p>
         </form>
</body>
</html>


