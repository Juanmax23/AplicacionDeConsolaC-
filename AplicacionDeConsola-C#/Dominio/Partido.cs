using Dominio.Ordenamiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Partido : IValidable
    {
        private int _id;
        private static int s_ultId = 1;
        private Seleccion _seleccion1;
        private Seleccion _seleccion2;
        private DateTime _fechaYHora;
        private bool _finalizado = false;
        private List<Incidencia> _incidencias = new List<Incidencia>();
        private Reseña _reseña;
        private string _resultado = "Pendiente";

        public Partido(Seleccion s1, Seleccion s2, DateTime fechaYHora)
        {
            this._seleccion1 = s1;
            this._seleccion2 = s2;
            this._fechaYHora = fechaYHora;
            this._id = s_ultId;
            s_ultId++;
        }

        public int Id
        {
            get { return _id; }
        }

        public bool Finalizado
        {
            get { return _finalizado; }
        }

        public List<Incidencia> Incidencias
        {
            get { return _incidencias; }
        }

        public Seleccion Seleccion1
        {
            get { return _seleccion1; }
        }

        public Seleccion Seleccion2
        {
            get { return _seleccion2; }
        }

        public void Validar()
        {
            ValidarSelecciones();
            ValidarFecha();
        }

        private void ValidarSelecciones()
        {
            if (_seleccion1 == null || _seleccion2 == null) throw new Exception("Una selección NO ha sido ingresada correctamente");
        }

        private void ValidarFecha()
        {
            DateTime inicio = new DateTime(2022, 11, 20);
            DateTime fin = new DateTime(2022, 12, 18);
            
            if (DateTime.Compare(_fechaYHora, inicio) < 0) throw new Exception($"La fecha ingresada para el partido {_seleccion1.NombrePais} vs {_seleccion2.NombrePais} es previa al inicio del torneo");
            if (DateTime.Compare(_fechaYHora, fin) > 0) throw new Exception($"La fecha ingresada para el partido {_seleccion1.NombrePais} vs {_seleccion2.NombrePais} es posterior al final del torneo");
        }

        public override string ToString()
        {
            return $"El {_fechaYHora}  {Seleccion1.NombrePais} vs {Seleccion2.NombrePais}  {CalcularGolesDeUnPartido()} Incidencias";
        }

        public void AgregarIncidenciaAPartido(Incidencia i)
        {
            try
            {
                if (ElJugadorEstaEnElPartido(i.Jugador))
                {
                    if  (Finalizado != true)
                    {
                        _incidencias.Add(i);
                    }else
                    {
                        throw new Exception("No puede ingresar incidencias ya que el partido está finalizado");
                    }
                    
                } else
                {
                    throw new Exception("El jugador no pertenece a ninguna de las dos selecciones");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ElJugadorEstaEnElPartido(Jugador m)
        {
            bool está = false;

            if (_seleccion1.JugadoresSeleccion.Contains(m))
            {
                está = true;
            } else if (_seleccion2.JugadoresSeleccion.Contains(m))
            {
                está = true;
            }

            return está;
        }

        public List<Jugador> ListarJugadoresConGoles()
        {
            List<Jugador> list = new List<Jugador>();
            foreach(Incidencia i in _incidencias)
            {
                //Si la incidencia es un gol agrega ese jugador a la lista
                //verifico que el jugador no se repita
                if (i.Inc == "Gol" && !list.Contains(i.Jugador)) list.Add(i.Jugador);
            }

            return list;
        }

        public List<Jugador> ListarJugadorConTarjetaRojaEnUnPartido()
        {
            List<Jugador> lista = new List<Jugador>();

            foreach (Incidencia i in _incidencias)
            {
                if (i.Inc == "Tarjeta roja")
                {
                    //No puede pasar que en un partido saquen roja dos veces al mismo jugador pero igual lo valido
                    if (!lista.Contains(i.Jugador)) { lista.Add(i.Jugador); }
                }
            }

            return lista;

        }

        public int CalcularGolesDeUnPartido()
        {
            int cantidadDeGoles = 0;
            foreach(Incidencia i in _incidencias)
            {
                if(i.Inc== "Gol") { cantidadDeGoles++; }
            }

            return cantidadDeGoles;
        }


        // abstract string FinalizarPartido();
    }
}
