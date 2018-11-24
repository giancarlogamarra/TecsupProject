using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class CursoBL
    {

        public async Task<IEnumerable<Curso>> GetItemsAsync()
        {
            CursoDAL dal = new CursoDAL();
            return await dal.GetItemsAsync();
        }

        public async Task<int> Delete(int Id)
        {
            CursoDAL dal = new CursoDAL();
            return await dal.DeleteAsync(Id);
        }

        public async Task<Curso> GetItemByIdAsync(int Id)
        {
            CursoDAL dal = new CursoDAL();
            return await dal.GetItemByIdAsync(Id);
        }

        public async Task<int> Update(Curso entity)
        {
            CursoDAL dal = new CursoDAL();
            return await dal.UpdateAsync(entity);
        }
    }
}
