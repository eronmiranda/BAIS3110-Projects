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
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Data.SqlClient;
using System.Data;

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
            try
            {
                User user = GetUser(Email);
                if(CheckMatch(user.Password,Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, Email),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role));

                    AuthenticationProperties authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToPage("/Admin/Index");
                }
            }
            catch (Exception)
            {
            }
            Message = "Invalid attempt";
            return Page();
        }

        public User GetUser(string email)
        {
            SqlConnection BAIS3150Connection = new SqlConnection();
            BAIS3150Connection.ConnectionString = @"Data Source=(local);Initial Catalog=BAIS3110Authentication;Integrated Security=true";

            BAIS3150Connection.Open();

            SqlCommand GetUserCommand = CreateSqlCommandSP(BAIS3150Connection, "GetUser");

            SqlParameter GetUserParameter = CreateSqlParameter("@Email", SqlDbType.VarChar, email);
            GetUserCommand.Parameters.Add(GetUserParameter);

            SqlDataReader DataReader = GetUserCommand.ExecuteReader();

            User existingUser = new User();
            if (DataReader.HasRows)
            {
                DataReader.Read();
                existingUser = new User
                {
                    UserName = DataReader["UserName"].ToString(),
                    Email = DataReader["Email"].ToString(),
                    Password = DataReader["Password"].ToString(),
                    Role = DataReader["Role"].ToString(),
                };
            }

            BAIS3150Connection.Close();

            return existingUser;
        }
        public bool CheckMatch(string hash, string input)
        {
            try
            {
                var parts = hash.Split(':');

                var salt = Convert.FromBase64String(parts[0]);

                var bytes = KeyDerivation.Pbkdf2(input, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);
                var hashed = Convert.ToBase64String(bytes);

                return parts[1].Equals(hashed);
            }
            catch
            {
                return false;
            }
        }
        private static SqlCommand CreateSqlCommandSP(SqlConnection sqlConnection, string storedProcedureName)
        {
            return new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = storedProcedureName
            };
        }

        private static SqlParameter CreateSqlParameter(string parameterName, SqlDbType sqlDbType, string sqlValue)
        {
            return new SqlParameter
            {
                ParameterName = parameterName,
                SqlDbType = sqlDbType,
                Direction = ParameterDirection.Input,
                SqlValue = sqlValue
            };
        }
    }
}
