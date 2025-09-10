using Biblioteca.Dominio;

namespace Biblioteca.Servicio.Interfaces;

public interface IServicioUsuario
{
  /// <summary>
  /// Registra un nuevo usuario en el sistema.
  /// </summary>
  void RegistrarUsuario(string id, string nombre);
  /// <summary>
  /// Obtiene un usuario por su ID.
  /// </summary>
  Usuario? ObtenerUsuario(string id);
  /// <summary>
  /// Obtiene todos los usuarios registrados.
  /// </summary>
  List<Usuario> ObtenerTodosUsuarios();
  /// <summary>
  /// Verifica si un usuario existe en el sistema.
  /// </summary>
  bool ExisteUsuario(string id);
}