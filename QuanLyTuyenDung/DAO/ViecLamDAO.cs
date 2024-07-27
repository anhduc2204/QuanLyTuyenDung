﻿using QuanLyTuyenDung.Models;
<<<<<<< HEAD
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> developer

namespace QuanLyTuyenDung.DAO
{
	public class ViecLamDAO
	{
        private readonly DataContext _dataContext;

        public ViecLamDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

<<<<<<< HEAD
        public async Task Delete(int id)
        {
            var viecLam = await _dataContext.DSViecLam.FindAsync(id);
            if (viecLam != null)
            {
                _dataContext.DSViecLam.Remove(viecLam);
                await _dataContext.SaveChangesAsync();
            }
        }


=======
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
>>>>>>> developer
    }
}
 
