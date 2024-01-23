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
    public class LoginRepository : ILoginRepository
    {
        ContactsdbMdfContext data;
        public LoginRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task Add(Login item)
        {
     
                if (item != null)
                {
                await data.Logins.AddAsync(item);
                await data.SaveChangesAsync();   }
             else { }

            
      
        }

        public async Task Delete(int id)
        {
       
                var x = await data.Logins.FirstOrDefaultAsync(a => a.Id == id);
                if (x != null)
                {
                    data.Logins.Remove(x);
                   await  data.SaveChangesAsync();
                }
                else {  }
            

        }

        public async Task<List<Login>> GetAll()
        {
            return await data.Logins.ToListAsync();
        }

        public async Task<Login> Update(Login item, int id)
        {
            item.Id = id;  
            data.Logins.Update(item);
            await data.SaveChangesAsync();
            return item;
        }
    }
}
