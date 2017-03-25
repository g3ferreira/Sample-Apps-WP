using _8pos.Controllers.Model;
using _8pos.Controllers.Utilities;
using _8pos.Controllers.ViewModel;
using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8pos.Controllers.View
{
    public class UserController : Controller
    {

        public ActionResult SignIn()
        {
            return View("SignIn");
        }

        public ActionResult RequestLogin(PosUser posUser)
        {
            PosUser user;
            if (!((posUser.UserName == null) || (posUser.Password == null)))
            {
                UserViewModel userViewModel = new UserViewModel();
                user = userViewModel.login(posUser.UserName, posUser.Password);
                if (user.MessageError == string.Empty && user.Status.Type.Equals("enable"))
                {
                    SessionController.setUserSession(user);
                    user.SelectedView = "1";
                    return View("UserDashBoard", user);
                }
                else
                {
                    user.MessageError = "please, validate your account.";
                    return View("SignIn", user);
                }
            }
            else
            {
                return View("SignIn");
            }
        }


        public ActionResult Index()
        {
            if (SessionController.userIsLogged("admin"))
            {
                return View(new UserViewModel().get());
            }
            else
            {
                return RedirectToAction("SignIn");
            }
        }

        [HttpGet]
        public ActionResult GeneralContent(int id)
        {
            if (SessionController.userIsLogged("admin") || SessionController.userIsLogged("default"))
            {
                return PartialView("_GeneralContent", SessionController.getUserSession());
            }
            else
            {
                return RedirectToAction("SignIn");
            }

        }

        [HttpGet]
        public ActionResult WebsiteContent(int id)
        {
            if (SessionController.userIsLogged("admin") || SessionController.userIsLogged("default"))
            {
                return PartialView("_WebsiteContent", SessionController.getUserSession());
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }

        }

        private PosUser getUserAttributes(int id)
        {
            if (SessionController.userIsLogged("admin") || SessionController.userIsLogged("default"))
            {

                return SessionController.getUserSession();
            }
            else
            {
                return null;
            }

        }

        public JsonResult ValidateUserName(string userName)
        {
            UserViewModel userViewModel = new UserViewModel();
            bool result;
            switch (Request.UrlReferrer.LocalPath)
            {
                case @"/User/SignIn":
                    result = userViewModel.userNameValidation(userName);
                    if (result)
                    {
                        string returnString = String.Format(CultureInfo.InvariantCulture, "invalid username");
                        return Json(returnString, JsonRequestBehavior.AllowGet);
                    }
                    break;

                case @"/SignUp":
                    result = userViewModel.userNameValidation(userName);
                    if (!result)
                    {
                        string returnString = String.Format(CultureInfo.InvariantCulture, "{0} is not avaible", userName);
                        return Json(returnString, JsonRequestBehavior.AllowGet);
                    }
                    break;
                default:
                    break;
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateEmail(string email)
        {
            UserViewModel userViewModel = new UserViewModel();
            bool result;
            switch (Request.UrlReferrer.LocalPath)
            {
                case @"/SignUp":
                    result = userViewModel.emailValidation(email);
                    if (!result)
                    {
                        string returnString = String.Format(CultureInfo.InvariantCulture, "{0} is registered", email);
                        return Json(returnString, JsonRequestBehavior.AllowGet);
                    }
                    break;
                default:
                    break;
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // user/validation/id/activationtoken
        public ActionResult Validation(int id, string activationToken)
        {
            UserViewModel userViewModel = new UserViewModel();
            PosUser posUser = userViewModel.getById(id);
            if (posUser.Status.Type.Equals("disable"))
            {
                SessionController.setUserSession(posUser);
                userViewModel.updateUserStatus(posUser, 1);
                return View("Validation", posUser);
            }
            else
            {
                SessionController.setUserSession(posUser);
                return View("Validation", posUser);
            }
           

        }

        //  
        // GET: /Associates/Create  
        public ActionResult Create()
        {
            if (SessionController.userIsLogged("admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("SignIn");
            }
        }

        //  
        // POST: /Associates/Create  
        [HttpPost]
        public ActionResult Create(PosUser posUser)
        {
            if (!((posUser.UserName == null) || (posUser.Password == null)))
            {
                UserViewModel userViewModel = new UserViewModel();
                posUser.Password = new Utility().encryptPassword(posUser.Password);
                posUser.ActivationToken = new Utility().encryptToken(posUser.FirstName + posUser.PosUserId);
                posUser.Status = new StatusViewModel().getById(2);
                posUser.Profile = new ProfileViewModel().getById(2);
                userViewModel.insert(posUser);
                new EmailController().sendMail(posUser.Email, string.Empty, string.Empty, "Account Validation", new EmailController().getEmailBody("http://192.168.100.107/user/validation/" + posUser.PosUserId + "/" + posUser.ActivationToken));
                return View("../signup/accountvalidation", posUser);
            }
            else
            {
                return RedirectToAction("SignIn");
            }

        }

        // GET: /Associates/Edit/5  
        public ActionResult Edit(int id = 0)
        {
            if (SessionController.userIsLogged("admin"))
            {
                return View(new UserViewModel().getById(id));
            }
            else
            {
                return RedirectToAction("SignIn");
            }

        }

        //  
        // POST: /Associates/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, PosUser posUser)
        {
            if (SessionController.userIsLogged("admin"))
            {
                UserViewModel userViewModel = new UserViewModel();
                PosUser posUserEdit = userViewModel.getById(id);
                //posUserEdit.PosUserId = posUser.PosUserId;
                posUserEdit.FirstName = posUser.FirstName;
                posUserEdit.LastName = posUser.LastName;
                posUserEdit.UserName = posUser.UserName;
                posUserEdit.Email = posUser.Email;
                posUserEdit.Password = new Utility().encryptPassword(posUser.Password);
                // posUserEdit.Status = posUser.Status;
                userViewModel.update(posUserEdit);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("SignIn");
            }

        }

        public ActionResult DashBoard(int id)
        {
            if (SessionController.userIsLogged("admin") || SessionController.userIsLogged("default"))
            {
                SessionController.getUserSession().SelectedView = "1";
                return View("UserDashBoard", SessionController.getUserSession());
            }
            else
            {
                return RedirectToAction("SignIn");
            }

        }

        public ActionResult Details(int id = 0)
        {
            if (SessionController.userIsLogged("admin"))
            {
                return View(new UserViewModel().getById(id));
            }
            else
            {
                return RedirectToAction("SignIn");
            }

        }

        //  
        // GET: /Associates/Delete/5  
        public ActionResult Delete(int id = 0)
        {
            if (SessionController.userIsLogged("admin"))
            {
                PosUser posUser = new UserViewModel().getById(id);
                return View(posUser);
            }
            else
            {
                return RedirectToAction("SignIn");
            }


        }

        //  
        // POST: /Associates/Delete/5  
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (SessionController.userIsLogged("admin"))
            {
                new UserViewModel().delete(new UserViewModel().getById(id));
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("SignIn");
            }

        }
    }
}