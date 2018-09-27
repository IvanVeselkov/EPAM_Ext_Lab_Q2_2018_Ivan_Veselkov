using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingKnowLedgeVIS.Models;
using ADO.NET.Repositories;
using System.Web.Security;
using ADO.NET.Models;

namespace TestingKnowLedgeVIS.Controllers
{
    public class AccountController : Controller
    {
        UserRepository US = new UserRepository();
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginModel model,string ReturnUrl)
        {
            var user = US.Get(model.Login);
            if (user !=null)
            {
                if (!string.IsNullOrEmpty(model.Login) && !string.IsNullOrEmpty(model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, false);

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "User with such login and password is not present");
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            var user = US.Get(model.Login);
            if (user.UserLogin == null)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    UserModel regUser = new UserModel();
                    Role usrole = new Role();
                    usrole.Default();
                    regUser.UserId = US.GetCount() + 1;
                    regUser.UserLogin = model.Login;
                    regUser.UserPasswd = model.Password;
                    regUser.UserRole=usrole;
                    US.Save(regUser);
                    FormsAuthentication.SetAuthCookie(model.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Passwords do not match");
                }
            }
            else
            {
                ModelState.AddModelError("", "A user with this data already exists");
            }
            return View(model);
        }

        public ActionResult LogOf()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/");
        }
    }
}
