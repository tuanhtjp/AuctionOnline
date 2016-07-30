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
    public class AuctionsController : Controller
    {
        private auctionDBEntities db = new auctionDBEntities();

        // GET: Admin/Auctions
        public ActionResult Index()
        {
            var auctions = db.Auctions.Include(a => a.Account).Include(a => a.Account1).Include(a => a.Category);
            return View(auctions.ToList());
        }

        // GET: Admin/Auctions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // GET: Admin/Auctions/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username");
            ViewBag.PermitID = new SelectList(db.Accounts, "AccountID", "Username");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Admin/Auctions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuctionID,AccountID,ProductName,CategoryID,StartPrice,Image,Description,StartTime,EndTime,PermitID,Status")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                db.Auctions.Add(auction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", auction.AccountID);
            ViewBag.PermitID = new SelectList(db.Accounts, "AccountID", "Username", auction.PermitID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", auction.CategoryID);
            return View(auction);
        }

        // GET: Admin/Auctions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", auction.AccountID);
            ViewBag.PermitID = new SelectList(db.Accounts, "AccountID", "Username", auction.PermitID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", auction.CategoryID);
            return View(auction);
        }

        // POST: Admin/Auctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuctionID,AccountID,ProductName,CategoryID,StartPrice,Image,Description,StartTime,EndTime,PermitID,Status")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", auction.AccountID);
            ViewBag.PermitID = new SelectList(db.Accounts, "AccountID", "Username", auction.PermitID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", auction.CategoryID);
            return View(auction);
        }

        // GET: Admin/Auctions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // POST: Admin/Auctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auction auction = db.Auctions.Find(id);
            db.Auctions.Remove(auction);
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
