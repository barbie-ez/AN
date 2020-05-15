using System;
using System.Collections.Generic;
using System.Linq;
using AN.Core;
using AN.Core.Domain;
using AN.DTO.Response;
using AN.Helpers.Logging;
using Microsoft.AspNetCore.Authorization;
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

        public AnimesController(ILogger<AnimesController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [Produces("application/json")]
        [HttpGet]
        public IActionResult GetAnimes()
        {
            _logger.LogInformation(MyLogEvents.GetItem, "Getting items");

            return Ok(new ResponseDTO<List<Anime>>(){ Code = 200, responseMessage="list of animes successfully returned",returnObject= _unitOfWork.Animes.GetAll().ToList() }) ;
        }

    }
}
