using AutoMapper;
using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CountryBL : ICountryBL
    {
       ICountryRepository countryRepository;
        private IMapper mapper;

        public CountryBL(ICountryRepository countryRepository,IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        public async Task Add(CountryDTO item)
        {
             await countryRepository.Add(mapper.Map<Country>(item));
        }

        public async Task Delete(int id)
        {
             await countryRepository.Delete(id);
        }

        public async Task<List<CountryDTO>> GetAll()
        {
            List<Country>countries = await countryRepository.GetAll();
            List<CountryDTO> result = new List<CountryDTO>();
            foreach (var country in countries)
            {
                result.Add(mapper.Map<CountryDTO>(country));    
            }
            return result;
        }

        public async Task<CountryDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CountryDTO> Update(CountryDTO item, int id)
        {
            return mapper.Map<CountryDTO>(
                await   countryRepository.Update(mapper.Map<Country>(item), id));
        }
    }
}
