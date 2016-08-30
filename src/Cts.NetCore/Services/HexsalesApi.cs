using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Cts.NetCore.Models;
using Cts.NetCore.Models.ViewModels;

namespace Cts.NetCore.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HexSalesApi
    {
        public const string hexSales = "https://api.hexsales.net/v1/";
        public HexSalesApi()
        {
            //Build Data
        }

        public IndexViewModel GetIndexData(string cardName)
        {
            var vm = new IndexViewModel();
            vm.CardSearchName = cardName;
            vm.Card = GetCardInfo(cardName);
            vm.CardPrice = GetPriceInfo(cardName);
            return vm;
        }

        public HexCard GetCardInfo(string cardName)
        {
            var queryString = hexSales + "articles/" + Uri.EscapeDataString(cardName);
            var response = MakeRequest(queryString);
            try
            {
                return JsonConvert.DeserializeObject<HexCard>(response.Result);                
            }
            catch
            {
                return new HexCard();
            }
            
        }

        public HexPrice GetPriceInfo(string cardName)
        {
            var queryString = hexSales + "articles/" + cardName + "/summaries?"
                + "start=" + DateTime.Now.AddYears(-2).ToString("yyyy-MM-dd")
                + "&end=" + DateTime.Now.ToString("yyyy-MM-dd");
            var response = MakeRequest(queryString);
            try
            {
                return JsonConvert.DeserializeObject<HexPrice>(response.Result);
            }
            catch
            {
                return new HexPrice();
            }

        }

        public async Task<string> MakeRequest(string requestUrl)
        {
            try
            {
                string received;
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.Method = "GET";
                using (var response = (HttpWebResponse)await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null))
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(responseStream))
                        {
                            received = await sr.ReadToEndAsync();
                        }
                    }
                }
                return received;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}