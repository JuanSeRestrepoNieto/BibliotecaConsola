using Biblioteca.Dominio;
using Biblioteca.Infraestructura;

namespace Biblioteca.Servicio
{
    /// <summary>
    /// Servicio que maneja la lógica de negocio para libros.
    /// </summary>
    public class ServicioLibro
    {
        private readonly IRepositorioLibro _repositorioLibro;

        public ServicioLibro(IRepositorioLibro repositorioLibro)
        {
            _repositorioLibro = repositorioLibro ?? throw new ArgumentNullException(nameof(repositorioLibro));
        }

        /// <summary>
        /// Agrega un nuevo libro al catálogo.
        /// </summary>
        public void AgregarLibro(string id, string titulo, string autor, string isbn)
        {
            try
            {
                ValidarDatosLibro(id, titulo, autor, isbn);
                
                var libro = new Libro(id, titulo, autor, isbn);
                _repositorioLibro.AgregarLibro(libro);
                
                LogOperacion($"Libro agregado: {libro}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al agregar libro: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene un libro por su ID.
        /// </summary>
        public Libro? ObtenerLibro(string id)
        {
            return _repositorioLibro.ObtenerLibro(id);
        }

        /// <summary>
        /// Obtiene todos los libros del catálogo.
        /// </summary>
        public List<Libro> ObtenerTodosLibros()
        {
            return _repositorioLibro.ObtenerTodosLibros();
        }

        /// <summary>
        /// Obtiene todos los libros disponibles.
        /// </summary>
        public List<Libro> ObtenerLibrosDisponibles()
        {
            return _repositorioLibro.ObtenerLibrosDisponibles();
        }

        /// <summary>
        /// Verifica si un libro existe en el sistema.
        /// </summary>
        public bool ExisteLibro(string id)
        {
            return _repositorioLibro.ExisteLibro(id);
        }

        private void ValidarDatosLibro(string id, string titulo, string autor, string isbn)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("El ID del libro no puede estar vacío");

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("El título del libro no puede estar vacío");

            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("El autor del libro no puede estar vacío");

            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN del libro no puede estar vacío");

            if (_repositorioLibro.ExisteLibro(id))
                throw new ArgumentException($"Ya existe un libro con ID '{id}'");

            if (_repositorioLibro.ExisteIsbn(isbn))
                throw new ArgumentException($"Ya existe un libro con ISBN '{isbn}'");
        }

        private void LogOperacion(string mensaje)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {mensaje}");
        }
    }
}
