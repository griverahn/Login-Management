using LoginManagemet.DataContext;
using LoginManagemet.DataContext.DTOs;
using LoginManagemet.DataContext.Entities;
using LoginManagemet.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.Controllers
{
    public class UserController : Controller
    {
        private readonly RoleServices _roleServices;
        private readonly UserServices _userServices;

        public UserController(RoleServices roleServices,
            UserServices userServices,
            AccessServices userPermissionsServices)
        {
            this._roleServices = roleServices;
            this._userServices = userServices;
 
        }

        public IActionResult Index()
        {
            var loggedUser = HttpContext.Session.GetInt32("UserId");
            if (loggedUser == 0 || loggedUser == null) { return RedirectToAction("Login", "Login"); }

            return View(_userServices.GetAll());
        }

        public IActionResult Add()
        {
            var loggedUser = HttpContext.Session.GetInt32("UserId");
            if (loggedUser == 0 || loggedUser == null) { return RedirectToAction("Login", "Login"); }

            ViewBag.roles = _roleServices.GetAll().Select(x => new SelectListItem() { Value = x.Name, Text = x.Name });

            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserDTO userDTO)
        {
            ViewBag.roles = _roleServices.GetAll().Select(x => new SelectListItem() { Value = x.Name, Text = x.Name });
            userDTO.AccountName = "Challenge";
            if (userDTO.UserRoles.FirstOrDefault() == "User")
            {
                userDTO.RoleId = 2;
            }

            if (userDTO.UserRoles.FirstOrDefault() == "Admin")
            {
                userDTO.RoleId = 1;
            }
            if (userDTO.UserRoles.FirstOrDefault() == "Public")
            {
                userDTO.RoleId = 3;
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    userDTO.Password = string.Empty;
                    userDTO.ConfirmPassword = string.Empty;
                    return View("Add", userDTO);
                }
                else
                {
                    _userServices.AddUser(userDTO);
                }
            }
            catch (Exception)
            {
                return View(userDTO);
            }

            return RedirectToAction("Index","User");
        }

        public IActionResult goModify(int Id)
        {
            var loggedUser = HttpContext.Session.GetInt32("UserId");
            if (loggedUser == 0 || loggedUser == null) { return RedirectToAction("Login", "Login"); }

            ViewBag.roles = _roleServices.GetAll().Select(x => new SelectListItem() { Value = x.Name, Text = x.Name });

            var user = _userServices.GetUser(Id);

            var userDTO = new UserDTO()
            { 
                Id = user.Id,
                AccountName = user.AccountName,
                Name = user.Name,
                Surname = user.Surname,
                Password = string.Empty,
                ConfirmPassword = string.Empty,
                Email = user.Email,
                RoleId = user.RoleId,
                IsEnable = user.IsEnable
                //UserRoles = roles.ToList(),
            };

            return View(userDTO);
        }

        [HttpPost]
        public IActionResult Modify(UserDTO userDTO)
        {
            _userServices.EditUser(userDTO);

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public IActionResult DeleteUser(int Id)
        {
            _userServices.DeleteUser(Id);
            return RedirectToAction("Index");
        }
    }
}
