using Dapper;
using Entities.Reportes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ReportesDAL : Connection
    {
        public async Task<IEnumerable<AlumnoResult>> SearchAlumnosAsync(string IdAlumno)
        {
            MySqlConnection connection = await base.OpenConnection();
            try
            {
                string whereClause = "";

                if (IdAlumno != "" ) {
                    whereClause = $"WHERE IdAlumno = {IdAlumno} "; 
                }

                IEnumerable<AlumnoResult> MatriculasList = null;
                if (connection != null)
                {
                    MatriculasList = await connection.QueryAsync<AlumnoResult>(
                          $"SELECT * FROM view_matriculas {whereClause}");
                }
                return MatriculasList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

         
    }
}
