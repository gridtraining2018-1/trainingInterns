<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="resetpassword.aspx.cs" Inherits="Forum.resetpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script type="text/jscript">
            function closeMsg()
                {
                    document.getElementById('<%=trError.ClientID%>').style.display='none';
                }
                function FormValidateSave() {
                    if (document.getElementById('<%=txtPassword.ClientID%>').value == '') {
                        document.getElementById('<%=trError.ClientID%>').style.display = 'block';
                        document.getElementById('<%=lblErrorMessage.ClientID%>').innerHTML = 'Please Enter Password';
                        document.getElementById('<%=txtPassword.ClientID%>').focus();
                        return false;
                    }

                    if (document.getElementById('<%=txtReenterPassword.ClientID%>').value == '') {
                        document.getElementById('<%=trError.ClientID%>').style.display = 'block';
                        document.getElementById('<%=lblErrorMessage.ClientID%>').innerHTML = 'Please Enter Repassword';
                        document.getElementById('<%=txtReenterPassword.ClientID%>').focus();
                        return false;
                    }


                    if (document.getElementById('<%=txtReenterPassword.ClientID%>').value != document.getElementById('<%=txtPassword.ClientID%>').value) {
                        document.getElementById('<%=trError.ClientID%>').style.display = 'block';
                        document.getElementById('<%=lblErrorMessage.ClientID%>').innerHTML = 'Password and Repassword is not matching';
                        document.getElementById('<%=txtReenterPassword.ClientID%>').focus();
                        return false;
                    }
                }
 </script>
    <table style="width: 100%">
        <tr>
            <td colspan="2">
                <h1>Reset Password</h1></td>
        </tr>
        <tr>
            <td colspan="2">
                 <div style="display: none;" id="trError" runat="server" >
                <div class="gray_strip">
                    <table width="100%"  border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="8%" height="30" valign="top" >
                                <img src="Styles/Images/err.jpeg" /></td>
                            <td width="85%" valign="top" height="30">
                                <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                            </td>
                            <td width="7%" valign="top" height="30">
                                 <img src="Styles/Images/index.jpeg" onclick="closeMsg()" />
                                  </td>
                        </tr>
                    </table>
                </div>
            </div></td>
        </tr>
        <tr>
            <td style="width: 187px">
                Enter Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 187px">
                Enter Password again</td>
            <td>
                <asp:TextBox ID="txtReenterPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" 
                    onclick="btnChangePassword_Click" OnClientClick="javascript:return FormValidateSave();" />
            </td>
        </tr>
    </table>
</asp:Content>
