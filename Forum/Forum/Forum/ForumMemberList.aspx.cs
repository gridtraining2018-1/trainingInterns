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
    public partial class ForumMemberList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
              

        }

        private void BindRepeater()
        {
            UserRegistration getMember = new UserRegistration();
            List<clsRegistration> lstUserRegistration = new List<clsRegistration>();
            lstUserRegistration = (List<clsRegistration>)Session["UserDetails"];

            rptMemberList.DataSource = getMember.getMemberList(lstUserRegistration[0].AuthorID); ;
            rptMemberList.DataBind();
            pageno(rptMemberList.Items.Count);
        
        }

        protected void lnkBtnPrev_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) - 1);
            BindRepeater();
        }

        protected void lnkBtnNext_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) + 1);
            BindRepeater();
        }

        public void pageno(int totItems)
        {
            // Calculate total numbers of pages
            int pgCount = totItems / 5 + totItems % 5;

            // Display Next>> button
            if (pgCount - 1 > Convert.ToInt16(txtHidden.Value))
                lnkBtnNext.Visible = true;
            else
                lnkBtnNext.Visible = false;

            // Display <<Prev button
            if ((Convert.ToInt16(txtHidden.Value)) > 1)
                lnkBtnPrev.Visible = true;
            else
                lnkBtnPrev.Visible = false;
        }

        //========= Edit,Delete buttons inside repeater.
        protected void rptMemberList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //====== Here we use switch state to distinguish which link button is clicked based 
            //====== on command name supplied to the link button.
            switch (e.CommandName)
            {
                //==== This case will fire when link button placed
                //==== inside repeater having command name "Delete" is clicked.

                case ("Addbuddy"):
                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    int id = Convert.ToInt32(e.CommandArgument);
                       List<clsRegistration> lstUserRegistration = new List<clsRegistration>();
                       lstUserRegistration = (List<clsRegistration>)Session["UserDetails"];

                       clsBuddyList buddy = new clsBuddyList();
                       buddy.Author_ID = lstUserRegistration[0].AuthorID;
                       buddy.Buddy_ID = id;

                       clsPrivateMessage addbuddy = new clsPrivateMessage();
                       addbuddy.SaveBuddy(buddy);
                       BindRepeater();
                    //==== Call delete method and pass id as argument.
                   
                    break;

              
            }
        }

        protected void rptMemberList_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            RepeaterItem ri = e.Item;
            List<clsRegistration> lstUserDetails = new List<clsRegistration>();
            lstUserDetails = (List<clsRegistration>)Session["UserDetails"];
            UserRegistration getMember = new UserRegistration();
           lstUserDetails = getMember.getMyBuddyList(Convert.ToInt16(lstUserDetails[0].AuthorID));

            for(int i = 0 ; i < lstUserDetails.Count ; i++)
            {
                HiddenField hd = (HiddenField)e.Item.FindControl("hdAddbuddy");
                if (lstUserDetails[i].AuthorID == Convert.ToInt32(hd.Value))
                {
                    ImageButton imgbut = (ImageButton)e.Item.FindControl("ImgAddBuddy");
                    imgbut.Enabled = false;
                    imgbut.ImageUrl = "Styles/Images/gorups_members.png";
                    imgbut.ToolTip = "Already in your list";
                }
            }
           
            }


    }
}