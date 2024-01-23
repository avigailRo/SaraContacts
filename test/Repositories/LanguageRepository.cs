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
    public class LanguageRepository : ILanguageRepository
    {
        ContactsdbMdfContext data;
        public LanguageRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task Add(Language item)
        {
   
                if (item != null)
                {
                
                await data.Languages.AddAsync(item);
                await data.SaveChangesAsync();

                 }
            else
            {

            }

        }

        public async Task Delete(int id)
        {

                var x = await data.Languages.FirstOrDefaultAsync(l => l.Id == id);
                if (x != null)
                {
                    data.Languages.Remove(x);
                   await  data.SaveChangesAsync();
                }
                else {  }
            

        }

        public async Task<List<Language>> GetAll()
        {
            return await data.Languages.ToListAsync();
        }

        public async Task<Language> Update(Language item, int id)
        {
            item.Id = id;
            data.Languages.Update(item);
            await data.SaveChangesAsync();  
            return item;
        }
    }
}
