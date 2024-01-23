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
    public class GroupRepository : IGroupRepository
    {
        ContactsdbMdfContext data;
        public GroupRepository(ContactsdbMdfContext _data)
        {
            data = _data;
        }
        public async Task Add(Group item)
        {
            try
            {
                await data.Groups.AddAsync(item);
                await data.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var x = await data.Groups.FirstOrDefaultAsync(g => g.Id == id);
                if (x != null)
                {
                    data.Groups.Remove(x);
                    await data.SaveChangesAsync();
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

        public async Task<List<Group>> GetAll()
        {
            try
            {
                return await data.Groups.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }

        }

        public async Task<Group> Update(Group item, int id)
        {
            try
            {
                item.Id = id;
                data.Groups.Update(item);
                await data.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new DALException("There is a problem saving the data to the db");
            }

        }
    }
}
