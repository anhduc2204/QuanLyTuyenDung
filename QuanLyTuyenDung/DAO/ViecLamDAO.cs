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


    }
}
