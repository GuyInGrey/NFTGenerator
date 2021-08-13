using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using NFTGenerator;

using NFTInterface.Models;

namespace NFTInterface.Controllers
{
    public class GhostNFT : Controller
    {
        public IActionResult Mint(string token)
        {
            if (token is null || !int.TryParse(token, out var tokenID) || tokenID < 0 || tokenID > 1023) { return StatusCode(422); }
            //if (wallet is null) { return StatusCode(422); }
            //wallet = wallet.StartsWith("0x") ? wallet[2..] : wallet;
            //if (wallet.Length != 40) { return StatusCode(422); }
            return File(Generator.Generate(tokenID/*, wallet*/), "image/png");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }) ;
        }
    }
}
