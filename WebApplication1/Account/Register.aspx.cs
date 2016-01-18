using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication1.Models;
using ForumData4;

namespace WebApplication1.Account
{
    public partial class Register : Page
    {
        public Register() : base()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FileUpload_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            ForumDAO forumDAO = ForumDAO.GetInstance();
            if(forumDAO.AddUser(Email.Text, Password.Text, Role.USER))
            {
                ErrorMessage.Text = "Zarejestrowano!";
                ErrorMessage.Visible = true;
            } else
            {
                ErrorMessage.Text = "Nie można zarejestrowac";
                ErrorMessage.Visible = true;
            }



            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else 
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
        }
    }
}