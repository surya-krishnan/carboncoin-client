using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarbonCoin
{
    public class MyAccountModel : PageModel
    {

        private readonly IHttpClientFactory _clientFactory;
        private string username;

        public MyAccountModel(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {

        }
    }
}
