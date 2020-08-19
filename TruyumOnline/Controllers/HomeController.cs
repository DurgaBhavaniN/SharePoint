using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TruyumOnline.Models;

namespace TruyumOnline.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult UserLogin(string UserName,string Password)
		{
			try
			{
				if (UserName == "Admin" && Password == "Admin")
				{
					return RedirectToAction("MenuList", "Admin");
				}
				else if (UserName == "Customer" && Password == "Customer")
				{
					return RedirectToAction("GetAllItems", "Customer");
				}
				else
				{
					ViewBag.Message = "Invalid Credentials";
				}
			}
			catch(Exception ex)
			{
				return NotFound(ex.Message);
			}
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
