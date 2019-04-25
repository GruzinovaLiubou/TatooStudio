using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Project.Logic.Servicies;
using Project.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        public async Task<ActionResult> Account(string email)
        {
            var emailToFind = email ?? User.Identity.Name;
            var userViewModel = await _accountService.FindUser(emailToFind);
            return View(userViewModel);
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult ProfileBooking()
        {
            return View();
        }
    
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var errors = await _accountService.CreateUser(model);
                if (errors.Count() == 0)
                {
                    var loginModel = new LoginModel { Email = model.Email, Password = model.Password };
                    return await LoginUser(loginModel, string.Empty);
                }
            }

            return View(model);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }

        }

        public ActionResult LogInPage(string returnUrl)
        {
            var a = _accountService.Test();
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogInPage(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                return await LoginUser(model, returnUrl);
            }

            ViewBag.returnUrl = returnUrl;
            return View();
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("LogInPage");
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var errors = await _accountService.UpdateUserAsync(model);
                if (errors.Count() == 0)
                {
                    return View("Account");
                }
                else
                {
                    return View();
                }
            }

            return View();
        }

        private async Task<ActionResult> LoginUser(LoginModel model, string returnUrl)
        {
            var claim = await _accountService.FindUserAndGetClaimsAsync(model, DefaultAuthenticationTypes.ApplicationCookie);
            if (claim == null)
            {
                ModelState.AddModelError("", "Not your login or password");
            }
            else
            {
                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true
                }, claim);
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction("Account", "Account", new { email = model.Email });
                return Redirect(returnUrl);
            }

            return View(nameof(LogInPage));
        }
    }
}