using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruyumOnline.Repositories;
using TruyumOnline.Models;

namespace TruyumOnline.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository adminrepository;
        public AdminController(IAdminRepository adminrepository)
        {
            this.adminrepository = adminrepository;
        }
        public IActionResult MenuList()
        {
            try
            {
                List<Items> itemsList = new List<Items>();
                itemsList = adminrepository.GetMenuItems().ToList();
                return View(itemsList);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult AddNewItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewItem(Items items)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    adminrepository.AddMenuItems(items);
                    return RedirectToAction("MenuList");
                }
               return View(items);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ModifyMenuItems(int? id)
        {
            Items item = adminrepository.GetMenuItemById(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModifyMenuItems(int id,Items items)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    adminrepository.ModifyMenuItems(items);
                    return RedirectToAction("MenuList");
                }
                return View(items);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetMenuItemById(int? id)
        {
            try
            {
                Items item = adminrepository.GetMenuItemById(id);
                return View(item);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult DeleteMenuItem(int? id)
        {
            return View(adminrepository.GetMenuItemById(id));
        }
        [HttpPost,ActionName("DeleteMenuItem")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMenuItem(int id)
        {
            adminrepository.DeleteMenuItem(id);
            return RedirectToAction("MenuList");
        }
    }
}