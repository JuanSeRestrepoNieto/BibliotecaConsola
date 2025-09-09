using Biblioteca.Dominio;

namespace Biblioteca.Infraestructura
{
    /// <summary>
    /// Interfaz que define las operaciones de repositorio para usuarios.
    /// </summary>
    public interface IRepositorioUsuario
    {
        /// <summary>
        /// Agrega un nuevo usuario al repositorio.
        /// </summary>
        void AgregarUsuario(Usuario usuario);

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        Usuario? ObtenerUsuario(string id);

        /// <summary>
        /// Obtiene todos los usuarios registrados.
        /// </summary>
        List<Usuario> ObtenerTodosUsuarios();

        /// <summary>
        /// Verifica si existe un usuario con el ID especificado.
        /// </summary>
        bool ExisteUsuario(string id);
    }
}
