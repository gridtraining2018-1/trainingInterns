<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForumMemberList.aspx.cs" Inherits="Forum.ForumMemberList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

<table border="0" class="innercontainer" >
   <tr>
              <td class="gray"> <a href="Index.aspx">Home</a> &#9654;<asp:HyperLink ID="hylCurrentPage" runat="server">HyperLink</asp:HyperLink></td>
              <td >
             
                       </td>
          </tr>
          <tr>
              <td><h1><asp:Label ID="lblThreadName" runat="server"> Forum Members</asp:Label></h1> </td>
              <td align="right">
               <p class="search-box-long">    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtSearch" WatermarkText="Search existing forum threads" runat="server">
                  </asp:TextBoxWatermarkExtender>   <asp:TextBox ID="txtSearch" runat="server" class="input-search-text" ></asp:TextBox>
                   <asp:ImageButton ID="imgSearch" class="input-search-submit" runat="server" ImageUrl="~/Styles/Images/search.gif" /> </p>
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
     
         <asp:Repeater ID="rptMemberList" runat="server"  onitemcommand="rptMemberList_ItemCommand"  onitemdatabound="rptMemberList_ItemDataBound" runat="server">
                            <ItemTemplate>
        <tr>
        <td><a href="ForumMember.aspx?AuthorID=<%#Eval("AuthorID")%>"><%#Eval("UserName")%></a></td>
            <td>
               <%#Eval("Joindate")%></td>
            <td>
               <%#Eval("Points")%></td>
            <td>
               <%#Eval("Lastvisit")%></td>
            <td> 
               <asp:UpdatePanel ID="upPanelRotator" runat="server" UpdateMode="Conditional" AutoPostBack="true">
    <ContentTemplate>
                <asp:ImageButton ID="ImgAddBuddy" runat="server" commandname="Addbuddy"  commandargument=<%#Eval("AuthorID")%> ImageUrl="Styles/Images/add_buddy.gif" AlternateText="Add Buddy" ToolTip="Add Buddy" />

        <asp:HiddenField ID="hdAddbuddy" runat="server" Value=<%#Eval("AuthorID")%> />
              </ContentTemplate>
        <%--       <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ImgAddBuddy" EventName="commandname" />
    </Triggers>--%>
           </asp:UpdatePanel>
              </td>
           
        </tr>
        </ItemTemplate>
        </asp:Repeater>

           </table>
       
        
            <asp:LinkButton ID="lnkBtnPrev" runat="server" Font-Underline="False" OnClick="lnkBtnPrev_Click" Font-Bold="True"><< Prev </asp:LinkButton>
            <input id="txtHidden" style="width: 28px" type="hidden" value="1"
                runat="server" />
            <asp:LinkButton ID="lnkBtnNext" runat="server" Font-Underline="False" OnClick="lnkBtnNext_Click" Font-Bold="True">Next >></asp:LinkButton>

</asp:Content>
