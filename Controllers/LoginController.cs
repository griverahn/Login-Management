using LoginManagemet.DataContext;
using LoginManagemet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static LoginManagemet.Models.AccountViewModel;

namespace LoginManagemet.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginContext _loginContext;
        private readonly UserServices _userServices;
        private readonly SecurityHelper _securityHelper;

        public LoginController(LoginContext loginContext, 
            UserServices userServices,
            SecurityHelper securityHelper)
        {
            this._loginContext = loginContext ?? throw new System.ArgumentNullException(nameof(loginContext));
            this._userServices = userServices ?? throw new System.ArgumentNullException(nameof(userServices));
            this._securityHelper = securityHelper ?? throw new System.ArgumentNullException(nameof(securityHelper));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {           
            //Enviar mensaje de Bienvenida /// cambiar, que no sea un metodo async

            var user = _userServices.GetUserByEmail(model.Email);

            if (user != null)
            {
                var encondedPassword = _securityHelper.encodePassword(model.Password);

                if (user.Password == encondedPassword)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetInt32("RoleId", user.RoleId);

                    return RedirectToAction("Index", "MenuOptions");
                }
            }

            ModelState.AddModelError("", "Invalid login attempt. Please verify your Email and Password.");
            return View();

        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("RoleId");
            return RedirectToAction("Login","Login");
        }

    }
}
