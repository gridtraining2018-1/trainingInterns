<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="Forum.ForgetPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">
    <table border="0" class="innercontainer" >
   <tr>
              <td class="gray"><a href="Index.aspx">Home</a> </td>
              <td align="right">
               &nbsp;              </td>
          </tr>
          <tr>
              <td><h1> Account Recovery</h1></td>
              <td align="right">
              
              </td>
          </tr>
               <tr>
              <td>If you already have a account on this forum but can't remember your username or password, enter your email address below.</td>
            <td>&nbsp;</td>
          </tr>
      </table>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <table width="100%" class="PlaneinnercontainerBio">
<tr><td style="width: 394px">&nbsp;</td><td>&nbsp;</td></tr>
          <tr>
        <td style="width: 394px">
          <strong>E-Mail</strong> :&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtAccountRecovery" runat="server" CssClass="Formlong"></asp:TextBox><br /><br />
            </td>
        <td>
            &nbsp;</td>
        </tr>
          <tr>
        <td colspan="2" style="width: 394px" align="left">
            <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
        <td style="width: 394px" align="center" >
            <asp:Button ID="btnAccountRecovery" runat="server" Text="Send Account Recovery" 
                onclick="btnAccountRecovery_Click" align="center" /><br /><br />
            </td>
        <td>
            &nbsp;</td>
        </tr>
        </table>
</asp:Content>
