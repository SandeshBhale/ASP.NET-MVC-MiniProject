using Microsoft.Win32;
using MiniProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject1.Areas.AdminArea.Controllers
{
    public class ClientProjectController : Controller
    {
        // GET: AdminArea/ClientProject
        ProjectContext pc = new ProjectContext();
        public ActionResult Index()
        {
            return View(this.pc.Projects.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(this.pc.Clients.ToList(), "ClientId", "ClientName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientProject c)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ClientId = new SelectList(this.pc.Clients.ToList(), "ClientId", "ClientName");
                this.pc.Projects.Add(c);
                this.pc.SaveChanges();
                return View("Index", this.pc.Projects.ToList());
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            ViewBag.ClientId = new SelectList(this.pc.Clients.ToList(), "ClientId", "ClientName");
            var rec = this.pc.Projects.Find(id);
            return View(rec);
        }

        [HttpPost]
        public ActionResult Edit(ClientProject c)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ClientId = new SelectList(this.pc.Clients.ToList(), "ClientId", "ClientName");
                this.pc.Entry(c).State = System.Data.Entity.EntityState.Modified;
                this.pc.SaveChanges();
                //return RedirectToRoute("Index");
                return View("Index", this.pc.Projects.ToList());
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(Int64 id)
        {
            var rec = this.pc.Projects.Find(id);
            this.pc.Projects.Remove(rec);
            this.pc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}