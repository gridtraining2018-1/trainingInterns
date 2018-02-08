<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forumterms.aspx.cs" Inherits="Forum.Registration.Forumterms" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">
    
    <table border="0" class="innercontainer" >
   <tr>
              <td class="gray"><a href="Index.aspx">Home</a> </td>
              <td align="right">
               &nbsp;              </td>
          </tr>
          <tr>
              <td ><h1>Register New Member</h1></td>
              <td >  &nbsp;   
        
              </td>
          </tr>
               <tr>
              <td >Please Read Rules And Policies</td>
              <td  width="50%">
                  
              </td>
          </tr>
      </table>
      </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <table border="0">
 <tr>
 <td>By accessing this forum, you agree to be legally bound by the following terms. If you do not agree to be legally bound by all of the following terms then please do not access and/or use this forum.<br /><br />
   You agree not to post any abusive, obscene, vulgar, slanderous, hateful, threatening, sexually-orientated or any other material that may violate any laws be it of your country or International Law. Doing so may lead to you being immediately and permanently banned, with notification of your Internet Service Provider if deemed required by us. The IP address of all posts are recorded to aid in enforcing these conditions. <br /><br />You agree that we have the right to remove, edit, move or close any topic at any time should we see fit. As a user you agree to any information you have entered to being stored in a database.<br /><br />
   You remain solely responsible for the content of your messages, and you agree to indemnify and hold harmless this forum and their agents with respect to any claim based upon any post you may make. We also reserve the right to reveal whatever information we know about you in the event of a complaint or legal action arising from any message posted by yourself.
   <br /><br />This forum uses cookies to identify logged in members as they move around or return to the forum. Cookies are also used to enhance the forum service, for example to remember forum options and display new posts since your last visit.
   </td>
 </tr>
        <tr align="center" >
        <td align="center">
         
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID ="btnAccept" runat="server" onclick="btnAccept_Click" Text="Accept" />&nbsp;&nbsp;&nbsp;
 <asp:Button ID ="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"  />
             
            
                </td>
        </tr>
            </table>


</asp:Content>




