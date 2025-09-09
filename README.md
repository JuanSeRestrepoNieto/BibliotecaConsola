# Sistema de Gestión de Biblioteca

## Descripción
Sistema de consola desarrollado en C# que demuestra la aplicación de los 4 pilares de la Programación Orientada a Objetos (POO) a través de un caso de uso real: la gestión de una biblioteca.

## Características
- ✅ **Abstracción**: Clase abstracta `ItemBiblioteca` e interfaz `IPrestable`
- ✅ **Herencia**: `Libro` hereda de `ItemBiblioteca`, `Prestamo` hereda de `Transaccion`
- ✅ **Polimorfismo**: Métodos virtuales y sobrescritura de métodos
- ✅ **Encapsulamiento**: Atributos privados con acceso controlado
- ✅ **Arquitectura Limpia**: Separación en capas (Dominio, Servicio, Infraestructura)
- ✅ **Patrón Repository**: Abstracción del acceso a datos
- ✅ **Inyección de Dependencias**: Servicios desacoplados y testeable

## Funcionalidades
- 👤 Gestión de usuarios
- 📚 Gestión de libros
- 📖 Gestión de préstamos y devoluciones
- 📊 Consultas y reportes
- ⚠️ Control de préstamos vencidos

## Requisitos
- .NET 8.0 o superior
- Visual Studio 2022 o Visual Studio Code

## Instalación y Ejecución

### Opción 1: Visual Studio
1. Abrir el archivo `Biblioteca.sln` en Visual Studio
2. Presionar F5 para ejecutar

### Opción 2: Línea de comandos
```bash
# Compilar
dotnet build

# Ejecutar
dotnet run
```

## Estructura del Proyecto
```
Biblioteca/
├── Dominio/                   # 🏗️ Capa de Dominio (4 pilares de POO)
│   ├── ItemBiblioteca.cs      # Clase abstracta (ABSTRACCIÓN)
│   ├── IPrestable.cs          # Interfaz (ABSTRACCIÓN)
│   ├── Libro.cs               # Implementa herencia y polimorfismo
│   ├── Usuario.cs             # Demuestra encapsulamiento
│   ├── Transaccion.cs         # Clase base (HERENCIA)
│   └── Prestamo.cs            # Hereda de Transaccion (HERENCIA)
├── Servicio/                  # 🧠 Capa de Servicios (Lógica de negocio)
│   ├── ServicioUsuario.cs     # Servicio para gestión de usuarios
│   ├── ServicioLibro.cs       # Servicio para gestión de libros
│   ├── ServicioPrestamo.cs    # Servicio para gestión de préstamos
│   └── ServicioBiblioteca.cs  # Servicio principal coordinador
├── Infraestructura/           # 💾 Capa de Infraestructura (Almacenamiento)
│   ├── IRepositorioUsuario.cs # Interfaz repositorio usuarios
│   ├── IRepositorioLibro.cs   # Interfaz repositorio libros
│   ├── IRepositorioPrestamo.cs# Interfaz repositorio préstamos
│   ├── RepositorioUsuario.cs  # Implementación repositorio usuarios
│   ├── RepositorioLibro.cs    # Implementación repositorio libros
│   └── RepositorioPrestamo.cs # Implementación repositorio préstamos
├── Program.cs                 # 🖥️ Interfaz de consola
├── Biblioteca.csproj          # 📦 Archivo de proyecto
├── Biblioteca.sln             # 🔧 Archivo de solución
└── README.md                  # 📖 Este archivo
```

## Uso del Sistema

### Menú Principal
1. **Gestionar Usuarios**: Registrar y consultar usuarios
2. **Gestionar Libros**: Agregar libros al catálogo
3. **Gestionar Préstamos**: Realizar préstamos y devoluciones
4. **Consultas y Reportes**: Ver resúmenes y estadísticas

### Datos de Prueba
El sistema incluye datos de prueba que se cargan automáticamente:
- 3 usuarios de ejemplo
- 3 libros de ejemplo

## Demostración de POO

### 1. Abstracción
- `ItemBiblioteca`: Define estructura común sin implementación
- `IPrestable`: Establece contrato para elementos prestables

### 2. Herencia
- `Libro : ItemBiblioteca, IPrestable`
- `Prestamo : Transaccion`

### 3. Polimorfismo
- Método `ObtenerInformacion()` implementado diferente en cada clase
- Método `EsValida()` sobrescrito en `Prestamo`

### 4. Encapsulamiento
- Atributos privados con propiedades de solo lectura
- Validaciones en constructores y métodos
- Control de acceso a datos internos

## Casos de Prueba
El sistema incluye validaciones para:
- IDs únicos para usuarios y libros
- ISBN únicos para libros
- Disponibilidad de libros antes de préstamo
- Validación de fechas y períodos de préstamo

## Autor
Sistema desarrollado como ejercicio académico para demostrar los principios de POO en un caso de uso práctico.