using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Project.Models;
using Project.Repositories;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public ActionResult Index()
        {
            UserViewModel userViewModel = new UserViewModel();
            UserRepository r = new UserRepository();
            var userlist = r.GetAll();
            foreach (var user in userlist)
            {
                userViewModel.Users.Add(user);
            }
            return View(userViewModel);
        }

        public ActionResult EditUser(UserModel user)
        {
            UserEditModel usModel = new UserEditModel();
            usModel.UserId = user.UserId;
            usModel.UserLogin = user.UserLogin;
            usModel.UserPasswd = user.UserPasswd;
            usModel.UserRole = user.UserRole;
            return View(usModel);
        }

        public ActionResult DeleteUser(int id, string login)
        {
            UserRepository r = new UserRepository();
            var user = r.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Project.Models.UserModel, UserModel>());
            var mapper = config.CreateMapper();

            return View(mapper.Map<UserModel>(user));
        }

    }
}