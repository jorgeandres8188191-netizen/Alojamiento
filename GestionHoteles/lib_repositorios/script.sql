INSERT INTO TelefonosClientes (Telefono) VALUES 
('123456789'),
('987654321'),
('555123456'),
('444987654'),
('666123789');

-- Clientes
INSERT INTO Clientes (Nombre, Email, FechaNacimiento, Documento, IdTelefonoCliente) VALUES
('Juan Perez', 'juan.perez@email.com', '1985-06-15', 123456789, 1),
('Maria Garcia', 'maria.garcia@email.com', '1990-12-05', 987654321, 2),
('Pedro Ruiz', 'pedro.ruiz@email.com', '1983-03-10', 555123789, 3),
('Laura Lopez', 'laura.lopez@email.com', '1995-09-25', 444987654, 4),
('Carlos Martinez', 'carlos.martinez@email.com', '1988-02-20', 666123456, 5);

-- TelefonosHoteles
INSERT INTO TelefonosHoteles (Telefono) VALUES 
('123450987'),
('987650432'),
('555132465'),
('444872635'),
('666154738');

-- Hoteles
INSERT INTO Hoteles (Nombre, Direccion, Calificacion, IdTelefonoHotel) VALUES
('Hotel Playa', 'Av. Costanera 123, Playa del Carmen', 5, 1),
('Hotel Montaña', 'Calle Alta 567, Pueblos de Montaña', 4, 2),
('Hotel Centro', 'Calle Principal 789, Centro Ciudad', 3, 3),
('Hotel Rio', 'Río Bravo 234, Cuenca del Río', 4, 4),
('Hotel Sol', 'Avenida Sol 456, Playa del Sol', 5, 5);

-- TelefonosAcompañantes
INSERT INTO TelefonosAcompañantes (Telefono) VALUES 
('123459876'),
('987651234'),
('555132789'),
('444876321'),
('666132456');

-- Acompañantes
INSERT INTO Acompañantes (Nombre, Email, FechaNacimiento, Documento, IdTelefonoAcompañante) VALUES
('Ana Perez', 'ana.perez@email.com', '1992-07-18', 123459876, 1),
('Luis Martinez', 'luis.martinez@email.com', '1991-04-25', 987651234, 2),
('Sofia Lopez', 'sofia.lopez@email.com', '1994-09-10', 555132789, 3),
('David Garcia', 'david.garcia@email.com', '1987-11-22', 444876321, 4),
('Paula Fernandez', 'paula.fernandez@email.com', '1989-08-30', 666132456, 5);

-- Reservas
INSERT INTO Reservas (CheckIn, CheckOut, IdCliente) VALUES
('2023-11-01', '2023-11-05', 1),
('2023-12-10', '2023-12-15', 2),
('2024-01-05', '2024-01-10', 3),
('2024-02-20', '2024-02-25', 4),
('2024-03-01', '2024-03-05', 5);

-- EstadosHabitaciones
INSERT INTO EstadosHabitaciones (Descripcion, Codigo) VALUES 
('Disponible', 'AB12'),
('Ocupada', 'ABC142'),
('Mantenimiento', 'KAS321'),
('Reservada', 'HFS324'),
('Inactiva', 'SDF423');

-- TiposHabitaciones
INSERT INTO TiposHabitaciones (Descripcion, Codigo) VALUES 
('Individual', 'IND'),
('Doble', 'DOB'),
('Suite', 'SUI'),
('Presidencial', 'PRE'),
('Triple', 'TRI');

-- Habitaciones
INSERT INTO Habitaciones (Numero, Piso, PrecioDia, IdEstadoHabitacion, IdTipoHabitacion, IdHotel, Capacidad) VALUES
(101, 1, 100.00, 1, 1, 1, 1),
(102, 1, 150.00, 2, 2, 2, 2),
(201, 2, 200.00, 3, 3, 3, 2),
(202, 2, 250.00, 4, 4, 4, 3),
(301, 3, 300.00, 5, 5, 5, 4);

-- Fases
INSERT INTO Fases (Descripcion, Codigo) VALUES 
('Inicio', 'FASE1'),
('Intermedio', 'FASE2'),
('Final', 'FASE3'),
('Pendiente', 'FASE4'),
('Cancelada', 'FASE5');

-- TiposMascotas
INSERT INTO TiposMascotas (Nombre, Raza) VALUES 
('Perro', 'Bulldog'),
('Gato', 'Siames'),
('Pajaro', 'Canario'),
('Conejo', 'Rex'),
('Tortuga', 'Galapagos');

-- Mascotas
INSERT INTO Mascotas (Nombre, FechaNacimiento, IdTipoMascota) VALUES
('Rocky', '2020-05-05', 1),
('Whiskers', '2018-03-15', 2),
('Chirpy', '2022-07-01', 3),
('Bunny', '2021-06-20', 4),
('Shelly', '2019-08-30', 5);

-- EstadosFacturas
INSERT INTO EstadosFacturas (Descripcion, Codigo) VALUES 
('Pendiente', 'EF1'),
('Pagada', 'EF2'),
('Cancelada', 'EF3'),
('Vencida', 'EF4'),
('Reembolsada', 'EF5');

-- ReservasHabitaciones
INSERT INTO ReservasHabitaciones (Fecha, Codigo, IdHabitacion, IdReserva, IdAcompañante, IdMascota, IdFase) VALUES
('2023-11-01', 1001, 1, 1, 1, 1, 1),
('2023-12-10', 1002, 2, 2, 2, 2, 2),
('2024-01-05', 1003, 3, 3, 3, 3, 3),
('2024-02-20', 1004, 4, 4, 4, 4, 4),
('2024-03-01', 1005, 5, 5, 5, 5, 5);

-- Facturas
INSERT INTO Facturas (FechaPago, Codigo, Total, SubTotal, IdEstadoFactura, IdReservaHabitacion) VALUES
('2023-11-05', 1001, 450.00, 400.00, 1, 1),
('2023-12-15', 1002, 600.00, 550.00, 2, 2),
('2024-01-10', 1003, 750.00, 700.00, 3, 3),
('2024-02-25', 1004, 900.00, 850.00, 4, 4),
('2024-03-05', 1005, 200.00, 150.00, 5, 5);