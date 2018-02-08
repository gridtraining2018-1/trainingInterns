<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Messagebox.aspx.cs" Inherits="Forum.Messagebox" %>
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
              <td><h1><asp:Label ID="lblName" runat="server" Text="Private Messages"></asp:Label></h1> </td>
              <td align="right">
               <p class="search-box-long">    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtSearch" WatermarkText="Search existing forum threads" runat="server">
                  </asp:TextBoxWatermarkExtender>   <asp:TextBox ID="txtSearch" runat="server" class="input-search-text" ></asp:TextBox>
                   <asp:ImageButton ID="imgSearch" class="input-search-submit" runat="server" ImageUrl="~/Styles/Images/search.gif" /> </p>
              </td>
          </tr>
               <tr>
              <td><asp:Label ID="lblsubject" runat="server" Text="Private Messages"></asp:Label></td>
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
   <asp:Repeater ID="rptPM" runat="server" onitemdatabound="rptPM_ItemDataBound">
                            <ItemTemplate>
                            
	<table width="100%"  border="0" cellspacing="0" cellpadding="0" class="comment-list">
  <tr class="comment-wrap" >
    <th  bgcolor="#e3e3e3"> 

    <asp:Label ID="lblauthorID" runat="server" Text=<%#Eval("From_ID")%> Visible="false"></asp:Label>  
      <asp:HyperLink ID="lnkReplyMessage" runat="server" NavigateUrl='<%# String.Format("ReplyMessage.aspx?MessageID={0}", Eval("PM_IDuni")) %>'>Reply Message</asp:HyperLink>
    </th>
  </tr>
  <tr>
    <td valign="top" ><%#Eval("strPm_Message_date")%><br /><br /> <%#Eval("PM_Message")%></td>
  </tr>

</table>
<br /><br />
  </ItemTemplate>
  </asp:Repeater>
</asp:Content>
