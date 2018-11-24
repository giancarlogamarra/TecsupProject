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
            CursoBL bl = new CursoBL();
            IEnumerable<Curso> ListAlumnos=await bl.GetItemsAsync();
            foreach (Curso alumno in ListAlumnos)
            {
               Console.WriteLine(alumno);
            }

        }
    }
}



