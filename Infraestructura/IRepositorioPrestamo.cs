using Biblioteca.Dominio;

namespace Biblioteca.Infraestructura
{
    /// <summary>
    /// Interfaz que define las operaciones de repositorio para préstamos.
    /// </summary>
    public interface IRepositorioPrestamo
    {
        /// <summary>
        /// Agrega un nuevo préstamo al repositorio.
        /// </summary>
        void AgregarPrestamo(Prestamo prestamo);

        /// <summary>
        /// Obtiene un préstamo por su ID.
        /// </summary>
        Prestamo? ObtenerPrestamo(string id);

        /// <summary>
        /// Obtiene todos los préstamos registrados.
        /// </summary>
        List<Prestamo> ObtenerTodosPrestamos();

        /// <summary>
        /// Obtiene todos los préstamos activos.
        /// </summary>
        List<Prestamo> ObtenerPrestamosActivos();

        /// <summary>
        /// Obtiene todos los préstamos vencidos.
        /// </summary>
        List<Prestamo> ObtenerPrestamosVencidos();

        /// <summary>
        /// Obtiene los préstamos de un usuario específico.
        /// </summary>
        List<Prestamo> ObtenerPrestamosPorUsuario(string usuarioId);

        /// <summary>
        /// Actualiza un préstamo existente.
        /// </summary>
        void ActualizarPrestamo(Prestamo prestamo);
    }
}
