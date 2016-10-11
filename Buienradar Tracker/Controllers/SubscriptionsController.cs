using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Buienradar_Tracker.Models;

namespace Buienradar_Tracker.Controllers
{
    public class SubscriptionsController : Controller
    {
        private SubscriptionDbContext db = new SubscriptionDbContext();

        // GET: Subscriptions/Create
        public ActionResult Create(string weatherStationCode)
        {
            ViewBag.WeatherStationCode = weatherStationCode;
            return View();
        }

        // POST: Subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeatherStationCode,Gender,Initials,FirstNames,Prefix,LastName,EmailAddress")] Subscription subscription)
        {
            subscription.Initials = subscription.Initials?.ToUpper();
            for (int i = subscription.Initials?.Length ?? 0; i > 0; i--)
            {
                subscription.Initials = subscription.Initials.Insert(i, ".");
            }
            
            if (ModelState.IsValid)
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(subscription);
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
