using Air_3550.Models;
using Air_3550.Utils;

using System;
using Air_3550.Data;

using System.Diagnostics;

namespace Air_3550.Services
{
    /// <summary>
    /// Services for User.
    /// </summary>
    internal class UserService
    {
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
    }
}