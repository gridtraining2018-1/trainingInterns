<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Forum.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">

<table border="0" class="innercontainer" >
   <tr>
              <td class="gray"> <a href="Index.aspx">Home</a> &#9654;<asp:HyperLink ID="hylCurrentPage" runat="server">HyperLink</asp:HyperLink></td>
              <td >
             
                       </td>
          </tr>
          <tr>
              <td><h1><asp:Label ID="lblForumName" runat="server" Text=""></asp:Label></h1></td>
              <td align="right">
               
              </td>
          </tr>
               <tr>
              <td><asp:Label ID="lblForumDescription" runat="server" Text=""></asp:Label></td>
              <td align="right">
                  
              </td>
          </tr>
                    <tr>
              <td>   <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="<div class='validationheader'>You must enter a value in the following field(s)</div>" DisplayMode="BulletList" EnableClientScript="true" CssClass="validationsummary"   />
          </td>
              <td align="right">
                                     </td>
          </tr>
      </table>
      </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
<table style="width: 100%" class="PlaneinnercontainerBio" >
        <tr>
            <td align="left" style="width: 153px" >
                <b>Real Name*</b></td>
            <td align="left">
                <asp:TextBox ID="txtRealName" CssClass="Formlong"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqtxtRealName" runat="server" ErrorMessage="RealName" Text="*" ControlToValidate="txtRealName" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 153px" >
                <strong>Email*</strong></td>
            <td align="left" style="height: 30px">
                <asp:TextBox ID="txtEmail" CssClass="Formlong" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqtxtEmail" runat="server" ErrorMessage="Email" Text="*" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
       
          </td>
        </tr>
        <tr>
            <td align="left" style="width: 153px" >
                <b>Password*</b></td>
            <td align="left" style="height: 30px">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="Formlong" TextMode="Password"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="ReqtxtPassword" runat="server" ErrorMessage="Password" Text="*" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
            <td align="left" style="width: 153px" >
                <b>Retype Password *</b></td>
            <td align="left">
                <asp:TextBox ID="txtRetypePassword" CssClass="Formlong" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password & RePassword is not same" ControlToCompare="txtPassword" ControlToValidate="txtRetypePassword" Text="*" ForeColor="Red"></asp:CompareValidator>
          </td>
        </tr>
        <tr>
            <td align="left" style="width: 153px" >

            <td align="left">
                <asp:Label ID="lblErrorMessage" runat="server" Text="Label" ForeColor="#FF6666"></asp:Label>    
          </td>
        </tr>
        <tr>
            <td align="left" style="width: 153px" >&nbsp;
                </td>
            <td align="left"><br />
                <asp:Button ID="btnRegister" runat="server" Text="Register" onclick="btnRegister_Click" />&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="imgCancel_Click" CausesValidation="false" />
                <br /><br />
                            
          </td>
        </tr>
    
     
    </table>
</asp:Content>
