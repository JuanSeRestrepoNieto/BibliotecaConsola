using System;

namespace Biblioteca.Dominio
{
    /// <summary>
    /// Clase que representa un libro en la biblioteca.
    /// Demuestra HERENCIA al heredar de ItemBiblioteca e implementar IPrestable.
    /// Demuestra ENCAPSULAMIENTO al mantener los datos privados y controlar el acceso.
    /// </summary>
    public class Libro : ItemBiblioteca, IPrestable
    {
        private string _autor;
        private string _isbn;
        private bool _disponible;

        public Libro(string id, string titulo, string autor, string isbn) 
            : base(id, titulo)
        {
            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("El autor no puede estar vacío", nameof(autor));
            
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío", nameof(isbn));

            _autor = autor.Trim();
            _isbn = isbn.Trim();
            _disponible = true; // Por defecto, un libro nuevo está disponible
        }

        // Propiedades de solo lectura - ENCAPSULAMIENTO
        public string Autor => _autor;
        public string ISBN => _isbn;
        public bool Disponible => _disponible;

        // Implementación de IPrestable - POLIMORFISMO
        public bool EstaDisponible()
        {
            return _disponible;
        }

        public void MarcarComoPrestado()
        {
            if (!_disponible)
                throw new InvalidOperationException("El libro ya está prestado");
            
            _disponible = false;
        }

        public void MarcarComoDisponible()
        {
            _disponible = true;
        }

        // Implementación del método abstracto - HERENCIA
        public override string ObtenerInformacion()
        {
            return $"Libro: {_titulo} - Autor: {_autor} - ISBN: {_isbn} - Disponible: {(_disponible ? "Sí" : "No")}";
        }

        public override string ToString()
        {
            return $"{_titulo} por {_autor}";
        }
    }
}
