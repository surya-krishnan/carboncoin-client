using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CarbonCoin
{

    public class BalanceInfo {

        public double ccbalance { get; set; }
        public double balance { get; set; }

    }

    public class MyAccountModel : PageModel
    {

        private readonly IHttpClientFactory _clientFactory;
        public BalanceInfo info;
        public string ye { get; private set; } = "lololol";
        public string responseStr { get; private set; } = "xx";

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

                string name, carbonTransfer, cashTransfer, timeStamp;

                request = new HttpRequestMessage(HttpMethod.Get, "");
                request.Headers.Add("auth", Constants.token);

                


            }
        }

    }
}
