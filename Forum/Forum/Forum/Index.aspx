<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Forum.Index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="UserControl/RightOptions.ascx" tagname="RightOptions" tagprefix="uc1" %>
<%@ Register src="UserControl/Statistics.ascx" tagname="Statistics" tagprefix="uc2" %>

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
              <td><h1> Forums</h1></td>
              <td align="right">
               <p class="search-box-long">    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtSearch" WatermarkText="Search existing forum" runat="server">
                  </asp:TextBoxWatermarkExtender>   <asp:TextBox ID="txtSearch" runat="server" class="input-search-text" ></asp:TextBox>
                   <asp:ImageButton ID="imgSearch" class="input-search-submit" runat="server" 
                       ImageUrl="~/Styles/Images/search.gif" onclick="imgSearch_Click" /> </p>
              </td>
          </tr>
               <tr>
              <td>Start a New Thread after selecting a forum below.</td>
              <td align="right">
                  
              </td>
          </tr>
      </table>
      </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <table style="width: 100%" class="biglist" >
        <tr>
            <td valign="top" >
            <table style="width: 100%" border="0"  >
                <tr  >
                 <th>
                                     &nbsp;</th>
                                 <th width="50%"  >
                                     <strong>Forum</strong></th>
                                    <th width="10%"  >
                                        <strong>Topics</strong></th>
                                    <th width="10%" >
                                        <strong>Posts</strong></th>
                                    <th width="30%" align="left">
                                        <strong>Last Post</strong></th>
                                    </tr>

                   <asp:Repeater ID="rptMainCategory" runat="server">
                            <ItemTemplate>
                            
                             <tr >
                              <td >
                                    <img src="Styles/Images/forum.gif" /></td>
                                 <td width="50%"  >
                                  <strong> <a href="ForumTopics.aspx?ForumID=<%#Eval("ForumID")%>&ForumTitle=<%#Eval("Formname")%>"><b> <%#Eval("Formname")%></b></a></strong><br /><%#Eval("Formumdescription")%></td>
                                    <td width="10%"><%#Eval("NoOfTopics")%>
                                        </td>
                                    <td width="10%"> <%#Eval("NoOfPosts")%>
                                        </td>
                                    <td width="30%" class="smText" align="left" >
                                     <a href="ForumPost.aspx?TopicID=<%#Eval("Topics.TopicID")%>&TopicName=<%#Eval("Topics.Subject")%>"> <%#Eval("Topics.Subject")%></a>
                                   <br /><span class="smLink">by</span> <a href="ForumMember.aspx?AuthorID=<%#Eval("Auther.AuthorID")%>" class="smLink"><%#Eval("Auther.Username")%></a>
                                   <br /><span class="smLink"><%#Eval("strLastPostDate").ToString()%></span>
                                       </td>
                                    </tr>
                              </ItemTemplate>
                            </asp:Repeater>
                            </table>
                     </td>
                                                   
        </tr>
        </table>
</asp:Content>


