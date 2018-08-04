using Prepaid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prepaid.Controllers
{
    public class UsersController : Controller
    {

        AppDbContext db = new AppDbContext(); 

        // GET: Users
        public ActionResult Index(int id)
        {
            var user = db.Users.Find(id);

            if (user == null)
                return HttpNotFound(); 

            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View(); 
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return View(); 
        }

        // GET: Users/Charge/1
        public ActionResult Charge(int id)
        {
            // Get user
            var user = db.Users.Find(id);

            if (user == null)
                return HttpNotFound();

            ChargeViewModel vm = new ChargeViewModel();
            vm.Message = "";
            vm.MessageType = "";

            vm.Username = user.FullName;

            return View(vm); 
        }

        // POST: Users/Charge/1
        [HttpPost]
        public ActionResult Charge(int id,int CreditNumber)
        {
           
            // Get the user 
            var user = db.Users.Find(id);

            ChargeViewModel vm = new ChargeViewModel()
            {
                Username = user.FullName
            };

            // Get the CreditNumber 
            var creditNumber = db.Credits.SingleOrDefault(c => c.CreditNumber == CreditNumber); 

            // Credit not exist 
            if(creditNumber == null)
            {
                vm.Message = "There is no credit with this number";
                vm.MessageType = "Error";
                return View(vm); 
            }

            // Check if it is paid 
            if (!creditNumber.IsAvaliable)
            {
                vm.Message = "This is credit is already paid";
                vm.MessageType = "Warning";
                return View(vm); 
            }

            // Check if it is not expire 
            if(creditNumber.ExpireDate < DateTime.Now)
            {
                vm.Message = "This is credit is expired at " + creditNumber.ExpireDate;
                vm.MessageType = "Warning";
                return View(vm);
            }

            // Credit available 
            creditNumber.User = user;
            creditNumber.ActivateDate = DateTime.Now;
            creditNumber.IsAvaliable = false;

            // User 
            user.Balance += creditNumber.Balance;

            // Update 
            db.SaveChanges();
            return RedirectToAction("Index", new { id = user.UserId }); 

        }
    }
}