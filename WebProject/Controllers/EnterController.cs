using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebProject.Domain.Interfaces;
using WebProject.Domain.Model;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class EnterController : Controller
    {
        IUnitOfWork context;
        public EnterController(IUnitOfWork unitOfWork)
        {
            context = unitOfWork;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users.Get(u => u.Login == register.Login);
                if (user.Count() == 0)
                {
                    User newuser = new User { Login= register.Login, Password= register.Password };
                    context.Users.Add(newuser);
                    context.SaveChanges();
                    user = context.Users.Get(u => u.Login == register.Login);

                    if (user.Count() != 0)
                    {
                        FormsAuthentication.SetAuthCookie(register.Login, true);
                        return RedirectToAction("MainPage", "Store");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(register);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var login_user = context.Users.Get(u => u.Login == model.Login);
                var passwork_user = context.Users.Get(u => u.Password == model.Password);
                if (login_user.Count() != 0 && passwork_user.Count() != 0)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("MainPage", "Store");
                }


                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем не существует, попробуйте ещё раз");
                }
            }

            return View();
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("MainPage", "Store");
        }
    }
}
