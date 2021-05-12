using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips_Api.Domain.Models;
using Trips_Api.Domain.Services;
using Trips_Api.Extensions;
using Trips_Api.Resources;

namespace Trips_Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;
        private readonly IMapper _mapper;

        public BookmarksController(IBookmarkService bookmarkService, IMapper mapper)
        {
            _bookmarkService = bookmarkService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookmarkResource>),200)]
        public async Task<IEnumerable<BookmarkResource>> GetAllAsync()
        {
            var bookmarks = await _bookmarkService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Bookmark>, IEnumerable<BookmarkResource>>(bookmarks);
            return resources;
        }


        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<BookmarkResource>), 200)]
        [ProducesResponseType(typeof(IEnumerable<BadRequestResult>), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveBookmarkResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var bookmark = _mapper.Map<SaveBookmarkResource, Bookmark>(resource);
            var result = await _bookmarkService.SaveAsync(bookmark);

            if (!result.Success)
                return BadRequest(result.Message);
            var bookmarkResource = _mapper.Map<Bookmark, BookmarkResource>(result.Resource);
            return Ok(bookmarkResource);
        }


    }
}
