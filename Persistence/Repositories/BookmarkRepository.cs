using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips_Api.Domain.Models;
using Trips_Api.Domain.Persistence.Contexts;
using Trips_Api.Domain.Persistence.Repositories;

namespace Trips_Api.Persistence.Repositories
{
    public class BookmarkRepository : BaseRepository, IBookmarkRepository
    {
        public BookmarkRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Bookmark bookmark)
        {
            await _context.Bookmarks.AddAsync(bookmark);
        }

        public async Task<Bookmark> FindByLatitudeAndLongitude(string latitude, string longitude)
        {
            List<Bookmark> bookmarks =  await _context.Bookmarks.Where(b => b.Latitude == latitude && b.Longitude == longitude)
                .ToListAsync();
            return bookmarks.FirstOrDefault();
        }

        public async Task<IEnumerable<Bookmark>> ListAsync()
        {
            return await _context.Bookmarks.ToListAsync();
        }
    }
}
