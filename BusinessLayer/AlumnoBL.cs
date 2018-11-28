using DataAccess;
using Entities;
using Entities.Reportes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AlumnoBL  
    {

        public async Task<IEnumerable<AlumnoResult>> SearchAlumnosAsync(string IdAlumno ="")
        {
            ReportesDAL dal = new ReportesDAL();
            return await dal.SearchAlumnosAsync(IdAlumno);
        }

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


