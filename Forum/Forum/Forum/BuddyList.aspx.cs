using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using DataLayer;
using AjaxControlToolkit;

namespace Forum
{
    public partial class BuddyList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                buddyList();
            }
        }

        private void buddyList()
        {
            List<clsRegistration> lstUserDetails = new List<clsRegistration>();
            lstUserDetails = (List<clsRegistration>)Session["UserDetails"];
            UserRegistration getMember = new UserRegistration();
            rptMemberList.DataSource = getMember.getMyBuddyList(Convert.ToInt16(lstUserDetails[0].AuthorID));
            rptMemberList.DataBind();
        }


        protected void rptMemberList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SendPrivateMessage")
            {
                Response.Redirect("SendPrivateMessage.aspx?SendTo=" + e.CommandArgument);
            }

        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            List<clsRegistration> lstUserDetails = new List<clsRegistration>();
            lstUserDetails = (List<clsRegistration>)Session["UserDetails"];
            UserRegistration getMember = new UserRegistration();
            string strBuddyName = txtSearch.Text;
            rptMemberList.DataSource = getMember.getMyBuddyListSearch(Convert.ToInt16(lstUserDetails[0].AuthorID), strBuddyName);
            rptMemberList.DataBind();
        }

    }
}