using MiniProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject1.Controllers
{
    public class ManageAdminController : Controller
    {
        // GET: ManageAdmin
        ProjectContext pc = new ProjectContext();

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(AdminVM a)
        {
            if (ModelState.IsValid)
            {
                var userExists = this.pc.Admins.SingleOrDefault(p => p.EmailId == a.EmailId && p.Password == a.Password);

                if (userExists != null)     
                {
                    Session["AdminId"] = userExists.AdminId;
                    Session["AdminName"] = userExists.AdminName;
                    return RedirectToAction("Index", "AdminHome", new { area = "AdminArea" });
                }   
                else
                {
                    ModelState.AddModelError("", "Email not found");
                    return View(a);
                }
            }
            return View();
            //return RedirectToAction("Index", "AdminHome", new { area = "AdminArea" });
        }


        [HttpGet]
        public ActionResult SignOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("SignIn");
        }
    }
}