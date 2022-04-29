using DataBaseServises.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServises.Repositories
{
    public class PhotoRepository : IRepository<Photo>
    {

        AdContext _context;
        DbSet<Photo> _photos;

        public PhotoRepository()
        {
            _context = new AdContext();
            _photos = _context.Photos;
        }

        public async Task<Photo> CreateAsync(Photo item) {
            var photo = await _photos.AddAsync(item);
            return photo.Entity;
           
         }

        public async Task<IList<Photo>> GetAllAsync() => await _photos.ToListAsync();

        public async Task<Photo> GetByIdAsync(Guid id)=>await _photos.FirstOrDefaultAsync(x=>x.Id == id);

        public void Remove(Photo item)=>_photos.Remove(item);
        public async Task SaveChangesAsync()=>_context.SaveChangesAsync();

        public void Update(Photo item) => _context.SaveChanges();
    }
}
