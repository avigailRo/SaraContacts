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
        public async Task  Add(Address item)
        {
     
              await data.Addresses.AddAsync(item);
              await  data.SaveChangesAsync();
            
    
        }

        public async Task Delete(int id)
        {
        
                var x = await data.Addresses.FirstOrDefaultAsync(a => a.Id == id);
                if (x != null)
                {
                    data.Addresses.Remove(x);
                   await data.SaveChangesAsync();
                
                }
                else
                {
                }
              
            
    
        }

        public async Task<List<Address>> GetAll()
        {
            return await data.Addresses.Include(a=>a.Country).ToListAsync();
        }

        public async Task<Address> Update(Address item, int id)
        {
            item.Id = id;
            data.Addresses.Update(item);
            await data.SaveChangesAsync();  
            return item;    
        }

    }
}
