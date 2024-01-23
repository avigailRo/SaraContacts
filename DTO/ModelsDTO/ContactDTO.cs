using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class ContactDTO
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Lname { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int? AddressId { get; set; }

        public int? StatusId { get; set; }

        public int? GroupId { get; set; }

        public int? LanguageId { get; set; }

        public DateTime? LastCall { get; set; }

        public string? Note { get; set; }

        public string? PrayerName { get; set; }


        


    }
}
