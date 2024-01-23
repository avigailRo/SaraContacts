using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICRUDBL<T>
    {
        public  Task<List<T>> GetAll();
        public Task<T> GetByID(int id);
        public Task Delete(int id);
        public Task Add(T item);
        public Task<T> Update(T item, int id);
    }
}
