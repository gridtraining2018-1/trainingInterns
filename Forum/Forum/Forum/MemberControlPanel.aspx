<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberControlPanel.aspx.cs" Inherits="Forum.MemberControlPanel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
           <asp:tabcontainer runat="server" ID="Tabs" Height="138px" OnClientActiveTabChanged="ActiveTabChanged"
            ActiveTabIndex="0" Width="402px">
            <asp:TabPanel runat="server" ID="Panel1" HeaderText="Signature and Bio">
                <ContentTemplate>
                    <asp:UpdatePanel ID="updatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        Signature:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="signatureText" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Bio:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="bioText" runat="server" />
                                    </td>
                                </tr>
                            </table>
                            <asp:Button ID="Button3" runat="Server" Text="Save" OnClick="SaveProfile" />
                            <br />
                            <br />
                            Hit Save to cause a postback from an update panel inside the tab panel.<br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" ID="Panel3" HeaderText="Email">
                <ContentTemplate>
                    Email:
                    <asp:TextBox ID="emailText" runat="server" />
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="SaveProfile" />
                    <br />
                    <br />
                    Hit Save to cause a full postback.
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" ID="Panel2" OnClientClick="PanelClick" HeaderText="Controls">
                <ContentTemplate>
                    <div>
                        Controls authored by Toolkit User (read-only - demo purposes):</div>
                    <ul>
                        <li>Calendar</li>
                        <li>MaskedEdit</li>
                        <li>Accordion</li>
                        <li>Calendar</li>
                        <li>Calendar</li>
                    </ul>
                    <br />
                </ContentTemplate>
            </asp:TabPanel>
           </asp:tabcontainer>

</asp:Content>
