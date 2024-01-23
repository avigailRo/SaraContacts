using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Language
    {
        public Language()
        {
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string LanguageName { get; set; } = null!;

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
