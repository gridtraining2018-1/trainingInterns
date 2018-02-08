using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;

namespace Forum.UserControl
{
    public partial class Statistics : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblThreads.Text =Convert.ToString(ClsStatistics.GetNoOfThread());
                lblPosts.Text = Convert.ToString(ClsStatistics.GetNoOfPosts());
                lblUsers.Text = Convert.ToString(ClsStatistics.GetNoOfUsers());

            }

        }
    }
}