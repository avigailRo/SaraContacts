using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Address
    {
        public Address()
        {
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int Building { get; set; }
        public int Appartment { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
