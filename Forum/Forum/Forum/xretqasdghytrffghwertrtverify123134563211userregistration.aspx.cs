using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using Entity;

namespace Forum
{
    public partial class xretqasdghytrffghwertrtverify123134563211userregistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserRegistration activate = new UserRegistration();
                activate.ActivateProfile(Request.QueryString["UID"]);
                List<clsRegistration> lstuserDetails = new List<clsRegistration>();
                lstuserDetails = activate.getUserDetails(null, null, Request.QueryString["UID"]);
                Session["UserDetails"] = lstuserDetails;
                Response.Redirect("Index.aspx");
            }

        }
    }
}