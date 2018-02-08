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
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnAccountRecovery_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAccountRecovery.Text.Trim()))
            {
                UserRegistration clsUserRegistration = new UserRegistration();
                ClsMessageTemplate registrationEmail = new ClsMessageTemplate();
                List<clsRegistration> lstuserDetails = new List<clsRegistration>();
                lstuserDetails = clsUserRegistration.getDetailsforPasswordRecovery(txtAccountRecovery.Text.Trim());
                if (lstuserDetails.Count > 0)
                {
                    try
                    {
                        registrationEmail.Name = "ForgetPassword";
                        registrationEmail.To = new List<string>();
                        registrationEmail.To.Add(txtAccountRecovery.Text);
                        registrationEmail.ToUserName = new List<string>();
                        registrationEmail.ToUserName.Add(lstuserDetails[0].Realname);
                        registrationEmail.UID = lstuserDetails[0].UID.ToString();
                        TokenMessageTemplate valEmail = new TokenMessageTemplate();
                        valEmail.SendEmail(registrationEmail);
                        btnAccountRecovery.Visible = false;
                        lblMessage.Visible = true;
                        txtAccountRecovery.Text = string.Empty;
                        lblMessage.Text = "If you have registered previously we have sent you a verification email. If you do not see it in your inbox please note that your email provider may have mistaken us as spam. If no email has arrived please try resetting your password again.";

                    }

                    catch (Exception ex)
                    {

                    }
                }
            }
            else
            {

            }
        }

      
    }
}