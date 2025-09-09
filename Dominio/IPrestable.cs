namespace Biblioteca.Dominio
{
    /// <summary>
    /// Interfaz que define el contrato para elementos que pueden ser prestados.
    /// Demuestra el pilar de ABSTRACCIÓN al establecer un contrato común
    /// sin especificar la implementación concreta.
    /// </summary>
    public interface IPrestable
    {
        /// <summary>
        /// Verifica si el elemento está disponible para préstamo.
        /// </summary>
        bool EstaDisponible();

        /// <summary>
        /// Marca el elemento como prestado.
        /// </summary>
        void MarcarComoPrestado();

        /// <summary>
        /// Marca el elemento como disponible.
        /// </summary>
        void MarcarComoDisponible();
    }
}
