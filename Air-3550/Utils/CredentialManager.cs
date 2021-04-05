using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;
using System.Diagnostics;

using static Air_3550.Constants.AppConstants;

namespace Air_3550.Utils
{
    /// <summary>
    /// Class to manage user Credential.
    /// </summary>
    class CredentialManager
    {
        /// <summary>
        /// Adds user credential in Windows Credential Manager.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public static void AddCredential(string userName, string password)
        {
            var vault = new PasswordVault();

            // Only Add if credential is not present
            try
            {
                var credential = vault.FindAllByResource(PROGRAM_NAME).FirstOrDefault();
            }
            catch (Exception)
            {
                var credential = new PasswordCredential(
                    resource: PROGRAM_NAME,
                    userName: userName,
                    password: password
                    );
                    vault.Add(credential);
            }  
        }

        /// <summary>
        /// Get user credential if present
        /// </summary>
        /// <returns> Dictionary of user ID and pasword or null if no credential is saved.</returns>
        public static (int, string) GetCredential()
        {
            var vault = new PasswordVault();
            try
            {
                var credential = vault.FindAllByResource(PROGRAM_NAME).FirstOrDefault();
                credential.RetrievePassword();
                return (Int32.Parse(credential.UserName), credential.Password);
            }
            catch (Exception)
            {
                return (-1, null);
            }
        }
    }
}
