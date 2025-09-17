CREATE DATABASE GestionHoteles;
GO
USE GestionHoteles;
GO

-- =====================
-- Tablas base
-- =====================

CREATE TABLE TelefonosClientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Telefono NVARCHAR(50) NOT NULL
);

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    FechaNacimiento DATETIME NOT NULL,
    Documento INT NOT NULL,
    IdTelefonoCliente INT NOT NULL,
    CONSTRAINT FK_Clientes_TelefonosClientes FOREIGN KEY (IdTelefonoCliente)
        REFERENCES TelefonosClientes(Id)
);

CREATE TABLE TelefonosHoteles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Telefono NVARCHAR(50) NOT NULL
);

CREATE TABLE Hoteles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(150) NOT NULL,
    Calificacion INT NOT NULL,
    IdTelefonoHotel INT NOT NULL,
    CONSTRAINT FK_Hoteles_TelefonosHoteles FOREIGN KEY (IdTelefonoHotel)
        REFERENCES TelefonosHoteles(Id)
);

CREATE TABLE TelefonosAcompañantes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Telefono NVARCHAR(50) NOT NULL
);

CREATE TABLE Acompañantes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    FechaNacimiento DATETIME NOT NULL,
    Documento INT NOT NULL,
    IdTelefonoAcompañante INT NOT NULL,
    CONSTRAINT FK_Acompañantes_TelefonosAcompañantes FOREIGN KEY (IdTelefonoAcompañante)
        REFERENCES TelefonosAcompañantes(Id)
);

-- =====================
-- Reservas y Facturación
-- =====================

CREATE TABLE Reservas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CheckIn DATETIME NOT NULL,
    CheckOut DATETIME NOT NULL,
    IdCliente INT NOT NULL,
    CONSTRAINT FK_Reservas_Clientes FOREIGN KEY (IdCliente)
        REFERENCES Clientes(Id)
);

CREATE TABLE EstadosHabitaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);

CREATE TABLE TiposHabitaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);

CREATE TABLE Habitaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Numero INT NOT NULL,
    Piso INT NOT NULL,
    PrecioDia DECIMAL(10,2) NOT NULL,
    IdEstadoHabitacion INT NOT NULL,
    IdTipoHabitacion INT NOT NULL,
    IdHotel INT NOT NULL,
    Capacidad INT, 
    CONSTRAINT FK_Habitaciones_Hoteles FOREIGN KEY (IdHotel)
        REFERENCES Hoteles(Id), 
    CONSTRAINT FK_Habitaciones_EstadosHabitaciones FOREIGN KEY (IdEstadoHabitacion)
        REFERENCES EstadosHabitaciones(Id),
    CONSTRAINT FK_Habitaciones_TiposHabitaciones FOREIGN KEY (IdTipoHabitacion)
        REFERENCES TiposHabitaciones(Id)
);

CREATE TABLE Fases (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);

CREATE TABLE TiposMascotas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Raza NVARCHAR(100) NOT NULL
);

CREATE TABLE Mascotas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    FechaNacimiento DATETIME NOT NULL,
    IdTipoMascota INT NOT NULL,
    CONSTRAINT FK_Mascotas_TiposMascotas FOREIGN KEY (IdTipoMascota)
        REFERENCES TiposMascotas(Id)
);

CREATE TABLE ReservasHabitaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL,
    Codigo INT NOT NULL,
    IdHabitacion INT NOT NULL,
    IdReserva INT NOT NULL,
    IdAcompañante INT NOT NULL,
    IdMascota INT NOT NULL,
    IdFase INT NOT NULL,
    CONSTRAINT FK_ReservasHabitaciones_Habitaciones FOREIGN KEY (IdHabitacion)
        REFERENCES Habitaciones(Id),
    CONSTRAINT FK_ReservasHabitaciones_Reservas FOREIGN KEY (IdReserva)
        REFERENCES Reservas(Id),
    CONSTRAINT FK_ReservasHabitaciones_Acompañantes FOREIGN KEY (IdAcompañante)
        REFERENCES Acompañantes(Id),
    CONSTRAINT FK_ReservasHabitaciones_Mascotas FOREIGN KEY (IdMascota)
        REFERENCES Mascotas(Id),
    CONSTRAINT FK_ReservasHabitaciones_Fases FOREIGN KEY (IdFase)
        REFERENCES Fases(Id)
);

CREATE TABLE EstadosFacturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);

CREATE TABLE Facturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaPago DATETIME NOT NULL,
    Codigo INT NOT NULL,
    Total DECIMAL(12,2) NOT NULL,
    SubTotal DECIMAL(12,2) NOT NULL,
    IdEstadoFactura INT NOT NULL,
    IdReservaHabitacion INT NOT NULL,
    CONSTRAINT FK_Facturas_EstadosFacturas FOREIGN KEY (IdEstadoFactura)
        REFERENCES EstadosFacturas(Id),
    CONSTRAINT FK_Facturas_ReservasHabitaciones FOREIGN KEY (IdReservaHabitacion)
        REFERENCES ReservasHabitaciones(Id)
);

-- =====================
-- Inserción de datos
-- =====================

-- Insertar TelefonosClientes
INSERT INTO TelefonosClientes (Telefono) VALUES 
('123456789'),
('987654321'),
('555123456'),
('444987654'),
('666123789');

-- Insertar Clientes
INSERT INTO Clientes (Nombre, Email, FechaNacimiento, Documento, IdTelefonoCliente) VALUES
('Juan Perez', 'juan.perez@email.com', '1985-06-15', 123456789, 1),
('Maria Garcia', 'maria.garcia@email.com', '1990-12-05', 987654321, 2),
('Pedro Ruiz', 'pedro.ruiz@email.com', '1983-03-10', 555123789, 3),
('Laura Lopez', 'laura.lopez@email.com', '1995-09-25', 444987654, 4),
('Carlos Martinez', 'carlos.martinez@email.com', '1988-02-20', 666123456, 5);

-- Insertar TelefonosHoteles
INSERT INTO TelefonosHoteles (Telefono) VALUES 
('123450987'),
('987650432'),
('555132465'),
('444872635'),
('666154738');

-- Insertar Hoteles
INSERT INTO Hoteles (Nombre, Direccion, Calificacion, IdTelefonoHotel) VALUES
('Hotel Playa', 'Av. Costanera 123, Playa del Carmen', 5, 1),
('Hotel Montaña', 'Calle Alta 567, Pueblos de Montaña', 4, 2),
('Hotel Centro', 'Calle Principal 789, Centro Ciudad', 3, 3),
('Hotel Rio', 'Río Bravo 234, Cuenca del Río', 4, 4),
('Hotel Sol', 'Avenida Sol 456, Playa del Sol', 5, 5);

-- Insertar TelefonosAcompañantes
INSERT INTO TelefonosAcompañantes (Telefono) VALUES 
('123459876'),
('987651234'),
('555132789'),
('444876321'),
('666132456');

-- Insertar Acompañantes
INSERT INTO Acompañantes (Nombre, Email, FechaNacimiento, Documento, IdTelefonoAcompañante) VALUES
('Ana Perez', 'ana.perez@email.com', '1992-07-18', 123459876, 1),
('Luis Martinez', 'luis.martinez@email.com', '1991-04-25', 987651234, 2),
('Sofia Lopez', 'sofia.lopez@email.com', '1994-09-10', 555132789, 3),
('David Garcia', 'david.garcia@email.com', '1987-11-22', 444876321, 4),
('Paula Fernandez', 'paula.fernandez@email.com', '1989-08-30', 666132456, 5);

-- Insertar Reservas
INSERT INTO Reservas (CheckIn, CheckOut, IdCliente) VALUES
('2023-11-01', '2023-11-05', 1),
('2023-12-10', '2023-12-15', 2),
('2024-01-05', '2024-01-10', 3),
('2024-02-20', '2024-02-25', 4),
('2024-03-01', '2024-03-05', 5);

-- Insertar EstadosHabitaciones
INSERT INTO EstadosHabitaciones (Descripcion) VALUES 
('Disponible'),
('Ocupada'),
('Mantenimiento'),
('Reservada'),
('Inactiva');

-- Insertar TiposHabitaciones
INSERT INTO TiposHabitaciones (Descripcion) VALUES 
('Individual'),
('Doble'),
('Suite'),
('Presidencial'),
('Triple');

-- Insertar Habitaciones
INSERT INTO Habitaciones (Numero, Piso, PrecioDia, IdEstadoHabitacion, IdTipoHabitacion, IdHotel, Capacidad) VALUES
(101, 1, 100.00, 1, 1, 1, 1),
(102, 1, 150.00, 2, 2, 2, 2),
(201, 2, 200.00, 3, 3, 3, 2),
(202, 2, 250.00, 4, 4, 4, 3),
(301, 3, 300.00, 5, 5, 5, 4);

-- Insertar Fases
INSERT INTO Fases (Descripcion) VALUES 
('Inicio'),
('Intermedio'),
('Final'),
('Pendiente'),
('Cancelada');

-- Insertar TiposMascotas
INSERT INTO TiposMascotas (Nombre, Raza) VALUES 
('Perro', 'Bulldog'),
('Gato', 'Siames'),
('Pajaro', 'Canario'),
('Conejo', 'Rex'),
('Tortuga', 'Galapagos');

-- Insertar Mascotas
INSERT INTO Mascotas (Nombre, FechaNacimiento, IdTipoMascota) VALUES
('Rocky', '2020-05-05', 1),
('Whiskers', '2018-03-15', 2),
('Chirpy', '2022-07-01', 3),
('Bunny', '2021-06-20', 4),
('Shelly', '2019-08-30', 5);

INSERT INTO EstadosFacturas (Descripcion) VALUES 
('Pendiente'),
('Pagada'),
('Cancelada'),
('Vencida'),
('Reembolsada');

INSERT INTO ReservasHabitaciones (Fecha, Codigo, IdHabitacion, IdReserva, IdAcompañante, IdMascota, IdFase) VALUES
('2023-11-01', 1001, 1, 1, 1, 1, 1),
('2023-12-10', 1002, 2, 2, 2, 2, 2),
('2024-01-05', 1003, 3, 3, 3, 3, 3),
('2024-02-20', 1004, 4, 4, 4, 4, 4),
('2024-03-01', 1005, 5, 5, 5, 5, 5);

-- Insertar Facturas
INSERT INTO Facturas (FechaPago, Codigo, Total, SubTotal, IdEstadoFactura, IdReservaHabitacion) VALUES
('2023-11-05', 1001, 450.00, 400.00, 1, 1),
('2023-12-15', 1002, 600.00, 550.00, 2, 2),
('2024-01-10', 1003, 750.00, 700.00, 3, 3),
('2024-02-25', 1004, 900.00, 850.00, 4, 4),
('2024-03-05', 1005, 200.00, 150.00, 5, 5);