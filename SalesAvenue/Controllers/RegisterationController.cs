using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesAvenue.Util;
using SalesAvenue.Models;
using SalesAvenue.DataAdaptor;

namespace SalesAvenue.Controllers
{
    public class RegisterationController : Controller
    {
        //
        // GET: /Registeration/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Users userDetails)
        {
            if (ModelState.IsValid)
            {
                UserRegisteration.RegisterUsers(userDetails.StoreName, userDetails.Email, null, Guid.Empty);
            }
            return View("Notification");
        }

        public ActionResult Registeration(Guid tokenId)
        {
            User userModel = UserRegisteration.GetRegisteredUsers(tokenId);

            return View(userModel);
        }

        [HttpPost]
        public ActionResult Registeration(User model)
        {
           if(ModelState.IsValid)
           {
               UserRegisteration.RegisterUsers(null, null, model.UserPassword, model.TokenID); 
           }
            return View("Confirmation");
        }

        [HttpPost]
        public JsonResult StoreNameExists(string StoreName)
        {
            var storeNameResult = UserRegisteration.GetStoreName(StoreName);
            return Json(storeNameResult == null);
        }
        [HttpPost]
        public JsonResult EmailExists(string Email)
        {
            var emailResult = UserRegisteration.GetEmail(Email);
            return Json(emailResult == null);
        }


    }


}

