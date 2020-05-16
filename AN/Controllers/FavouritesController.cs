using System;
using System.Collections.Generic;
using System.Linq;
using AN.Core;
using AN.Core.Domain;
using AN.DTO.Get;
using AN.DTO.Post;
using AN.DTO.Response;
using AN.Helpers.Constants;
using AN.Helpers.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AN.Controllers
{
    [Route("api/v1/user/{userId}/favourites")]
    [ApiController]
    [Authorize]
    public class FavouritesController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        private readonly ILogger<FavouritesController> _logger;

        private readonly IMapper _mapper;

        public FavouritesController(ILogger<FavouritesController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet(Name = "GetFavoritesForUser")]
        public ActionResult GetFavoritesForUser(string userId)
        {
            _logger.LogInformation(MyLogEvents.ListItems, "Listing user Favourites");

            if (!_unitOfWork.Favorites.UserExists(userId))
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "User does not exis");

                return NotFound(new ResponseDTO<string> { Code = 401, responseMessage = "User does not exist", returnObject = null });
            }

            var favouritesFromUsers = _unitOfWork.Favorites.GetUserFavorites(userId);

            var favoritesToReturn = _mapper.Map<IEnumerable<FavoriteDTO>>(favouritesFromUsers);

            return Ok(new ResponseDTO<List<FavoriteDTO>>() { Code = ResponseCodes.Success, responseMessage = "list of animes successfully returned", returnObject = favoritesToReturn.ToList() });
        }

        [HttpPost]
        public ActionResult CreateFavoritesForUser(string userId, [FromBody]CreateFavoriteDTO favourite)
        {
            _logger.LogInformation(MyLogEvents.InsertItem, "Adding user Favourites");

            if (!_unitOfWork.Favorites.UserExists(userId))
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "User does not exis");

                return NotFound(new ResponseDTO<string> { Code = 401, responseMessage = "User does not exist", returnObject = null });
            }

            var favouritesEntity = _mapper.Map<Favorite>(favourite);

            favouritesEntity.UserId = userId;

            _unitOfWork.Favorites.Add(favouritesEntity);

            _unitOfWork.Complete();

            var favoritesToReturn= _mapper.Map<FavoriteDTO>(favouritesEntity);

            return CreatedAtAction("GetFavoritesForUser",new { userId },new ResponseDTO<FavoriteDTO>() { Code = ResponseCodes.Success, responseMessage = "list of animes successfully returned", returnObject = favoritesToReturn });
        }

    }
}
