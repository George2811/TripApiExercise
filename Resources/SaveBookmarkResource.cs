using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trips_Api.Resources
{
    public class SaveBookmarkResource
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }

    }
}
