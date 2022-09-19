using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    
    public class CustomersController : Controller
    {
        private ApplicationDbContext _Context;
        public CustomersController()
        {
            _Context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        public ActionResult New()
        {
            var membershiptypes = _Context.MemberShipTypes.ToList();
            var viewModel = new CustomerFormViewModel() {
                Customer = new Customer(),
                MemberShipTypes = membershiptypes
            };
            return View("CustomerForm",viewModel);
        }
        public ActionResult Edit(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemberShipTypes =_Context.MemberShipTypes.ToList()
            };

            return View("CustomerForm",viewmodel); 
        }
        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public ActionResult Save(Customer customer)
        {
            /*
             this action do three things: 
            1-add a new customer to the database.
            2-update an existing customer by editing the form .
            3-if the form has any erorr ,we returned the same form.
             */
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MemberShipTypes = _Context.MemberShipTypes.ToList()
                };
                return View("CustomerForm", viewmodel);
            }
            if (customer.Id == 0) //customer doesn't exist,so we will add the cus..
            {
                _Context.Customers.Add(customer);
            }
            else
            {
                var updatedCustomer = _Context.Customers.Single(c => c.Id == customer.Id);
                updatedCustomer.Name = customer.Name;
                updatedCustomer.Birthdate = customer.Birthdate;
                updatedCustomer.MemberShipTypeId = customer.MemberShipTypeId;
                updatedCustomer.IsSubscibedToNewsLetter = customer.IsSubscibedToNewsLetter;
            }
            _Context.SaveChanges();
            return RedirectToAction("Index","Customers");  
        }
        public ViewResult Index()
        {
            var customers = _Context.Customers.Include(c=>c.MemberShipType);

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _Context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        /*
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>

            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" },
                new Customer{Id=3,Name="naseem hasasneh"}
            };
        

        }
        */
    }
}