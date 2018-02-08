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
    public partial class EditPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                lblheading.Text = "Edit : " + HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["TopicName"].ToString();
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
                txtMessage.Text = Thread.Message.ToString();
                if (Thread.Topic.RowNum != 1)
                {
                    txtSubject.Visible = false;
                    ViewState["txtSubject"] = Thread.Topic.Subject.ToString();
                }
                txtSubject.Text = Thread.Topic.Subject.ToString().Replace("Re: ", "");
                ViewState["topicID"] = Thread.Topic_ID.ToString();

            }


        }

        protected void btnPost_Click(object sender, EventArgs e)
        {

            try
            {
                ClsThread thread = new ClsThread();
                ClsTopics topic = new ClsTopics();

                thread.Message = System.Web.HttpUtility.HtmlDecode(txtMessage.Text).Replace("'","''");
                thread.Thread_ID = Convert.ToInt32(Request.QueryString["ThreadID"]);

                if(ViewState["txtSubject"] !=null)
                topic.Subject = txtSubject.Text.ToString();
                topic.TopicID = Convert.ToInt32(ViewState["topicID"]);

                topic.Thread = thread;

                ClsModifyData update = new ClsModifyData();

                try
                {
                    update.EditForumThread(topic);
                    Response.Redirect(ViewState["UrlReferrer"].ToString());
                }
                catch (Exception EX)
                {
                    ExceptionUtility.LogException(EX, "btnPost_Click");
                }
            }
            catch (Exception Ex)
            {
                ExceptionUtility.LogException(Ex, "btnPost_Click");
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}


