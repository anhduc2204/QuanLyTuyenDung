using System.ComponentModel.DataAnnotations;

namespace QuanLyTuyenDung.Models.ViewModels
{
    public class QuanLyUngTuyenViewModel
    {
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        public string MoTa { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống"), Range(1, float.MaxValue, ErrorMessage = "Mức lương không hợp lệ")]
        public float MucLuong { get; set; }

        public IEnumerable<UngTuyenViewModel> UngTuyenViews { get; set; }




    }
}
