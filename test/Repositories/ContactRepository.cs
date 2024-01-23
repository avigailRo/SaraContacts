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
    public class ContactRepository : IContactRepository
    {
        ContactsdbMdfContext data;
        public ContactRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task Add(Contact item)
        {
            try
            {
                await data.Contacts.AddAsync(item);
                await data.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }
        }

        public async Task Delete(int id)
        {
            try { 
            var x = await data.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (x != null)
            {
                data.Contacts.Remove(x);
                await data.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("The item dosent exist");

            }}
            catch (NotFoundException ex)
            {
                throw new NotFoundException("The item dosent exist");
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }


        }

        public async Task<List<Contact>> GetAll()
        {
            try
            {
                return await data.Contacts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }
        }

        public async Task<Contact> Update(Contact item, int id)
        {
            try { 
            item.Id = id;
            data.Contacts.Update(item);
            await data.SaveChangesAsync();
            return item;}
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }


        }
    }
}
