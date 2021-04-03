using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_3550.Models
{
    class Address
    {
        string Address1 { get; set; }
#nullable enable
        string? Address2 { get; set; }
#nullable disable
        string City { get; set; }
        string State { get; set; }
        int ZipCode { get; set; }
    }
}
