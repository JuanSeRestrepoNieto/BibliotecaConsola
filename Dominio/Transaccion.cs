using System;

namespace Biblioteca.Dominio
{
    /// <summary>
    /// Clase base que representa una transacción en el sistema.
    /// Demuestra HERENCIA al proporcionar funcionalidad común
    /// para operaciones que involucran fechas y validaciones.
    /// </summary>
    public abstract class Transaccion
    {
        protected string _id;
        protected DateTime _fechaCreacion;

        protected Transaccion(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("El ID no puede estar vacío", nameof(id));

            _id = id.Trim();
            _fechaCreacion = DateTime.Now;
        }

        // Propiedades de solo lectura - ENCAPSULAMIENTO
        public string Id => _id;
        public DateTime FechaCreacion => _fechaCreacion;

        /// <summary>
        /// Valida si la transacción es válida.
        /// Método virtual que puede ser sobrescrito por clases derivadas.
        /// </summary>
        public virtual bool EsValida()
        {
            return !string.IsNullOrWhiteSpace(_id) && _fechaCreacion <= DateTime.Now;
        }

        public override string ToString()
        {
            return $"Transacción {_id} - {_fechaCreacion:dd/MM/yyyy HH:mm}";
        }
    }
}
