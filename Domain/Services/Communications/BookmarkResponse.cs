using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips_Api.Domain.Models;

namespace Trips_Api.Domain.Services.Communications
{
    public class BookmarkResponse : BaseResponse<Bookmark>
    {
        public BookmarkResponse(Bookmark resource) : base(resource)
        {
        }

        public BookmarkResponse(string message) : base(message)
        {
        }
    }
}
