using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using DataLayer;

namespace Forum
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<clsRegistration> lstUserDetails = new List<clsRegistration>();
                lstUserDetails = (List<clsRegistration>)Session["UserDetails"];


                if (lstUserDetails == null)
                {
                    btnLoginLogout.Text = "Login";
                    btnLoginLogout.PostBackUrl = "login.aspx";
                    hlkRegister.Visible = true;
                    hlkMemeberList.Visible = false;
                    liMemberControlPanel.Visible = false;
                    hlkImgMyThread.Visible = false;
                    liMyThread.Visible = false;
                    lblMemberControlPanel.Visible = false;
                    liMemberControlPanel.Visible = false;
                    liInbox.Visible = false;
                }
                else
                {
                    btnLoginLogout.Text = "Logout [" + lstUserDetails[0].Realname + "]";
                    btnLoginLogout.PostBackUrl = Request.RawUrl;
                    hlkRegister.Visible = false;
                    hlkMemeberList.Visible = true;
                    liMemberControlPanel.Visible = true;
                    hlkImgMyThread.Visible = true;
                    liMyThread.Visible = true;
                    lblMemberControlPanel.Visible = true;
                    liMemberControlPanel.Visible = true;
                    liInbox.Visible = true;
                    int noOfunreadMessage = ClsStatistics.GetUnreadEmail(lstUserDetails[0].AuthorID);
                    lblLabel.Text = noOfunreadMessage == 0 ? "" : "(" + noOfunreadMessage + ")";
                    int noOfPenddingBuddyRequest = ClsStatistics.getPenddingBuddyRequest(lstUserDetails[0].AuthorID);
                    lblBuddyList.Text = noOfPenddingBuddyRequest == 0 ? "" : "(" + noOfPenddingBuddyRequest + ")";

                }
            }
            else
            {
                List<clsRegistration> lstUserDetails = new List<clsRegistration>();
                lstUserDetails = (List<clsRegistration>)Session["UserDetails"];


                if (lstUserDetails == null)
                {
                    btnLoginLogout.Text = "Login";
                    btnLoginLogout.PostBackUrl = "login.aspx";
                    hlkRegister.Visible = true;
                    hlkMemeberList.Visible = false;
                    liMemberControlPanel.Visible = false;
                    hlkImgMyThread.Visible = false;
                    liMyThread.Visible = false;
                    lblMemberControlPanel.Visible = false;
                    liMemberControlPanel.Visible = false;
                    liInbox.Visible = false;
                }
                else
                {
                    btnLoginLogout.Text = "Logout [" + lstUserDetails[0].Realname + "]";
                    btnLoginLogout.PostBackUrl = Request.RawUrl;
                    hlkRegister.Visible = false;
                    hlkMemeberList.Visible = true;
                    liMemberControlPanel.Visible = true;
                    hlkImgMyThread.Visible = true;
                    liMyThread.Visible = true;
                    lblMemberControlPanel.Visible = true;
                    liMemberControlPanel.Visible = true;
                    liInbox.Visible = true;
                    int noOfunreadMessage = ClsStatistics.GetUnreadEmail(lstUserDetails[0].AuthorID);
                    lblLabel.Text = noOfunreadMessage == 0 ? "" : "(" + noOfunreadMessage + ")";
                    int noOfPenddingBuddyRequest = ClsStatistics.getPenddingBuddyRequest(lstUserDetails[0].AuthorID);
                    lblBuddyList.Text = noOfPenddingBuddyRequest == 0 ? "" : "(" + noOfPenddingBuddyRequest + ")";

                }
            }

        }

        protected void btnLoginLogout_Click(object sender, EventArgs e)
        {

            List<clsRegistration> lstUserDetails = new List<clsRegistration>();
            lstUserDetails = (List<clsRegistration>)Session["UserDetails"];

            string AuthorID = Convert.ToString(lstUserDetails[0].AuthorID);

            if (lstUserDetails != null || lstUserDetails.Count == 0)
            {

                //btnLoginLogout.Text = "Login";
                //btnLoginLogout.PostBackUrl = "login.aspx";
                
                hlkRegister.Visible = true;
                hlkMemeberList.Visible = false;
                liMemberControlPanel.Visible = false;
                hlkImgMyThread.Visible = false;
                liMyThread.Visible = false;
                lblMemberControlPanel.Visible = false;
                liMemberControlPanel.Visible = false;
                liInbox.Visible = false;
                //Addedd for Updating Last Visit time
                UpdateLastVisit(AuthorID);

                Session.Abandon();
                Response.Redirect("Index.aspx");
            }
            else
            {
                btnLoginLogout.Text = "Logout [" + lstUserDetails[0].Realname + "]";
                btnLoginLogout.PostBackUrl = Request.RawUrl;
                //  Imglogin.ImageUrl = "Styles/images/logout.gif";

                hlkRegister.Visible = false;
                hlkMemeberList.Visible = true;
                liMemberControlPanel.Visible = true;
                hlkImgMyThread.Visible = true;
                liMyThread.Visible = true;
                lblMemberControlPanel.Visible = true;
                liMemberControlPanel.Visible = true;
                liInbox.Visible = true;
                int noOfunreadMessage = ClsStatistics.GetUnreadEmail(lstUserDetails[0].AuthorID);
                lblLabel.Text = noOfunreadMessage == 0 ? "" : "(" + noOfunreadMessage + ")";
                int noOfPenddingBuddyRequest = ClsStatistics.getPenddingBuddyRequest(lstUserDetails[0].AuthorID);
                lblBuddyList.Text = noOfPenddingBuddyRequest == 0 ? "" : "(" + noOfPenddingBuddyRequest + ")";
            }
        }

        public void UpdateLastVisit(string AuthorID)
        {
           
            try
            {
                UserRegistration LastVisit = new UserRegistration();
                LastVisit.UpdateLastVisit(AuthorID);    
            }
            catch { }
        }

        
    }
}
