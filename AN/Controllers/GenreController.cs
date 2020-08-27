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


    [Route("api/v1/genre")]
    [ApiController]
    [Authorize]
    public class GenreController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        private readonly ILogger<GenreController> _logger;

        private readonly IMapper _mapper;

        public GenreController(ILogger<GenreController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet()]
        public ActionResult GetGenres()
        {
                _logger.LogInformation(MyLogEvents.ListItems, "Listing Genres");

                var genres = _unitOfWork.Genres.GetAll();

                var genreToReturn = _mapper.Map<IEnumerable<GenreDTO>>(genres);

                return Ok(new ResponseDTO<List<GenreDTO>>() { Code = ResponseCodes.Success, responseMessage = "list of genres successfully returned", returnObject = genreToReturn.ToList() });
            
        }

        [Produces("application/json")]
        [HttpGet("{genreId}", Name = "GetGenresWithId")]
        public ActionResult GetGenresWithId(int genreId)
        {
            _logger.LogInformation(MyLogEvents.GetItem, "Get Genre");

            var genre = _unitOfWork.Genres.FirstOrDefault(r => r.Id == genreId);

            if (genre == null)
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "Genre does not exist");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "Genre does not exist", returnObject = null });

            }

            var genreToReturn = _mapper.Map<GenreDTO>(genre);

            return Ok(new ResponseDTO<GenreDTO>() { Code = ResponseCodes.Success, responseMessage = "list of genres successfully returned", returnObject = genreToReturn });
        }

        [Produces("application/json")]
        [HttpGet("{genreId}/anime", Name = "GetGenresWithAnime")]
        public ActionResult GetGenresWithAnime(int genreId)
        {
            _logger.LogInformation(MyLogEvents.GetItem, "Get Genres with Anime");

            var genre = _unitOfWork.Genres.GetGenreWithAnime(genreId);

            if (genre == null)
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "Genre does not exist");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "Genre does not exist", returnObject = null });

            }

            var genreToReturn = _mapper.Map<GenreDTO>(genre);


            return Ok(new ResponseDTO<GenreDTO>() { Code = ResponseCodes.Success, responseMessage = "list of genres successfully returned", returnObject = genreToReturn });
        }


        [HttpPost()]
        public ActionResult CreateGenres(CreateGenreDTO genre)
        {
            _logger.LogInformation(MyLogEvents.InsertItem, "Create Genres");

            if (genre == null)
            {
                return BadRequest();
            }

            var genreEntity = _mapper.Map<Genre>(genre);

            _unitOfWork.Genres.Add(genreEntity);

            _unitOfWork.Complete();

            var genreToReturn = _mapper.Map<GenreDTO>(genreEntity);

            return CreatedAtRoute("GetGenresWithId", new { genreId = genreEntity.Id }, new ResponseDTO<GenreDTO>() { Code = ResponseCodes.Success, responseMessage = "list of genres successfully returned", returnObject = genreToReturn });
        }
    }
}
