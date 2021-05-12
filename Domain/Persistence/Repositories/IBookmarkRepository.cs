using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips_Api.Domain.Models;

namespace Trips_Api.Domain.Persistence.Repositories
{
    public interface IBookmarkRepository
    {
        Task<IEnumerable<Bookmark>> ListAsync();
        Task AddAsync(Bookmark bookmark);
        Task<Bookmark> FindByLatitudeAndLongitude(string latitude, string longitude);
        
    }
}
