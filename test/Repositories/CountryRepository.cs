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
    public class CountryRepository : ICountryRepository
    {
        ContactsdbMdfContext data;
        public CountryRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task Add(Country item)
        {
            try
            {
                await data.Countries.AddAsync(item);
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
                var x = await data.Countries.FirstOrDefaultAsync(c => c.Id == id);
                if (x != null)
                {
                    data.Countries.Remove(x);
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

        public async Task<List<Country>> GetAll()
        {
            try
            {
                return await data.Countries.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }
        }

        public async Task<Country> Update(Country item, int id)
        {
            try
            {
                item.Id = id;
                data.Countries.Update(item);
                await Update(item, id);
                return item;
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }
        }
    }

}
