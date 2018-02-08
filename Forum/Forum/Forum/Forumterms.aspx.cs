using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.Registration
{
    public partial class Forumterms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            }

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");

        }

        protected void ImgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(ViewState["UrlReferrer"].ToString());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}