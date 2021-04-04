using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace Air_3550.Services
{
    class AuthService
    {
        /// <summary>
        /// Signs in the user, saves username and password in Vault.
        /// If credential is stored in vault, user doesn't have to sign in
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public static void SignIn(string userName, string password)
        {
            var vault = new PasswordVault();
            var credential = new PasswordCredential(
                resource: "Air3550",
                userName: userName,
                password: password
                );
            vault.Add(credential);
        }
    }
}
