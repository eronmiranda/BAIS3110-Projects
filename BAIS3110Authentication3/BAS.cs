using BAIS3110Authentication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3110Authentication
{
    public class BAS
    {
        public bool CreateUser(User newUser)
        {
            bool confirmation = false;

            SecurityManager UserManager = new SecurityManager();

            confirmation = UserManager.CreateUser(newUser);

            return confirmation;
        }
    }
}
