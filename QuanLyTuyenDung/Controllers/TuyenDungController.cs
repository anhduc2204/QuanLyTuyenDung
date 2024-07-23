using Microsoft.AspNetCore.Mvc;
using QuanLyTuyenDung.DAO;
using QuanLyTuyenDung.Models.ViewModels;
using QuanLyTuyenDung.Models;

namespace QuanLyTuyenDung.Controllers
{
    [Route("Admin/")]
	public class TuyenDungController : Controller
	{

        [HttpGet]
        [Route("DonUngTuyen/{id_vieclam}")]
        public IActionResult DonUngTuyen(int id_vieclam)
        {
            return View();
        }


    }
}
