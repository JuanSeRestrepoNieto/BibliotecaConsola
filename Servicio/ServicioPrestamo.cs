using Biblioteca.Dominio;
using Biblioteca.Infraestructura;

namespace Biblioteca.Servicio
{
    /// <summary>
    /// Servicio que maneja la lógica de negocio para préstamos.
    /// </summary>
    public class ServicioPrestamo
    {
        private readonly IRepositorioPrestamo _repositorioPrestamo;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioLibro _repositorioLibro;

        public ServicioPrestamo(
            IRepositorioPrestamo repositorioPrestamo,
            IRepositorioUsuario repositorioUsuario,
            IRepositorioLibro repositorioLibro)
        {
            _repositorioPrestamo = repositorioPrestamo ?? throw new ArgumentNullException(nameof(repositorioPrestamo));
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            _repositorioLibro = repositorioLibro ?? throw new ArgumentNullException(nameof(repositorioLibro));
        }

        /// <summary>
        /// Realiza un nuevo préstamo.
        /// </summary>
        public void RealizarPrestamo(string usuarioId, string libroId, int diasPrestamo)
        {
            try
            {
                ValidarDatosPrestamo(usuarioId, libroId, diasPrestamo);

                var usuario = _repositorioUsuario.ObtenerUsuario(usuarioId);
                var libro = _repositorioLibro.ObtenerLibro(libroId);

                if (usuario == null)
                    throw new ArgumentException($"Usuario con ID '{usuarioId}' no encontrado");

                if (libro == null)
                    throw new ArgumentException($"Libro con ID '{libroId}' no encontrado");

                if (!libro.EstaDisponible())
                    throw new InvalidOperationException("El libro no está disponible para préstamo");

                var prestamoId = GenerarIdPrestamo();
                var prestamo = new Prestamo(prestamoId, usuario, libro, diasPrestamo);
                _repositorioPrestamo.AgregarPrestamo(prestamo);
                
                LogOperacion($"Préstamo realizado: {prestamo}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al realizar préstamo: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Registra la devolución de un préstamo.
        /// </summary>
        public void RegistrarDevolucion(string prestamoId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(prestamoId))
                    throw new ArgumentException("El ID del préstamo no puede estar vacío");

                var prestamo = _repositorioPrestamo.ObtenerPrestamo(prestamoId);
                if (prestamo == null)
                    throw new ArgumentException($"Préstamo con ID '{prestamoId}' no encontrado");

                prestamo.RegistrarDevolucion();
                _repositorioPrestamo.ActualizarPrestamo(prestamo);
                
                LogOperacion($"Devolución registrada: {prestamo}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al registrar devolución: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene todos los préstamos activos.
        /// </summary>
        public List<Prestamo> ObtenerPrestamosActivos()
        {
            return _repositorioPrestamo.ObtenerPrestamosActivos();
        }

        /// <summary>
        /// Obtiene todos los préstamos vencidos.
        /// </summary>
        public List<Prestamo> ObtenerPrestamosVencidos()
        {
            return _repositorioPrestamo.ObtenerPrestamosVencidos();
        }

        /// <summary>
        /// Obtiene todos los préstamos.
        /// </summary>
        public List<Prestamo> ObtenerTodosPrestamos()
        {
            return _repositorioPrestamo.ObtenerTodosPrestamos();
        }

        /// <summary>
        /// Obtiene los préstamos de un usuario específico.
        /// </summary>
        public List<Prestamo> ObtenerPrestamosPorUsuario(string usuarioId)
        {
            return _repositorioPrestamo.ObtenerPrestamosPorUsuario(usuarioId);
        }

        private void ValidarDatosPrestamo(string usuarioId, string libroId, int diasPrestamo)
        {
            if (string.IsNullOrWhiteSpace(usuarioId))
                throw new ArgumentException("El ID del usuario no puede estar vacío");

            if (string.IsNullOrWhiteSpace(libroId))
                throw new ArgumentException("El ID del libro no puede estar vacío");

            if (diasPrestamo <= 0)
                throw new ArgumentException("Los días de préstamo deben ser mayores a 0");
        }

        private string GenerarIdPrestamo()
        {
            return $"P{DateTime.Now:yyyyMMddHHmmss}";
        }

        private void LogOperacion(string mensaje)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {mensaje}");
        }
    }
}
