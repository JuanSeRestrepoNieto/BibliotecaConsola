using Biblioteca.Dominio;

namespace Biblioteca.Infraestructura
{
    /// <summary>
    /// Implementación en memoria del repositorio de préstamos.
    /// </summary>
    public class RepositorioPrestamo : IRepositorioPrestamo
    {
        private readonly List<Prestamo> _prestamos;

        public RepositorioPrestamo()
        {
            _prestamos = new List<Prestamo>();
        }

        public void AgregarPrestamo(Prestamo prestamo)
        {
            if (prestamo == null)
                throw new ArgumentNullException(nameof(prestamo));

            _prestamos.Add(prestamo);
        }

        public Prestamo? ObtenerPrestamo(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return _prestamos.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public List<Prestamo> ObtenerTodosPrestamos()
        {
            return new List<Prestamo>(_prestamos);
        }

        public List<Prestamo> ObtenerPrestamosActivos()
        {
            return _prestamos.Where(p => p.Activo).ToList();
        }

        public List<Prestamo> ObtenerPrestamosVencidos()
        {
            return _prestamos.Where(p => p.Activo && p.EstaVencido()).ToList();
        }

        public List<Prestamo> ObtenerPrestamosPorUsuario(string usuarioId)
        {
            if (string.IsNullOrWhiteSpace(usuarioId))
                return new List<Prestamo>();

            return _prestamos.Where(p => p.Usuario.Id.Equals(usuarioId, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void ActualizarPrestamo(Prestamo prestamo)
        {
            if (prestamo == null)
                throw new ArgumentNullException(nameof(prestamo));

            var index = _prestamos.FindIndex(p => p.Id.Equals(prestamo.Id, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                _prestamos[index] = prestamo;
            }
        }
    }
}
