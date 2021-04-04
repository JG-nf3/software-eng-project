namespace Air_3550.Models
{
    /// <summary>
    /// POCO for Address.
    /// </summary>
    public class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public override string ToString()
        {
            return base.ToString() + ":\n" + Id + "\n" + Address1 + "\n" + Address2 + "\n" + City + "\n" + State + "\n" + ZipCode;
        }
    }
}