using DataBaseServises.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServises.Repositories
{
    public class AdRepository:IRepository<Ad>
    {
        DbSet<Ad> _ads;
        AdContext _context;

        public AdRepository()
        {
            _context = new AdContext();
            _ads = _context.Ads;
           
        }
       

        public async Task<Ad> CreateAsync(Ad item)
        {
            var ad= await _ads.AddAsync(item);
            return ad.Entity;
        }
        public void Update(Ad item)=>_ads.Update(item);
       

        public async Task<IList<Ad>> GetAllAsync()=> await _ads.ToListAsync();

        public async Task<Ad> GetByIdAsync(Guid id)=>await _ads.FirstOrDefaultAsync(x=>x.Id==id);

        public void Remove(Ad item)=>_ads.Remove(item);

        public async Task SaveChangesAsync()=>_context.SaveChangesAsync();
    }
}
