using QuanLyTuyenDung.Models;

namespace QuanLyTuyenDung.DAO
{
	public class ViecLamDAO
	{
        private readonly DataContext _dataContext;

        public ViecLamDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Delete(int id)
        {
            var viecLam = await _dataContext.DSViecLam.FindAsync(id);
            if (viecLam != null)
            {
                _dataContext.DSViecLam.Remove(viecLam);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task Update(ViecLam updatedViecLam)
        {
            // Tìm việc làm cần cập nhật
            var viecLam = await _dataContext.DSViecLam.FindAsync(updatedViecLam.MaViecLam);
            if (viecLam != null)
            {
                // Cập nhật thuộc tính của việc làm
                viecLam.TieuDe = updatedViecLam.TieuDe;
                viecLam.MoTa = updatedViecLam.MoTa;
                viecLam.MucLuong = updatedViecLam.MucLuong;
                viecLam.NgayTao = updatedViecLam.NgayTao;
                viecLam.NgayHetHan = updatedViecLam.NgayHetHan;
                viecLam.TrangThai = updatedViecLam.TrangThai;

                // Lưu thay đổi vào cơ sở dữ liệu
                await _dataContext.SaveChangesAsync();
            }
        }

    }
}
