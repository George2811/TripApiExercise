using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trips_Api.Domain.Models
{
    public class Bookmark
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
