using Biblioteca.Dominio;

namespace Biblioteca.Infraestructura
{
    /// <summary>
    /// Implementación en memoria del repositorio de usuarios.
    /// </summary>
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly List<Usuario> _usuarios;

        public RepositorioUsuario()
        {
            _usuarios = new List<Usuario>();
        }

        public void AgregarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (ExisteUsuario(usuario.Id))
                throw new ArgumentException($"Ya existe un usuario con ID '{usuario.Id}'");

            _usuarios.Add(usuario);
        }

        public Usuario? ObtenerUsuario(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return _usuarios.FirstOrDefault(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public List<Usuario> ObtenerTodosUsuarios()
        {
            return new List<Usuario>(_usuarios);
        }

        public bool ExisteUsuario(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            return _usuarios.Any(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }
    }
}
