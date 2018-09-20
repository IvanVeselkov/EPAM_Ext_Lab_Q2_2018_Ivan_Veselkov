using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADO.NET.Models;
using ADO.NET.Repositories;
using TestingKnowLedgeVIS.Models;
using AutoMapper;

namespace TestingKnowLedgeVIS.Controllers
{
    public class RoleController : Controller
    {
        RoleRepository RoleRep = new RoleRepository();
        // GET: Role
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            ViewRoles VR = new ViewRoles();
            VR.Roles = RoleRep.GetAll();
            return View(VR);
        }
        
        public ActionResult EditRole(Role role)
        {
            EditRoleView ERV = new EditRoleView();
            ERV.Desc = role.Desc;
            return View(ERV);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditRole(RoleEditModel model)
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRole(int id)
        {
            RoleRepository RR = new RoleRepository();
            var role = RR.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ADO.NET.Models.UserModel, UserModel>());
            var mapper = config.CreateMapper();
            return View(mapper.Map<Role>(role));
        }

    }
}