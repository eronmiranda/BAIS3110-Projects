using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3110Authentication.Pages.Admin
{
    public class CreateUserModel : PageModel
    {
        public string ErrorMessage { get; set; }
        public string FormMessage { get; set; }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Role { get; set; }

        public void OnPost()
        {
        }
    }
}
