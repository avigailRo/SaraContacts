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
                await data.Groups.AddAsync(item);
                await data.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
          
                var x = await data.Groups.FirstOrDefaultAsync(g => g.Id == id);
                if (x != null)
                {
                    data.Groups.Remove(x);
                    await data.SaveChangesAsync();
                }
                else {  }
            

        }

        public async Task<List<Group>> GetAll()
        {
            return await data.Groups.ToListAsync();
        }

        public async Task<Group> Update(Group item, int id)
        {
            item.Id = id;
            data.Groups.Update(item);
            await data.SaveChangesAsync();
            return item;
        }
    }
}
