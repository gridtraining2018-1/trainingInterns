<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyPost.aspx.cs" Inherits="Forum.MyPost" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

<table border="0" class="innercontainer" >
   <tr>
              <td class="gray"> <a href="Index.aspx">Home</a> &#9654;<asp:Label ID="lblCurrentPage" runat="server" Text=""></asp:Label></td>
              <td >
             
                       </td>
          </tr>
          <tr>
              <td><h1><asp:Label ID="lblAutherName" runat="server" Text="All Forums My Post"></asp:Label></h1></td>
              <td align="right">
     
              </td>
          </tr>
               <tr>
              <td><asp:Label ID="lblForumDescription" runat="server" Text=""></asp:Label></td>
              <td align="right">
                  <strong>Filter by:</strong>
                                   <asp:CheckBox ID="chkThreadIStarted" runat="server" AutoPostBack="True" 
                                       oncheckedchanged="chkThreadIStarted_CheckedChanged" />Thread I Started<asp:CheckBox 
                                       ID="chkReplyMarkedasAnswer" runat="server" AutoPostBack="True" 
                                       oncheckedchanged="chkReplyMarkedasAnswer_CheckedChanged" />
                                   My Reply Marked as Answer 
              </td>
          </tr>
          
      </table>
      </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <table style="width: 100%" align="left" >
        <tr>
            <td style="width:90" valign="top" >
            <table style="width: 100%"  >
             
                <tr  >
                 <td  >
                                     &nbsp;</td>
                                 <td width="80%"  >
                                     <strong>Forum Topics</strong></td>
                                    <td width="10%" align="center"  >
                                        <strong>Views</strong></td>
                                    <td width="10%" align="center" >
                                        <strong>Replies</strong></td>
                                    </tr>

                            <asp:Repeater ID="rptForumTopics" runat="server">
                            <ItemTemplate>
                            
                             <tr >
                              <td >
                                    <img src="Styles/Images/forum.gif" /></td>
                                 <td width="80%" class="smLink"  >
                                  <strong> <a href="ForumPost.aspx?TopicID=<%#Eval("TopicID")%>&TopicName=<%#Eval("Subject")%>"><%#Eval("Subject")%></a></strong>
                                  <br /><span class="smText">Created in&nbsp;<a href="ForumTopics.aspx?ForumID=<%#Eval("Forum.ForumID")%>&ForumTitle=<%#Eval("Forum.Formname")%>" class="smLink"><%#Eval("Forum.Formname")%></a>,
                                  Last Posted By&nbsp;<a href="ForumMember.aspx?AuthorID=<%#Eval("LastThreadCreatedByID")%>" class="smLink"><%#Eval("LastThreadCreatedBy")%></a></span></td>
                                    <td width="10%" align="center"  ><%#Eval("Noofviews")%>
                                        </td>
                                    <td width="10%" align="center" > <%#Eval("Noofreplies")%>
                                        </td>
                                 </tr>
            
                            </ItemTemplate>
                            </asp:Repeater>
                            </table>
                        </td>
                                                   
  
        </tr>
 
        </table>
</asp:Content>
