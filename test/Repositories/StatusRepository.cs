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
    public class StatusRepository : IStatusRepository
    {
        ContactsdbMdfContext data;
        public StatusRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task  Add(Status item)
        {
        
                if (item != null)
                {
          
                await data.Statuses.AddAsync(item);
                await data.SaveChangesAsync();
                     }
            else { }

            

        }

        public async Task Delete(int id)
        {
         
                var x = await data.Statuses.FirstOrDefaultAsync(s => s.Id == id);
                if (x != null)
                {
                    data.Statuses.Remove(x);
                   await  data.SaveChangesAsync();
                }
                else {  }
            
     
        }

        public async Task<List<Status>> GetAll()
        {
            return await data.Statuses.ToListAsync();
        }

        public async Task<Status> Update(Status item, int id)
        {
            item.Id = id;  
            data.Statuses.Update(item);
            await data.SaveChangesAsync();
            return item;    
        }
    }
}
