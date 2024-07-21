using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyTuyenDung.Models.ViewModels
{
    public class ViecLamViewModel
    {
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        public string MoTa { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống"), Range(1, float.MaxValue, ErrorMessage = "Mức lương không hợp lệ")]
        public float MucLuong { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        public DateTime NgayTao { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        public DateTime NgayHetHan { get; set; }

        public int TrangThai { get; set; }

    }
}
