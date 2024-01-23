using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICRUDRepository<T>
    {
        public  Task<List<T>> GetAll();
        public Task Delete(int id);
        public Task Add(T item);
        public Task<T> Update(T item, int id);
    }
}
