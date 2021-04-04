using Air_3550.Data;
using Air_3550.Models;
using Air_3550.Utils;
using System.Collections.Generic;
using System.Diagnostics;

namespace Air_3550.Services
{
    /// <summary>
    /// Services for User.
    /// </summary>
    internal class UserService
    {
        /// <summary>
        /// Get User by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>User object if Id is present, null otherwise</returns>
        public static User GetUserById(int Id)
        {
            using var db = new AppDBContext();
            User user = db.Users.Find(Id);
            return user;
        }

        /// <summary>
        ///  Add User to the database.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="birthDate"></param>
        /// <param name="address"></param>
        /// <param name="type"></param>
        /// <returns> Added User. </returns>
        public static User AddUser(string firstName, string lastName, string email, string password, string phoneNumber, string birthDate, Address address, UserType type)
        {
            User addedUser = new User()
            {
                Id = UniqueID.GenerateUniqueID(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                BirthDate = birthDate,
                Type = type
            };

            using var db = new AppDBContext();
            db.Users.Add(addedUser);
            db.SaveChanges();

            AddAddress(address);
            Debug.WriteLine("ADDED USER");
            Debug.WriteLine(addedUser.ToString());
            return addedUser;
        }

        /// <summary>
        /// Add Address related to Customer.
        /// </summary>
        /// <param name="addedAddress"></param>
        private static void AddAddress(Address addedAddress)
        {
            using var db = new AppDBContext();
            db.Addresses.Add(addedAddress);
            db.SaveChanges();

            Debug.WriteLine("ADDED ADDRESS");
            Debug.WriteLine(addedAddress.ToString());
        }
        
        /// <summary>
        /// Sign in User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool SignIn(int userId, string password)
        {
            using var db = new AppDBContext();
            var user = db.Users.Find(userId);

            CredentialManager.AddCredential(userId.ToString(), password);
            Debug.WriteLine("User Credential Saved.");

            Debug.WriteLine("Signed In");
            Debug.WriteLine(user.ToString());

            return true;
        }

        /// <summary>
        /// Auto Sign In user if credential is present in Credential Manager
        /// Sets Global Logged In User
        /// </summary>
        public static void AutoSignIn()
        {
            var (userId, password) = CredentialManager.GetCredential();
            if (userId > 0)
            {
                Debug.WriteLine("User Credential found.");
                App.loggedUser = GetUserById(userId);
                Debug.WriteLine(App.loggedUser.ToString());
                Debug.WriteLine("UserId = {0}, Password = {1}",userId, password);
            }
        }

    }
}