using Microsoft.AspNetCore.Mvc;
using QuanLyTuyenDung.DAO;
using QuanLyTuyenDung.Models.ViewModels;
using QuanLyTuyenDung.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace QuanLyTuyenDung.Controllers
{
    [Route("Admin/")]
	public class TuyenDungController : Controller
	{

        //Quan Ly Viec Lam
        [HttpGet]
        [Route("QuanLyViecLam")]
        [Route("")]
        public IActionResult QuanLyViecLam()
        {
            return View("~/Views/Admin/QuanLyViecLam.cshtml");
        }
        //Them Viec Lam
        [HttpGet]
        [Route("ThemViecLam")]
        public IActionResult ThemViecLam()
        {
            return View("~/Views/Admin/ThemViecLam.cshtml");
        }


        [HttpGet]
        [Route("DonUngTuyen/{id_vieclam}")]
        public IActionResult DonUngTuyen(int id_vieclam)
        {
            return View();
        }


    }
}
