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
    public partial class resetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                }
            }

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() != null)
            {
                UserRegistration changePassword = new UserRegistration();
                changePassword.UpdatePassword(Request.QueryString["UID"].ToString(), txtPassword.Text);
                Response.Redirect("index.asp");
            }
        }
    }
}