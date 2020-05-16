using System;
using System.Collections.Generic;
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

    [Route("api/v1/anime/{animeId}/forum")]
    [ApiController]
    [Authorize]
    public class ForumController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        private readonly ILogger<ForumController> _logger;

        private readonly IMapper _mapper;

        public ForumController(ILogger<ForumController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet(Name = "GetForumsForAnime")]
        public ActionResult GetForumsForAnime(int animeId)
        {
            _logger.LogInformation(MyLogEvents.ListItems, "Listing anime Favourites");

            if (!_unitOfWork.Forums.AnimeExists(animeId))
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "anime does not exis");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "anime does not exist", returnObject = null });
            }

            var forumsForAnimes = _unitOfWork.Forums.GetAnimeForums(animeId);

            var forumToReturn = _mapper.Map<IEnumerable<ForumDTO>>(forumsForAnimes);

            return Ok(new ResponseDTO<IEnumerable<ForumDTO>>() { Code = ResponseCodes.Success, responseMessage = "list of anime forums successfully returned", returnObject = forumToReturn });
        }

        [Produces("application/json")]
        [HttpGet("{forumId}",Name = "GetForumForAnime")]
        public ActionResult GetForumForAnime(int animeId, int forumId)
        {
            _logger.LogInformation(MyLogEvents.GetItem, "Get Anime Studio");

            if (!_unitOfWork.Forums.AnimeExists(animeId))
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "anime does not exis");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "anime does not exist", returnObject = null });
            }

            var forum = _unitOfWork.Forums.FirstOrDefault(r => r.Id == forumId);

            if (forum == null)
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "Forum does not exist");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "Forum does not exist", returnObject = null });
            }

            var forumsForAnimes = _unitOfWork.Forums.GetAnimeForum(animeId,forumId);

            var forumToReturn = _mapper.Map<ForumDTO>(forumsForAnimes);

            return Ok(new ResponseDTO<ForumDTO>() { Code = ResponseCodes.Success, responseMessage = "list of anime forums successfully returned", returnObject = forumToReturn });
        }

        [HttpPost]
        public ActionResult CreateForumFromAnime(int animeId, [FromBody]CreateForumDTO forum)
        {
            _logger.LogInformation(MyLogEvents.InsertItem, "Adding anime Ratings");

            if (!_unitOfWork.Forums.AnimeExists(animeId))
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "anime does not exis");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "anime does not exist", returnObject = null });
            }

            var forumEntity = _mapper.Map<Forum>(forum);

            forumEntity.AnimeId = animeId;

            _unitOfWork.Forums.Add(forumEntity);

            _unitOfWork.Complete();

            var forumToReturn = _mapper.Map<ForumDTO>(forumEntity);

            return CreatedAtRoute("GetForumForAnime", new { animeId }, new ResponseDTO<ForumDTO>() { Code = ResponseCodes.Success, responseMessage = "list of animes forums successfully returned", returnObject = forumToReturn });
        }

    }
}


