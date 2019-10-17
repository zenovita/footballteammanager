using Staj.Business;
using Staj.Business.Interface;
using Staj.Domain;
using Staj.Models;
using Staj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj.Controllers
{
    public class UserController : Controller
    {
        IUserBusiness userBusiness;

        public UserController(IUserBusiness _userBusiness)
        {
            userBusiness = _userBusiness;
        }
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginUser(UserDomainModel _user)
        {
            string user = userBusiness.authenticateUser(_user);
            string result = "Cannot Login";

            if (user.Equals("Admin"))
            {
                Session["UserType"] = "Admin";
                result = "Success";
            }
            else if(user.Equals("Standard"))
            {
                Session["UserType"] = "Standard";
                result = "Success";
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult LogoutUser()
        {
            string result = "";
            if(Session["UserType"].Equals("Admin") || Session["UserType"].Equals("Standard"))
            {
                Session.Remove("UserType");
                result = "Logged off";
            }
            else
            {
                result = "No login";
            }

            return Json(result);
        }
    }
}