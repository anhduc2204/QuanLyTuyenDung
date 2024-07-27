using QuanLyTuyenDung.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<ViecLam>> GetAll()
        {
            return await _dataContext.DSViecLam
                .Include(vl => vl.DSDonUT)
                .ToListAsync<ViecLam>();
        }

        public async Task<ViecLam> Save(ViecLam viecLam)
        {
            var vl = await _dataContext.DSViecLam.AddAsync(viecLam);
            await _dataContext.SaveChangesAsync();
            return vl.Entity;
        }

        public async Task<ViecLam> GetByID(int id)
        {
            return await _dataContext.DSViecLam.FindAsync(id);

        }

        public async Task<List<ViecLam>> TimKiem(String searchString)
        {
            return await _dataContext.DSViecLam
                        .Where(v => v.TieuDe.Contains(searchString) || v.MoTa.Contains(searchString))
                        .ToListAsync();

        }
    }
}
 
