using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace task3.Controllers
{
    public class UserController1 : Controller
    {
        public IActionResult Regester()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HandelRegester()
        {
            //بدي استخدم الي هو من v to v
            string name = Request.Form["name"];
            string Email = Request.Form["Email"];
            string Password = Request.Form["Password"];
            string Returnpassword = Request.Form["Returnpassword"];

            if(Password != Returnpassword)
            {
                TempData["errer"] = "Password dont match";
                return View();//لاااااا ننسى بعطيه هاد الغلط و برجعه على نفس الصفحة عشان يعيد
            }

            //هلأ بدي اخزنهم بال سيشن الي عملتها بال بروقرم
            HttpContext.Session.SetString("Username", name);
            HttpContext.Session.SetString("UserEmail", Email);
            HttpContext.Session.SetString("Userpassword", Password);
            


            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HandelLogin()
        {
            string Email = Request.Form["Email"];
            string Password = Request.Form["Password"];

            //بدي انادي الي خزنته بال سيشن
            var sessionEmail = HttpContext.Session.GetString("UserEmail");
            var sessionPasswprd = HttpContext.Session.GetString("Userpassword");


            if(Email == sessionEmail && Password== sessionPasswprd)
            {
                return RedirectToAction("Index", "Home");//صبية هون لانه رايح على كونترولر تاني 
            }
            else
            {
                TempData["wrong"] = "wrong password or email try again";
                return View();
            }
               
        }
        public IActionResult Profile()
        {
            //هون بدي اقرأ داتا من الي خزنتهم بال سيشن واعرضهم بال فيو يعني اشيين رح استخدم 
            var username = HttpContext.Session.GetString("Username");
            var useremail = HttpContext.Session.GetString("UserEmail");
            var userpassword = HttpContext.Session.GetString("userpassword");

            //حكيت بدي اشين الاشي الاول تمام التاني بدي اعرض عالصفحة بعد ما جبت الداتا اذامن c to v
            ViewBag.Username = username;
            ViewBag.UserEmail = useremail;
            ViewBag.userpassword = userpassword;
            return View();
        }
    }
}
