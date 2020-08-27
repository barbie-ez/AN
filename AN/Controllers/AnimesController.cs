using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AN.Core;
using AN.Core.Domain;
using AN.DTO.Get;
using AN.DTO.Post;
using AN.DTO.Response;
using AN.Helpers.Constants;
using AN.Helpers.Filter;
using AN.Helpers.Logging;
using AN.Helpers.Tools;
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
        public ActionResult GetAnimes([FromQuery] PaginationFilter filter)
        {
            _logger.LogInformation(MyLogEvents.ListItems, "Listing animes");

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            return Ok(new ResponseDTO<List<Anime>>() { Code = 200, responseMessage = "list of animes successfully returned", returnObject = _unitOfWork.Animes.GetAll().ToList() });
        }

        [

        Produces("application/json")]
        [HttpGet("{Id}", Name = "GetAnimesWithId")]
        public ActionResult GetAnimesWithId(int Id)
        {
            _logger.LogInformation(MyLogEvents.GetItem, "Get Anime");

            var anime = _unitOfWork.Animes.FirstOrDefault(r => r.Id == Id);

            if (anime == null)
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "Anime does not exist");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "Anime does not exist", returnObject = null });

            }

            var animeToReturn = _mapper.Map<AnimeDTO>(anime);

            return Ok(new ResponseDTO<AnimeDTO>() { Code = ResponseCodes.Success, responseMessage = "list of animes successfully returned", returnObject = animeToReturn });
        }

        [Produces("application/json")]
        [HttpGet("Icon/{Id}", Name = "GetAnimeIcon")]
        public async Task<ActionResult> GetAnimeIcon(string Id)
        {
            _logger.LogInformation(MyLogEvents.GetItem, "Get Anime Icon");

            if (string.IsNullOrEmpty(Id))
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "Icon does not exist");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "Anime does not exist", returnObject = null });
            }

            if (Id == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/images", Id);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return File(memory, Helper.GetContentType(path), Path.GetFileName(path));
        }

        [Produces("application/json")]
        [HttpPost]
        public ActionResult CreateAnime([FromForm] CreateAnimeDTO anime)
        {
            _logger.LogInformation(MyLogEvents.InsertItem, "Adding anime");

            if (_unitOfWork.Animes.FirstOrDefault(a=>a.Title==anime.Title)!=null)
            {
                _logger.LogInformation(MyLogEvents.InsertItem, "anime already created");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "anime already created", returnObject = null });
            }

            var animeEnitity = _mapper.Map<Anime>(anime);

            _unitOfWork.Animes.Add(animeEnitity);

            _unitOfWork.Complete();

            foreach (var item in anime.AnimeGenre)
            {
                if (_unitOfWork.Genres.FirstOrDefault(g => g.Id == item)!=null)
                {
                    animeEnitity.AnimeGenres.Add(new AnimeGenre {AnimeId=animeEnitity.Id, GenreId=item });
                }
            }

           
            animeEnitity.AnimeIcon = UploadFile(anime.AnimeIcon);

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

        private async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/images", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, Helper.GetContentType(path), Path.GetFileName(path));
        }


    }

}

