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
    public partial class ForumTopics : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserDetails"] == null)
                    btnNewTopi.Visible = false;
                BindRepeater(1);

            }

        }

        private void BindRepeater(int pageIndex)
        {
            ClsGetRecord MainCategory = new DataLayer.ClsGetRecord();
            List<ClsTopics> lstTopics = new List<ClsTopics>();
            lstTopics = MainCategory.GetForumTopics(Convert.ToInt32(Request.QueryString["ForumID"]));

            rptForumTopics.DataSource = lstTopics;
            rptForumTopics.DataBind();
            lblForumName.Text = Convert.ToString(Request.QueryString["ForumTitle"]);
            if (lstTopics.Count != 0)
            {
                lblForumDescription.Text = lstTopics[0].Forum.Formumdescription;
            }
            else
            {
                lblForumDescription.Text = "No Record Found";
            }
            lblCurrentPage.Text = Convert.ToString(Request.QueryString["ForumTitle"]);

            BindPager(lstTopics.Count, pageIndex);

        } 

        protected void btnNewTopic_Click(object sender, EventArgs e)
        {
            Response.Redirect("StartNewTopic.aspx?ForumID=" + Convert.ToInt32(Request.QueryString["ForumID"]));
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            BindRepeater(pageIndex);
        }

        public void BindPager(int totalRecords, int pageIndex)
        {
            ClsGetRecord populatePager = new ClsGetRecord();
            rptPager.DataSource = populatePager.PopulatePager(totalRecords, pageIndex);
            rptPager.DataBind(); 

        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            ClsGetRecord MainCategory = new DataLayer.ClsGetRecord();

            string strSearch = txtSearch.Text;

            List<ClsTopics> lstForumTopics = new List<ClsTopics>();
            lstForumTopics = MainCategory.GetForumTopicsSearch(Convert.ToInt32(Request.QueryString["ForumID"]), strSearch);

            rptForumTopics.DataSource = lstForumTopics;
            rptForumTopics.DataBind();

            BindPager(lstForumTopics.Count, 1);
        }
    }
}