using DAL.Exceptions;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class AddressRepository : IAddressRepository
    {
        ContactsdbMdfContext data;
        public AddressRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task Add(Address item)
        {
            try
            {
                await data.Addresses.AddAsync(item);
                await data.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }

        }

        public async Task Delete(int id)
        {
            try
            {
                var x = await data.Addresses.FirstOrDefaultAsync(a => a.Id == id);
                if (x != null)
                {
                    data.Addresses.Remove(x);
                    await data.SaveChangesAsync();

                }

                else
                {
                    throw new NotFoundException("The item dosent exist");
                }
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException("The item dosent exist");
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }





        }

        public async Task<List<Address>> GetAll()
        {
            try
            {
                return await data.Addresses.Include(a => a.Country).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }
        }

        public async Task<Address> Update(Address item, int id)
        {
            try
            {
                item.Id = id;
                data.Addresses.Update(item);
                await data.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }

        }

    }
}
