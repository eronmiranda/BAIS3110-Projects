using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3110Authentication.Pages.Admin
{
    [Authorize(Roles = "Admin", Policy = "RequireAdmin")]
    public class CreateUserModel : PageModel
    {
        public string ErrorMessage { get; set; }
        public string FormMessage { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        public void OnPost()
        {
            User newUser = new User
            {
                UserName = UserName,
                Email = Email,
                Password = Password,
                Role = Role
            };

            if (CreateUser(newUser))
            {
                FormMessage = "You have successfully created a User.";
            }
            else
            {
                ErrorMessage = "Creating a User was not successful.";
            }
        }

        private bool CreateUser(User newUser)
        {
            bool success = false;

            BAS AuthenticationDirector = new BAS();

            try
            {
                success = AuthenticationDirector.CreateUser(newUser);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message.ToString();
            }

            return success;
        }
    }
}
