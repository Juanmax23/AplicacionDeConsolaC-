using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Periodista : IValidable
    {
        private int _id;
        private int s_ultId = 1;
        private string _nombreYApellido;
        private string _email;
        private string _password;
        private List<Reseña> _reseñas = new List<Reseña>();

        public Periodista(string nombreYApellido, string email, string password)
        {
            this._id = s_ultId;
            s_ultId++;
            this._nombreYApellido = nombreYApellido;
            this._email = email;
            this._password = password;
        }
        public string  Email
        {
            get { return _email; }
        }
        public string NombreYApellido
        {
            get { return _nombreYApellido; }
        }

        public void Validar()
        {
            ValidarNombreYApellido();
            ValidarEmail();
            ValidarContraseña();
        }

        private void ValidarNombreYApellido()
        {
            if (string.IsNullOrEmpty(_nombreYApellido)) throw new Exception("El nombre no puede ser vacío");
        }

        private void ValidarEmail()
        {
            if (string.IsNullOrEmpty(_email)) throw new Exception("El email no puede ser vacío");
            if (!(_email.Contains("@"))) throw new Exception("El email debe contener un @");
            if (_email[0] == '@' || _email[_email.Length - 1] == '@') throw new Exception("El @ no puede estar en la primera posicion ni en la ultima");

        }
        
        public override bool Equals(object obj)
        {
            Periodista p = obj as Periodista;
            return p != null && p.Email.Equals(this._email);
        }

        private void ValidarContraseña()
        {
            if  (_password.Length < 8) throw new Exception("La contraseña tiene que tener por lo menos 8 caracteres");
        }

        public override string ToString()
        {
            return $"NombreYApellido: {_nombreYApellido} Gmail: {_email}";
        }

        public void IngresarReseña()
        {
            //método para la segunda parte del obligatorio
        }

    }
}
