using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int AddressId { get; set; }
        public int StatusId { get; set; }
        public int GroupId { get; set; }
        public int LanguageId { get; set; }
        public DateTime LastCall { get; set; }
        public string Note { get; set; } = null!;
        public string PrayerName { get; set; } = null!;

        public virtual Address Address { get; set; } = null!;
        public virtual Group Group { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
    }
}
