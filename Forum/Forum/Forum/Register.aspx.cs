using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using Entity;
using MessageTemplate;


namespace Forum
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hylCurrentPage.Text = "Rules And Policies";
                hylCurrentPage.NavigateUrl = Request.UrlReferrer.ToString();
                lblForumName.Text = "Register New Member";
                lblForumDescription.Text = "Enter Registration Details";
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                lblErrorMessage.Visible = false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            clsRegistration clsRegisterUser = new clsRegistration();

            if ((!string.IsNullOrEmpty(txtRealName.Text.Trim()) && !string.IsNullOrEmpty(txtRealName.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtEmail.Text.Trim())) && ((txtPassword.Text.Trim().CompareTo(txtRetypePassword.Text.Trim())) == 0))
            {
                clsRegisterUser.Username = txtEmail.Text.Trim();
                clsRegisterUser.Realname = txtRealName.Text.Trim();
                clsRegisterUser.Password = txtPassword.Text.Trim();
                clsRegisterUser.Authoremail = txtEmail.Text.Trim();

                UserRegistration clsUserRegistration = new UserRegistration();
                try
                {
                 switch (clsUserRegistration.CreateUser(clsRegisterUser))
                  {
                      case 1:
                         List<clsRegistration> lstuserDetails = new List<clsRegistration>();
                         lstuserDetails = clsUserRegistration.getUserDetails(txtEmail.Text.Trim(), txtPassword.Text.Trim(), "0");

                        ClsMessageTemplate registrationEmail = new ClsMessageTemplate();
                        registrationEmail.Name = "Registration";
                        registrationEmail.To = new List<string>();
                        registrationEmail.To.Add(txtEmail.Text);
                        registrationEmail.ToUserName = new List<string>();
                        registrationEmail.ToUserName.Add(txtRealName.Text);
                        registrationEmail.UID = lstuserDetails[0].UID.ToString();

                        //TokenMessageTemplate valEmail = new TokenMessageTemplate();
                        //valEmail.SendEmail(registrationEmail);

                          Response.Redirect("Confirmation.aspx");
                          break;
                      case 2:
                          //trError.Style["Display"] = "block";
                          lblErrorMessage.Visible = true;
                          lblErrorMessage.Text = "User already Exist..";

                          break;
                      case 0:
                          //trError.Style["Display"] = "block";
                          lblErrorMessage.Visible = true;
                          lblErrorMessage.Text = "Oop's Error Occured In Performing Operation..";
                          break;

                  }
                }
                catch
                {
                    //trError.Style["Display"] = "block";
                    //lblErrorMessage.Text = "Oop's Error Occured In Performing Operation";
                }
            }
            else
            {
                //trError.Style["Display"] = "block";
                //lblErrorMessage.Text = "Oop's Error Occured In Performing Operation";
            }
            
       
        }

     
        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}