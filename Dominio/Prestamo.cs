using System;

namespace Biblioteca.Dominio
{
    /// <summary>
    /// Clase que representa un préstamo en la biblioteca.
    /// Demuestra HERENCIA al heredar de Transaccion.
    /// Demuestra ENCAPSULAMIENTO al mantener los datos privados y controlar el acceso.
    /// Demuestra POLIMORFISMO al sobrescribir métodos de la clase base.
    /// </summary>
    public class Prestamo : Transaccion
    {
        private Usuario _usuario;
        private Libro _libro;
        private DateTime _fechaVencimiento;
        private bool _activo;

        public Prestamo(string id, Usuario usuario, Libro libro, int diasPrestamo) 
            : base(id)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));
            
            if (libro == null)
                throw new ArgumentNullException(nameof(libro));
            
            if (diasPrestamo <= 0)
                throw new ArgumentException("Los días de préstamo deben ser mayores a 0", nameof(diasPrestamo));

            if (!libro.EstaDisponible())
                throw new InvalidOperationException("El libro no está disponible para préstamo");

            _usuario = usuario;
            _libro = libro;
            _fechaVencimiento = _fechaCreacion.AddDays(diasPrestamo);
            _activo = true;

            // Marcar el libro como prestado
            _libro.MarcarComoPrestado();
            
            // Agregar el préstamo al usuario
            _usuario.AgregarPrestamo(this);
        }

        // Propiedades de solo lectura - ENCAPSULAMIENTO
        public Usuario Usuario => _usuario;
        public Libro Libro => _libro;
        public DateTime FechaVencimiento => _fechaVencimiento;
        public bool Activo => _activo;

        /// <summary>
        /// Verifica si el préstamo está vencido.
        /// </summary>
        public bool EstaVencido()
        {
            return _activo && DateTime.Now > _fechaVencimiento;
        }

        /// <summary>
        /// Calcula los días de retraso si el préstamo está vencido.
        /// </summary>
        public int ObtenerDiasRetraso()
        {
            if (!EstaVencido())
                return 0;
            
            return (DateTime.Now - _fechaVencimiento).Days;
        }

        /// <summary>
        /// Registra la devolución del libro.
        /// </summary>
        public void RegistrarDevolucion()
        {
            if (!_activo)
                throw new InvalidOperationException("El préstamo ya fue devuelto");

            _activo = false;
            _libro.MarcarComoDisponible();
        }

        // Sobrescritura del método de la clase base - POLIMORFISMO
        public override bool EsValida()
        {
            return base.EsValida() && _usuario != null && _libro != null;
        }

        public override string ToString()
        {
            var estado = _activo ? (EstaVencido() ? "VENCIDO" : "ACTIVO") : "DEVUELTO";
            return $"Préstamo {_id}: {_libro.Titulo} - {_usuario.Nombre} - {estado} - Vence: {_fechaVencimiento:dd/MM/yyyy}";
        }
    }
}
