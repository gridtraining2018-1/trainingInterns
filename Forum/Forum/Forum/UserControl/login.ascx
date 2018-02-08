<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="Forum.UserControl.login" %>

<table width="100%">
    <tr>
        <td  colspan="3">
           <strong>Email</strong></td>
        <td>
            <asp:TextBox ID="txtUserName" CssClass="Formlong" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email" Text="*" ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
  

        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1" colspan="3">
            <strong>  Password</strong></td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="Formlong"  TextMode="Password"></asp:TextBox>  
            <asp:RequiredFieldValidator ID="reqtxtRealName" runat="server" ErrorMessage="Password" Text="*" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
  
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td >
            &nbsp;</td>
        <td >
            &nbsp;</td>
        <td >
            &nbsp;</td>
        <td>
            <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember me" Checked ="false" /><br /></td>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td >
            &nbsp;</td>
        <td >
            &nbsp;</td>
        <td >
            &nbsp;</td>
        <td>
         <asp:Button ID="btnLogin" runat="server" Text="Login"  OnClientClick="javascript:return FormValidateSave();" onclick="btnLogin_Click" />
                    
        </td>
        <td>
            &nbsp;</td>
    </tr>


    <tr>
        <td >
            &nbsp;</td>
        <td >
            &nbsp;</td>
        <td >
            &nbsp;</td>
        <td>
         <a href="../ForgetPassword.aspx">Can't access your account?</a>   
           
        </td>
        <td>
            &nbsp;</td>
    </tr>


</table>

