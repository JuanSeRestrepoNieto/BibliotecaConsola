using Biblioteca.Dominio;

namespace Biblioteca.Infraestructura
{
    /// <summary>
    /// Implementación en memoria del repositorio de libros.
    /// </summary>
    public class RepositorioLibro : IRepositorioLibro
    {
        private readonly List<Libro> _libros;

        public RepositorioLibro()
        {
            _libros = new List<Libro>();
        }

        public void AgregarLibro(Libro libro)
        {
            if (libro == null)
                throw new ArgumentNullException(nameof(libro));

            if (ExisteLibro(libro.Id))
                throw new ArgumentException($"Ya existe un libro con ID '{libro.Id}'");

            if (ExisteIsbn(libro.ISBN))
                throw new ArgumentException($"Ya existe un libro con ISBN '{libro.ISBN}'");

            _libros.Add(libro);
        }

        public Libro? ObtenerLibro(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return _libros.FirstOrDefault(l => l.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public List<Libro> ObtenerTodosLibros()
        {
            return new List<Libro>(_libros);
        }

        public List<Libro> ObtenerLibrosDisponibles()
        {
            return _libros.Where(l => l.EstaDisponible()).ToList();
        }

        public bool ExisteLibro(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            return _libros.Any(l => l.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public bool ExisteIsbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            return _libros.Any(l => l.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
        }
    }
}
