using AsiaLabv1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsiaLabv1.Controllers
{
    public class MainController : Controller
    {

        //this class is used for user/employee related queries
        //any query related to employee has been written in this class
        UserService UsersService = new UserService();
        BranchService BranchesService = new BranchService();

        public ActionResult LoginPage()
        {
            return View("LoginPage");
        }

        public ActionResult Khaali()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection LoginForm)
        {
            //UsersService.AddUserType("Admin");
            //UsersService.AddUserType("Doctor");
            //UsersService.AddUserType("Receptionist");
            //UsersService.AddUserType("Technician");

            //BranchesService.AddBranch("branch1name", "branch 1 address", "Br Code");

            string username = LoginForm["Email"].ToString();
            string password = LoginForm["Password"].ToString();

            var model = UsersService.ValidateLogin(username, password);

            if (model != null)
            {
                Session["loginuser"] = model.Id;
                Session["loginusername"] = model.Name;

                return View(model.UserRole + "Dashboard", model);
            }

            return RedirectToAction("LoginPage");
        }

        public ActionResult abc()
        {
            return View();
        }


        public ActionResult LogOut()
        {
            Session["loginuser"] = null;
            Session["loginusername"] = null;
            return RedirectToAction("LoginPage");
        }

    }
}
