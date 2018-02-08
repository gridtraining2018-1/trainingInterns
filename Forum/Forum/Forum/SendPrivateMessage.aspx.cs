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
       
    public partial class SendPrivateMessage : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<clsRegistration> lstUserDetails = new List<clsRegistration>();
                lstUserDetails = (List<clsRegistration>)Session["UserDetails"];

                List<SendPM> chkUser = new List<SendPM>();
                clsPrivateMessage pm = new clsPrivateMessage();

                List<clsBuddyList> chkBuddyStatus = new List<clsBuddyList>();

                chkBuddyStatus = pm.toUserdetail(Convert.ToInt32(lstUserDetails[0].AuthorID), Convert.ToInt32(Request.QueryString["SendTo"]));

                if (chkBuddyStatus.Count != 0 && chkBuddyStatus[0].isApproved == true)
                {
                    lblAutherName.Text = chkBuddyStatus[0].buddy.Realname;
                    ViewState["FromID"] = Convert.ToInt32(lstUserDetails[0].AuthorID);
                }
                else
                {
                    lblAutherName.Text = chkBuddyStatus[0].buddy.Realname;
                    tblmain.Visible = false;
                    CustomValidator cv = new CustomValidator();
                    cv.IsValid = false;
                    cv.ErrorMessage = "You can't send private message to this user as you are not in his buddy list";
                    this.Page.Validators.Add(cv);
                }
               

            }

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            List<SendPM> chkUser = new List<SendPM>();
            List<clsBuddyList> chkBuddyStatus = new List<clsBuddyList>();
           
            clsPrivateMessage pm = new clsPrivateMessage();
            chkBuddyStatus = pm.toUserdetail(Convert.ToInt32(ViewState["FromID"]), Convert.ToInt32(Request.QueryString["SendTo"]));

            if (chkBuddyStatus.Count != 0 && chkBuddyStatus[0].isApproved == true)
            {
                SendPM Pm = new SendPM();
                Pm.From_ID = Convert.ToInt32(ViewState["FromID"]);
                Pm.Author_ID = Convert.ToInt32(Request.QueryString["SendTo"]);
                Pm.PM_Tittle = txtSubject.Text.ToString().Trim().Replace("'", "''");
                Pm.PM_Message = txtMessage.Text.ToString().Trim().Replace("'", "''");
                clsPrivateMessage send = new clsPrivateMessage();
                send.sendMessage(Pm);
                Response.Redirect("EditForumMember.aspx");
            }
            else
            {
               CustomValidator cv = new CustomValidator();
                cv.IsValid = false;
                cv.ErrorMessage = "You can't send message to this user";
                this.Page.Validators.Add(cv);
            }

            
            

    
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}