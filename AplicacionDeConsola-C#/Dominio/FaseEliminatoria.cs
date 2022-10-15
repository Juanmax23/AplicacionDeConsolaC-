using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FaseEliminatoria: Partido, IValidable
    {
        private bool _huboAlargue;
        private bool _huboPenales;
        private Etapa _etapa;
        private string _resultado;

        public FaseEliminatoria(Seleccion s1, Seleccion s2, DateTime fechaYHora, Etapa etapa, bool huboAlargue, bool huboPenales) :base (s1, s2, fechaYHora)
        {
            this._huboAlargue = huboAlargue;
            this._huboPenales = huboPenales;
            this._etapa = etapa;
        }

    }
}
