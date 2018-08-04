using Prepaid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prepaid.Controllers
{
    public class CreditsController : Controller
    {

        AppDbContext db = new AppDbContext();

        // GET: Credits
        public ActionResult Index()
        {
            var credits = db.Credits.ToList();

            return View(credits);
        }

        // GET: Credites/Create
        public ActionResult Create()
        {
            return View(); 
        }

        // POST: Credits/Create
        [HttpPost]
        public ActionResult Create(Credit credit)
        {
            // Check if the id is existing 
            var oldCredit = db.Credits.Find(credit.SerialNumber); 

            if(oldCredit != null)
            {
                return View(); 
            }
            db.Credits.Add(credit);
            db.SaveChanges();

            return RedirectToAction("Index"); 
        }

    }
}