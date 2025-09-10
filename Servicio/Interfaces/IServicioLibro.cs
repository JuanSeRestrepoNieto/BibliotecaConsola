using Biblioteca.Dominio;

namespace Biblioteca.Servicio.Interfaces;

public interface IServicioLibro
{
  /// <summary>
  /// Obtiene un libro
  /// </summary>
  void AgregarLibro(string id, string titulo, string autor, string isbn);

  /// <summary>
  /// Obtiene un libro por su ID.
  /// </summary>
  Libro? ObtenerLibro(string id);

  /// <summary>
  /// Obtiene todos los libros del catálogo.
  /// </summary>
  List<Libro> ObtenerTodosLibros();

  /// <summary>
  /// Obtiene todos los libros disponibles.
  /// </summary>
  List<Libro> ObtenerLibrosDisponibles();

  /// <summary>
  /// Verifica si un libro existe en el sistema.
  /// </summary>
  bool ExisteLibro(string id);  
}