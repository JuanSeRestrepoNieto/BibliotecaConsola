using Biblioteca.Dominio;

namespace Biblioteca.Infraestructura
{
    /// <summary>
    /// Interfaz que define las operaciones de repositorio para libros.
    /// </summary>
    public interface IRepositorioLibro
    {
        /// <summary>
        /// Agrega un nuevo libro al repositorio.
        /// </summary>
        void AgregarLibro(Libro libro);

        /// <summary>
        /// Obtiene un libro por su ID.
        /// </summary>
        Libro? ObtenerLibro(string id);

        /// <summary>
        /// Obtiene todos los libros registrados.
        /// </summary>
        List<Libro> ObtenerTodosLibros();

        /// <summary>
        /// Obtiene todos los libros disponibles.
        /// </summary>
        List<Libro> ObtenerLibrosDisponibles();

        /// <summary>
        /// Verifica si existe un libro con el ID especificado.
        /// </summary>
        bool ExisteLibro(string id);

        /// <summary>
        /// Verifica si existe un libro con el ISBN especificado.
        /// </summary>
        bool ExisteIsbn(string isbn);
    }
}
