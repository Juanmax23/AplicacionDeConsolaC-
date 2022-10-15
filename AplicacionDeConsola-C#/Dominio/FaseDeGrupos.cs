using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FaseDeGrupos: Partido, IValidable
    {
        private Grupo _grupo;
        private string _resultado;

        public FaseDeGrupos(Seleccion s1, Seleccion s2, DateTime fechaYHora, Grupo grupo) :base(s1, s2, fechaYHora)
        {
            this._grupo = grupo;
        }

        public string Resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }

 
    }
}
