using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using Entity;


namespace Forum.UserControl
{
    public partial class login : System.Web.UI.UserControl
    {

         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtUserName.Text = Request.Cookies["UserName"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            
                if (!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                   

                    UserRegistration AuthenticateUser = new UserRegistration();
                    List<clsRegistration> lstuserDetails = new List<clsRegistration>();
                    lstuserDetails = AuthenticateUser.getUserDetails(txtUserName.Text.Trim(), txtPassword.Text.Trim(),"0");
                    if (lstuserDetails.Count > 0)
                    {
                        Session["UserDetails"] = lstuserDetails;
                        if (chkRememberMe.Checked)
                        {
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                        }
                        else
                        {
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                        }

                        Response.Cookies["UserName"].Value = txtUserName.Text.Trim();
                        Response.Cookies["Password"].Value = txtPassword.Text.Trim();

                        if (Session["GoToURLAfterLogin"] == null)
                        {
                            Response.Redirect("index.aspx");
                        }
                        else
                        {
                            string gotoPage = Session["GoToURLAfterLogin"].ToString();
                            Session["GoToURLAfterLogin"] = null;
                            Response.Redirect(gotoPage);
                        }
                    }
                    else
                    {

                        validationMessage("Email/Password is wrong, Please try again.");
                    }

                }
                else
                {
                    validationMessage("Email/Password");
                }
            }

        private void validationMessage(string message)
        {
            ValidationSummary vs = (ValidationSummary)Parent.FindControl("ValidationSummary2");
            CustomValidator cv = new CustomValidator();
            cv.IsValid = false;
            cv.ErrorMessage = message;
            this.Page.Validators.Add(cv);
        }
            
        }
    }
