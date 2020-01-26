using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CarbonCoin.Pages
{
    public class StoreItem {
        public string _id { get; set; }
        public string name { get; set; }
        public double cashCost { get; set; }
        public double carbonCost { get; set; }
        public int leftInStock { get; set; }
    }

    public class ShopModel : PageModel
    {
        IHttpClientFactory _clientFactory;
        public List<StoreItem> storeItems;
        public int index;
        public string token = Constants.token;

        public ShopModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://172.17.79.129:3000/store/inventory");
            request.Headers.Add("auth", Constants.token);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                storeItems = JsonConvert.DeserializeObject<List<StoreItem>>(json);
            }
        }

    }
}
