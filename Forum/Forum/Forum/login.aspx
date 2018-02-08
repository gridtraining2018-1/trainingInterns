<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Forum.login" %>
<%@ Register src="UserControl/login.ascx" tagname="login" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<table border="0" class="innercontainer" >
   <tr>
              <td class="gray"><a href="Index.aspx">Home</a> </td>
              <td align="right">
               &nbsp;              </td>
          </tr>
          <tr>
              <td ><h1>Log In</h1></td>
              <td >  &nbsp;   
        
              </td>
          </tr>
               <tr>
              <td >Enter your login credentials</td>
              <td  width="50%">
                  
              </td>
          </tr>
               <tr>
              <td colspan="2" ><asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="<div class='validationheader'>You must enter a value in the following field(s)</div>" DisplayMode="BulletList" EnableClientScript="true" CssClass="validationsummary"   /></td>
          </tr>
      </table>
      </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <table style="width: 100%" class="Planeforumcontent innercontainer" >
        <tr>
            <td >
                <uc1:login ID="login1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
 