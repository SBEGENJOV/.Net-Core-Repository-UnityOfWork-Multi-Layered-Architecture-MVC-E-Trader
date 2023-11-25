using DataLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.Security.Claims;

namespace odevCoreUOF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public readonly ApplicationDbContext context;
        public AccountController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var data = context.Users.Where(k => k.UserName == user.UserName).SingleOrDefault();
                if (data != null)
                {
                    bool isValid = data.UserName == user.UserName && data.UserPassword == user.UserPassword;
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name,user.UserName) }, CookieAuthenticationDefaults.AuthenticationScheme);
                        var prinp = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, prinp);
                        HttpContext.Session.SetString("UserName", user.UserName);
                        return RedirectToAction("Index", "Siparis");
                    }
                    else
                    {
                        TempData["errorpsw"] = "Hatalı Şifre";
                        return View(user);
                    }
                }
                else
                {
                    TempData["errorUsername"] = "Hatalı Şifre";
                    return View(user);
                }
            }
            else
            {
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach (var key in storedCookies)
            {
                Response.Cookies.Delete(key);
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SingUp(User user)
        {
            if (ModelState.IsValid)
            {
                var data = new User()
                {
                    UserName = user.UserName,
                    UserPassword = user.UserPassword
                };
                context.Users.Add(data);
                context.SaveChanges();
                TempData["successMessage"] = "başarılı";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["errorMessage"] = "Başarısız";
                return View(user);
            }
        }
    }
}
