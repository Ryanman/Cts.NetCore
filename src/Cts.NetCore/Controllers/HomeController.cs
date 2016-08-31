using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;
using Cts.NetCore.Models;
using Cts.NetCore.Services;
using Cts.NetCore.Models.ViewModels;

namespace Cts.NetCore.Controllers
{
    public class HomeController : Controller
    {
        public const string defaultCard = "Vampire King";
        public IActionResult Index(string cardName = null)
        {
            var service = new HexSalesApi();
            var vm = service.GetIndexData(cardName ?? defaultCard);
            return View(vm);
        }

        [HttpPost]
        public ActionResult LoadCardInfoTab(IndexViewModel card)
        {
            var service = new HexSalesApi();
            //var results = service.GetCardInfo(card.CardSearchName);            
            //return PartialView("Views/Shared/_CardInfo.cshtml", results);
            var results = service.GetIndexData(card.CardSearchName);
            return View("Views/Shared/Index.cshtml", results);
        }
    }
}
