using Biblioteca.Dominio;
using Biblioteca.Infraestructura;

namespace Biblioteca.Servicio
{
    /// <summary>
    /// Servicio que maneja la lógica de negocio para usuarios.
    /// </summary>
    public class ServicioUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicioUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        public void RegistrarUsuario(string id, string nombre)
        {
            try
            {
                ValidarDatosUsuario(id, nombre);
                
                var usuario = new Usuario(id, nombre);
                _repositorioUsuario.AgregarUsuario(usuario);
                
                LogOperacion($"Usuario registrado: {usuario}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al registrar usuario: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        public Usuario? ObtenerUsuario(string id)
        {
            return _repositorioUsuario.ObtenerUsuario(id);
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados.
        /// </summary>
        public List<Usuario> ObtenerTodosUsuarios()
        {
            return _repositorioUsuario.ObtenerTodosUsuarios();
        }

        /// <summary>
        /// Verifica si un usuario existe en el sistema.
        /// </summary>
        public bool ExisteUsuario(string id)
        {
            return _repositorioUsuario.ExisteUsuario(id);
        }

        private void ValidarDatosUsuario(string id, string nombre)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("El ID del usuario no puede estar vacío");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del usuario no puede estar vacío");

            if (_repositorioUsuario.ExisteUsuario(id))
                throw new ArgumentException($"Ya existe un usuario con ID '{id}'");
        }

        private void LogOperacion(string mensaje)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {mensaje}");
        }
    }
}
