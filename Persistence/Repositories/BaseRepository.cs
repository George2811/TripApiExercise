using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips_Api.Domain.Persistence.Contexts;

namespace Trips_Api.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
