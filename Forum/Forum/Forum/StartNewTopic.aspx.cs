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
    public partial class StartNewTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                lblForumName.Text = "Create New Topic";
                hylCurrentPage.Text = HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["ForumTitle"];
                hylCurrentPage.NavigateUrl = Request.UrlReferrer.ToString();


            }

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {

          List<ClsTopics> topic = new List<ClsTopics>();

          ClsTopics clsTopic = new ClsTopics();
          clsTopic.Subject = txtSubject.Text;
          clsTopic.ForumID = Convert.ToInt32(Request.QueryString["ForumID"]);

          ClsThread thread = new ClsThread();
          thread.Message = System.Web.HttpUtility.HtmlDecode(txtBox1.Text);
          List<clsRegistration> lstUserDetails = new List<clsRegistration>();
          lstUserDetails = (List<clsRegistration>)Session["UserDetails"];
          thread.Author_ID = lstUserDetails[0].AuthorID; 
          clsTopic.Thread = thread;

                 
          ClsModifyData addNewTopic = new ClsModifyData();
          addNewTopic.AddNewTopic(clsTopic);
          Response.Redirect(ViewState["UrlReferrer"].ToString());
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["UrlReferrer"].ToString());
        }
    }
}