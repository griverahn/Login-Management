using LoginManagemet.DataContext.DTOs;
using LoginManagemet.DataContext.Entities;
using LoginManagemet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.Controllers
{
    public class MenuOptionsController : Controller
    {
        private readonly MenuServices _menuServices;
        private readonly AccessServices _accessServices;
        private readonly UserServices _userServices;
        private const string MenuOptions = "MenuOptions";
        private const string SubCategories = "SubCategories";
        private const string FirstChildLvl = "FirstChildLvl";


        public MenuOptionsController(MenuServices menuServices,
              AccessServices accessServices,
              UserServices userServices)
        {
            this._menuServices = menuServices;
            this._accessServices = accessServices;
            this._userServices = userServices;
        }

        public IActionResult Index()
        {
            ///Validando Permisos del Usuario Logueado
            var loggedUser = HttpContext.Session.GetInt32("UserId");
            if (loggedUser == 0 || loggedUser == null) { return RedirectToAction("Login","Login"); }
         
            var userInfo = _userServices.GetUser((int)loggedUser);

            var options = _menuServices.GetMenuOptions();
            var userAccess = _accessServices.GetPermissionsByRole(userInfo.RoleId);


            ViewBag.Welcome = userInfo.Name + ' ' + userInfo.Surname;

            var putOptionsIntoDTO = TransferOptiosToDTO(options, loggedUser, userAccess);

            return View(putOptionsIntoDTO);
        }

        private IEnumerable<MenuOptionDTO> TransferOptiosToDTO(IEnumerable<MenuOption> options, int? loggedUserId,
            IEnumerable<RoleAccessDTO> userAccess)
        {
            var optionsDTOs = new List<MenuOptionDTO>();

            foreach (var option in options)
            {
                var addOption = new MenuOptionDTO() { 
                    Id = option.Id,
                    Name = option.Name,
                    Description = option.Description,
                    IsEnable = option.IsEnable,
                    Reference = ValidateAccess(option.Reference,userAccess, MenuOptions, option.Id),
                    MenuSubcategories = TransformSubcategories(option.Id, loggedUserId, userAccess)
                };
                optionsDTOs.Add(addOption);
            }

            return optionsDTOs;
        }

        private List<MenuSubcategoryDTO> TransformSubcategories(int optionId, int? loggedUserId,
            IEnumerable<RoleAccessDTO> userAccess)
        {
            var dbSubcategories = _menuServices.GetSubcategory(optionId);
            List<MenuSubcategoryDTO> subMenuList = new List<MenuSubcategoryDTO>();

            foreach (var subcategory in dbSubcategories)
            {
                var addSubcategory = new MenuSubcategoryDTO()
                {
                    Id = subcategory.Id,
                    Name = subcategory.Name,
                    Description = subcategory.Description,
                    IsEnable = subcategory.IsEnable,
                    Reference = ValidateAccess(subcategory.Reference,userAccess, SubCategories, subcategory.Id),
                    MenuOptionId = subcategory.MenuOptionId,
                    ChildSubMenu = TransformChilds(subcategory.Id, loggedUserId, userAccess)
                };
                subMenuList.Add(addSubcategory);
            }

            return subMenuList;
        }

        private List<ChildSubMenuDTO> TransformChilds(int subcategoryId, int? loggedUserId,
            IEnumerable<RoleAccessDTO> userAccess)
        {
            var subcategoriesChilds = _menuServices.GetSubcategoryChild(subcategoryId);
            List<ChildSubMenuDTO> childMenuList = new List<ChildSubMenuDTO>();

            foreach (var child in subcategoriesChilds)
            {
                var addChild = new ChildSubMenuDTO()
                {
                    Id = child.Id,
                    Subcategory_id = child.Subcategory_id,
                    Description = child.Description,
                    Reference = ValidateAccess(child.Reference, userAccess, FirstChildLvl, child.Id)
                };
                childMenuList.Add(addChild);
            }
            return childMenuList;
        }

        private string ValidateAccess(string reference, IEnumerable<RoleAccessDTO> userAccess, 
            string levelName, int idLevel)
        {
            if (userAccess.Where(s => s.LevelName == levelName && s.LevelOptionId == idLevel).ToList().Any())
            {
                return reference;
            }
            return "#";
        }
    }
}
