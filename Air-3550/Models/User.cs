using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_3550.Models
{
    enum UserType
    {
        CUSTOMER,
        LOAD_ENGINEER,
        MARKETING_MANAGER,
        FLIGHT_MANAGER,
        ACCOUNTING_MANAGER,
        ADMIN
    }

    public class User
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        int PhoneNumber { get; set; }
        DateTime BirthDate { get; set; }
        Address address { get; set; }
        UserType type { get; set; }
    }
}
