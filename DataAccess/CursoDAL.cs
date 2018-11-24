using Dapper;
using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CursoDAL : Connection,  IBaseDAL<Curso>
    {
        public async Task<int> DeleteAsync(int Id)
        {
            MySqlConnection connection = base.OpenConnection();
            try
            {
                int rowsAfected = -1;
                if (connection != null)
                {
                    rowsAfected = await connection.ExecuteAsync(
                          @"DELETE FROM tcursos 
                             WHERE IdCurso = @Id", new
                          {
                              Id
                          });

                }
                return rowsAfected;
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

        public async Task<Curso> GetItemByIdAsync(int Id)
        {
            MySqlConnection connection = base.OpenConnection();
            try
            {
                Curso curso= null;
                if (connection != null)
                {
                    curso = (await connection.QueryFirstAsync<Curso>(
                          @"SELECT IdCurso, Nombre, Capacidad, Horario FROM tecsupdb.tcursos
                             WHERE IdCurso = @IdCurso", new
                          {
                              IdCurso = Id
                          }));

                }
                return curso;
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

        public async Task<IEnumerable<Curso>> GetItemsAsync()
        {
            MySqlConnection connection = base.OpenConnection();
            try
            {
                IEnumerable<Curso> CursoList = null;
                if (connection != null)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@TipoEntidad", 'C');
                    CursoList = await connection.QueryAsync<Curso>(
                          @"GET_ALUMNOS_OR_CURSOS", parameters, null, null, System.Data.CommandType.StoredProcedure);
                }
                return CursoList;
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

        public async Task<int> UpdateAsync(Curso entity)
        {

            MySqlConnection connection = base.OpenConnection();
            try
            {
                int rowsAfected = -1;
                if (connection != null)
                {
                    rowsAfected = await connection.ExecuteAsync(
                          @"UPDATE tcursos 
                             SET Nombre = @Nombre,
                                 Capacidad = @Apellido,
                                 Horario = @Dni
                             WHERE IdCurso = @IdCurso", new
                          {
                              IdCurso = entity.IdCurso,
                              Nombre = entity.Nombre,
                              Capacidad = entity.Capacidad,
                              Horario = entity.Horario
                          });

                }
                return rowsAfected;
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
