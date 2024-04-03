using Microsoft.Ajax.Utilities;
using MiniProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniProject1.UserAuth;

namespace MiniProject1.Areas.AdminArea.Controllers
{
    [CustAuth]
    public class AdminHomeController : Controller
    {
        // GET: AdminArea/AdminHome
        ProjectContext pc = new ProjectContext();
        [HttpGet]
        public ActionResult EditProfile(long Id)
        {
            var rec = this.pc.Admins.Find(Id);
            return View(rec);
        }

        [HttpPost]
        public ActionResult EditProfile(Admin a)
        {
            if (ModelState.IsValid)
            {
                this.pc.Entry(a).State = System.Data.Entity.EntityState.Modified;
                this.pc.SaveChanges();
                return View(a);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ChangePassword(Int64 id)
        {
            ViewBag.AdminId = id;
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(AdminChangePassVM a)
        {
            if (ModelState.IsValid)
            {
                var oldrec = this.pc.Admins.Find(a.AdminId);
                oldrec.Password = a.Password;
                this.pc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //Below code for Clients CURD
        public ActionResult List()
        {
            return View(this.pc.Clients.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client c)
        {
            if (ModelState.IsValid)
            {
                this.pc.Clients.Add(c);
                this.pc.SaveChanges();
                return View("List", this.pc.Clients.ToList());
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            var rec = this.pc.Clients.Find(id);
            return View(rec);
        }

        [HttpPost]
        public ActionResult Edit(Client c)
        {
            if (ModelState.IsValid)
            {
                pc.Entry(c).State = System.Data.Entity.EntityState.Modified;
                this.pc.SaveChanges();
                return View("List", this.pc.Clients.ToList());
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(Int64 id)
        {
            var rec = this.pc.Clients.Find(id);
            this.pc.Clients.Remove(rec);
            this.pc.SaveChanges();
            return RedirectToAction("List");
        }


        //Below is this code for User CURD

        public ActionResult Index()
        {
            return View(this.pc.ClientProjectUsers.ToList());
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewBag.ProjectId = new SelectList(this.pc.Projects.ToList(), "ProjectId", "ProjectName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(ClientProjectUser c)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ProjectId = new SelectList(this.pc.Projects.ToList(), "ProjectId", "ProjectName");
                this.pc.ClientProjectUsers.Add(c);
                this.pc.SaveChanges();
                return View("Index", this.pc.ClientProjectUsers.ToList());
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(Int64 id)
        {
            ViewBag.ProjectId = new SelectList(this.pc.Projects.ToList(), "ProjectId", "ProjectName");
            var rec = this.pc.ClientProjectUsers.Find(id);
            return View(rec);
        }

        [HttpPost]
        public ActionResult EditUser(ClientProjectUser c)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ProjectId = new SelectList(this.pc.Projects.ToList(), "ProjectId", "ProjectName");
                this.pc.Entry(c).State = System.Data.Entity.EntityState.Modified;
                this.pc.SaveChanges();
                return View("Index", this.pc.ClientProjectUsers.ToList());
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteUser(Int64 id)
        {
            var rec = this.pc.ClientProjectUsers.Find(id);
            this.pc.ClientProjectUsers.Remove(rec);
            this.pc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}