using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CarbonCoin
{

    public class BalanceInfo {

        public double carbonBalance { get; set; }
        public double balance { get; set; }

    }

    public class TransactionData {
        public string senderName { get; set; }
        public string recipientName { get; set; }
        public double cashTransfer { get; set; }
        public double carbonTransfer { get; set; }
    }

    public class MyAccountModel : PageModel
    {

        private readonly IHttpClientFactory _clientFactory;
        public BalanceInfo info;
        public List<TransactionData> transData;
        public string htmlStr = "";

        public MyAccountModel(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://172.17.79.129:3000/balance");
            request.Headers.Add("auth", Constants.token);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                info = JsonConvert.DeserializeObject<BalanceInfo>(json);

                request = new HttpRequestMessage(HttpMethod.Get, "http://172.17.79.129:3000/transactions/viewable");
                request.Headers.Add("auth", Constants.token);

                response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode) {
                    json = await response.Content.ReadAsStringAsync();

                    transData = JsonConvert.DeserializeObject<List<TransactionData>>(json);
  
                }


            }
        }
    }
}
