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
    public partial class mymailaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindgrid();
            }

        }

        protected void rptMainCategor_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            RepeaterItem ri = e.Item;
           if (Session["UserDetails"] != null)
            {

                if ((ri.ItemType == ListItemType.Item) || (ri.ItemType == ListItemType.AlternatingItem))
                {

                    Label lblHidenField = (Label)ri.FindControl("lblHidenField");
                    Image imgReadEmail = (Image)ri.FindControl("imgReadEmail");
                    if (lblHidenField != null)
                    {
                        if (Convert.ToBoolean(lblHidenField.Text) == false)
                        {
                            imgReadEmail.ImageUrl = "~/Styles/Images/unread_mail.gif"; 
                        }
                        else
                        {
                            imgReadEmail.ImageUrl = "~/Styles/Images/read_mail.gif";
                        }
                       
                    }
                  

                }
            }

           
        }

        private void Bindgrid()
        {
            List<SendPM> lstThread = new List<SendPM>();
            List<clsRegistration> inbox = new List<clsRegistration>();
            inbox = (List<clsRegistration>)Session["UserDetails"];
            clsPrivateMessage pm = new clsPrivateMessage();

            lstThread = pm.inbox(Convert.ToInt32(inbox[0].AuthorID), 1, 10);
            rptMainCategory.DataSource = lstThread;
            rptMainCategory.DataBind();
      

        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            List<SendPM> lstThread = new List<SendPM>();
            List<clsRegistration> inbox = new List<clsRegistration>();
            inbox = (List<clsRegistration>)Session["UserDetails"];
            clsPrivateMessage pm = new clsPrivateMessage();

            string strSubject = txtSearch.Text;

            lstThread = pm.inboxSearch(Convert.ToInt32(inbox[0].AuthorID), 1, 10, strSubject);
            rptMainCategory.DataSource = lstThread;
            rptMainCategory.DataBind();
        }
    }
}