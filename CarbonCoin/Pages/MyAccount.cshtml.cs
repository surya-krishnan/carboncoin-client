using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CarbonCoin
{

    public class BalanceInfo {

        public double ccbalance { get; set; }
        public double moneyBalance { get; set; }

    }

    public class MyAccountModel : PageModel
    {

        private readonly IHttpClientFactory _clientFactory;
        public BalanceInfo info;
        public string ye = "lolol";

        public MyAccountModel(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://172.17.79.129:3000/balance");
            request.Headers.Add("token", Constants.token);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                string json = responseStream.ToString();

                info = JsonConvert.DeserializeObject<BalanceInfo>(json);

                ye = "xd";

            }
            else
            {
                ye = "poop";
            }
        }

    }
}
