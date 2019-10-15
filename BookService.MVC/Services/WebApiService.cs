using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookService.MVC.Services
{
    public class WebApiService
    {
        public static T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew(
                    () => JsonConvert.DeserializeObject<T>(response.Result)
                ).Result;
            }
        }
    }
}
