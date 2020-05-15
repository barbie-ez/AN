using System;
using AN.Core;
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
            return Ok(_unitOfWork.Animes.GetAll());
        }

    }
}
