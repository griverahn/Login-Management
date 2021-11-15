using LoginManagemet.DataContext.DTOs;
using LoginManagemet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleServices _roleServices;
        private readonly MenuServices _menuServices;
        private const string MenuOptions = "MenuOptions";
        private const string SubCategories = "SubCategories";
        private const string FirstChildLvl = "FirstChildLvl";

        public RoleController(RoleServices roleServices,
            MenuServices menuServices)
        {
            this._roleServices = roleServices;
            this._menuServices = menuServices;
        }

        public IActionResult Index()
        {
            var loggedUser = HttpContext.Session.GetInt32("UserId");
            if (loggedUser == 0 || loggedUser == null) { return RedirectToAction("Login", "Login"); }

            var dbRoles = _roleServices.GetAll();
            var roles = new List<RoleDTO>();
     
            foreach (var dbRole in dbRoles)
            {
                var addRole = new RoleDTO()
                {
                    Id = dbRole.Id,
                    Name = dbRole.Name,
                    Description = dbRole.Description,
                    IsEnable = dbRole.IsEnable

                };
                roles.Add(addRole);
            }

            return View(roles);
        }

        private IEnumerable<MenuAccessItemsDTO> FillMenuOptions(int id)
        {
            var accessDetail = new List<MenuAccessItemsDTO>();

            var headOptions = _menuServices.GetMenuOptions();

            foreach (var headOption in headOptions)
            {
                var addHead = new MenuAccessItemsDTO()
                {
                    optionId = headOption.Id,
                    OptionIdName = headOption.Name,
                    sourceTable = MenuOptions
                };
                accessDetail.Add(addHead);

                var subOptions = _menuServices.GetSubcategory(headOption.Id);

                foreach (var subOption in subOptions)
                {
                    var addSub = new MenuAccessItemsDTO()
                    {
                        optionId = subOption.Id,
                        OptionIdName = subOption.Name,
                        sourceTable = SubCategories
                    };
                    accessDetail.Add(addSub);

                    var childOptions = _menuServices.GetSubcategoryChild(subOption.Id);

                    foreach (var childOption in childOptions)
                    {
                        var addChild = new MenuAccessItemsDTO()
                        {
                            optionId = childOption.Id,
                            OptionIdName = childOption.Description,
                            sourceTable = FirstChildLvl
                        };
                        accessDetail.Add(addChild);
                    }
                }
            }

            return accessDetail;
        }

        public IActionResult Add()
        {
            var loggedUser = HttpContext.Session.GetInt32("UserId");
            if (loggedUser == 0 || loggedUser == null) { return RedirectToAction("Login", "Login"); }

            var loggedUserRole = HttpContext.Session.GetInt32("RoleId");
            var fillViewBack = FillMenuOptions((int)loggedUserRole);

            ViewBag.MenuOptions = fillViewBack.Select(x => new SelectListItem()
            { Value = x.optionId.ToString(), Text = x.OptionIdName });


            return View();
        }

        [HttpPost]
        public IActionResult AddAccess(RoleAccessDTO roleAccessDTO)
        {
            return View();
        }
    }
}
