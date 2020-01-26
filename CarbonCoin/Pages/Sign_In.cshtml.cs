using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace CarbonCoin
{
    public class Sign_InModel : PageModel
    {

        private bool success;

        [BindProperty]
        public string username { get; set; }

        [BindProperty]
        public string password { get; set; }

        private string token { get; set; }

        private readonly IHttpClientFactory _clientFactory;

        public Sign_InModel(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            // do something with username and password

                // Check validity of username, match with databse

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("username", "Username is a required field.");
                ModelState.AddModelError("password", "Password is a required field.");
                return Page();
            }
            else if (string.IsNullOrEmpty(username))
            {
                ModelState.AddModelError("username", "Username is a required field.");
                return Page();
            } else if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "Password is a required field.");
                return Page();
            }


            //Uri siteUri = new Uri("172.17.79.129:3000/auth/user/philnic");
            //string bob = Get(siteUri);

            var request = new HttpRequestMessage(HttpMethod.Get, "http://172.17.79.129:3000/auth");
            request.Content = new StringContent("{\"username\":\"" + username + "\",\"password\":\"" + password + "\"}", Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                token = responseStream.ToString();

                Constants.token = token;
                Constants.username = username;
                Constants.password = password;

                return RedirectToPage("./MyAccount");
            }
            else
            {
                ModelState.AddModelError("password", "Invalid Username or Password");
                return Page();
            }


        }

       
    }
}
