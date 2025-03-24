
-- Crear la base de datos
CREATE DATABASE TecnicosUH;
USE TecnicosUH;
GO

-- Crear las tablas
CREATE TABLE usuarios (
    UsuarioID INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Correo VARCHAR(50) NOT NULL,
    Telefono VARCHAR(12) NULL,
    Clave VARCHAR(255) NOT NULL DEFAULT '12345'
);

CREATE TABLE Tecnicos (
    TecnicoID INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Especialidad VARCHAR(50) NOT NULL,
    Telefono VARCHAR(12) NULL
);

CREATE TABLE Equipos (
    EquiposID INT IDENTITY PRIMARY KEY,
    TipoEquipo VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50) NULL,
    UsuarioID INT FOREIGN KEY REFERENCES usuarios(UsuarioID)
);

CREATE TABLE Reparaciones (
    ReparacionID INT IDENTITY PRIMARY KEY,
    Estado VARCHAR(12) NOT NULL,
    Fecha DATETIME,
    EquipoID INT FOREIGN KEY REFERENCES Equipos(EquiposID)
);

CREATE TABLE Asignaciones (
    AsignacionID INT IDENTITY PRIMARY KEY,
    ReparacionID INT FOREIGN KEY REFERENCES Reparaciones(ReparacionID),
    TecnicoID INT FOREIGN KEY REFERENCES Tecnicos(TecnicoID),
    Fecha DATETIME
);

CREATE TABLE DetalleReparacion (
    DetalleID INT IDENTITY PRIMARY KEY,
    ReparacionID INT FOREIGN KEY REFERENCES Reparaciones(ReparacionID),
    Descripcion VARCHAR(100),
    FechaInicio DATETIME,
    FechaFin DATETIME
);

-- Insertar datos iniciales
INSERT INTO usuarios (Nombre, Correo, Telefono) VALUES ('Juan Perez', 'Juan@email.com', '123456789');

-- Modificar usuario
UPDATE usuarios SET Nombre = 'Juan P. Perez' WHERE UsuarioID = 1;

-- Insertar equipos
INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES ('Laptop', 'HP', 1);

-- Procedimientos almacenados

-- Insertar usuario
CREATE PROCEDURE sp_InsertarUsuario
    @Nombre VARCHAR(50),
    @Correo VARCHAR(50),
    @Telefono VARCHAR(12),
    @Clave VARCHAR(255)
AS
BEGIN
    -- Verificar si el correo ya está registrado
    IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Correo = @Correo)
    BEGIN
        INSERT INTO Usuarios (Nombre, Correo, Telefono, Clave)
        VALUES (@Nombre, @Correo, @Telefono, @Clave);
    END
    ELSE
    BEGIN
        PRINT 'El correo ya está registrado';
    END
END;

-- Consultar usuarios
CREATE PROCEDURE sp_ConsultarUsuarios
AS
BEGIN
    SELECT * FROM usuarios;
END;

-- Obtener técnicos
CREATE PROCEDURE sp_ObtenerTecnicos
AS
BEGIN
    SELECT * FROM Tecnicos;
END;

-- Insertar equipo
CREATE PROCEDURE sp_InsertarEquipo
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID)
    VALUES (@TipoEquipo, @Modelo, @UsuarioID);
END;

-- Modificar técnico
CREATE PROCEDURE sp_ModificarTecnico
    @ID INT,
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50),
    @Telefono VARCHAR(12)
AS
BEGIN
    -- Verificar si el ID existe antes de modificar
    IF EXISTS (SELECT 1 FROM Tecnicos WHERE TecnicoID = @ID)
    BEGIN
        UPDATE Tecnicos
        SET Nombre = @Nombre,
            Especialidad = @Especialidad,
            Telefono = @Telefono
        WHERE TecnicoID = @ID;
    END
    ELSE
    BEGIN
        PRINT 'El técnico con este ID no existe.';
    END
END;

-- Eliminar técnico
CREATE PROCEDURE sp_EliminarTecnico
    @ID INT
AS
BEGIN
    -- Verificar si el ID existe antes de eliminar
    IF EXISTS (SELECT 1 FROM Tecnicos WHERE TecnicoID = @ID)
    BEGIN
        DELETE FROM Tecnicos WHERE TecnicoID = @ID;
    END
    ELSE
    BEGIN
        PRINT 'El técnico con este ID no existe.';
    END
END;

-- Verificar usuario para el login
CREATE PROCEDURE sp_VerificarUsuario
    @Correo VARCHAR(50),
    @Clave VARCHAR(255)
AS
BEGIN
    SELECT COUNT(*) 
    FROM Usuarios 
    WHERE Correo = @Correo AND Clave = @Clave;
END;

-- Comandos de prueba
EXEC sp_ConsultarUsuarios;
EXEC sp_ObtenerTecnicos;
EXEC sp_ModificarTecnico 1, 'Carlos Ramírez', 'Computación', '123456789';
EXEC sp_InsertarTecnico 'Juan Pérez', 'Electricidad', '123456789';
EXEC sp_VerificarUsuario 'admin@email.com', '12345';

-- Mostrar la tabla de usuarios
SELECT * FROM Usuarios;
SELECT * FROM Usuarios WHERE Correo = 'admin@email.com';

-- Actualizar clave de usuario
UPDATE Usuarios 
SET Clave = '12347' 
WHERE Correo = 'admin@email.com';

-- Mostrar clave formateada
SELECT '[' + Clave + ']' FROM Usuarios WHERE Correo = 'admin@email.com';

-- Revisar estructura de la tabla usuarios
EXEC sp_help Usuarios;

-- Verificar usuarios con claves vacías
SELECT * FROM Usuarios WHERE Clave IS NULL OR Clave = '';

-- Insertar usuario administrador
INSERT INTO Usuarios (Nombre, Correo, Telefono, Clave) 
VALUES ('Admin', 'admin@email.com', '123456789', '12345');

-- Alterar procedimiento de verificación de usuario con encriptación de clave
ALTER PROCEDURE sp_VerificarUsuario
    @Correo VARCHAR(50),
    @Clave VARCHAR(255)
AS
BEGIN
    SELECT COUNT(*) 
    FROM Usuarios 
    WHERE Correo = @Correo AND Clave = CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', @Clave));
END;

-- Ver el código del procedimiento almacenado
EXEC sp_helptext 'sp_VerificarUsuario';



------procedimientos 

CREATE PROCEDURE sp_InsertarEquipo
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID)
    VALUES (@TipoEquipo, @Modelo, @UsuarioID);
END;
GO

-- 📌 2. Modificar un equipo
CREATE PROCEDURE sp_ModificarEquipo
    @EquiposID INT,
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    UPDATE Equipos
    SET TipoEquipo = @TipoEquipo,
        Modelo = @Modelo,
        UsuarioID = @UsuarioID
    WHERE EquiposID = @EquiposID;
END;
GO

-- 📌 3. Eliminar un equipo
CREATE PROCEDURE sp_EliminarEquipo
    @EquiposID INT
AS
BEGIN
    DELETE FROM Equipos WHERE EquiposID = @EquiposID;
END;
GO

-- 📌 4. Consultar todos los equipos
CREATE PROCEDURE sp_ObtenerEquipos
AS
BEGIN
    SELECT 
        E.EquiposID, 
        E.TipoEquipo, 
        E.Modelo, 
        U.Nombre AS Usuario
    FROM Equipos E
    INNER JOIN Usuarios U ON E.UsuarioID = U.UsuarioID;
END;
GO

EXEC sp_InsertarEquipo 'Laptop', 'Dell XPS', 1;

EXEC sp_ModificarEquipo 1, 'PC de Escritorio', 'HP Elite', 2;

EXEC sp_EliminarEquipo 3;

EXEC sp_ObtenerEquipos;

EXEC sp_InsertarEquipo 'PC', 'HP', 16;

SELECT * FROM Usuarios WHERE UsuarioID = 16;

EXEC sp_helptext 'sp_InsertarEquipo';


EXEC sp_InsertarEquipo 'PC', 'HP', 16;

INSERT INTO Usuarios (Nombre, Correo, Telefono) VALUES ('Nuevo Usuario', 'nuevo@email.com', '123456789');


SELECT * FROM Equipos;
SELECT * FROM Usuarios WHERE UsuarioID = 16;


INSERT INTO Usuarios (Nombre, Correo, Telefono, Clave)
VALUES ('Juan Pérez', 'juan@email.com', '123456789', '12345');

INSERT INTO Usuarios (Nombre, Correo, Telefono, Clave)
VALUES ('Maria Lopez', 'maria@email.com', '987654321', 'abc123');

SELECT * FROM Usuarios;

EXEC sp_InsertarEquipo 'PC', 'HP', 1;


---- intento de arreglo de agregar equipos 

ALTER PROCEDURE sp_InsertarEquipo
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE UsuarioID = @UsuarioID)
    BEGIN
        INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID)
        VALUES (@TipoEquipo, @Modelo, @UsuarioID);
    END
    ELSE
    BEGIN
        -- THROW es más moderno que RAISERROR
        THROW 50001, 'El UsuarioID no existe.', 1;
    END
END;


SELECT * FROM usuarios;

USE TecnicosUH;
SELECT DB_NAME() AS BaseEnUso;

SELECT * FROM Usuarios;

SELECT * 
FROM Equipos E
JOIN Usuarios U ON E.UsuarioID = U.UsuarioID;

ALTER PROCEDURE sp_ObtenerEquipos
AS
BEGIN
    SELECT 
        E.EquiposID, 
        ISNULL(E.TipoEquipo, 'Sin equipo') AS TipoEquipo,
        ISNULL(E.Modelo, 'Sin equipo') AS Modelo,
        U.Nombre AS Usuario
    FROM Usuarios U
    LEFT JOIN Equipos E ON U.UsuarioID = E.UsuarioID;
END;

ALTER PROCEDURE sp_ObtenerEquipos
AS
BEGIN
    SELECT 
        ISNULL(E.EquiposID, 0) AS EquiposID, 
        ISNULL(E.TipoEquipo, 'Sin equipo') AS TipoEquipo,
        ISNULL(E.Modelo, 'Sin equipo') AS Modelo,
        U.Nombre AS Usuario
    FROM Usuarios U
    LEFT JOIN Equipos E ON U.UsuarioID = E.UsuarioID;
END;


INSERT INTO Usuarios (Nombre, Correo, Telefono, Clave)
VALUES ('Joshua F', 'joshua@email.com', '123456789', '12345');


SELECT * FROM Usuarios WHERE Nombre LIKE '%lol%';



ALTER PROCEDURE sp_ObtenerEquipos
AS
BEGIN
    SELECT 
        E.EquiposID, 
        E.TipoEquipo, 
        E.Modelo, 
        U.Nombre AS Usuario
    FROM Equipos E
    INNER JOIN Usuarios U ON E.UsuarioID = U.UsuarioID
END;

SELECT U.UsuarioID, U.Nombre, U.Correo, U.Telefono
FROM Usuarios U
LEFT JOIN Equipos E ON U.UsuarioID = E.UsuarioID
WHERE E.UsuarioID IS NULL



---- reparaciones insertar

CREATE PROCEDURE sp_InsertarReparacion
    @EquipoID INT,
    @Fecha DATETIME,
    @Estado VARCHAR(12)
AS
BEGIN
    INSERT INTO Reparaciones (EquipoID, Fecha, Estado)
    VALUES (@EquipoID, @Fecha, @Estado);
END;
GO

CREATE PROCEDURE sp_ModificarReparacion
    @ReparacionID INT,
    @EquipoID INT,
    @Fecha DATETIME,
    @Estado VARCHAR(12)
AS
BEGIN
    UPDATE Reparaciones
    SET EquipoID = @EquipoID,
        Fecha = @Fecha,
        Estado = @Estado
    WHERE ReparacionID = @ReparacionID;
END;
GO


CREATE PROCEDURE sp_EliminarReparacion
    @ReparacionID INT
AS
BEGIN
    DELETE FROM Reparaciones WHERE ReparacionID = @ReparacionID;
END;
GO


CREATE PROCEDURE sp_ObtenerReparaciones
AS
BEGIN
    SELECT 
        R.ReparacionID,
        R.Estado,
        R.Fecha,
        E.EquiposID,
        E.TipoEquipo,
        E.Modelo,
        U.Nombre AS Usuario
    FROM Reparaciones R
    INNER JOIN Equipos E ON R.EquipoID = E.EquiposID
    INNER JOIN Usuarios U ON E.UsuarioID = U.UsuarioID;
END;
GO


ALTER PROCEDURE sp_ObtenerReparaciones
AS
BEGIN
    SELECT 
        R.ReparacionID,
        R.Estado,
        R.Fecha,
        E.EquiposID AS EquipoID,
        E.TipoEquipo,
        E.Modelo,
        U.Nombre AS Usuario
    FROM Reparaciones R
    INNER JOIN Equipos E ON R.EquipoID = E.EquiposID
    INNER JOIN Usuarios U ON E.UsuarioID = U.UsuarioID;
END;
GO


CREATE PROCEDURE sp_CrearYAsignarReparacion
    @EquipoID INT,
    @TecnicoID INT
AS
BEGIN
    DECLARE @ReparacionID INT;

    INSERT INTO Reparaciones (EquipoID, Fecha, Estado)
    VALUES (@EquipoID, GETDATE(), 'Pendiente');

    SET @ReparacionID = SCOPE_IDENTITY();

    INSERT INTO Asignaciones (ReparacionID, TecnicoID, Fecha)
    VALUES (@ReparacionID, @TecnicoID, GETDATE());
END;
GO


CREATE PROCEDURE sp_ObtenerReparacionesConTecnico
AS
BEGIN
    SELECT 
        R.ReparacionID,
        R.Estado,
        R.Fecha,
        E.Modelo AS Equipo,
        T.Nombre AS Tecnico
    FROM Reparaciones R
    INNER JOIN Equipos E ON R.EquipoID = E.EquiposID
    INNER JOIN Asignaciones A ON R.ReparacionID = A.ReparacionID
    INNER JOIN Tecnicos T ON A.TecnicoID = T.TecnicoID;
END;
GO
