using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using TestingKnowLedgeVIS.Models;
using ADO.NET.Repositories;
using ADO.NET.Models;

namespace TestingKnowLedgeVIS.Controllers
{
    public class UserController : Controller
    {
        UserRepository Repo = new UserRepository();
        // GET: User
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            UserViewModel userViewModel = new UserViewModel();
            var userlist = Repo.GetAll();
            foreach (var user in userlist)
            {
                userViewModel.Users.Add(user);
            }
            return View(userViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(UserModel user)
        {
            UserEditModel usModel = new UserEditModel();
            usModel.UserId = user.UserId;
            usModel.UserLogin = user.UserLogin;
            usModel.UserPasswd = user.UserPasswd;
            usModel.UserRole = user.UserRole;
            return View(usModel);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(UserEditModel model)
        {
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(int id, string login)
        {
            UserRepository r = new UserRepository();
            var user = r.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ADO.NET.Models.UserModel, UserModel>());
            var mapper = config.CreateMapper();

            return View(mapper.Map<UserModel>(user));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(int id)
        {
            Repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}