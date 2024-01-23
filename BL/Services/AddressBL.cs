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
    public class AddressBL : IAddressBL
    {
        IAddressRepository addressRepository;
        private IMapper mapper;
        public AddressBL(IAddressRepository addressRepository, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }
        public async Task Add(AddressDTO item)
        {
             await addressRepository.Add(mapper.Map<Address>(item));
        }

        public async Task Delete(int id)
        {
             await addressRepository.Delete(id);
        }

        public async Task<List<AddressDTO>> GetAll()
        {
            List<Address> addresses = await addressRepository.GetAll();
            List<AddressDTO>addressDTO = new List<AddressDTO>();
            foreach (var address in addresses)
            {
                addressDTO.Add(mapper.Map<AddressDTO>(address));    
            }
            return addressDTO;
        }

        public async Task<AddressDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressDTO> Update(AddressDTO item, int id)
        {
            return mapper.Map<AddressDTO>(
               await addressRepository.Update(mapper.Map<Address>(item), id));
        }
    }
}
