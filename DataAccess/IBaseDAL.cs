using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IBaseDAL<T>
    {
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> GetItemByIdAsync(int Id);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int Id);
    }
}
