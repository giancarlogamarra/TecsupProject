using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
        public class Alumno
        {
            public long IdAlumno { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Dni { get; set; }
            public string Email { get; set; }
            public int NroMatriculas { get; set; }

        public override string ToString()
        {
            return string.Format("ID={0} , NOMBRE={1}, APELLIDO={2}",
                                this.IdAlumno, this.Nombre, this.Apellido);
        }
    }   
}
