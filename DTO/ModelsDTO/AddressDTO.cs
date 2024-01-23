using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class AddressDTO
    {
        public int Id { get; set; }

        public int? CountryId { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public int? Building { get; set; }

        public int? Appartment { get; set; }
    }
}
