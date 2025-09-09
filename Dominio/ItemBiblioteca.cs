using System;

namespace Biblioteca.Dominio
{
    /// <summary>
    /// Clase abstracta que representa un elemento de la biblioteca.
    /// Demuestra el pilar de ABSTRACCIÓN al definir la estructura común
    /// para elementos que pueden ser prestados sin especificar implementación.
    /// </summary>
    public abstract class ItemBiblioteca
    {
        protected string _id;
        protected string _titulo;

        protected ItemBiblioteca(string id, string titulo)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("El ID no puede estar vacío", nameof(id));
            
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("El título no puede estar vacío", nameof(titulo));

            _id = id.Trim();
            _titulo = titulo.Trim();
        }

        public string Id => _id;
        public string Titulo => _titulo;

        /// <summary>
        /// Método abstracto que debe ser implementado por las clases derivadas.
        /// Demuestra polimorfismo al permitir diferentes implementaciones.
        /// </summary>
        public abstract string ObtenerInformacion();

        public override string ToString()
        {
            return $"{_titulo} (ID: {_id})";
        }
    }
}
