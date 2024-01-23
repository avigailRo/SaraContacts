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
    public class LoginRepository : ILoginRepository
    {
        ContactsdbMdfContext data;
        public LoginRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task Add(Login item)
        {
            try
            {
                await data.Logins.AddAsync(item);
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
            var x = await data.Logins.FirstOrDefaultAsync(a => a.Id == id);
            if (x != null)
            {
                data.Logins.Remove(x);
                await data.SaveChangesAsync();
            }
            else {
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

        public async Task<List<Login>> GetAll()
        {
            try { 
            return await data.Logins.ToListAsync();}
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }
        }

        public async Task<Login> Update(Login item, int id)
        {
            try { 
            item.Id = id;
            data.Logins.Update(item);
            await data.SaveChangesAsync();
            return item;}
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }
        }
    }
}
