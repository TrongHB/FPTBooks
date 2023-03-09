using FPTBookS.Models;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Authen(User _user)
        {
            ViewBag.Category = db.Categories.ToList();
            var check = db.Users.Where(s => s.Username.Equals(_user.Username) && s.Password.Equals(_user.Password)).FirstOrDefault();
            if (check == null)
            {
                ViewBag.Error = "Error Username or Password! Try again!";
                return View("Index", _user);
            }
            else
            {
                Session["UserID"] = _user.UserID;
                Session["Username"] = _user.Username;
                if(_user.Username == "admin")
                {
                    return RedirectToAction("Admin", "Home");
                }
                else 
                {

                    return RedirectToAction("User", "Home");
                }
;            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();
        }
        //method Register
        [HttpPost]
        public ActionResult Register(User _user)
        {
            ViewBag.Category = db.Categories.ToList();
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Username == _user.Username);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Username already exists! Please, enter another username!";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            ViewBag.Category = db.Categories.ToList();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
