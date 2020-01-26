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

        }

        public IActionResult OnPost()
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

            // or you can redirect to another page
            return RedirectToPage("./Index");
        }
    }
}
