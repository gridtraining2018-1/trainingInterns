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
    public partial class MyPost : System.Web.UI.Page
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
            ClsGetRecord MainCategory = new DataLayer.ClsGetRecord();
            List<ClsTopics> lstTopics = new List<ClsTopics>();
            List<clsRegistration> lstUser = new List<clsRegistration>();
            lstUser =(List<clsRegistration>)Session["UserDetails"];
                
            lstTopics = MainCategory.GetMyTopics(Convert.ToInt32(lstUser[0].AuthorID));

            if (chkThreadIStarted.Checked == true)
            {
                var filter = from ClsTopics in lstTopics
                             where ClsTopics.StartThreadCreatedByID == Convert.ToInt32(lstUser[0].AuthorID)
                             select ClsTopics;

                rptForumTopics.DataSource = filter;
                rptForumTopics.DataBind();


            }
            if (chkReplyMarkedasAnswer.Checked == true)
            {
                var filter = from ClsTopics in lstTopics
                             where ClsTopics.Thread.Thanks == 1
                             select ClsTopics;

                rptForumTopics.DataSource = filter;
                rptForumTopics.DataBind();


            }
            if (chkThreadIStarted.Checked == false && chkReplyMarkedasAnswer.Checked == false)
            {

                rptForumTopics.DataSource = lstTopics;
                rptForumTopics.DataBind();
            }
           // lblForumName.Text = Convert.ToString(Request.QueryString["ForumTitle"]);
        }

        protected void chkThreadIStarted_CheckedChanged(object sender, EventArgs e)
        {
            BindRepeater();
        }

        protected void chkReplyMarkedasAnswer_CheckedChanged(object sender, EventArgs e)
        {
            BindRepeater();
        }

    }
    }
