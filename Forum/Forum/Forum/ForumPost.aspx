<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForumPost.aspx.cs" Inherits="Forum.ForumPost" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">
  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

<table border="0" class="innercontainer" >
   <tr>
              <td class="gray"> <a href="Index.aspx">Home</a> &#9654;<asp:HyperLink ID="hylCurrentPage" runat="server">HyperLink</asp:HyperLink></td>
              <td >
             
                       </td>
          </tr>
          <tr>
              <td><h1><asp:Label ID="lblThreadName" runat="server"></asp:Label></h1> </td>
              <td align="right">
               <p class="search-box-long">    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtSearch" WatermarkText="Search existing forum posts" runat="server">
                  </asp:TextBoxWatermarkExtender>   <asp:TextBox ID="txtSearch" runat="server" class="input-search-text" ></asp:TextBox>
                   <asp:ImageButton ID="imgSearch" class="input-search-submit" runat="server" 
                       ImageUrl="~/Styles/Images/search.gif" onclick="imgSearch_Click" /> </p>
              </td>
          </tr>
               <tr>
              <td><asp:Label ID="lblForumDescription" runat="server" Text=""></asp:Label></td>
              <td align="right">
                  
              </td>
          </tr>
                    <tr>
              <td>  </td>
              <td align="right">
                

                     </td>
          </tr>
      </table>
      </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:Repeater ID="rptForumThread" runat="server" 
        onitemcommand="rptForumThread_ItemCommand" 
        onitemdatabound="rptForumThread_ItemDataBound">
                            <ItemTemplate>
                            
	<table width="100%"  border="0" cellspacing="0" cellpadding="0" class="comment-list">
  <tr class="comment-wrap" >
    <th colspan="2" bgcolor="#e3e3e3">   
        <asp:HyperLink ID="lnkReplyTopic" runat="server" NavigateUrl='<%# String.Format("ReplyTopic.aspx?ThreadID={0}&TopicID={1}", Eval("Thread_ID"), Eval("Topic_ID")) %>'>Reply Topic</asp:HyperLink><span runat="server" Visible="false" id="sapnlnkReplyTopic" class="separator">|</span>
        <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopup">
            <asp:Panel ID="Panel3" runat="server">
                <div>

                     <p><strong>Alert Moderators</strong></p>
                </div>
            </asp:Panel>
            <div>
             <p> Type : 
            <asp:DropDownList ID="ddlList" runat="server">
            <asp:ListItem Text="(Choose an Alert Type)" Value=""></asp:ListItem>
            <asp:ListItem Text="Spam/Advertising" Value="Abusive"></asp:ListItem>
            <asp:ListItem Text="Inappropriate" Value="Inappropriate"></asp:ListItem>
            <asp:ListItem Text="Off Topic" Value="Off Topic"></asp:ListItem>
            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
            <asp:ListItem Text="Incomprehensible" Value="Incomprehensible"></asp:ListItem>
            <asp:ListItem Text="Duplicate" Value="Duplicate"></asp:ListItem>
           
            </asp:DropDownList>

              </p>
                 <p> Reason: <br />
                <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" CssClass="textarea" ></asp:TextBox>

              </p>
                <p style="text-align: center;">
                    <asp:Button ID="OkButton" runat="server" Text="OK" CommandName="AltModerator" CommandArgument='<%#Eval("Thread_ID")%>' />
                    <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
                </p>
            </div>
        </asp:Panel>
        <asp:Button ID="btnDummy" runat="server" Text="Button" Style="display: none" CommandName="AltModerator" CommandArgument='<%#Eval("Thread_ID")%>'  /> 
           <asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="lnkAlertModerators"
            PopupControlID="Panel1" BackgroundCssClass="modalBackground" OkControlID="btnDummy"
            CancelControlID="CancelButton" DropShadow="true" PopupDragHandleControlID="Panel3" />
        <asp:HyperLink ID="lnkAlertModerators" NavigateUrl="#" runat="server" Visible="false">Alert Moderators</asp:HyperLink><span runat="server" id="sapnlnkAlertModerators" Visible="false" class="separator">|</span>
        <asp:HyperLink ID="lnkEditPost" runat="server" Visible="false" NavigateUrl='<%# String.Format("EditPost.aspx?ThreadID={0}",Eval("Thread_ID"))%>' >Edit Topic</asp:HyperLink><span runat="server" Visible="false" id="sapnlnkEditPost" class="separator">|</span>
        <asp:LinkButton ID="lnkMarkedAsAnswer" Visible="false" runat="server" CommandName="cmd" CommandArgument='<%#Eval("Thread_ID")%>'>Marked As Answered</asp:LinkButton>
        <asp:Label ID="lblAutherID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"auther.AuthorID") %>'></asp:Label>
         
         
<%--                   <%ReplyTopic.aspx?ThreadID=<%#Eval("Thread_ID")%>&TopicID=<%#Eval("Topic_ID")%>--%>
                       	

					
   </th>
  </tr>
  <tr>
    <td valign="top" width="20%" rowspan="1" ><a href="ForumMember.aspx?AuthorID=<%#Eval("auther.AuthorID")%>"> <img src="<%#Eval("auther.Avatar")%>" alt=" <%#Eval("auther.Username")%>" width="100px" height="100px" /></a>
    <br /><strong> <%#Eval("auther.Username")%></strong>
    <br><%#Eval("auther.Location")%>
    <br>Points: <%#Eval("auther.Points")%>
    <br>Joined: <%#DateTime.Parse(Eval("auther.Joindate").ToString()).ToString("MMM d, yyyy")%></td>
    <td width="80%"> <strong><%#Eval("topic.Subject")%></strong><br /><%#Eval("strMessageDate")%><br /><br />
    <%#Eval("Message")%></td>
  </tr>

</table>
<br /><br />
  </ItemTemplate>
  </asp:Repeater>
 

</asp:Content>
