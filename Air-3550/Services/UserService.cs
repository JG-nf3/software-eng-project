using Air_3550.Data;
using Air_3550.Models;
using Air_3550.Utils;

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
        public static User FindUserById(int Id)
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
        public static User AddUser(string firstName, string lastName, string email, string password, long phoneNumber, string birthDate, long creditCardNumber, Address address, UserType type)
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
                CreditCardNumber = creditCardNumber,
                Type = type
            };

            using var db = new AppDBContext();
            db.Users.Add(addedUser);
            db.SaveChanges();
            AddAddress(address);
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
        }

        /// <summary>
        /// Sign in User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns>true if successfully signed in, false otherwise</returns>
        public static bool SignIn(int userId, string password)
        {
            User user = FindUserById(userId);
            if (user == null)
            {
                return false;
            }
            CredentialManager.AddCredential(userId.ToString(), SHA512Generate.GenerateSHA512(password));
            return true;
        }

        /// <summary>
        /// Auto Sign In user
        /// Sets Global Logged In User
        /// </summary>
        public static void AutoSignIn()
        {
            var (userId, _) = CredentialManager.GetCredential();
            if (userId > 0)
            {
                App.loggedUser = FindUserById(userId);
            }
        }
    }
}