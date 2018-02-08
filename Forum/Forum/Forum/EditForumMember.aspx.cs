using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using DataLayer;
using AjaxControlToolkit;
namespace Forum
{
    public partial class EditForumMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                BindMyProfile();
                BindRepeater();

                BindProfile();
    
            }

        }

        private void BindProfile()
        {

            List<clsRegistration> lstUserDetails = new List<clsRegistration>();
            lstUserDetails = (List<clsRegistration>)Session["UserDetails"];

            txtRealName.Text = lstUserDetails[0].Realname;
            txtAIMAddress.Text = lstUserDetails[0].AIM;
            txtBio.Text = lstUserDetails[0].Bio;
            txtDateOfBirth.Text = lstUserDetails[0].DOB == default(DateTime) ? "" : lstUserDetails[0].DOB.ToString("MMM d, yyyy");  
            txtFacebook.Text = lstUserDetails[0].Facebook;
            txtHomePage.Text = lstUserDetails[0].Homepage;
            bindCountry(lstUserDetails[0].Location); 
            txtSignature.Text = lstUserDetails[0].Signature;
            txtSkypeName.Text =lstUserDetails[0].Skype;
            txtTwitter.Text = lstUserDetails[0].Twitter;
            txtWindowsLiveMessenger.Text = lstUserDetails[0].MSN;
            txtYahooMessenger.Text = lstUserDetails[0].Yahoo;
            txtLinkedIn.Text = lstUserDetails[0].LinkedIn;
            ddlGender.SelectedValue = lstUserDetails[0].Gender;

            ViewState["AutherID"] = lstUserDetails[0].AuthorID;
           

      

        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            clsRegistration auther = new clsRegistration();

            auther.Realname =   txtRealName.Text ;
            auther.AIM = txtAIMAddress.Text;
            auther.Bio = txtBio.Text ;
            auther.DOB = Convert.ToDateTime(txtDateOfBirth.Text);
            auther.Facebook = txtFacebook.Text ;
            auther.Homepage =  txtHomePage.Text;
            auther.Location =  ddlCountry.SelectedValue.ToString() ;
            auther.Signature = txtSignature.Text;
            auther.Skype =  txtSkypeName.Text;
            auther.Twitter = txtTwitter.Text;
            auther.MSN = txtWindowsLiveMessenger.Text;
            auther.Yahoo = txtYahooMessenger.Text;
            auther.LinkedIn = txtLinkedIn.Text;
            auther.Gender = ddlGender.SelectedValue;
            

            auther.AuthorID = Convert.ToInt32(ViewState["AutherID"]);


            UserRegistration clsUserRegistration = new UserRegistration();
                try
                {
                    switch (clsUserRegistration.UpdateProfile(auther))
                    {
                        case 1:
                            Session["UserDetails"]= clsUserRegistration.getUserDetails(null, null, Convert.ToString(auther.AuthorID));;
                            Response.Redirect("EditForumMember.aspx");
                            break;
                        case 2:
                         //   trError.Style["Display"] = "block";
                       //     lblErrorMessage.Text = "User already Exist";
                            break;
                        case 0:
                       //     trError.Style["Display"] = "block";
                       //     lblErrorMessage.Text = "Oop's Error Occured In Performing Operation";
                            break;

                    }

                   
                }
                catch
                {
                 //   trError.Style["Display"] = "block";
                 //   lblErrorMessage.Text = "Oop's Error Occured In Performing Operation";
                }
           
            
        }

        protected void fileUploadSuccess(object sender, AsyncFileUploadEventArgs e)
        {
            if (AjaxSamplefileUpload.HasFile)
            {
                System.Threading.Thread.Sleep(5000);
                string FileName = System.IO.Path.GetFileNameWithoutExtension(AjaxSamplefileUpload.FileName);
                FileName = RemoveSpecialCharacters.Remove(FileName + DateTime.Now.ToString());
                FileName = FileName + System.IO.Path.GetExtension(AjaxSamplefileUpload.FileName);
                AjaxSamplefileUpload.SaveAs(Server.MapPath("avatars/") + FileName);
                UserRegistration saveImage = new UserRegistration();
                saveImage.UploadImage(FileName, Convert.ToInt32(ViewState["AutherID"]));
                Response.Redirect("EditForumMember.aspx");
            }

        }

    


      private  void bindCountry(string location)
        {
          ClsGetRecord country = new ClsGetRecord();
          List<clsCountry> lstCountry = country.getCountry();
          ddlCountry.DataSource = lstCountry;
          for(int i = 0; i < lstCountry.Count ; i++)
          {
              ddlCountry.Items.Add(new ListItem(lstCountry[i].NameEN.ToString(), lstCountry[i].ID.ToString()));

          }
          ddlCountry.SelectedValue = location;
       
        }

      private void BindMyProfile()
      {

         List<clsRegistration> lstUserDetails = new List<clsRegistration>();
          lstUserDetails = (List<clsRegistration>)Session["UserDetails"];
         
          lblBio.Text = string.IsNullOrEmpty(lstUserDetails[0].Bio.ToString()) ? "N/A" : lstUserDetails[0].Bio.ToString();
          lblLastVisit.Text = lstUserDetails[0].Lastvisit == default(DateTime) ? "N/A" : DateFormate.PostDate(lstUserDetails[0].Lastvisit);
          lblMemberSince.Text = lstUserDetails[0].Joindate == default(DateTime) ? null : lstUserDetails[0].Joindate.ToString("MMM d, yyyy");
          lblPoints.Text = Convert.ToString(lstUserDetails[0].Points);
          lblAutherName.Text = Convert.ToString(lstUserDetails[0].Username);
          imgProfilePic.ImageUrl = Convert.ToString(lstUserDetails[0].Avatar);
          lblAIMAddress.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].MSN)) ? "N/A" : Convert.ToString(lstUserDetails[0].MSN);
          lblFacebook.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Facebook)) ? "N/A" : Convert.ToString(lstUserDetails[0].Facebook);
          lblHomepage.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Homepage)) ? "N/A" : Convert.ToString(lstUserDetails[0].Homepage);
          lblLinkedIn.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].LinkedIn)) ? "N/A" : Convert.ToString(lstUserDetails[0].LinkedIn);
          lblLocation.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Location)) ? "N/A" : Convert.ToString(lstUserDetails[0].Location);
          lblskypeName.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Skype)) ? "N/A" : Convert.ToString(lstUserDetails[0].Skype);
          lblTwitter.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Twitter)) ? "N/A" : Convert.ToString(lstUserDetails[0].Twitter);
          lblyahooMessanger.Text = string.IsNullOrEmpty(Convert.ToString(lstUserDetails[0].Yahoo)) ? "N/A" : Convert.ToString(lstUserDetails[0].Yahoo);
          lblDOB.Text = lstUserDetails[0].DOB == default(DateTime) ? "N/A" : lstUserDetails[0].DOB.ToString("MMM d, yyyy");
          lblPosts.Text = lstUserDetails[0].Noofposts.ToString();
          lblAnswer.Text = lstUserDetails[0].Answered.ToString();
      }

      private void BindRepeater()
      {
          ClsGetRecord MainCategory = new DataLayer.ClsGetRecord();
          List<ClsTopics> lstTopics = new List<ClsTopics>();

          List<clsRegistration> lstUserDetails = new List<clsRegistration>();
          lstUserDetails = (List<clsRegistration>)Session["UserDetails"];

          lstTopics = MainCategory.GetAutherRecentTopics(Convert.ToInt32(lstUserDetails[0].AuthorID));
          rptForumTopics.DataSource = lstTopics;
          rptForumTopics.DataBind();
          // lblForumName.Text = Convert.ToString(Request.QueryString["ForumTitle"]);
      }
       
    }
}