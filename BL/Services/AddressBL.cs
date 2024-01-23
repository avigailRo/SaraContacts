using AutoMapper;
using BL.Interfaces;
using DAL.Exceptions;
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
            try { 
             await addressRepository.Add(mapper.Map<Address>(item));}
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(DALException) && ex.GetType() != typeof(NotFoundException))
                {
                    throw new BLException("There is a problem to map");
                }
                else
                    throw;
            }
        }

        public async Task Delete(int id)
        {
            
             await addressRepository.Delete(id);
        }

        public async Task<List<AddressDTO>> GetAll()
        {
            try { 
            List<Address> addresses = await addressRepository.GetAll();
            List<AddressDTO>addressDTO = new List<AddressDTO>();
            foreach (var address in addresses)
            {
                addressDTO.Add(mapper.Map<AddressDTO>(address));    
            }
            return addressDTO;}
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(DALException) && ex.GetType() != typeof(NotFoundException))
                {
                    throw new BLException("There is a problem to map");
                }
                else
                    throw;
            }
        }

        public async Task<AddressDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressDTO> Update(AddressDTO item, int id)
        {
            try { 
            return mapper.Map<AddressDTO>(
               await addressRepository.Update(mapper.Map<Address>(item), id));}
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(DALException) && ex.GetType() != typeof(NotFoundException))
                {
                    throw new BLException("There is a problem to map");
                }
                else
                    throw;
            }
        }
    }
}
