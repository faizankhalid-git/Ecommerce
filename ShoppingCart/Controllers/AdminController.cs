using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShoppingCart.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
        return View("Login");
        }
        public ActionResult Dashboard()
        {
        return View();
        }
        public ActionResult Signup()
        {
        return View();
        }
        public ActionResult Login()
        {
        return View();
        }
        public ActionResult Category()
        {
        return View();
        }
        public ActionResult Product()
        {
        return View();
        }
        public ActionResult ProductImages(int id)
        {
        return View(id);
        }
        public ActionResult MovProductImage(HttpPostedFileBase image, int previousID)
        {
        string pic = System.IO.Path.GetFileName(image.FileName);
        string path = System.IO.Path.Combine(Server.MapPath("~/DataBaseContent/ProductImages"), pic);
        image.SaveAs(path);
        return View("ProductImages", previousID);
        }

        #region Login With FaceBook
        private Uri RediredtUri
        {
            get
            {
            var uriBuilder = new UriBuilder(Request.Url);
            uriBuilder.Query = null;
            uriBuilder.Fragment = null;
            uriBuilder.Path = Url.Action("FacebookCallback");
            return uriBuilder.Uri;
            }
        }
        [AllowAnonymous]
        public ActionResult Facebook()
        {
        var fb = new FacebookClient();
        var loginUrl = fb.GetLoginUrl(new
        {
            client_id = "2513371995581915",
            client_secret = "aa7dac72f776d2e40392d7e63489422a",
            redirect_uri = RediredtUri.AbsoluteUri,
            response_type = "code",
            scope = "email"
        });

        return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)

        {
        var fb = new FacebookClient();
        dynamic result = fb.Post("oauth/access_token", new
        {
            client_id = "2513371995581915",
            client_secret = "aa7dac72f776d2e40392d7e63489422a",
            redirect_uri = RediredtUri.AbsoluteUri,
            code = code
        });

        var accessToken = result.access_token;
        Session["AccessToken"] = accessToken;
        fb.AccessToken = accessToken;
        dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,hometown,timezone,verified,picture,age_range,feed.limit(1)");
        string email = me.email;
        TempData["first_name"] = me.first_name;
        TempData["lastname"] = me.last_name;
        FormsAuthentication.SetAuthCookie(email, false);
        return RedirectToAction("Dashboard", "Admin");
        }
        #endregion

    }
}