using Microsoft.AspNetCore.Mvc;
using QuanLyTuyenDung.Models;
using System.Diagnostics;

namespace QuanLyTuyenDung.Controllers
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

		
	}
}
