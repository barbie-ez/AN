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
using AN.Helpers.Logging;
using AN.Helpers.Tools;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ubiety.Dns.Core.Common;

namespace AN.Controllers
{
    [Route("api/v1/studio")]
    [ApiController]
    [Authorize]
    public class StudiosController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        private readonly ILogger<StudiosController> _logger;

        private readonly IMapper _mapper;

        public StudiosController(ILogger<StudiosController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet()]
        public ActionResult GetStudios()
        {
            _logger.LogInformation(MyLogEvents.ListItems, "Listing Studios");

            var studios = _unitOfWork.Studios.GetAll();

            var studioToReturn = _mapper.Map<IEnumerable<StudioDTO>>(studios);

            return Ok(new ResponseDTO<List<StudioDTO>>() { Code = ResponseCodes.Success, responseMessage = "list of studios successfully returned", returnObject = studioToReturn.ToList() });
        }

        [Produces("application/json")]
        [HttpGet("{studioId}", Name = "GetStudiosWithId")]
        public ActionResult GetStudiosWithId(int studioId)
        {
            _logger.LogInformation(MyLogEvents.GetItem, "Get Studio");

            var studio = _unitOfWork.Studios.FirstOrDefault(r => r.Id == studioId);

            if (studio == null)
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "Studio does not exist");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "Studio does not exist", returnObject = null });

            }

            var studioToReturn = _mapper.Map<StudioDTO>(studio);

            return Ok(new ResponseDTO<StudioDTO>() { Code = ResponseCodes.Success, responseMessage = "list of studios successfully returned", returnObject = studioToReturn });
        }

        [Produces("application/json")]
        [HttpGet("{studioId}/anime", Name = "GetStudiosWithAnime")]
        public ActionResult GetStudiosWithAnime(int studioId)
        {
            _logger.LogInformation(MyLogEvents.GetItem, "Get Studio with Anime");

            var studio = _unitOfWork.Studios.GetStudioWithAnime(studioId);

            if (studio == null)
            {
                _logger.LogInformation(MyLogEvents.GetItemNotFound, "Studio does not exist");

                return NotFound(new ResponseDTO<string> { Code = ResponseCodes.NotFound, responseMessage = "Studio does not exist", returnObject = null });

            }

            var studioToReturn = _mapper.Map<StudioDTO>(studio);


            return Ok(new ResponseDTO<StudioDTO>() { Code = ResponseCodes.Success, responseMessage = "list of studios successfully returned", returnObject = studioToReturn });
        }


        //[Produces("application/json")]
        //[HttpGet(Name = "GetStudiosWithAnimes")]
        //public ActionResult GetStudiosWithAnimes()
        //{
        //    _logger.LogInformation(MyLogEvents.ListItems, "Listing Studios with Anime");

        //    var studios = _unitOfWork.Studios.GetStudioWithAnime();

        //    var studioToReturn = _mapper.Map<IEnumerable<StudioDTO>>(studios);

        //    return Ok(new ResponseDTO<List<StudioDTO>>() { Code = ResponseCodes.Success, responseMessage = "list of studios successfully returned", returnObject = studioToReturn.ToList() });
        //}
        private async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, Helper.GetContentType(path), Path.GetFileName(path));
        }
        [HttpPost()]
        public ActionResult CreateStudios(CreateStudioDTO studio)
        {
            _logger.LogInformation(MyLogEvents.InsertItem, "Create Studios");

            if (studio == null)
            {
                return BadRequest();
            }

            var studioEntity = _mapper.Map<Studio>(studio);

            _unitOfWork.Studios.Add(studioEntity);

            _unitOfWork.Complete();

            var studioToReturn = _mapper.Map<StudioDTO>(studioEntity);

            return CreatedAtRoute("GetStudiosWithId", new { studioId= studioEntity.Id },new ResponseDTO<StudioDTO>() { Code = ResponseCodes.Success, responseMessage = "list of studios successfully returned", returnObject = studioToReturn });
        }
    }
}
