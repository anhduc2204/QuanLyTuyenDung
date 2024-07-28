﻿using Microsoft.AspNetCore.Mvc;
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
			var ndjson = HttpContext.Session.GetString("NguoiDung");

			if (ndjson == null)
			{
				return RedirectToAction("Login", "TaiKhoan");
			}
			var quyenHan = HttpContext.Session.GetString("QuyenHan");
			if (quyenHan == null || !quyenHan.Equals("Admin"))
			{
				return RedirectToAction("Login", "TaiKhoan");
			}
			var dsViecLam = await _viecLamDAO.GetAll();
			return View(dsViecLam);
		}


		//Get Them Viec Lam
		[HttpGet]
		[Route("ThemViecLam")]
		public IActionResult ThemViecLam()
		{
			var ndjson = HttpContext.Session.GetString("NguoiDung");

			if (ndjson == null)
			{
				return RedirectToAction("Login", "TaiKhoan");
			}
			var quyenHan = HttpContext.Session.GetString("QuyenHan");
			if (quyenHan == null || !quyenHan.Equals("Admin"))
			{
				return RedirectToAction("Login", "TaiKhoan");
			}
			ViewBag.Action = 1;
			
			return View("ViecLam");
		}

		[HttpPost]
		[Route("ThemViecLam")]
		public async Task<IActionResult> ThemViecLam(ViecLamViewModel model)
		{

			var ndjson = HttpContext.Session.GetString("NguoiDung");

			if (ndjson == null)
			{
				return RedirectToAction("Login", "TaiKhoan");
			}
			var quyenHan = HttpContext.Session.GetString("QuyenHan");
			if (quyenHan == null || !quyenHan.Equals("Admin"))
			{
				return RedirectToAction("Login", "TaiKhoan");
			}


			if (!ModelState.IsValid || model.NgayHetHan <= model.NgayTao)
			{
				if (model.NgayHetHan <= model.NgayTao)
				{
					ModelState.AddModelError("NgayHetHan", "Ngày hết hạn phải lớn hơn ngày tạo");
					return View("ViecLam",model);
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
		[Route("CapNhatViecLam/{id_vieclam}")]
		public async Task<IActionResult> CapNhatViecLam(int id_vieclam)
		{
			ViecLam viecLam = await _viecLamDAO.GetByID(id_vieclam);
			
			ViecLamViewModel model = new ViecLamViewModel
			{
				MaViecLam = viecLam.MaViecLam,
				TieuDe = viecLam.TieuDe,
				MoTa = viecLam.MoTa,
				MucLuong = viecLam.MucLuong,
				NgayTao = viecLam.NgayTao,
				NgayHetHan = viecLam.NgayHetHan,
				TrangThai = viecLam.TrangThai ? 1 : 0
			};
            ViewBag.Action = 0;
			ViewBag.id_vieclam = viecLam.MaViecLam;
            return View("ViecLam", model);
		}


		[HttpPost]
		[Route("CapNhatViecLam/{id_vieclam}")]
		public async Task<IActionResult> CapNhatViecLam(int id_vieclam, ViecLamViewModel model)
		{
			if (!ModelState.IsValid || model.NgayHetHan <= model.NgayTao)
			{
				if (model.NgayHetHan <= model.NgayTao)
				{
					ModelState.AddModelError("NgayHetHan", "Ngày hết hạn phải lớn hơn ngày tạo");
					return View("ViecLam",model);
				}
			}

			var viecLam = await _viecLamDAO.GetByID(id_vieclam);

			if(viecLam == null)
			{
				return View("ViecLam", model);
			}

			viecLam.TieuDe = model.TieuDe;
			viecLam.MoTa = model.MoTa;
			viecLam.MucLuong = model.MucLuong;
			viecLam.NgayTao = model.NgayTao;
			viecLam.NgayHetHan = model.NgayHetHan;
			viecLam.TrangThai = Convert.ToBoolean(model.TrangThai);

			var vl = _viecLamDAO.Update(viecLam);
			if(vl != null)
			{
				ViewBag.MessageCode = 1;
				ViewBag.Message = "Cập nhật thành công";
			}
			else
			{
				ViewBag.MessageCode = 0; 
				ViewBag.Message = "Cập nhật thất bại";
			}
			return RedirectToAction("CapNhatViecLam", new {id_viecLam = viecLam.MaViecLam});
		}


		[HttpGet]
		[Route("XoaViecLam/{id_vieclam}")]
        public async Task<IActionResult> XoaViecLam(int id_vieclam)
		{

			var viecLam = await _viecLamDAO.GetByID(id_vieclam);
			_viecLamDAO.Delete(viecLam);	
			return RedirectToAction("QuanLyViecLam", "TuyenDung");
		}




        [HttpGet]
		[Route("DonUngTuyen/{id_vieclam}")]
		public async Task<IActionResult> DonUngTuyen(int id_vieclam)
		{
			var ndjson = HttpContext.Session.GetString("NguoiDung");

			if (ndjson == null)
			{
				return RedirectToAction("Login", "TaiKhoan");
			}
			var quyenHan = HttpContext.Session.GetString("QuyenHan");
			if (quyenHan == null || !quyenHan.Equals("Admin"))
			{
				return RedirectToAction("Login", "TaiKhoan");
			}

			List<DonUngTuyen> DSDon = _ungTuyenDAO.getDonByMaViecLam(id_vieclam);
			ViecLam viecLam = await _viecLamDAO.GetByID(id_vieclam);
			List<UngTuyenViewModel> _UngTuyenViews = new List<UngTuyenViewModel>();
			foreach (DonUngTuyen don in DSDon)
			{
				var ungTuyenView = new UngTuyenViewModel
				{
					HoTen = don.NguoiDung.TenND,
					Email = don.NguoiDung.Email,
					SDT = don.NguoiDung.SDT,
					NgaySinh = don.NguoiDung.NgaySinh,
					MoTa = don.MoTa,
					MaND = don.iMaND

				};
				_UngTuyenViews.Add(ungTuyenView);

			}
			QuanLyUngTuyenViewModel model = new QuanLyUngTuyenViewModel
			{
				TieuDe = viecLam.TieuDe,
				MoTa = viecLam.MoTa,
				MucLuong = viecLam.MucLuong,
				UngTuyenViews = _UngTuyenViews
			};

			return View(model);
		}

		[HttpGet]
		[Route("ThongBao/{id_nd}")]
		public async Task<IActionResult> ThongBao(int id_nd)
		{
			var ndjson = HttpContext.Session.GetString("NguoiDung");
			if (ndjson == null)
			{
				return RedirectToAction("Login", "TaiKhoan");
			}
			var quyenHan = HttpContext.Session.GetString("QuyenHan");
			if (quyenHan == null || !quyenHan.Equals("Admin"))
				if (quyenHan == null || !quyenHan.Equals("Admin"))
			{
				return RedirectToAction("Login", "TaiKhoan");
			}

			NguoiDung nd = await _nguoiDungDAO.GetByID(id_nd);
			ThongBaoViewModel model = new ThongBaoViewModel();
			model.ToEmail = nd.Email;
			ViewBag.id_nd = id_nd;
			return View(model);
		}

		[HttpPost]
		[Route("ThongBao/{id_nd}")]
		public async Task<IActionResult> ThongBao(int id_nd, ThongBaoViewModel model)
		{
			ViewBag.id_nd = id_nd;
			if (!ModelState.IsValid)
			{
				if(string.IsNullOrWhiteSpace(model.Subject))
				{
					ModelState.AddModelError("Subject", "Không được bỏ trống");
				}
				if (string.IsNullOrWhiteSpace(model.Message))
				{
					ModelState.AddModelError("Message", "Không được bỏ trống");
				}

				return View(model);
			}

			int check = await Utils.MailUtil.GuiThongBao(model.ToEmail.Trim(), model.Subject.Trim(), model.Message.Trim());
			ViewBag.MessageCode = check;
			if (check == 1)
			{
				ViewBag.Message = "Gửi thành công";
			}
			else
			{
				ViewBag.Message = "Gửi thất bại";
			}
			return View(model);
		}


	}
}
