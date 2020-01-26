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
        private readonly IHttpClientFactory _clientFactory;

        [BindProperty]
        public string username { get; set; }

        [BindProperty]
        public string password { get; set; }

        public void OnGet()
        {
            // you can initialize the values. for example I set the username
            username = "test";
        }

        public IActionResult OnPost()
        {
            // do something with username and password

            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "Password is a required field.");
                return Page();
            }

            // or you can redirect to another page
            return RedirectToPage("./Index");
        }
    }
}
