<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForumTopics.aspx.cs" Inherits="Forum.ForumTopics" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="UserControl/RightOptions.ascx" tagname="RightOptions" tagprefix="uc1" %>
<%@ Register src="UserControl/Statistics.ascx" tagname="Statistics" tagprefix="uc2" %>
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
              <td><h1><asp:Label ID="lblForumName" runat="server" Text=""></asp:Label></h1></td>
              <td align="right">
               <p class="search-box-long">    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtSearch" WatermarkText="Search existing forum topics" runat="server">
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
                  <asp:Button ID="btnNewTopi" runat="server" onclick="btnNewTopic_Click" Text="New Topic"  />

                     </td>
          </tr>
      </table>
      </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 
<table style="width: 100%" align="left" class="biglist" >
        <tr>
            <td valign="top" colspan="2" >
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
                                    <img src="Styles/Images/topic.png" /></td>
                                 <td width="80%" >
                                  <strong> <a href="ForumPost.aspx?TopicID=<%#Eval("TopicID")%>&TopicName=<%#Eval("Subject")%>"><strong><%#Eval("Subject")%></strong></a></strong>
                                  <br /><span class="smLink">Created by&nbsp;<a href="ForumMember.aspx?AuthorID=<%#Eval("StartThreadCreatedByID")%>" class="smLink"><%#Eval("StartThreadCreatedBy")%></a>,
                                  Last posted by&nbsp;<a href="ForumMember.aspx?AuthorID=<%#Eval("LastThreadCreatedByID")%>" class="smLink"><%#Eval("LastThreadCreatedBy")%></a></span></td>
                                    <td width="10%" align="center"  ><%#Eval("Noofviews")%>
                                        </td>
                                    <td width="10%" align="center" > <%#Eval("Noofreplies")%>
                                        </td>
                    
                            </ItemTemplate>
                            </asp:Repeater>
                            </table>
                            <br /><br />
                                <asp:Repeater ID="rptPager" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
                        </td>
                                                   
        </tr>
         </table>
</asp:Content>
