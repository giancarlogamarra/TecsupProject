using BusinessLayer;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
 

namespace Tecsusp
{
    class Program
    {
        static  void Main(string[] args)
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            AlumnoBL bl = new AlumnoBL();

            IEnumerable<Alumno> ListAlumnos=await bl.GetItemsAsync();
            foreach (Alumno alumno in ListAlumnos)
            {
               Console.WriteLine(alumno);
            }

       
            Alumno a = await bl.GetItemByIdAsync(2);
            a.Nombre = "Nombre cambiado";
            int flag1 = await bl.Update(a);
            int flag2 = await bl.Delete(2);
        }
    }
}



