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
    public class StatusRepository : IStatusRepository
    {
        ContactsdbMdfContext data;
        public StatusRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task  Add(Status item)
        {
            try { 
          
                await data.Statuses.AddAsync(item);
                await data.SaveChangesAsync();}
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }




        }

        public async Task Delete(int id)
        {
            try { 
                var x = await data.Statuses.FirstOrDefaultAsync(s => s.Id == id);
                if (x != null)
                {
                    data.Statuses.Remove(x);
                   await  data.SaveChangesAsync();
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

        public async Task<List<Status>> GetAll()
        {
            try { 
            return await data.Statuses.ToListAsync();}
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }
        }

        public async Task<Status> Update(Status item, int id)
        {
            try { 
            item.Id = id;  
            data.Statuses.Update(item);
            await data.SaveChangesAsync();
            return item;}
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }
        }
    }
}
