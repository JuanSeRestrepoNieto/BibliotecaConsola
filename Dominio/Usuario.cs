using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Dominio
{
    /// <summary>
    /// Clase que representa un usuario de la biblioteca.
    /// Demuestra ENCAPSULAMIENTO al mantener los datos privados
    /// y proporcionar métodos controlados para acceder a la información.
    /// </summary>
    public class Usuario
    {
        private string _id;
        private string _nombre;
        private List<Prestamo> _prestamos;

        public Usuario(string id, string nombre)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("El ID no puede estar vacío", nameof(id));
            
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));

            _id = id.Trim();
            _nombre = nombre.Trim();
            _prestamos = new List<Prestamo>();
        }

        // Propiedades de solo lectura - ENCAPSULAMIENTO
        public string Id => _id;
        public string Nombre => _nombre;
        public IReadOnlyList<Prestamo> Prestamos => _prestamos.AsReadOnly();

        /// <summary>
        /// Obtiene los préstamos activos del usuario.
        /// </summary>
        public List<Prestamo> ObtenerPrestamosActivos()
        {
            return _prestamos.Where(p => p.Activo).ToList();
        }

        /// <summary>
        /// Agrega un préstamo a la lista del usuario.
        /// Método interno para mantener la integridad de datos.
        /// </summary>
        internal void AgregarPrestamo(Prestamo prestamo)
        {
            if (prestamo == null)
                throw new ArgumentNullException(nameof(prestamo));
            
            _prestamos.Add(prestamo);
        }

        public override string ToString()
        {
            return $"{_nombre} (ID: {_id})";
        }

        public override bool Equals(object obj)
        {
            return obj is Usuario usuario && _id == usuario._id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }
}
