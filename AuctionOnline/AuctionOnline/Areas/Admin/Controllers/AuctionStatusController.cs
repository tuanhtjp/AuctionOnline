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
    public class AuctionStatusController : Controller
    {
        private auctionDBEntities db = new auctionDBEntities();

        // GET: Admin/AuctionStatus
        public ActionResult Index()
        {
            var auctionStatus = db.AuctionStatus.Include(a => a.Auction);
            return View(auctionStatus.ToList());
        }

        // GET: Admin/AuctionStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionStatu auctionStatu = db.AuctionStatus.Find(id);
            if (auctionStatu == null)
            {
                return HttpNotFound();
            }
            return View(auctionStatu);
        }

        // GET: Admin/AuctionStatus/Create
        public ActionResult Create()
        {
            ViewBag.AuctionID = new SelectList(db.Auctions, "AuctionID", "ProductName");
            return View();
        }

        // POST: Admin/AuctionStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ASID,AuctionID,AccountID,BidPrice,BidTime")] AuctionStatu auctionStatu)
        {
            if (ModelState.IsValid)
            {
                db.AuctionStatus.Add(auctionStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuctionID = new SelectList(db.Auctions, "AuctionID", "ProductName", auctionStatu.AuctionID);
            return View(auctionStatu);
        }

        // GET: Admin/AuctionStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionStatu auctionStatu = db.AuctionStatus.Find(id);
            if (auctionStatu == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuctionID = new SelectList(db.Auctions, "AuctionID", "ProductName", auctionStatu.AuctionID);
            return View(auctionStatu);
        }

        // POST: Admin/AuctionStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ASID,AuctionID,AccountID,BidPrice,BidTime")] AuctionStatu auctionStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auctionStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuctionID = new SelectList(db.Auctions, "AuctionID", "ProductName", auctionStatu.AuctionID);
            return View(auctionStatu);
        }

        // GET: Admin/AuctionStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionStatu auctionStatu = db.AuctionStatus.Find(id);
            if (auctionStatu == null)
            {
                return HttpNotFound();
            }
            return View(auctionStatu);
        }

        // POST: Admin/AuctionStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuctionStatu auctionStatu = db.AuctionStatus.Find(id);
            db.AuctionStatus.Remove(auctionStatu);
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
