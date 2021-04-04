using Air_3550.Data;
using System;

namespace Air_3550.Utils
{
    /// <summary>
    /// Class to help Unique Id generation of Customer
    /// </summary>
    internal class UniqueID
    {
        /// <summary>
        /// Generate Unique Id for the customer
        /// </summary>
        /// <returns> unique id for customer</returns>
        public static int GenerateUniqueID()
        {
            var rand = new Random();
            int id;
            using var db = new AppDBContext();
            while (true)
            {
                id = rand.Next(100000, 1000000);
                var user = db.Users.Find(id);
                if (user == null) { return id; }
            }
        }
    }
}