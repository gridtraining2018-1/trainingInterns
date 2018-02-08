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
    public partial class ForumMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProfile();
                BindRepeater();
            }

        }

        private void BindProfile()
        {

            List<clsRegistration> lstUserDetails = new List<clsRegistration>();
            UserRegistration auther = new UserRegistration();
            lstUserDetails = auther.getUserDetails(null, null, Request.QueryString["AuthorID"]);

            lblBio.Text = string.IsNullOrEmpty(lstUserDetails[0].Bio.ToString()) ? "N/A" : lstUserDetails[0].Bio.ToString();
            lblLastVisit.Text = lstUserDetails[0].Lastvisit == default(DateTime) ? "N/A" : DateFormate.PostDate(lstUserDetails[0].Lastvisit);
            lblMemberSince.Text = lstUserDetails[0].Joindate == default(DateTime) ? null : lstUserDetails[0].Joindate.ToString("MMM d, yyyy");
            lblPoints.Text = Convert.ToString(lstUserDetails[0].Points);
            lblAutherName.Text = Convert.ToString(lstUserDetails[0].Username);
            imgProfilePic.ImageUrl = Convert.ToString(lstUserDetails[0].Avatar);
            lblAIMAddress.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].MSN)) ? "N/A" : Convert.ToString(lstUserDetails[0].MSN);
            lblFacebook.Text =string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Facebook)) ? "N/A" : Convert.ToString(lstUserDetails[0].Facebook);
            lblHomepage.Text =string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Homepage)) ? "N/A" : Convert.ToString(lstUserDetails[0].Homepage) ;
            lblLinkedIn.Text =string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].LinkedIn)) ? "N/A" : Convert.ToString(lstUserDetails[0].LinkedIn);
            lblLocation.Text =string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Location)) ? "N/A" : Convert.ToString(lstUserDetails[0].Location);
            lblskypeName.Text =string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Skype)) ? "N/A" : Convert.ToString(lstUserDetails[0].Skype);
            lblTwitter.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Twitter)) ? "N/A" : Convert.ToString(lstUserDetails[0].Twitter);
            lblyahooMessanger.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Yahoo)) ? "N/A" : Convert.ToString(lstUserDetails[0].Yahoo);
            lblDOB.Text = lstUserDetails[0].DOB == default(DateTime) ? "N/A" : lstUserDetails[0].DOB.ToString("MMM d, yyyy");
            lblPosts.Text = lstUserDetails[0].Noofposts.ToString();
            lblAnswer.Text = lstUserDetails[0].Answered.ToString();
        }

        private void BindRepeater()
        {
            ClsGetRecord MainCategory = new DataLayer.ClsGetRecord();
            List<ClsTopics> lstTopics = new List<ClsTopics>();


            lstTopics = MainCategory.GetAutherRecentTopics(Convert.ToInt32(Request.QueryString["AuthorID"]));
            rptForumTopics.DataSource = lstTopics;
            rptForumTopics.DataBind();
            // lblForumName.Text = Convert.ToString(Request.QueryString["ForumTitle"]);
        }

   

        protected void btnAddBuddy_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["AuthorID"]);
            List<clsRegistration> lstUserRegistration = new List<clsRegistration>();
            lstUserRegistration = (List<clsRegistration>)Session["UserDetails"];

            clsBuddyList buddy = new clsBuddyList();
            buddy.Author_ID = lstUserRegistration[0].AuthorID;
            buddy.Buddy_ID = id;

            clsPrivateMessage addbuddy = new clsPrivateMessage();
            addbuddy.SaveBuddy(buddy);
        }
    }
}