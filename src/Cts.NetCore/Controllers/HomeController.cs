using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;
using Cts.NetCore.Models;
using Cts.NetCore.Services;

namespace Cts.NetCore.Controllers
{
    public class HomeController : Controller
    {
        public const string defaultCard = "Vampire King";
        public IActionResult Index()
        {
            var service = new HexSalesApi();
            var vm = service.GetIndexData(defaultCard);
            return View(vm);
        }
    }
}
