using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Matricula
    {
        public Alumno _Alumno { get; private set; }
        public int IdCurso { get; private set; }
        public DateTime FechaMatricula { get; private set; }
        public string IdUsuario { get; private set; }

        public Matricula(Alumno alumno, int IdCurso,DateTime FechaMatricula, string IdUsuario) {
            this._Alumno = alumno;
            this.IdCurso = IdCurso;
            this.FechaMatricula = FechaMatricula;
            this.IdUsuario = IdUsuario;
        }
    }
}

