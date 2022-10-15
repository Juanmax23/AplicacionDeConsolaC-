using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Reseña
    {
        private Periodista _periodista;
        private DateTime _fecha;
        private Partido _partido;
        private string _titulo;
        private string _contenido;

        public Reseña(Periodista periodista, DateTime fecha, Partido partido, string titulo, string contenido)
        {
            this._periodista = periodista;
            this._fecha = fecha;
            this._partido = partido;
            this._titulo = titulo;
            this._contenido = contenido;
        }


    }
}
