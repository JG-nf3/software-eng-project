namespace Air_3550.Models
{
    public enum UserType
    {
        CUSTOMER,
        LOAD_ENGINEER,
        MARKETING_MANAGER,
        FLIGHT_MANAGER,
        ACCOUNTING_MANAGER,
        ADMIN
    }

    /// <summary>
    /// POCO for User
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public UserType Type { get; set; }

        public override string ToString()
        {
            return base.ToString() + ":\n" + Id + "\n" + FirstName + "\n" + LastName + "\n" + Email + "\n" + Password + "\n" + BirthDate + "\n" + Type;
        }
    }
}