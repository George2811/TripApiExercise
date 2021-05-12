using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips_Api.Domain.Models;
using Trips_Api.Domain.Persistence.Repositories;
using Trips_Api.Domain.Services;
using Trips_Api.Domain.Services.Communications;

namespace Trips_Api.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookmarkService(IBookmarkRepository bookmarkRepository, IUnitOfWork unitOfWork)
        {
            _bookmarkRepository = bookmarkRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Bookmark>> ListAsync()
        {
            return await _bookmarkRepository.ListAsync();
        }

        public async Task<BookmarkResponse> SaveAsync(Bookmark bookmark)
        {
            try
            {
                Bookmark bookmarkRequest = await _bookmarkRepository.FindByLatitudeAndLongitude(bookmark.Latitude, bookmark.Longitude);
                if (bookmarkRequest != null)
                    return new BookmarkResponse("An error ocurred while saving the bookmark: Geolocation is already assigned to an existing Bookmark");
                await _bookmarkRepository.AddAsync(bookmark);
                await _unitOfWork.CompleteAsync();
                return new BookmarkResponse(bookmark);
            }
            catch (Exception ex)
            {
                return new BookmarkResponse($"An error ocurred while saving the bookmark: {ex.Message}");
            }
        }
    }
}
