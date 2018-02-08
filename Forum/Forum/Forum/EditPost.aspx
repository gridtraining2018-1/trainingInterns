<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="Forum.EditPost" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">

<table border="0" class="innercontainer" >
   <tr>
              <td class="gray"> <a href="Index.aspx">Home</a> &#9654;<asp:HyperLink ID="hylCurrentPage" runat="server"></asp:HyperLink></td>
              <td >
             
                       </td>
          </tr>
          <tr>
              <td><h1>  <asp:Label ID="lblheading" runat="server" Text=""></asp:Label></h1> </td>
              <td align="right">
                 </td>
          </tr>
               <tr>
              <td><asp:Label ID="lblForumDescription" runat="server" Text=""></asp:Label></td>
              <td align="right">
                  
              </td>
          </tr>
                    <tr>
              <td colspan="2">       <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="<div class='validationheader'>You must enter a value in the following field(s)</div>" DisplayMode="BulletList" EnableClientScript="true" CssClass="validationsummary"   />
  </td>
          </tr>
      </table>
      </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

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
                      
                              <td align="center" >
                              <asp:TextBox CssClass="Inputlong" ID="txtSubject" runat="server" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Subject" Text="*" ForeColor="Red" ControlToValidate="txtSubject"></asp:RequiredFieldValidator>
               
                              <br /><br />
      <asp:UpdatePanel ID="updatePanel2" runat="server">
                    <ContentTemplate>

    <asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" Columns="100" Rows="20"
                    />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Message" Text="." ForeColor="White"  ControlToValidate="txtMessage"></asp:RequiredFieldValidator>
                          
                    
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
                      <asp:JustifyLeft />
                        <asp:JustifyCenter />
                        <asp:JustifyRight />
                        <asp:JustifyFull />
                    <asp:InsertImage />
                    
                    
                    <asp:RemoveFormat />
                   
                    </Toolbar>
    </asp:HtmlEditorExtender>
        </ContentTemplate>
        </asp:UpdatePanel>
    <div align="center"> <br />
        <asp:Button ID="btnPost" runat="server" Text="Post" onclick="btnPost_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click" />

                                          </div> 
                                        </td>
                                 </tr>
         
        </table>
   
               
                                 
                              
                     
                           
                  
                       


</asp:Content>
