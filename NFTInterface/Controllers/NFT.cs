using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using NFTGenerator;

using NFTInterface.Models;

namespace NFTInterface.Controllers
{
    public class NFT : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public NFT(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Image(string token)
        {
            if (token is null || !int.TryParse(token, out var tokenID) || tokenID < 0 || tokenID > 1023) { return StatusCode(422); }
            return File(Generator.Generate(tokenID), "image/png");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
