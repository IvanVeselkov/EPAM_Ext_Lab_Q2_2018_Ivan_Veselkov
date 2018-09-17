using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Repositories;
using AutoMapper;

namespace Project.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            ViewRoles VR = new ViewRoles();
            RoleRepository RR = new RoleRepository();
            VR.Roles = RR.GetAll();
            return View(VR);
        }
        
        public ActionResult EditRole(Role role)
        {
            EditRoleView ERV = new EditRoleView();
            ERV.Desc = role.Desc;
            return View(ERV);
        }

        public ActionResult DeleteRole(int id)
        {
            RoleRepository RR = new RoleRepository();
            var role = RR.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Project.Models.UserModel, UserModel>());
            var mapper = config.CreateMapper();
            return View(mapper.Map<Role>(role));
        }
    }
}