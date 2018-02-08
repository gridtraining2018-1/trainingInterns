<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendPrivateMessage.aspx.cs" Inherits="Forum.SendPrivateMessage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <table border="0" class="innercontainer" >
   <tr>
              <td class="gray"> <a href="Index.aspx">Home</a> &#9654;<asp:Label ID="lblCurrentPage" runat="server" Text=""></asp:Label></td>
              <td >
             
                       </td>
          </tr>
          <tr>
              <td><h1>Private Message to <asp:Label ID="lblAutherName" runat="server"></asp:Label></h1></td>
              <td align="right">
     
              </td>
          </tr>
               <tr>
              <td><asp:Label ID="lblForumDescription" runat="server" Text=""></asp:Label></td>
              <td align="right">
                  
              </td>
          </tr>
          <tr>
          <td colspan="2"> <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="<div class='validationheader'>You must enter a value in the following field(s)</div>" DisplayMode="BulletList" EnableClientScript="true" CssClass="validationsummary"   />  </td>
          </tr>
      </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">

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

        <table runat="server" id="tblmain" style="width: 100%" align="center" >
                           
                             <tr align="center" >
                               <td align="center" valign="top" ><strong>Message</strong>
                                           </td>
                              <td align="center" >
      <asp:UpdatePanel ID="updatePanel2" runat="server">
                    <ContentTemplate>
<asp:TextBox CssClass="Inputlong" ID="txtSubject" runat="server" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Subject" Text="*" ForeColor="Red" ControlToValidate="txtSubject"></asp:RequiredFieldValidator>
                 <br /><br />
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
        <asp:Button ID="btnPost" runat="server" Text="Send private message" onclick="btnPost_Click" /> &nbsp;<asp:Button ID="btnCancel"
            runat="server" Text="Cancel" onclick="btnCancel_Click" />
    
                                            </div> 
                                        </td>
                                 </tr>
         
        </table>
</asp:Content>
