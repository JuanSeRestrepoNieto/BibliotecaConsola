using Biblioteca.Dominio;

namespace Biblioteca.Servicio.Interfaces;

public interface IServicioPrestamo
{
  void RealizarPrestamo(string usuarioId, string libroId, int diasPrestamo);
  /// <summary>
  /// Registra la devolución de un préstamo.
  /// </summary>
  public void RegistrarDevolucion(string prestamoId);
  /// <summary>
  /// Obtiene todos los préstamos activos.
  /// </summary>
  public List<Prestamo> ObtenerPrestamosActivos();
  /// <summary>
  /// Obtiene todos los préstamos vencidos.
  /// </summary>
  public List<Prestamo> ObtenerPrestamosVencidos();
  /// <summary>
  /// Obtiene todos los préstamos.
  /// </summary>
  public List<Prestamo> ObtenerTodosPrestamos();
  /// <summary>
  /// Obtiene los préstamos de un usuario específico.
  /// </summary>
  public List<Prestamo> ObtenerPrestamosPorUsuario(string usuarioId);        
}