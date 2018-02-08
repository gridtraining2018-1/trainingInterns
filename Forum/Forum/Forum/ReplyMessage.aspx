<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReplyMessage.aspx.cs" Inherits="Forum.ReplyMessage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
<table border="0" class="innercontainer" >
   <tr>
              <td class="gray"> <a href="Index.aspx">Home</a> &#9654;<asp:HyperLink ID="hylCurrentPage" runat="server"></asp:HyperLink></td>
              <td >
             
                       </td>
          </tr>
          <tr>
              <td><h1> <asp:Label ID="lblheading" runat="server" Text=""></asp:Label></h1> </td>
              <td align="right">
                 </td>
          </tr>
               <tr>
              <td><asp:Label ID="lblForumDescription" runat="server" Text=""></asp:Label></td>
              <td align="right">
                  
              </td>
          </tr>
                    <tr>
                <td colspan="3">
                 <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="<div class='validationheader'>You must enter a value in the following field(s)</div>" DisplayMode="BulletList" EnableClientScript="true" CssClass="validationsummary"   />


                     </td>
          </tr>
      </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
 <table width="100%"  border="0" cellspacing="0" cellpadding="0" class="comment-list-reply">
    <tr>
     <td>
     <h3><asp:Label ID="lblSubject" runat="server" Text=""></asp:Label></h3>
      <asp:Label ID="lblMessageDate" runat="server" Text=""></asp:Label><br /><br />
      <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
  </tr>
 

</table>
<br /><br />

  <script>

      function windowUnload() {
          if (Sys.Extended.UI.HtmlEditorExtenderBehavior.IsDirty()) {
              alert('unsaved data');
          }
          var htmleditorextender = $find('<%=htmlEditorExtender1.ClientID%>');
          if (htmleditorextender.get_isDirty()) {
              alert('unsaved data in htmlEditorExtender1.');
          }
      }
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

        <table style="width: 100%" align="center" >
                           
                             <tr align="center" >
                               <td align="center" valign="top" ><strong>Message</strong>
                                           </td>
                              <td align="center" >
      <asp:UpdatePanel ID="updatePanel2" runat="server">
                    <ContentTemplate>

    <asp:TextBox ID="txtMessage" runat="server" Columns="100" Rows="20" TextMode="MultiLine">
    </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Message" Text="." ForeColor="White" ControlToValidate="txtMessage"></asp:RequiredFieldValidator>
                   <br />
                            <asp:HtmlEditorExtender  ID="htmlEditorExtender1" TargetControlID="txtMessage"
                    runat="server" DisplaySourceTab="true">
                       <Toolbar>
                    <asp:Bold />
                    <asp:Italic />
                    <asp:Underline />
                    <asp:InsertOrderedList />
                    <asp:InsertUnorderedList />
                     <asp:StrikeThrough />
                    <asp:Copy />
                    <asp:Cut />
                    <asp:Indent />
                    <asp:InsertImage />
                    
                    
                    <asp:RemoveFormat />
                    
                   
                    </Toolbar>
    </asp:HtmlEditorExtender>
                    </ContentTemplate>
        </asp:UpdatePanel>
    <div align="center"> 
        <asp:Button ID="btnPost" runat="server" Text="Reply" onclick="btnPost_Click" /> &nbsp;<asp:Button ID="btnCancel"
            runat="server" Text="Cancel" onclick="btnCancel_Click" />
    
                                            </div> 
                                        </td>
                                 </tr>
         
        </table>
   
</asp:Content>
