<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuddyList.aspx.cs" Inherits="Forum.BuddyList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<table border="0" class="innercontainer" >
   <tr>
              <td class="gray"> <a href="Index.aspx">Home</a> &#9654;<asp:HyperLink ID="hylCurrentPage" runat="server">HyperLink</asp:HyperLink></td>
              <td >
             
                       </td>
          </tr>
          <tr>
              <td><h1><asp:Label ID="lblBuddyList" runat="server">Buddy List</asp:Label></h1> </td>
              <td align="right">
               <p class="search-box-long">    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtSearch" WatermarkText="Search existing Buddy name" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
 <table style="width: 100%">
          <tr>
            <td>
                <b>UserName</b></td>
            <td>
                <b>Registered</b></td>
            <td>
                <b>Points</b></td>
            <td>
                <b>Last Active</b></td>
            <td>
               <b>Add Buddy</b></td>
        </tr>
     
         <asp:Repeater ID="rptMemberList" runat="server"  onitemcommand="rptMemberList_ItemCommand" runat="server">
                            <ItemTemplate>
        <tr>
        <td>
        <a href="ForumMember.aspx?AuthorID=<%#Eval("AuthorID")%>"><img src="<%#Eval("Avatar")%>" alt=" <%#Eval("Username")%>" width="100px" height="100px" /></a><br />
        <a href="ForumMember.aspx?AuthorID=<%#Eval("AuthorID")%>"><%#Eval("UserName")%></a></td>
            <td>
               <%#Eval("strJoindate")%></td>
            <td>
               <%#Eval("Points")%></td>
            <td>
               <%#Eval("strLastvisit")%></td>
            <td> 
           
                <asp:ImageButton ID="ImgAddBuddy" runat="server" commandname="deleteBuddy"  commandargument=<%#Eval("AuthorID")%> ImageUrl="Styles/Images/delete_message.png" />
                <asp:ImageButton ID="ImgSendPrivateMessage" runat="server" commandname="SendPrivateMessage"  commandargument=<%#Eval("AuthorID")%> ImageUrl="Styles/Images/private_message.gif" />
           
              </td>
           
        </tr>
        </ItemTemplate>
        </asp:Repeater>

           </table>
</asp:Content>
