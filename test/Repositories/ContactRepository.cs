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
    public class ContactRepository : IContactRepository
    {
        ContactsdbMdfContext data;
        public ContactRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task Add(Contact item)
        {
            await data.Contacts.AddAsync(item);
            await data.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var x = await data.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (x != null)
            {
                data.Contacts.Remove(x);
                await data.SaveChangesAsync();
            }
            else
            {

            }


        }

        public async Task<List<Contact>> GetAll()
        {
            return await data.Contacts.ToListAsync();
        }

        public async Task<Contact> Update(Contact item, int id)
        {
            item.Id = id;
            data.Contacts.Update(item);
            await data.SaveChangesAsync();
            return item;


        }
    }
}
