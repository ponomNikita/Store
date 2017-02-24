using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Contracts;
using Store.ViewModels;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly ILogger _logger;

        public AccountController(IAccountService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(LoginUserViewModel model)
        {
            var currentUser = _service.Login(model.Email, model.Password);
            LoginUserResponseViewModel response = new LoginUserResponseViewModel(currentUser);

            return Json(response);
        }

        [HttpGet]
        public JsonResult IsAuthorized()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json(new {IsAuthorized = true, UserName = User.Identity.Name}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { IsAuthorized = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            _service.Logout();

            return new EmptyResult();
        }
    }
}