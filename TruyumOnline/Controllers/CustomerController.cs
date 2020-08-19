using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruyumOnline.Repositories;
using TruyumOnline.Models;

namespace TruyumOnline.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerrepository;
        public CustomerController(ICustomerRepository customerrepository)
        {
            this.customerrepository = customerrepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                List<Items> itemsList = new List<Items>();
                itemsList = customerrepository.GetAllItems().ToList();
                return View(itemsList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult AddToCart(int? id)
        {
            try
            {
                Items item = customerrepository.GetMenuItemById(id);
                customerrepository.AddToCart(item);
                return View(item);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllCartItems()
        {
            try
            {
                return View(customerrepository.GetAllCartItems());
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult DeleteCartItem(int? id)
        {
            return View(customerrepository.GetCartItem(id));
        }
        [HttpPost, ActionName("DeleteCartItem")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCartItem(int id)
        {
            customerrepository.DeleteCartItem(id);
            return RedirectToAction("GetAllCartItems");
        }
    }
}