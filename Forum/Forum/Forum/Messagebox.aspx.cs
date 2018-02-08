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
    public partial class Messagebox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                List<clsRegistration> lstUserDetails = new List<clsRegistration>();
                lstUserDetails = (List<clsRegistration>)Session["UserDetails"];
                ViewState["authorID"] = lstUserDetails[0].AuthorID;

                clsPrivateMessage setAsRead = new clsPrivateMessage();
                setAsRead.updateUnreadEmail(Request.QueryString["MesageID"]);

                bindRepeater();
            }

        }

        private void bindRepeater()
        {
            clsPrivateMessage getPm = new clsPrivateMessage();
            List<SendPM> lstPrivatemessage = new List<SendPM>();
            lstPrivatemessage = getPm.getPrivateMessage(Request.QueryString["MesageID"]);
            rptPM.DataSource = lstPrivatemessage;
            rptPM.DataBind();
            lblsubject.Text = lstPrivatemessage[0].PM_Tittle.ToString();
            Session["lstMessage"] = lstPrivatemessage;

        }

        protected void rptPM_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            RepeaterItem ri = e.Item;
            if (ViewState["authorID"] != null)
            {

                if ((ri.ItemType == ListItemType.Item) || (ri.ItemType == ListItemType.AlternatingItem))
                {

                    HyperLink lnkReplyMessage = (HyperLink)ri.FindControl("lnkReplyMessage");
                    Label lblauthorID = (Label)ri.FindControl("lblauthorID");
                    if (lnkReplyMessage != null)
                    {
                        if (Convert.ToInt32(lblauthorID.Text) == Convert.ToInt32(ViewState["authorID"]))
                        {
                            lnkReplyMessage.Visible = false;
                                                     
                        }
                    }
                   

                }
            }

          
        }
    }
}