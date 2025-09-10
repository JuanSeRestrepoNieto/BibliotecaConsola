using Biblioteca.Dominio;
using System.Collections.Generic;

/// <summary>
/// Interfaz que define las operaciones de servicio para la biblioteca.
/// </summary>
namespace Biblioteca.Servicio.Interfaces;

public interface IServicioBiblioteca
{
  void RegistrarUsuario(string id, string nombre);
  Usuario? ObtenerUsuario(string id);
  List<Usuario> ObtenerTodosUsuarios();
  void AgregarLibro(string id, string titulo, string autor, string isbn);
  Libro? ObtenerLibro(string id);
  List<Libro> ObtenerTodosLibros();
  List<Libro> ObtenerLibrosDisponibles();
  void RealizarPrestamo(string usuarioId, string libroId, int diasPrestamo);
  void RegistrarDevolucion(string prestamoId);
  List<Prestamo> ObtenerPrestamosActivos();
  List<Prestamo> ObtenerPrestamosVencidos();
  List<Prestamo> ObtenerTodosPrestamos();
  /// <summary>
  /// Obtiene un resumen general del estado de la biblioteca.
  /// </summary>
  ResumenBiblioteca ObtenerResumenGeneral();
}