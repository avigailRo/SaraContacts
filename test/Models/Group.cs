using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Group
    {
        public Group()
        {
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; } = null!;

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
