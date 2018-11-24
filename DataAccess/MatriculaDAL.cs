using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MatriculaDAL : Connection
    {

        public async Task<bool> MatricularAsync(Matricula matricula)
        {

            MySqlConnection conexion = await base.OpenConnection();
            
            var transaccion = conexion.BeginTransaction();
            try
            {
                if (conexion != null)
                {  
                    long IdAlumno= await CrearAlumno(matricula._Alumno, conexion, transaccion);
                    matricula._Alumno.IdAlumno = IdAlumno;
                    await CrearMatricula(matricula, conexion, transaccion);
                    transaccion.Commit();
                }
                return true;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return false;
            }
        }
        private async Task<long> CrearAlumno(Alumno alumno, MySqlConnection conexion, MySqlTransaction transaccion)
        {
            string sql = @"INSERT INTO talumnos(Nombre, Apellido, Dni, Email)
                            values(@Nombre,@Apellido,@Dni,@Email);";

            var command = new MySqlCommand(sql, conexion, transaccion);
            command.Parameters.AddWithValue("@Nombre", alumno.Nombre);
            command.Parameters.AddWithValue("@Apellido", alumno.Apellido);
            command.Parameters.AddWithValue("@Dni", alumno.Dni);
            command.Parameters.AddWithValue("@Email", alumno.Email);

            await command.ExecuteNonQueryAsync();
            long LastId = command.LastInsertedId;
            return LastId;
        }

        private async Task CrearMatricula(Matricula matricula, MySqlConnection conexion, MySqlTransaction transaccion)
        {
            string sql = @"INSERT INTO tmatricula(IdAlumno, IdCurso, FechaMatricula, IdUsuario)
                            values(@IdAlumno,@IdCurso,@FechaMatricula,@IdUsuario)";

            var command = new MySqlCommand(sql, conexion, transaccion);
            command.Parameters.AddWithValue("@IdAlumno", matricula._Alumno.IdAlumno);
            command.Parameters.AddWithValue("@IdCurso", matricula.IdCurso);
            command.Parameters.AddWithValue("@FechaMatricula", matricula.FechaMatricula);
            command.Parameters.AddWithValue("@IdUsuario", matricula.IdUsuario);

            await command.ExecuteNonQueryAsync();
        }
    }
}
