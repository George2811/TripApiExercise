using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips_Api.Domain.Models;
using Trips_Api.Resources;

namespace Trips_Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Bookmark, BookmarkResource>();
        }
    }
}
