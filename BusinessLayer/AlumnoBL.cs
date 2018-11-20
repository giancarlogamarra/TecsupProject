using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AlumnoBL  
    {
       
        public async Task<IEnumerable<Alumno>> GetItemsAsync()
        {
            AlumnoDAL dal = new AlumnoDAL();
            return await dal.GetItemsAsync();
        }
     
        public async Task<int> Delete(int Id)
        {
            AlumnoDAL dal = new AlumnoDAL();
            return await dal.DeleteAsync(Id);
        }

        public async Task<Alumno> GetItemByIdAsync(int Id)
        {
            AlumnoDAL dal = new AlumnoDAL();
            return await dal.GetItemByIdAsync(Id);
        }

        public async Task<int> Update(Alumno entity)
        {
            AlumnoDAL dal = new AlumnoDAL();
            return await dal.UpdateAsync(entity);
        }
    }
}


