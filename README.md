# 🎾 GestiónClasesPadel

**GestiónClasesPadel** es una aplicación de escritorio desarrollada en **C# (WinForms)** con **Entity Framework Core** y **SQL Server** como base de datos. El sistema permite gestionar profesores, estudiantes, horarios e inscripciones para clases de pádel, facilitando la organización de la escuela y el seguimiento de pagos.

---

## 🚀 Características principales

- ✅ Gestión de **Profesores** (nombre, tipo de deporte)
- ✅ Gestión de **Estudiantes** (nombre completo, teléfono, email)
- ✅ Administración de **Horarios** (día, fecha, hora inicio/fin)
- ✅ Registro de **Inscripciones** a clases
- ✅ Seguimiento del estado de pago de las clases
- ✅ Asociación entre inscripciones, estudiantes y horarios (relaciones muchos a muchos)
- ✅ Control de disponibilidad de horarios con profesores

---

## 🛠️ Tecnologías utilizadas

- 💻 **Lenguaje:** C# (.NET 6 o superior)
- 🖼️ **Interfaz gráfica:** Windows Forms
- 🗃️ **Base de datos:** SQL Server
- 🧠 **ORM:** Entity Framework Core
- ⚙️ **IDE recomendado:** Visual Studio 2022
- 🐙 **Control de versiones:** Git + Git Bash (MINGW64)

---

## 📦 Instalación y configuración

### 1. Clonar el repositorio

```bash
https://github.com/VinceSM/ClasesApp.git
```

### 2️⃣ Crear la base de datos en SQL Server

Abrí SQL Server Management Studio (SSMS) y ejecutá el siguiente script:

```sql
-- Crear base de datos
CREATE DATABASE gestionclases;
GO

USE gestionclases;
GO

-- Tabla Profesores
CREATE TABLE Profesores (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    tipoDeporte VARCHAR(50) NOT NULL,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL
);
GO

-- Tabla Estudiantes
CREATE TABLE Estudiantes (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombreCompleto VARCHAR(200) NOT NULL,
    telefono VARCHAR(20),
    email VARCHAR(100),
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL
);
GO

-- Tabla Horarios
CREATE TABLE Horarios (
    id INT PRIMARY KEY IDENTITY(1,1),
    dia VARCHAR(10) NOT NULL,
    fecha DATE,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    id_Profesor INT NOT NULL,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL,
    FOREIGN KEY (id_Profesor) REFERENCES Profesores(id)
);
GO

-- Tabla Inscripciones
CREATE TABLE Inscripciones (
    id INT PRIMARY KEY IDENTITY(1,1),
    precioClase DECIMAL(10,2) NOT NULL,
    pagado BIT DEFAULT 0,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL
);
GO

-- Tabla puente Inscripciones_has_Horarios
CREATE TABLE Inscripciones_has_Horarios (
    idIncripcionesClases INT,
    idHorario INT,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL,
    PRIMARY KEY (idIncripcionesClases, idHorario),
    FOREIGN KEY (idIncripcionesClases) REFERENCES Inscripciones(id),
    FOREIGN KEY (idHorario) REFERENCES Horarios(id)
);
GO

-- Tabla puente Inscripciones_has_Estudiantes
CREATE TABLE Inscripciones_has_Estudiantes (
    idIncripcionesClases INT,
    idEstudiantes INT,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL,
    PRIMARY KEY (idIncripcionesClases, idEstudiantes),
    FOREIGN KEY (idIncripcionesClases) REFERENCES Inscripciones(id),
    FOREIGN KEY (idEstudiantes) REFERENCES Estudiantes(id)
);
GO
```