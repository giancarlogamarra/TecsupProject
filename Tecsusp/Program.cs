using BusinessLayer;
using DataAccess;
using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace Tecsusp
{
    class Program
    {
        static  void Main(string[] args)
        {
            MainAsync();
        }

        static async void MainAsync()
        {
            Alumno a = new Alumno() {
                Nombre ="Luis TX1",
                Apellido ="Perez TX",
                Dni = "44552266",
                Email = "luis@gmail.com"
            };
            Matricula matricula = new Matricula(a,1,DateTime.Now,"admin");
            MatriculaBL bl = new MatriculaBL();
            bool result = await bl.MatricularAsync(matricula);
            Console.WriteLine(result);
        }
    }
}



