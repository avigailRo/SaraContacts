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
         
                if (item != null)
                {            await data.Countries.AddAsync(item);
               await  data.SaveChangesAsync();
                }
                else { }
            
  
        }

        public async Task Delete(int id)
        {

                var x = await data.Countries.FirstOrDefaultAsync(c => c.Id == id);
                if (x != null)
                {
                    data.Countries.Remove(x);
                    await data.SaveChangesAsync();
                }
                else {  }
    
        }

        public async Task<List<Country>> GetAll()
        {
            return await data.Countries.ToListAsync();
        }

        public async Task<Country> Update(Country item, int id)
        {
            item.Id = id;
            data.Countries.Update(item);
            await Update(item, id); 
            return item;    
        }    
    }

}
