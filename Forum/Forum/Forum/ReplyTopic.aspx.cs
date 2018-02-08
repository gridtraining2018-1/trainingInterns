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
    public partial class ReplyTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserDetails"] == null)
                {
                    Session["GoToURLAfterLogin"] = Request.UrlReferrer.ToString();
                    Response.Redirect("login.aspx");
                }
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                lblheading.Text = "Reply to : " + HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["TopicName"].ToString();
                hylCurrentPage.Text = HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["TopicName"].ToString(); 
                
                lblPostHeading.Text = lblheading.Text;
                BindData();

            }
        }

        private void BindData()
        {

            List<ClsThread> lstThread = new List<ClsThread>();
            lstThread = (List<ClsThread>)Session["lstThread"];

            var Edit = lstThread.Where(p => p.Thread_ID == Convert.ToInt32(Request.QueryString["ThreadID"]));

            foreach (var Thread in Edit)
            {
               lblPostMessage.Text = Thread.Message.ToString();
               imgAvatar.ImageUrl = Thread.Auther.Avatar;
               lblAuthor.Text = Thread.Auther.Username;
               lblLocation.Text = Thread.Auther.Location;
               lblMessageDate.Text = Thread.Message_date.ToString();
               lblPoints.Text = Thread.Auther.Points.ToString();
               lblJoindate.Text = Thread.Auther.Joindate.ToString();

                

            }


        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            
            ClsTopics clsTopic = new ClsTopics();
            clsTopic.TopicID = Convert.ToInt32(Request.QueryString["TopicID"]);
            clsTopic.Subject ="";

            ClsThread thread = new ClsThread();
            thread.Message = txtMessage.Text;
            List<clsRegistration> lstUserDetails = new List<clsRegistration>();
            lstUserDetails = (List<clsRegistration>)Session["UserDetails"];
            thread.Author_ID = lstUserDetails[0].AuthorID;
            
            clsTopic.Thread = thread;

            ClsModifyData addNewTopic = new ClsModifyData();
            if(!string.IsNullOrEmpty(thread.Message))
            addNewTopic.AddNewThread(clsTopic);

            Response.Redirect(ViewState["UrlReferrer"].ToString());
          
        }

  
    }
}