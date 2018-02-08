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
    public partial class ForumPost : System.Web.UI.Page
    {
        int initial;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                ClsModifyData NoOfview = new ClsModifyData();
                NoOfview.UpdateView(Convert.ToInt32(Request.QueryString["TopicID"]));

                BindRepeater();
                lblThreadName.Text = Convert.ToString(Request.QueryString["TopicName"]);
                hylCurrentPage.Text = HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["ForumTitle"];
                hylCurrentPage.NavigateUrl = Request.UrlReferrer.ToString();
                
            }
        }

        private void BindRepeater()
        {
            ClsGetRecord MainCategory = new DataLayer.ClsGetRecord();
            List<ClsThread> lstThread = new List<ClsThread>();

            lstThread = MainCategory.GetForumPost(Convert.ToInt32(Request.QueryString["TopicID"]));
            rptForumThread.DataSource = lstThread;
            rptForumThread.DataBind();
            Session["lstThread"] = lstThread;
           
        }
        protected void rptForumThread_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            RepeaterItem ri = e.Item;
            int startAuther;
            startAuther = 0;
            if (Session["UserDetails"] == null)
            {

                if ((ri.ItemType == ListItemType.Item) || (ri.ItemType == ListItemType.AlternatingItem))
                {

                    HyperLink lnkAlertModerators = (HyperLink)ri.FindControl("lnkAlertModerators");
                    if (lnkAlertModerators != null)
                    {
                        lnkAlertModerators.Visible = false;
                        ri.FindControl("sapnlnkAlertModerators").Visible = false;
                    }
                    HyperLink lnkEditPost = (HyperLink)ri.FindControl("lnkEditPost");
                    if (lnkEditPost != null)
                    {
                        lnkEditPost.Visible = false;
                        ri.FindControl("sapnlnkEditPost").Visible = false;
                    }
                    LinkButton lnkMarkedAsAnswer = (LinkButton)ri.FindControl("lnkMarkedAsAnswer");

                    if (lnkMarkedAsAnswer != null)
                    {
                        lnkMarkedAsAnswer.Visible = false;

                    }


                    ri.FindControl("sapnlnkReplyTopic").Visible = false;

                }
            }

            else
            {
                List<clsRegistration> lstUserDetails = new List<clsRegistration>();
                lstUserDetails = (List<clsRegistration>)Session["UserDetails"];

                if ((ri.ItemType == ListItemType.Item) || (ri.ItemType == ListItemType.AlternatingItem))
                {
                   

                    Label lblAutherID = (Label)ri.FindControl("lblAutherID");
                    startAuther = Convert.ToInt32(lblAutherID.Text);
                    if (ri.ItemIndex == 0)
                    {

                        initial = startAuther;
                    }
                    //LinkButton lnkMarkedAs = (LinkButton)ri.FindControl("lnkMarkedAsAnswer");

                    //if (ri.ItemIndex == 0)
                    //{
                    //    if (lstUserDetails[0].AuthorID == initial)
                    //    {
                    if (initial == lstUserDetails[0].AuthorID && ri.ItemIndex != 0 && Convert.ToInt32(lblAutherID.Text) != lstUserDetails[0].AuthorID)
                    {
                        ri.FindControl("lnkMarkedAsAnswer").Visible = true;
                        ri.FindControl("lnkAlertModerators").Visible = true;
                        ri.FindControl("sapnlnkAlertModerators").Visible = true;
                        
                        
                    }
                    if (Convert.ToInt32(lblAutherID.Text) == lstUserDetails[0].AuthorID)
                    {
                        ri.FindControl("lnkEditPost").Visible = true;
                        ri.FindControl("sapnlnkReplyTopic").Visible = true;
                    }
                    if (Convert.ToInt32(lblAutherID.Text) != lstUserDetails[0].AuthorID)
                    {
                        ri.FindControl("lnkAlertModerators").Visible = true;
                        ri.FindControl("sapnlnkReplyTopic").Visible = true;
                    }
                  
                   
                 
                }
            }
        }
                  

             

        protected void rptForumThread_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cmd")
            {
                ClsModifyData updatePost = new ClsModifyData();
                updatePost.UpdateMarkedAsAnswer(Convert.ToInt32(e.CommandArgument));
                BindRepeater();
                          
            }
            if (e.CommandName == "AltModerator")
            {
                clsAlertModerator alertModeraor = new clsAlertModerator();
                List<clsRegistration> lstUserDetails = new List<clsRegistration>();
                lstUserDetails = (List<clsRegistration>)Session["UserDetails"];

                alertModeraor.ReportedByID = lstUserDetails[0].AuthorID;
                alertModeraor.ThreadID = Convert.ToInt32(e.CommandArgument);
                   
                TextBox txtReason = (TextBox)e.Item.FindControl("txtReason");
                if(txtReason !=null)
                {
                    alertModeraor.Reason = txtReason.Text;
                }
                DropDownList ddlCat = (DropDownList)e.Item.FindControl("ddlList");

                alertModeraor.Type = ddlCat.SelectedValue.ToString();

                ClsModifyData alert = new ClsModifyData();
                if(!string.IsNullOrEmpty(alertModeraor.Type))
                alert.alertModeraor(alertModeraor);
                BindRepeater();
                          
            }
            
        
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            ClsGetRecord MainCategory = new DataLayer.ClsGetRecord();

            string strSearch = txtSearch.Text;

            List<ClsThread> lstForumPost = new List<ClsThread>();
            lstForumPost = MainCategory.GetForumPostSearch(Convert.ToInt32(Request.QueryString["TopicID"]), strSearch);

            rptForumThread.DataSource = lstForumPost;
            rptForumThread.DataBind();
        }


    }
}