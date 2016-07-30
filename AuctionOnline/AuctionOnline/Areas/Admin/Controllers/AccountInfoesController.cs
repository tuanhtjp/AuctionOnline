using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuctionOnline.Areas.Admin.Models;

namespace AuctionOnline.Areas.Admin.Controllers
{
    public class AccountInfoesController : Controller
    {
        private auctionDBEntities db = new auctionDBEntities();

        // GET: Admin/AccountInfoes
        public ActionResult Index()
        {
            var accountInfoes = db.AccountInfoes.Include(a => a.Account);
            return View(accountInfoes.ToList());
        }

        // GET: Admin/AccountInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountInfo accountInfo = db.AccountInfoes.Find(id);
            if (accountInfo == null)
            {
                return HttpNotFound();
            }
            return View(accountInfo);
        }

        // GET: Admin/AccountInfoes/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username");
            return View();
        }

        // POST: Admin/AccountInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ACIFID,AccountID,FullName,DOB,Sex,Address,Phone,Image,Status")] AccountInfo accountInfo)
        {
            if (ModelState.IsValid)
            {
                db.AccountInfoes.Add(accountInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", accountInfo.AccountID);
            return View(accountInfo);
        }

        // GET: Admin/AccountInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountInfo accountInfo = db.AccountInfoes.Find(id);
            if (accountInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", accountInfo.AccountID);
            return View(accountInfo);
        }

        // POST: Admin/AccountInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ACIFID,AccountID,FullName,DOB,Sex,Address,Phone,Image,Status")] AccountInfo accountInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", accountInfo.AccountID);
            return View(accountInfo);
        }

        // GET: Admin/AccountInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountInfo accountInfo = db.AccountInfoes.Find(id);
            if (accountInfo == null)
            {
                return HttpNotFound();
            }
            return View(accountInfo);
        }

        // POST: Admin/AccountInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountInfo accountInfo = db.AccountInfoes.Find(id);
            db.AccountInfoes.Remove(accountInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
