using System;
using System.Linq;
using Biblioteca.Dominio;
using Biblioteca.Servicio;
using Biblioteca.Infraestructura;

namespace Biblioteca
{
    /// <summary>
    /// Programa principal que proporciona la interfaz de consola
    /// para el sistema de gestión de biblioteca.
    /// </summary>
    class Program
    {
        private static ServicioBiblioteca _servicioBiblioteca;

        static void Main(string[] args)
        {
            InicializarServicios();
            CargarDatosPrueba();
            MostrarMenuPrincipal();
        }

        /// <summary>
        /// Inicializa todos los servicios y repositorios del sistema.
        /// </summary>
        private static void InicializarServicios()
        {
            // Crear repositorios
            var repositorioUsuario = new RepositorioUsuario();
            var repositorioLibro = new RepositorioLibro();
            var repositorioPrestamo = new RepositorioPrestamo();

            // Crear servicios
            var servicioUsuario = new ServicioUsuario(repositorioUsuario);
            var servicioLibro = new ServicioLibro(repositorioLibro);
            var servicioPrestamo = new ServicioPrestamo(repositorioPrestamo, repositorioUsuario, repositorioLibro);

            // Crear servicio principal
            _servicioBiblioteca = new ServicioBiblioteca(servicioUsuario, servicioLibro, servicioPrestamo);
        }

        /// <summary>
        /// Carga datos de prueba para demostrar el funcionamiento del sistema.
        /// </summary>
        private static void CargarDatosPrueba()
        {
            try
            {
                // Usuarios de prueba
                _servicioBiblioteca.RegistrarUsuario("U001", "María González");
                _servicioBiblioteca.RegistrarUsuario("U002", "Carlos Rodríguez");
                _servicioBiblioteca.RegistrarUsuario("U003", "Ana Martínez");

                // Libros de prueba
                _servicioBiblioteca.AgregarLibro("L001", "Cien Años de Soledad", "Gabriel García Márquez", "978-84-376-0494-7");
                _servicioBiblioteca.AgregarLibro("L002", "Don Quijote", "Miguel de Cervantes", "978-84-376-0495-4");
                _servicioBiblioteca.AgregarLibro("L003", "El Principito", "Antoine de Saint-Exupéry", "978-84-376-0496-1");

                Console.WriteLine("✅ Datos de prueba cargados exitosamente.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error cargando datos de prueba: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Muestra el menú principal del sistema.
        /// </summary>
        private static void MostrarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("    SISTEMA DE GESTIÓN DE BIBLIOTECA    ");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("1. 👤 Gestionar Usuarios");
                Console.WriteLine("2. 📚 Gestionar Libros");
                Console.WriteLine("3. 📖 Gestionar Préstamos");
                Console.WriteLine("4. 📊 Consultas y Reportes");
                Console.WriteLine("5. 🚪 Salir");
                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        GestionarUsuarios();
                        break;
                    case "2":
                        GestionarLibros();
                        break;
                    case "3":
                        GestionarPrestamos();
                        break;
                    case "4":
                        MostrarConsultas();
                        break;
                    case "5":
                        Console.WriteLine("¡Gracias por usar el Sistema de Biblioteca!");
                        return;
                    default:
                        MostrarMensajeError("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        #region Gestión de Usuarios

        private static void GestionarUsuarios()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("         GESTIÓN DE USUARIOS           ");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("1. 📝 Registrar Usuario");
                Console.WriteLine("2. 👥 Ver Todos los Usuarios");
                Console.WriteLine("3. 🔙 Volver al Menú Principal");
                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarUsuario();
                        break;
                    case "2":
                        VerTodosUsuarios();
                        break;
                    case "3":
                        return;
                    default:
                        MostrarMensajeError("Opción no válida.");
                        break;
                }
            }
        }

        private static void RegistrarUsuario()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("         REGISTRAR NUEVO USUARIO        ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            try
            {
                Console.Write("ID del usuario: ");
                var id = Console.ReadLine();

                Console.Write("Nombre completo: ");
                var nombre = Console.ReadLine();

                _servicioBiblioteca.RegistrarUsuario(id, nombre);
                MostrarMensajeExito("Usuario registrado exitosamente.");
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
        }

        private static void VerTodosUsuarios()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("           TODOS LOS USUARIOS          ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            var usuarios = _servicioBiblioteca.ObtenerTodosUsuarios();
            if (usuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
            }
            else
            {
                foreach (var usuario in usuarios)
                {
                    var prestamosActivos = usuario.ObtenerPrestamosActivos().Count;
                    Console.WriteLine($"• {usuario} - Préstamos activos: {prestamosActivos}");
                }
            }

            PresionarTeclaParaContinuar();
        }

        #endregion

        #region Gestión de Libros

        private static void GestionarLibros()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("          GESTIÓN DE LIBROS            ");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("1. 📝 Agregar Libro");
                Console.WriteLine("2. 📚 Ver Todos los Libros");
                Console.WriteLine("3. ✅ Ver Libros Disponibles");
                Console.WriteLine("4. 🔙 Volver al Menú Principal");
                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        AgregarLibro();
                        break;
                    case "2":
                        VerTodosLibros();
                        break;
                    case "3":
                        VerLibrosDisponibles();
                        break;
                    case "4":
                        return;
                    default:
                        MostrarMensajeError("Opción no válida.");
                        break;
                }
            }
        }

        private static void AgregarLibro()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("          AGREGAR NUEVO LIBRO          ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            try
            {
                Console.Write("ID del libro: ");
                var id = Console.ReadLine();

                Console.Write("Título: ");
                var titulo = Console.ReadLine();

                Console.Write("Autor: ");
                var autor = Console.ReadLine();

                Console.Write("ISBN: ");
                var isbn = Console.ReadLine();

                _servicioBiblioteca.AgregarLibro(id, titulo, autor, isbn);
                MostrarMensajeExito("Libro agregado exitosamente.");
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
        }

        private static void VerTodosLibros()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("            TODOS LOS LIBROS           ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            var libros = _servicioBiblioteca.ObtenerTodosLibros();
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros en el catálogo.");
            }
            else
            {
                foreach (var libro in libros)
                {
                    Console.WriteLine($"• {libro.ObtenerInformacion()}");
                }
            }

            PresionarTeclaParaContinuar();
        }

        private static void VerLibrosDisponibles()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("         LIBROS DISPONIBLES            ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            var libros = _servicioBiblioteca.ObtenerLibrosDisponibles();
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros disponibles para préstamo.");
            }
            else
            {
                foreach (var libro in libros)
                {
                    Console.WriteLine($"• {libro}");
                }
            }

            PresionarTeclaParaContinuar();
        }

        #endregion

        #region Gestión de Préstamos

        private static void GestionarPrestamos()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("         GESTIÓN DE PRÉSTAMOS          ");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("1. 📖 Realizar Préstamo");
                Console.WriteLine("2. 📤 Registrar Devolución");
                Console.WriteLine("3. 📋 Ver Préstamos Activos");
                Console.WriteLine("4. ⚠️  Ver Préstamos Vencidos");
                Console.WriteLine("5. 🔙 Volver al Menú Principal");
                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        RealizarPrestamo();
                        break;
                    case "2":
                        RegistrarDevolucion();
                        break;
                    case "3":
                        VerPrestamosActivos();
                        break;
                    case "4":
                        VerPrestamosVencidos();
                        break;
                    case "5":
                        return;
                    default:
                        MostrarMensajeError("Opción no válida.");
                        break;
                }
            }
        }

        private static void RealizarPrestamo()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("           REALIZAR PRÉSTAMO           ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            try
            {
                Console.Write("ID del usuario: ");
                var usuarioId = Console.ReadLine();

                Console.Write("ID del libro: ");
                var libroId = Console.ReadLine();

                Console.Write("Días de préstamo: ");
                if (!int.TryParse(Console.ReadLine(), out int dias) || dias <= 0)
                {
                    MostrarMensajeError("Los días de préstamo deben ser un número positivo.");
                    return;
                }

                _servicioBiblioteca.RealizarPrestamo(usuarioId, libroId, dias);
                MostrarMensajeExito("Préstamo realizado exitosamente.");
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
        }

        private static void RegistrarDevolucion()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("         REGISTRAR DEVOLUCIÓN          ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            try
            {
                Console.Write("ID del préstamo: ");
                var prestamoId = Console.ReadLine();

                _servicioBiblioteca.RegistrarDevolucion(prestamoId);
                MostrarMensajeExito("Devolución registrada exitosamente.");
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex.Message);
            }
        }

        private static void VerPrestamosActivos()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("          PRÉSTAMOS ACTIVOS            ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            var prestamos = _servicioBiblioteca.ObtenerPrestamosActivos();
            if (prestamos.Count == 0)
            {
                Console.WriteLine("No hay préstamos activos.");
            }
            else
            {
                foreach (var prestamo in prestamos)
                {
                    var estado = prestamo.EstaVencido() ? "⚠️ VENCIDO" : "✅ ACTIVO";
                    Console.WriteLine($"• {prestamo} - {estado}");
                }
            }

            PresionarTeclaParaContinuar();
        }

        private static void VerPrestamosVencidos()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("         PRÉSTAMOS VENCIDOS            ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            var prestamos = _servicioBiblioteca.ObtenerPrestamosVencidos();
            if (prestamos.Count == 0)
            {
                Console.WriteLine("No hay préstamos vencidos.");
            }
            else
            {
                foreach (var prestamo in prestamos)
                {
                    var diasRetraso = prestamo.ObtenerDiasRetraso();
                    Console.WriteLine($"• {prestamo} - Retraso: {diasRetraso} días");
                }
            }

            PresionarTeclaParaContinuar();
        }

        #endregion

        #region Consultas y Reportes

        private static void MostrarConsultas()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("         CONSULTAS Y REPORTES          ");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("1. 📊 Resumen General");
                Console.WriteLine("2. 📚 Libros por Usuario");
                Console.WriteLine("3. 🔙 Volver al Menú Principal");
                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        MostrarResumenGeneral();
                        break;
                    case "2":
                        MostrarLibrosPorUsuario();
                        break;
                    case "3":
                        return;
                    default:
                        MostrarMensajeError("Opción no válida.");
                        break;
                }
            }
        }

        private static void MostrarResumenGeneral()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("            RESUMEN GENERAL            ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            var resumen = _servicioBiblioteca.ObtenerResumenGeneral();

            Console.WriteLine($"👥 Total de usuarios: {resumen.TotalUsuarios}");
            Console.WriteLine($"📚 Total de libros: {resumen.TotalLibros}");
            Console.WriteLine($"✅ Libros disponibles: {resumen.LibrosDisponibles}");
            Console.WriteLine($"📖 Préstamos activos: {resumen.PrestamosActivos}");
            Console.WriteLine($"⚠️  Préstamos vencidos: {resumen.PrestamosVencidos}");

            PresionarTeclaParaContinuar();
        }

        private static void MostrarLibrosPorUsuario()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("         LIBROS POR USUARIO            ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();

            var usuarios = _servicioBiblioteca.ObtenerTodosUsuarios();
            foreach (var usuario in usuarios)
            {
                var prestamosActivos = usuario.ObtenerPrestamosActivos();
                Console.WriteLine($"\n👤 {usuario.Nombre}:");
                
                if (prestamosActivos.Count == 0)
                {
                    Console.WriteLine("   No tiene préstamos activos.");
                }
                else
                {
                    foreach (var prestamo in prestamosActivos)
                    {
                        var estado = prestamo.EstaVencido() ? "⚠️ VENCIDO" : "✅ ACTIVO";
                        Console.WriteLine($"   • {prestamo.Libro.Titulo} - {estado}");
                    }
                }
            }

            PresionarTeclaParaContinuar();
        }

        #endregion

        #region Métodos de Utilidad

        private static void MostrarMensajeExito(string mensaje)
        {
            Console.WriteLine($"✅ {mensaje}");
            PresionarTeclaParaContinuar();
        }

        private static void MostrarMensajeError(string mensaje)
        {
            Console.WriteLine($"❌ {mensaje}");
            PresionarTeclaParaContinuar();
        }

        private static void PresionarTeclaParaContinuar()
        {
            Console.WriteLine();
            Console.Write("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        #endregion
    }
}