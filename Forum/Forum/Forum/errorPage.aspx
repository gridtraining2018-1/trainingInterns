<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="errorPage.aspx.cs" Inherits="Forum.errorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
<table border="0" class="innercontainer" >
   <tr>
              <td class="gray"><a href="Index.aspx">Home</a> </td>
              <td align="right">
               &nbsp;              </td>
          </tr>
          <tr>
              <td><h1> Oops!</h1></td>
              <td align="right">
              
              </td>
          </tr>
               <tr>
              <td>It’s looking like you may have taken a wrong turn
              <td align="right">
                  
              </td>
          </tr>
      </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <table style="width: 100%" class="biglist" >
        <tr>
            <td valign="top" style="width: 491px" >
           <h1 > 404: Page not Found</h1><br />
            Sorry, but the page you are looking for has not been found. Try checking the URL for errors, then hit the refresh button on your browser. 
            </td>
             <td valign="top" >
                 <img alt="" src="Styles/Images/404.jpg" style="width: 288px; height: 272px" /></td>
            </tr>
            </table>
</asp:Content>
