using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AN.Models;
using AN.Core;
using Microsoft.AspNetCore.Authorization;

namespace AN.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IUnitOfWork _unitOfWork { get; set; }

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
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

        [Produces("application/json")]
        [HttpPost]
        public IActionResult GetAnimes(int id)
        {

            return Ok(_unitOfWork.Animes.GetAll());
        }

    }
}
