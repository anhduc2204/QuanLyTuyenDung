using Microsoft.AspNetCore.Mvc;
using QuanLyTuyenDung.DAO;
using QuanLyTuyenDung.Models.ViewModels;
using QuanLyTuyenDung.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace QuanLyTuyenDung.Controllers
{
    [Route("Admin/")]
	public class TuyenDungController : Controller
	{

        private readonly ViecLamDAO _viecLamDAO;
        private readonly NguoiDungDAO _nguoiDungDAO;
        private readonly UngTuyenDAO _ungTuyenDAO;

        public TuyenDungController(ViecLamDAO viecLamDAO, NguoiDungDAO nguoiDungDAO, UngTuyenDAO ungTuyenDAO)
        {
            _viecLamDAO = viecLamDAO;
            _nguoiDungDAO = nguoiDungDAO;
            _ungTuyenDAO = ungTuyenDAO;

        }

        //Quan Ly Viec Lam
        [HttpGet]
        [Route("QuanLyViecLam")]
        [Route("")]

        public async Task<IActionResult> QuanLyViecLam()
        {
            //var ndjson = HttpContext.Session.GetString("NguoiDung");

            //if (ndjson == null)
            //{
            //    return RedirectToAction("Login", "TaiKhoan");
            //}

            NguoiDung nd = new NguoiDung { Email = "thang@gmail.com", MaND = 1, iMaTaiKhoan = 2, GioiTinh="Nam",NgaySinh=DateTime.Now};
            var ndJson = JsonConvert.SerializeObject(nd, Formatting.None,
                                        new JsonSerializerSettings()
                                        {
                                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                        });
            var nguoiDung = JsonConvert.DeserializeObject<NguoiDung>(ndJson);
            //var quyen = HttpContext.Session.GetString("QuyenHan");
            //if (quyen == null || !quyen.Equals("Admin"))
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            var dsViecLam = await _viecLamDAO.GetAll();
            return View(dsViecLam);
        }


        //Get Them Viec Lam
        [HttpGet]
        [Route("ThemViecLam")]
        public IActionResult ThemViecLam()
        {
            return View();
        }

        [HttpPost]
        [Route("ThemViecLam")]
        public async Task<IActionResult> ThemViecLam(ViecLamViewModel model)
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
                TieuDe = model.TieuDe,
                MoTa = model.MoTa,
                MucLuong = model.MucLuong,
                NgayTao = model.NgayTao,
                NgayHetHan = model.NgayHetHan,
                TrangThai = Convert.ToBoolean(model.TrangThai)
            };
            await _viecLamDAO.Save(viecLam);

            return RedirectToAction("QuanLyViecLam");
        }


        [HttpGet]
        [Route("DonUngTuyen/{id_vieclam}")]
        public IActionResult DonUngTuyen(int id_vieclam)
        {
            return View();
        }


    }
}
