using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trips_Api.Domain.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
