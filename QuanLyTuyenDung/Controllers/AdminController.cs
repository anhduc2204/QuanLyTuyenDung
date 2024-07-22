using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanLyTuyenDung.DAO;
using QuanLyTuyenDung.Models;
using QuanLyTuyenDung.Models.ViewModels;

namespace QuanLyTuyenDung.Controllers
{
    public class AdminController : Controller
    {
        private readonly ViecLamDAO _viecLamDAO;
        private readonly NguoiDungDAO _nguoiDungDAO;
        private readonly UngTuyenDAO _ungTuyenDAO;

        public AdminController(ViecLamDAO viecLamDAO, NguoiDungDAO nguoiDungDAO, UngTuyenDAO ungTuyenDAO)
        {
            _viecLamDAO = viecLamDAO;
            _nguoiDungDAO = nguoiDungDAO;
            _ungTuyenDAO = ungTuyenDAO;

        }

        //Quan Ly Viec Lam
        [HttpGet]
        [Route("QuanLyViecLam")]
        [Route("")]
        public  IActionResult QuanLyViecLam()
        {
            return View("~/Views/Admin/QuanLyViecLam.cshtml");
        }

    }
}
