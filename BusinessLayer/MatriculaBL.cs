using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MatriculaBL
    {
        public async Task<bool> MatricularAsync(Matricula matricula)
        {
            MatriculaDAL dal = new MatriculaDAL();
            return await dal.MatricularAsync(matricula);
        }
    }
}
