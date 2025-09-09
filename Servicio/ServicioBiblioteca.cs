using Biblioteca.Dominio;
using Biblioteca.Infraestructura;

namespace Biblioteca.Servicio
{
    /// <summary>
    /// Servicio principal que coordina todas las operaciones de la biblioteca.
    /// </summary>
    public class ServicioBiblioteca
    {
        private readonly ServicioUsuario _servicioUsuario;
        private readonly ServicioLibro _servicioLibro;
        private readonly ServicioPrestamo _servicioPrestamo;

        public ServicioBiblioteca(
            ServicioUsuario servicioUsuario,
            ServicioLibro servicioLibro,
            ServicioPrestamo servicioPrestamo)
        {
            _servicioUsuario = servicioUsuario ?? throw new ArgumentNullException(nameof(servicioUsuario));
            _servicioLibro = servicioLibro ?? throw new ArgumentNullException(nameof(servicioLibro));
            _servicioPrestamo = servicioPrestamo ?? throw new ArgumentNullException(nameof(servicioPrestamo));
        }

        #region Operaciones de Usuario

        public void RegistrarUsuario(string id, string nombre)
        {
            _servicioUsuario.RegistrarUsuario(id, nombre);
        }

        public Usuario? ObtenerUsuario(string id)
        {
            return _servicioUsuario.ObtenerUsuario(id);
        }

        public List<Usuario> ObtenerTodosUsuarios()
        {
            return _servicioUsuario.ObtenerTodosUsuarios();
        }

        #endregion

        #region Operaciones de Libro

        public void AgregarLibro(string id, string titulo, string autor, string isbn)
        {
            _servicioLibro.AgregarLibro(id, titulo, autor, isbn);
        }

        public Libro? ObtenerLibro(string id)
        {
            return _servicioLibro.ObtenerLibro(id);
        }

        public List<Libro> ObtenerTodosLibros()
        {
            return _servicioLibro.ObtenerTodosLibros();
        }

        public List<Libro> ObtenerLibrosDisponibles()
        {
            return _servicioLibro.ObtenerLibrosDisponibles();
        }

        #endregion

        #region Operaciones de Préstamo

        public void RealizarPrestamo(string usuarioId, string libroId, int diasPrestamo)
        {
            _servicioPrestamo.RealizarPrestamo(usuarioId, libroId, diasPrestamo);
        }

        public void RegistrarDevolucion(string prestamoId)
        {
            _servicioPrestamo.RegistrarDevolucion(prestamoId);
        }

        public List<Prestamo> ObtenerPrestamosActivos()
        {
            return _servicioPrestamo.ObtenerPrestamosActivos();
        }

        public List<Prestamo> ObtenerPrestamosVencidos()
        {
            return _servicioPrestamo.ObtenerPrestamosVencidos();
        }

        public List<Prestamo> ObtenerTodosPrestamos()
        {
            return _servicioPrestamo.ObtenerTodosPrestamos();
        }

        #endregion

        #region Métodos de Utilidad

        /// <summary>
        /// Obtiene un resumen general del estado de la biblioteca.
        /// </summary>
        public ResumenBiblioteca ObtenerResumenGeneral()
        {
            return new ResumenBiblioteca
            {
                TotalUsuarios = _servicioUsuario.ObtenerTodosUsuarios().Count,
                TotalLibros = _servicioLibro.ObtenerTodosLibros().Count,
                LibrosDisponibles = _servicioLibro.ObtenerLibrosDisponibles().Count,
                PrestamosActivos = _servicioPrestamo.ObtenerPrestamosActivos().Count,
                PrestamosVencidos = _servicioPrestamo.ObtenerPrestamosVencidos().Count
            };
        }

        #endregion
    }

    /// <summary>
    /// Clase que representa un resumen del estado de la biblioteca.
    /// </summary>
    public class ResumenBiblioteca
    {
        public int TotalUsuarios { get; set; }
        public int TotalLibros { get; set; }
        public int LibrosDisponibles { get; set; }
        public int PrestamosActivos { get; set; }
        public int PrestamosVencidos { get; set; }
    }
}
