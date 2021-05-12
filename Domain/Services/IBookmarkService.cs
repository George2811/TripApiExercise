using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips_Api.Domain.Models;
using Trips_Api.Domain.Services.Communications;

namespace Trips_Api.Domain.Services
{
    public interface IBookmarkService
    {
        Task<IEnumerable<Bookmark>> ListAsync();
        Task<BookmarkResponse> SaveAsync(Bookmark bookmark);
    }
}
