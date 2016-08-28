using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Cts.NetCore.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HexSalesApi
    {
        public HexSalesApi()
        {
            //Build Data
        }

        public string CreateRequest(string queryString)
        {
            string UrlRequest = "https://api.hexsales.net/v1/" +
                                 queryString;
            return (UrlRequest);
        }

        public async Task<string> MakeRequest(string requestUrl)
        {
            try
            {
                string received;
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.Method = "GET";
                using (var response = (HttpWebResponse) await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)) {
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

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HexsalesApiExtensions
    {
        public static IApplicationBuilder UseHexsalesApi(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HexSalesApi>();
        }
    }
}
