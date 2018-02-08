<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditForumMember.aspx.cs" Inherits="Forum.EditForumMember" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">
  <script type="text/javascript">
      function PanelClick(sender, e) {
          var Messages = $get('<%=Messages.ClientID%>');
          Highlight(Messages);
      }

      function ActiveTabChanged(sender, e) {
          var CurrentTab = $get('<%=CurrentTab.ClientID%>');
          CurrentTab.innerHTML = sender.get_activeTab().get_headerText();
          Highlight(CurrentTab);
      }

      var HighlightAnimations = {};
      function Highlight(el) {
          if (HighlightAnimations[el.uniqueID] == null) {
              HighlightAnimations[el.uniqueID] = Sys.Extended.UI.Animation.createAnimation({
                  AnimationName: "color",
                  duration: 0.5,
                  property: "style",
                  propertyKey: "backgroundColor",
                  startValue: "#FFFF90",
                  endValue: "#FFFFFF"
              }, el);
          }
          HighlightAnimations[el.uniqueID].stop();
          HighlightAnimations[el.uniqueID].play();
      }

      function ToggleHidden(value) {
          $find('<%=Tabs.ClientID%>').get_tabs()[2].set_enabled(value);
      }
    </script>
  <script type="text/javascript">

      function uploadSuccess() {
          document.getElementById('<%=lblMsg.ClientID %>').innerHTML = "Your File Uploaded Successfully";
      }

      function uploadFail() {
          document.getElementById('<%=lblMsg.ClientID %>').innerHTML = "Your File upload Failed.";
      }
    </script>
    <table border="0" class="innercontainer" >
   <tr>
              <td class="gray"> <a href="Index.aspx">Home</a> &#9654;<asp:Label ID="lblCurrentPage" runat="server" Text=""></asp:Label></td>
              <td >
             
                       </td>
          </tr>
          <tr>
              <td><h1><asp:Label ID="lblAutherName" runat="server" Text="Site Settings"></asp:Label></h1></td>
              <td align="right">
     
              </td>
          </tr>
               <tr>
              <td><asp:Label ID="lblForumDescription" runat="server" Text=""></asp:Label></td>
              <td align="right">
                  
              </td>
          </tr>
          <tr>
          <td colspan="2"> <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="<div class='validationheader'>You must enter a value in the following field(s)</div>" DisplayMode="BulletList" EnableClientScript="true" CssClass="validationsummary"   />  </td>
          </tr>
      </table>
      </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
      <asp:tabcontainer runat="server" ID="Tabs"  OnClientActiveTabChanged="ActiveTabChanged"
            ActiveTabIndex="0" CssClass="visoft__tab_xpie7" >
             <asp:TabPanel runat="server" ID="TabPanel2" HeaderText="My Profile">
                <ContentTemplate>
                    <asp:UpdatePanel ID="updatePanel2" runat="server">
                        <ContentTemplate>
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
                      
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" ID="Panel1" HeaderText="Edit Profile">
                <ContentTemplate>
                    <asp:UpdatePanel ID="updatePanel1" runat="server">
                        <ContentTemplate>
                         <table width="100%"  border="0">

  <tr>
    <td style="text-align: left; width: 233px;"20%">Real Name</td>
    <td style="text-align: left">
        <asp:TextBox CssClass="Formlong" ID="txtRealName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqtxtRealName" runat="server" ErrorMessage="RealName" Text="*" ControlToValidate="txtRealName" ForeColor="Red"></asp:RequiredFieldValidator>
        
        </td>
  </tr>
  <tr>
    <td style="text-align: left; width: 233px;">Gender</td>
    <td style="text-align: left"> 
        <asp:DropDownList ID="ddlGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td style="text-align: left; width: 233px;" >Location</td>
    <td style="text-align: left" > 
    
        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="Formlong">
        </asp:DropDownList>
                <asp:RequiredFieldValidator ID="ReqddlCountry" runat="server" ErrorMessage="Country" Text="*" ControlToValidate="ddlCountry" ForeColor="Red"></asp:RequiredFieldValidator>

        </td>
  </tr>
  <tr>
    <td style="text-align: left; width: 233px;">Homepage</td>
    <td style="text-align: left"> <asp:TextBox CssClass="Formlong" ID="txtHomePage"  runat="server"></asp:TextBox>     <asp:RegularExpressionValidator   
            ID="RegtxtHomePage"  
            runat="server"   
            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"  
            ControlToValidate="txtHomePage"  
            ErrorMessage="Input valid Internet URL!" Text="*" ForeColor="Red"  
            
            ></asp:RegularExpressionValidator>  </td>
  </tr>
  <tr>
    <td style="text-align: left; width: 233px;">Twitter</td>
    <td style="text-align: left"> <asp:TextBox CssClass="Formlong" ID="txtTwitter" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator   
            ID="RegtxtTwitter"  
            runat="server"   
            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"  
            ControlToValidate="txtTwitter"  
            ErrorMessage="Twitter" Text="*" ForeColor="Red"  
            
            ></asp:RegularExpressionValidator>
    
    </td>
  </tr>
    <tr>
    <td style="text-align: left; width: 233px;">Facebook</td>
    <td style="text-align: left"> <asp:TextBox CssClass="Formlong" ID="txtFacebook" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator   
            ID="RegularExpressionValidator1"  
            runat="server"   
            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"  
            ControlToValidate="txtFacebook"  
            ErrorMessage="Facebook" Text="*" ForeColor="Red"  
            
            ></asp:RegularExpressionValidator>
    </td>
  </tr>
    <tr>
    <td style="text-align: left; width: 233px;">LinkedIn</td>
    <td style="text-align: left"> <asp:TextBox CssClass="Formlong" ID="txtLinkedIn" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator   
            ID="RegLinkedIn"  
            runat="server"   
            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"  
            ControlToValidate="txtLinkedIn"  
            ErrorMessage="Facebook" Text="*" ForeColor="Red"  
            
            ></asp:RegularExpressionValidator>
    </td>
  </tr>
    <tr>
    <td style="text-align: left; width: 233px;">Windows Live Messenger</td>
    <td style="text-align: left"> <asp:TextBox CssClass="Formlong" ID="txtWindowsLiveMessenger" runat="server"></asp:TextBox></td>
  </tr>
    <tr>
    <td style="text-align: left; width: 233px;">Skype Name</td>
    <td style="text-align: left"> <asp:TextBox CssClass="Formlong" ID="txtSkypeName" runat="server"></asp:TextBox></td>
  </tr>
    <tr>
    <td style="text-align: left; width: 233px;">Yahoo Messenger</td>
    <td style="text-align: left"> <asp:TextBox CssClass="Formlong" ID="txtYahooMessenger" runat="server"></asp:TextBox></td>
  </tr>
    <tr>
    <td style="text-align: left; width: 233px;">AIM Address</td>
    <td style="text-align: left"> <asp:TextBox CssClass="Formlong" ID="txtAIMAddress" runat="server"></asp:TextBox></td>
  </tr>
      <tr>
    <td style="text-align: left; width: 233px;">Date of Birth</td>
    <td style="text-align: left">
     
     <asp:TextBox CssClass="Formlong" ID="txtDateOfBirth" runat="server"></asp:TextBox>
      <asp:ImageButton runat="Server" ID="imgCalender" ImageUrl="Styles/Images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" Width="16px" Height="16px" /><br />
        <asp:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDateOfBirth" PopupButtonID="imgCalender">
        </asp:CalendarExtender>
    </td>
  </tr>
        <tr>
    <td style="text-align: left; width: 233px;">Signature</td>
    <td style="text-align: left"> <asp:TextBox CssClass="Formlong" ID="txtSignature" runat="server"></asp:TextBox></td>
  </tr>
        <tr>
    <td style="text-align: left; width: 233px; vertical-align:top">Bio</td>
    <td style="text-align: left"> <asp:TextBox CssClass="Formlong" ID="txtBio" runat="server" 
            Height="213px" TextMode="MultiLine" Width="744px"></asp:TextBox></td>
  </tr>
        <tr>
    <td style="text-align: left; width: 233px; vertical-align:top">&nbsp;</td>
    <td style="text-align: left"> 
        <asp:Button ID="btnUpdateProfile" runat="server" Text="Save" onclick="btnUpdateProfile_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnUpdateProfile_Click" />

            </td>
  </tr>
</table>
                      
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
              <asp:TabPanel runat="server" ID="TabPanel1" OnClientClick="PanelClick" HeaderText="Avatar">
                <ContentTemplate>
             
               <table width="100%"  border="0">
               <tr><td>   <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label> </td></tr>

  <tr>
    <td style="text-align: left; width: 233px;">       <asp:AsyncFileUpload ID="AjaxSamplefileUpload" OnClientUploadComplete="uploadSuccess"
            OnClientUploadError="uploadFail" CompleteBackColor="White" Width="350px" runat="server"
            UploaderStyle="Modern" UploadingBackColor="#CCFFFF" ThrobberID="imgLoading" OnUploadedComplete="fileUploadSuccess" /><br />
            <asp:Image ID="imgLoading" runat="server" ImageUrl="Styles/Images/loading.gif" /></td>
    
  </tr>
 
</table>
              
       </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" ID="Panel3" HeaderText="Forum Preferences">
                <ContentTemplate>
                    Email:
                    <asp:TextBox ID="emailText" runat="server" />
                 
                </ContentTemplate>
            </asp:TabPanel>
           
           </asp:tabcontainer>
           <asp:Label runat="server" Visible="false" ID="CurrentTab" /><br />
        <asp:Label runat="server" ID="Messages" />
        <br />
        <br />
   
</asp:Content>
