using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Customer_Classes;

namespace SalesOrderSystemWebUI.Controllers
{ 

    [Authorize(Roles ="Admin, Casher")]
    public class CustomerController : Controller
    {
        CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            this._customerService = customerService;
        }

        public IActionResult Index()
        {
            var Customers = _customerService.GetAllWithOrders();
            return View(Customers);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        public IActionResult EditCustomer(int Id)
        {
            var customer = _customerService.GetCustomerById(Id);
            if (customer == null) return NotFound();
            //if (customer is Person p)
            //    return View("EditPerson", p);
            //else if (customer is Company c)
            //    return View("EditCompany", c);
            //else
                return View(customer);
        }
        public IActionResult LoadCustomerForm(string type)
        {
            if (type == "Person")
                return PartialView("PersonForm");

            if (type == "Company")
                return PartialView("CompanyForm");

            return PartialView("_DefaultForm");
        }
        public IActionResult LoadCustomer(int Id)
        {
            try
            {
                var customer = _customerService.GetCustomerById(Id);
                return PartialView("EditCustomer", customer);
            }
            catch
            {
                return Json(new { redirectUrl = Url.Action("AddCustomer", "Customer") });
            }
        }

        public IActionResult CustomerDetails(int Id)
        {
            var customer = _customerService.GetCustomerById(Id);
            if (customer == null) return NotFound();

            return View(customer);
        }
        [HttpPost]
        public IActionResult SaveEditedCustomer(Customer customer)
        {
            if (customer is not null && customer.CustomerId != 0)
            {
                _customerService.UpdateCustomer(customer);
                return RedirectToAction("index");
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCustomer(int Id)
        {
            _customerService.RemoveCustomer(Id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SaveAddedCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.AddCustomer(customer);
                return RedirectToAction("index");
            }
            return View("AddCustomer", customer);
        }


    }
}
