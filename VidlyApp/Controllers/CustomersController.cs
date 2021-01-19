using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using VidlyApp.Models;
using VidlyApp.ViewModels;

namespace VidlyApp.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context; //Create an instance of the ApplicationDdContext

        public CustomersController()
        {
            _context = new ApplicationDbContext(); //Initialise it with the creation of a new Customerscontroller object
        }

        protected override void Dispose(bool disposing) //Override the displose method of the controller to tell it to dispose of the ApplicationDbContext instance when it's done
        {
            _context.Dispose();
        }

        [HttpPost] //Ensure this action can only be called by HttpPost not HttpGet. If acvtions modify data, they should never be accessible by HTttpGet
        [Route("Customers/Save")]
        public ActionResult Save(Customer customer) //MVC Framework will automatically map request data to this model
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0) //If user is posing a new customer (without an ID value)
                _context.Customers.Add(customer); //Add new customer
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id); //Else, get the customer object from DBModel
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }

            _context.SaveChanges();//Persist data to the DB. SaveChanges() goes through all the modified objects as recorded in the DBContex, and generates an SQL statement for each change.

            return RedirectToAction("Index", "Customers");
        }

        // CREATE: Customers/New
        [Route("Customers/New")]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(), //Create a new blank customer with default values (0's) so satisfy the validation summary on new customer form that customer ID is not null
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        } 

        // GET: Customer/{id}
        [Route("Customers/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null){
                return HttpNotFound();
            } else
            {
                
                return View(customer);
            }
        }

        // PUT: Customers
        [Route("Customers/Edit")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            } else
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

        }

        // GET: Customers
        [Route("Customers")]
        public ActionResult Customers()
        {
            return View();
        }
    }
}