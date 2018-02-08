<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mymailaspx.aspx.cs" Inherits="Forum.mymailaspx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
   <table border="0" class="innercontainer" >
      <tr>
         <td class="gray"><a href="Index.aspx">Home</a> </td>
         <td align="right">&nbsp;</td>
      </tr>
      <tr>
         <td><h1>Private Message</h1></td>
         <td align="right">
            <p class="search-box-long">    
               <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtSearch" WatermarkText="Search existing Subject" runat="server"> </asp:TextBoxWatermarkExtender>   
               <asp:TextBox ID="txtSearch" runat="server" class="input-search-text" Height="16px" Width="246px" ></asp:TextBox>
               <asp:ImageButton ID="imgSearch" class="input-search-submit" runat="server" ImageUrl="~/Styles/Images/search.gif" Height="24px" onclick="imgSearch_Click" /> 
            </p>
         </td>
      </tr>
      <tr>
         <td>You have 0 Private Messages, you can receive another 1000 from a total of 1000</td>
         <td align="right">
            <asp:Button ID="btnDelete" runat="server" Text="Delete" />
         </td>
      </tr>
   </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
   <table style="width: 100%" class="biglist" >
      <tr>
         <td valign="top" >
            <table style="width: 100%" border="0"  >
               <tr>
                  <th>&nbsp;</th>
                  <th width="20%"><strong>From</strong></th>
                  <th width="50%"><strong>Subject</strong></th>
                  <th width="30%"><strong>Date</strong></th>                             
               </tr>
               <asp:Repeater ID="rptMainCategory" runat="server" onitemdatabound="rptMainCategor_ItemDataBound">
                  <ItemTemplate>
                     <tr>
                        <td>
                           <asp:CheckBox ID="chk" runat="server" />
                        </td>
                        <td width="20%">
                           <asp:Image ID="imgReadEmail" runat="server"/> <a href="Messagebox.aspx?MesageID=<%#Eval("PM_IDuni")%>"><%#Eval("fromAuthor.Realname")%></a>
                        </td>
                        <td width="50%">
                           <a href="Messagebox.aspx?MesageID=<%#Eval("PM_IDuni")%>"><%#Eval("PM_Tittle")%></a>
                        </td>
                        <td width="30%" class="smText" align="left" >
                           <%#Eval("strPm_Message_date")%>
                           <asp:Label ID="lblHidenField" runat="server" Text='<%#Eval("Read_Post")%>'></asp:Label>
                        </td>
                     </tr>
                  </ItemTemplate>
               </asp:Repeater>
            </table>
         </td>
      </tr>
   </table>
</asp:Content>