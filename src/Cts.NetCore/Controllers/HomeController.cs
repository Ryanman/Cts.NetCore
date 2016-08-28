using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;
using Cts.NetCore.Models;
using Cts.NetCore.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cts.NetCore.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var request = WebRequest.Create("https://api.hexsales.net/v1/articles/Vampire%20King");
            var service = new HexSalesApi();
            var queryString = "articles/Vampire%20King";
            queryString = service.CreateRequest(queryString);
            var vampireKing =  service.MakeRequest(queryString);
            HexCard vampKing = JsonConvert.DeserializeObject<HexCard>(vampireKing.Result);

            return View(vampireKing);
        }
    }
}
