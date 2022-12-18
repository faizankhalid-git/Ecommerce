using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class WebsiteController : Controller
    {
        // GET: Website
        public ActionResult Index()
        {
        return View();
        }
        public ActionResult Store()
        {
        return View();
        }
        public ActionResult CheckOut()
        {
        return View();
        }
        public ActionResult UserLogin()
        {
        return View();
        }
        public ActionResult CreateUser()
        {
        return View();
        }
    }
}