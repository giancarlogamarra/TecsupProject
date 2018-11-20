using Dapper;
using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public  class AlumnoDAL : Connection ,IBaseDAL<Alumno>
    {
        public async Task<IEnumerable<Alumno>> GetItemsAsync()
        {
            MySqlConnection connection = base.OpenConnection();
            try {
                IEnumerable<Alumno> AlumnosList = null;
                if (connection != null)
                {
                    AlumnosList = await connection.QueryAsync<Alumno>(
                          @"SELECT IdAlumno, Nombre, Apellido, Dni ,Email FROM talumnos");
                }
                    return AlumnosList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                finally
                {
                    if(connection.State ==System.Data.ConnectionState.Open)
                        connection.Close();
                }
        }

        public async Task<Alumno> GetItemByIdAsync(int idAlumno)
        {
            MySqlConnection connection = base.OpenConnection();
            try
            {
                Alumno Alumno = null;
                if (connection != null)
                {
                    Alumno = (await connection.QueryFirstAsync<Alumno>(
                          @"SELECT IdAlumno, Nombre, Apellido, Dni ,Email FROM talumnos
                             WHERE IdAlumno = @IdAlumno",new {
                              IdAlumno= idAlumno
                          }));

                }
                return Alumno;
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

        public async Task<int> UpdateAsync(Alumno alumno)
        {
            MySqlConnection connection = base.OpenConnection();
            try
            {
                int flag = -1;
                if (connection != null)
                {
                    flag = await connection.ExecuteAsync(
                          @"UPDATE talumnos 
                             SET Nombre = @Nombre,
                                 Apellido = @Apellido,
                                 Dni = @Dni,
                                 Email = @Email
                             WHERE IdAlumno = @IdAlumno", new
                          {
                              IdAlumno = alumno.IdAlumno,
                              Nombre = alumno.Nombre,
                              Apellido = alumno.Apellido,
                              Dni = alumno.Dni,
                              Email = alumno.Email,
                          });

                }
                return flag;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        public async Task<int> DeleteAsync(int IdAlumno)
        {
            MySqlConnection connection = base.OpenConnection();
            try
            {
                int flag = -1;
                if (connection != null)
                {
                    flag = await connection.ExecuteAsync(
                          @"DELETE FROM talumnos 
                             WHERE IdAlumno = @IdAlumno", new
                          {
                              IdAlumno
                          });

                }
                return flag;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

    }
}
