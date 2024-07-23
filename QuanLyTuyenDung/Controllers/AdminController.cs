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

        [HttpGet]
        [Route("ThemViecLam")]
        public IActionResult ThemViecLam()
        {
            return View("~/Views/Admin/ThemViecLam.cshtml");
        }

        [HttpPost]
        [Route("CapNhatViecLam")]
        public async Task<IActionResult> CapNhatViecLam(ViecLamViewModel model)
        {
            if (!ModelState.IsValid || model.NgayHetHan <= model.NgayTao)
            {
                if (model.NgayHetHan <= model.NgayTao)
                {
                    ModelState.AddModelError("NgayHetHan", "Ngày hết hạn phải lớn hơn ngày tạo");
                    return View(model);
                }
            }

            var viecLam = new ViecLam
            {
                MaViecLam = model.MaViecLam,
                TieuDe = model.TieuDe,
                MoTa = model.MoTa,
                MucLuong = model.MucLuong,
                NgayTao = model.NgayTao,
                NgayHetHan = model.NgayHetHan,
                TrangThai = Convert.ToBoolean(model.TrangThai)
            };

            await _ViecLamdao.Update(viecLam);
            return RedirectToAction("QuanLyViecLam");
        }
    }
}
