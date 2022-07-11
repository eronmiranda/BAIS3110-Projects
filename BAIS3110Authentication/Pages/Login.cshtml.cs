using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BAIS3110Authentication.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnPost()
        {
            string UserEmail = "emiranda4@nait.ca";
            string UserName = "Eronielle Miranda";
            string UserPassword = "123";
            string UserRole = "Admin";

            if(Email == UserEmail)
            {
                if(Password == UserPassword)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, Email),
                        new Claim(ClaimTypes.Name, UserName)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, UserRole));

                    AuthenticationProperties authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToPage("/Admin/Index");
                }
            }
            Message = "Invalid attempt";
            return Page();
        }
    }
}
