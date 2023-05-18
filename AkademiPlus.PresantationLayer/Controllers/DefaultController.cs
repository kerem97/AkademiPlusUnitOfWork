using AkademiPlus.BusinessLayer.Abstract;
using AkademiPlus.EntityLayer.Concrete;
using AkademiPlus.PresantationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace AkademiPlus.PresantationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICustomerService _customerService;

        public DefaultController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult CustomerList()
        {
            var values = _customerService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CustomerAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerAdd(Customer customer)
        {
            _customerService.TInsert(customer);
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public IActionResult SendMoney()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMoney(CustomerViewModel customerViewModel)
        {
            var value1 = _customerService.TGetByID(customerViewModel.SenderID);
            var value2 = _customerService.TGetByID(customerViewModel.ReceiverID);

            value1.CustomerBalance -= customerViewModel.Amount;
            value2.CustomerBalance += customerViewModel.Amount;

            List<Customer> modifiedCustomers = new List<Customer>()
            {
                value1,
                value2
            };

            _customerService.TMultiUpdate(modifiedCustomers);
            return RedirectToAction("CustomerList");
        }

    }
}
