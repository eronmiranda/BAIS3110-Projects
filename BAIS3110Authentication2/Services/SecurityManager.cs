using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BAIS3110Authentication.Services
{
    public class SecurityManager
    {
        private string ConnectionString = Startup.ConnectionString;

        public bool CreateUser(User newUser)
        {
            bool success = false;

            SqlConnection BAIS3150Connection = new SqlConnection();
            BAIS3150Connection.ConnectionString = ConnectionString;

            BAIS3150Connection.Open();

            SqlCommand BAIS3150UserCommand = CreateSqlCommandSP(BAIS3150Connection, "CreateUser");

            SqlParameter UserNameParameter = CreateSqlParameter("@UserName", SqlDbType.VarChar, newUser.UserName);
            BAIS3150UserCommand.Parameters.Add(UserNameParameter);

            SqlParameter EmailParameter = CreateSqlParameter("@Email", SqlDbType.VarChar, newUser.Email);
            BAIS3150UserCommand.Parameters.Add(EmailParameter);

            SqlParameter PasswordParameter = CreateSqlParameter("@Password", SqlDbType.VarChar, CalculateHash(newUser.Password));
            BAIS3150UserCommand.Parameters.Add(PasswordParameter);

            SqlParameter RoleParameter = CreateSqlParameter("@Role", SqlDbType.VarChar, newUser.Role);
            BAIS3150UserCommand.Parameters.Add(RoleParameter);

            BAIS3150UserCommand.ExecuteNonQuery();

            BAIS3150Connection.Close();

            success = true;
            return success;
        }

        private string CalculateHash(string password)
        {
            var salt = GenerateSalt(16);

            var bytes = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);

            var hashed = Convert.ToBase64String(bytes);

            return $"{ Convert.ToBase64String(salt) }:{ hashed }";
        }

        private static byte[] GenerateSalt(int length)
        {
            var salt = new byte[length];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            return salt;
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
