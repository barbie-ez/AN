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

    [Route("api/v1/anime/{animeId}/rating")]
    [ApiController]
    [Authorize]
    public class RatingsController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        private readonly ILogger<RatingsController> _logger;

        private readonly IMapper _mapper;

        public RatingsController(ILogger<RatingsController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet(Name = "GetRatingsForAnime")]
        public ActionResult GetRatingsForAnime(int animeId)
        {
            _logger.LogInformation(MyLogEvents.ListItems, "Listing anime Favourites");

            if (!_unitOfWork.Ratings.AnimeExists(animeId))
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "anime does not exis");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "anime does not exist", returnObject = null });
            }

            var ratingsFromUsers = _unitOfWork.Ratings.GetAnimeRatings(animeId);

            var ratingsToReturn = _mapper.Map<IEnumerable<RatingDTO>>(ratingsFromUsers);

            return Ok(new ResponseDTO<IEnumerable<RatingDTO>>() { Code = ResponseCodes.Success, responseMessage = "list of anime ratings successfully returned", returnObject = ratingsToReturn });
        }

        [HttpPost]
        public ActionResult CreateRatingForAnime(int animeId, [FromBody]CreateRatingDTO rating)
        {
            _logger.LogInformation(MyLogEvents.InsertItem, "Adding anime Ratings");

            if (!_unitOfWork.Ratings.AnimeExists(animeId))
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "anime does not exis");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "anime does not exist", returnObject = null });
            }

            var ratingEntity = _mapper.Map<Rating>(rating);

            ratingEntity.AnimeId = animeId;

            _unitOfWork.Ratings.Add(ratingEntity);

            _unitOfWork.Complete();

            var ratingsToReturn = _mapper.Map<RatingDTO>(ratingEntity);

            return CreatedAtRoute("GetRatingsForAnime", new { animeId }, new ResponseDTO<RatingDTO>() { Code = ResponseCodes.Success, responseMessage = "list of animes ratings successfully returned", returnObject = ratingsToReturn });
        }

    }
}
