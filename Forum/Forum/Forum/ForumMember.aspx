<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForumMember.aspx.cs" Inherits="Forum.ForumMember" %>
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
              <td><h1>About :<asp:Label ID="lblAutherName" runat="server" Text=""></asp:Label></h1></td>
              <td align="right">
     
                  <asp:Button ID="btnAddBuddy" runat="server" Text="Add buddy" 
                      onclick="btnAddBuddy_Click" />
     
              </td>
          </tr>
               <tr>
              <td><asp:Label ID="lblForumDescription" runat="server" Text=""></asp:Label></td>
              <td align="right">
                  
              </td>
          </tr>
          
      </table>
      </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <table width="100%"  border="0">
 
  <tr>
    <td style="text-align: left; width: 153px;" valign="top" >
            <asp:Image ID="imgProfilePic" runat="server" Width="150px" Height="200px" />
            </td>
    <td style="text-align: left" valign="top" >
    <table width="100%"  class="PlaneinnercontainerBio"><tr><td colspan="4"> <strong>Biography</strong>
            <hr /></td></tr>
            <tr class="PlaneinnercontainerBio"><td style="width: 101px">  
                
                <strong>Date of Birth</strong></td><td valign="TOP" style="width: 170px"> 
                    :&nbsp;<asp:Label ID="lblDOB" runat="server" Text=""></asp:Label>
            </td><td valign="top" style="width: 76px"> <strong>Points&nbsp;</strong></td><td valign=top> 
                : <asp:Label ID="lblPoints" runat="server" Text=""></asp:Label>
            </td></tr>
            <tr><td style="width: 101px">  
                
                <strong>Location</strong></td><td valign="TOP" style="width: 170px"> 
                    : <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
            </td><td valign="top" style="width: 76px"> 
            <strong>Posts</strong></td><td valign=top> 
                    : <asp:Label ID="lblPosts" runat="server" Text=""></asp:Label>
            </td></tr>
            <tr><td style="width: 101px">  
                
                <strong>Occupation</strong></td><td valign="TOP" style="width: 170px"> 
                    : <asp:Label ID="lblOccupation" runat="server" Text=""></asp:Label>
            </td><td valign="top" style="width: 76px"> 
            <strong>Answer</strong></td><td valign=top> 
                    : <asp:Label ID="lblAnswer" runat="server" Text=""></asp:Label>
            </td></tr>
            <tr><td style="width: 101px">  
                
                <strong>Member Since</strong></td><td valign="TOP" style="width: 170px"> 
                    : <asp:Label ID="lblMemberSince" runat="server" Text=""></asp:Label>
            </td><td valign="top" style="width: 76px"> <strong>Last Visit </strong>
            </td><td valign=top> 
                    : <asp:Label ID="lblLastVisit" runat="server" Text=""></asp:Label>
            </td></tr><tr><td colspan="4"><br /> <asp:Label ID="lblBio" runat="server" Text=""></asp:Label>
       <br />
       <br />
            </td></tr></table>
          
            </td>
            </tr>
  </table><br /><br />
                  <table width="100%"  border="0" class="PlaneinnercontainerBio" >
          <tr>

    <td style="text-align: left; width: 115px;">Homepage</td>
    <td style="text-align: left; width: 254px;"> <asp:Label ID="lblHomepage" runat="server" Text=""></asp:Label></td>
    <td style="text-align: left" rowspan="9" valign="top"> 

                  <table style="width: 100%" class="PlaneinnercontainerBio" >
                  <tr><td><strong> Recent Posts</strong><hr /></td></tr>
                  <asp:Repeater ID="rptForumTopics" runat="server">
                            <ItemTemplate>
                            
                             <tr >
                                 <td width="80%">
                                  <strong> <a href="ForumPost.aspx?TopicID=<%#Eval("TopicID")%>&TopicName=<%#Eval("Subject")%>"><%#Eval("Subject")%></a></strong>&nbsp;
                                  -&nbsp;<%#Eval("thread.strMessageDate")%><br /><%#Eval("thread.Message")%><br /><br /></td>
                               
                                 </tr>
                               </ItemTemplate>
                            </asp:Repeater>
                            </table>     
              </td>
  </tr>
  
  <tr>
    <td style="text-align: left; width: 115px;">Twitter</td>
    <td style="text-align: left; width: 254px;"> <asp:Label ID="lblTwitter" runat="server" Text=""></asp:Label></td>
  </tr>
  
  <tr>
    <td style="text-align: left; width: 115px;">Facebook</td>
    <td style="text-align: left; width: 254px;"> <asp:Label ID="lblFacebook" runat="server" Text=""></asp:Label></td>
  </tr>
  
  <tr>
    <td style="text-align: left; width: 115px;">LinkedIn</td>
    <td style="text-align: left; width: 254px;"> <asp:Label ID="lblLinkedIn" runat="server" Text=""></asp:Label></td>
  </tr>
  
  <tr>
    <td style="text-align: left; width: 115px;">Windows Live Messenger</td>
    <td style="text-align: left; width: 254px;"> <asp:Label ID="lblMessanger" runat="server" Text=""></asp:Label></td>
  </tr>
  
  <tr>
    <td style="text-align: left; width: 115px;">Skype Name</td>
    <td style="text-align: left; width: 254px;"> <asp:Label ID="lblskypeName" runat="server" Text=""></asp:Label></td>
  </tr>
  
  <tr>
    <td style="text-align: left; width: 115px;">Yahoo Messenger</td>
    <td style="text-align: left; width: 254px;"> <asp:Label ID="lblyahooMessanger" runat="server" Text=""></asp:Label></td>
  </tr>
  
  <tr>
    <td style="text-align: left; width: 115px;">AIM Address</td>
    <td style="text-align: left; width: 254px;"> <asp:Label ID="lblAIMAddress" runat="server" Text=""></asp:Label></td>
  </tr>
  
  <tr>
    <td style="text-align: left; width: 115px;">&nbsp;</td>
    <td style="text-align: left; width: 254px;">&nbsp;</td>
  </tr>
         </table>    
  
  


</asp:Content>
