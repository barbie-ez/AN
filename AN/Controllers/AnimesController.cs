using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AN.Controllers
{
    [Route("api/v1/anime")]
    [ApiController]
    [Authorize]
    public class AnimesController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }
        private readonly ILogger<AnimesController> _logger;
        private readonly IMapper _mapper;
        IWebHostEnvironment _environment;
        public AnimesController(ILogger<AnimesController> logger, IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment environment)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _environment = environment;
        }

        [Produces("application/json")]
        [HttpGet]
        public ActionResult GetAnimes()
        {
            _logger.LogInformation(MyLogEvents.ListItems, "Listing animes");

            return Ok(new ResponseDTO<List<Anime>>() { Code = 200, responseMessage = "list of animes successfully returned", returnObject = _unitOfWork.Animes.GetAll().ToList() });
        }

        [Produces("application/json")]
        [HttpGet("{Id}", Name = "GetAnimesWithId")]
        public ActionResult GetAnimesWithId(int Id)
        {
            _logger.LogInformation(MyLogEvents.GetItem, "Get Studio");

            var anime = _unitOfWork.Animes.FirstOrDefault(r => r.Id == Id);

            if (anime == null)
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "Anime does not exist");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "Anime does not exist", returnObject = null });

            }

            var animeToReturn = _mapper.Map<AnimeDTO>(anime);

            return Ok(new ResponseDTO<AnimeDTO>() { Code = ResponseCodes.Success, responseMessage = "list of animes successfully returned", returnObject = animeToReturn });
        }

        [HttpPost]
        public ActionResult CreateAnime([FromForm] CreateAnimeDTO anime)
        {
            _logger.LogInformation(MyLogEvents.InsertItem, "Adding anime");

            if (_unitOfWork.Animes.FirstOrDefault(a=>a.Title==anime.Title)!=null)
            {
                _logger.LogInformation(MyLogEvents.InsertItem, "anime already created");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "anime does not exist", returnObject = null });
            }

            var animeEnitity = _mapper.Map<Anime>(anime);

            animeEnitity.AnimeIcon = UploadFile(anime.AnimeIcon);

            _unitOfWork.Animes.Add(animeEnitity);

            

            _unitOfWork.Complete();

            var animeToReturn = _mapper.Map<AnimeDTO>(animeEnitity);

            return CreatedAtRoute("GetAnimesWithId", new { animeToReturn.Id }, new ResponseDTO<AnimeDTO>() { Code = ResponseCodes.Success, responseMessage = "list of animes forums successfully returned", returnObject = animeToReturn });
        }

        private string UploadFile(IFormFile file)
        {
            string filename = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                filename = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return filename;
        }

    }

}

