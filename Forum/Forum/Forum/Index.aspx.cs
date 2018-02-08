using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using Entity;
using DataLayer;
namespace Forum
{
    public partial class Index : System.Web.UI.Page
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

               rptMainCategory.DataSource = MainCategory.GetForum();
               rptMainCategory.DataBind();
               
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            ClsGetRecord MainCategory = new DataLayer.ClsGetRecord();

            string strSearch = txtSearch.Text;
            rptMainCategory.DataSource = MainCategory.GetForumSearch(strSearch);
            rptMainCategory.DataBind();


        }

  

    
    }
}

