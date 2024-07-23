namespace QuanLyTuyenDung.Controllers
{
	public class UngTuyenController
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
        [Route("Index")]
        [Route("")]
        public IActionResult QuanLyViecLam()
        {
            return View("~/Views/Admin/Index.cshtml");
        }

    }
}
