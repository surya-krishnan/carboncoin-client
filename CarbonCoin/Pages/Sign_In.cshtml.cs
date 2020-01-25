using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarbonCoin
{
    public class Sign_InModel : PageModel
    {
        private string username, password;
        private readonly IHttpClientFactory _clientFactory;

        public Sign_InModel(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {
        }

        public void submitButtonClick(object sender, EventArgs e) {
            username = String.Format("{0}", Request.Form["username"]);
            password = String.Format("{0}", Request.Form["password"]);

            //var request = new HttpRequestMessage(HttpMethod.Get, "");
            //request.Headers.Add("Username", "");

            Response.Redirect("~/Index");
        }
    }
}
