using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        public IActionResult Index(int tokenID)
        {
            return File(new byte[] { (byte)tokenID }, "text/text");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
