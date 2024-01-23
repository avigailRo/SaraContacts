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
    public class LanguageRepository : ILanguageRepository
    {
        ContactsdbMdfContext data;
        public LanguageRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task Add(Language item)
        {
            try {
                await data.Languages.AddAsync(item);
            await data.SaveChangesAsync(); }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }


        }

        public async Task Delete(int id)
        {
            try { 
                var x = await data.Languages.FirstOrDefaultAsync(l => l.Id == id);
                if (x != null)
                {
                    data.Languages.Remove(x);
                   await  data.SaveChangesAsync();
                }
                else {
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

        public async Task<List<Language>> GetAll()
        {
            try { 
            return await data.Languages.ToListAsync();}
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }

        }

        public async Task<Language> Update(Language item, int id)
        {
            try { 
            item.Id = id;
            data.Languages.Update(item);
            await data.SaveChangesAsync();  
            return item;}
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }

        }
    }
}
