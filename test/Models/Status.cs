using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Status
    {
        public Status()
        {
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
