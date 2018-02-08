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
    public partial class ReplyMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            List<SendPM> lstMessage = new List<SendPM>();
            lstMessage = (List<SendPM>)Session["lstMessage"];

            var Edit = lstMessage.Where(p => p.PM_IDuni == Convert.ToString(Request.QueryString["MessageID"]));

            foreach (var rm in Edit)
            {
                lblSubject.Text = rm.PM_Tittle.ToString();
                lblMessageDate.Text = rm.strPm_Message_date;
                lblMessage.Text = rm.PM_Message.ToString();
                ViewState["FromID"] = rm.From_ID.ToString();
                ViewState["Tittle"] = rm.PM_Tittle.ToString();
                ViewState["PM_IDuni"] = rm.PM_IDuni.ToString();
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            List<clsRegistration> lstUserDetails = new List<clsRegistration>();
            lstUserDetails = (List<clsRegistration>)Session["UserDetails"];
            clsPrivateMessage reply = new clsPrivateMessage();
            SendPM pm = new SendPM();

            pm.From_ID = lstUserDetails[0].AuthorID;
            pm.Author_ID = Convert.ToInt32(ViewState["FromID"]);
            pm.PM_Tittle = ViewState["Tittle"].ToString();
            pm.PM_Message = System.Web.HttpUtility.HtmlDecode(txtMessage.Text).Trim().Replace("'", "''");
            pm.PM_IDuni = ViewState["PM_IDuni"].ToString();

            reply.replyMessage(pm);
            Response.Redirect("mymailaspx.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("mymailaspx.aspx");
        }
    }
}