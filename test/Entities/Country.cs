using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
