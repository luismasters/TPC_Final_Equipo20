create database TiendaRopa
use TiendaRopa

create table Categoria(
Id int identity(1,1) primary key,
Descripcion Varchar(200) not null unique,
)

create table Genero(
Id int identity(1,1) primary key,
Descripcion Varchar(200) not null unique,
)

create table Linea(
Id int identity(1,1) primary key,
Descripcion Varchar(200) not null unique,
)

create table Prenda(
Id int  identity(1,1) not null primary key,
Descripcion Varchar(200) not null,
Precio money not null check (Precio>=0),
IdCategoria int not  null foreign key references Categoria(Id),
IdLinea int not  null foreign key references Linea(Id),
IdGenero int not  null foreign key references Genero(Id),
)

create table Imagenes(
Id int identity(1,1) primary key,
IdPrenda int Foreign key references Prenda(Id),
ImagenUrl varchar(1000) not null,
)

CREATE TABLE Rol (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Pass VARCHAR(50) NOT NULL,
    IdRol INT NOT NULL FOREIGN KEY REFERENCES Rol(Id),
    Email VARCHAR(255) NOT NULL 
);

CREATE TABLE Stock (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdPrenda INT NOT NULL FOREIGN KEY REFERENCES Prenda(Id),
    Cantidad INT NOT NULL CHECK (Cantidad >= 0),
    Talle VARCHAR(10) NOT NULL,
    Lote VARCHAR(50) NOT NULL,
)

CREATE TABLE CiudadEnvio(
	IDCiudad int IDENTITY(1,1) PRIMARY KEY,
	Descripcion varchar(100) NOT NULL,
	PrecioEnvio int NOT NULL,
)

CREATE TABLE MedioPago(
	IDPago tinyint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Descripcion varchar(50) NOT NULL
)

CREATE TABLE Ventas(
	IDVenta int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IDUsuario int NOT NULL FOREIGN KEY REFERENCES Usuario (Id),
	IDEnvio int not null,
	MedioPago tinyint NOT NULL,
	PrecioTotal float NOT NULL,
	Pagado bit NULL,
	Descripcion varchar (1000)
)

CREATE TABLE Envios(
	IDEnvio int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IDVenta int NOT NULL FOREIGN KEY REFERENCES Ventas (IdVenta),
	IDUsuario int NOT NULL FOREIGN KEY REFERENCES Usuario (Id),
	Direccion varchar(200) NOT NULL,
	Telefono varchar(30) NULL,
	Observaciones varchar(300) NULL,
	Entregado bit NULL,
	IDCiudad int NOT NULL FOREIGN KEY REFERENCES CiudadEnvio (IdCiudad),
)

CREATE TABLE DetalleVentas(
	IDDetalle int IDENTITY(1,1) PRIMARY KEY,
	IDVenta int NOT NULL FOREIGN KEY REFERENCES Ventas (IdVenta),
	IDPrenda int NOT NULL FOREIGN KEY REFERENCES Prenda (Id),
	Cantidad int NOT NULL,
	PrecioUnitario money NOT NULL,
)

Insert into CiudadEnvio (Descripcion, PrecioEnvio) values ('Ciudad Autonoma de Buenos Aires', 1500)
Insert into CiudadEnvio (Descripcion, PrecioEnvio) values ('GBA Sur', 2000)
Insert into CiudadEnvio (Descripcion, PrecioEnvio) values ('GBA Norte', 2000)
Insert into CiudadEnvio (Descripcion, PrecioEnvio) values ('GBA Oeste', 2000)
Insert into CiudadEnvio (Descripcion, PrecioEnvio) values ('Rosario', 3000)
Insert into CiudadEnvio (Descripcion, PrecioEnvio) values ('Cordoba', 3500)

Insert into MedioPago values ('Efectivo')
Insert into MedioPago values ('Debito')
Insert into MedioPago values ('Credito')

insert into Categoria (Descripcion) values ('Remeras')
insert into Categoria (Descripcion) values ('Buzos')
insert into Categoria (Descripcion) values ('Camperas')
insert into Categoria (Descripcion) values ('Pantalones')
insert into Categoria (Descripcion) values ('Todas')

insert into Genero (Descripcion) values ('Masculino')
insert into Genero (Descripcion) values ('Femenino')

insert into Linea (Descripcion) values ('Gamer')
insert into Linea (Descripcion) values ('Casual')
insert into Linea (Descripcion) values ('Deportiva')
insert into Linea (Descripcion) values ('Formal')
insert into Linea (Descripcion) values ('Playa')
insert into Linea (Descripcion) values ('Todas')

insert into Prenda(Descripcion,Precio,IdCategoria,IdGenero,IdLinea) values ('Remera Gamer Mario Bros',5000,1,1,1)
insert into Prenda(Descripcion,Precio,IdCategoria,IdGenero,IdLinea) values ('Campera Gamer Diablo IV',65000,3,1,1)
insert into Prenda(Descripcion,Precio,IdCategoria,IdGenero,IdLinea) values ('Buzo Gamer Halo',42000,2,1,1)
insert into Prenda(Descripcion,Precio,IdCategoria,IdGenero,IdLinea) values ('Remera Gamer Bros Star',5000,1,1,1)
insert into Prenda(Descripcion,Precio,IdCategoria,IdGenero,IdLinea) values ('Pantalon Hombre Cargo',25000,4,1,2)
insert into Prenda(Descripcion,Precio,IdCategoria,IdGenero,IdLinea) values ('Remera Gamer Xbox',7000,1,1,1)
insert into Prenda(Descripcion,Precio,IdCategoria,IdGenero,IdLinea) values ('Pantalon Hombre Casual',35000,4,1,2)
insert into Prenda(Descripcion,Precio,IdCategoria,IdGenero,IdLinea) values ('Remera Gamer Bros Gore',6500,1,1,1)


insert into imagenes (IdPrenda,ImagenUrl) Values (2,'https://i.postimg.cc/j2WZnys3/Captura-de-pantalla-2023-11-03-131244.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (3,'https://i.postimg.cc/pXw18c5f/Captura-de-pantalla-2023-11-03-132030.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (4,'https://i.postimg.cc/C5WJGd5h/Captura-de-pantalla-2023-11-03-131944.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (5,'https://i.postimg.cc/L8FNhqGv/Captura-de-pantalla-2023-11-03-132344.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (6,'https://i.postimg.cc/sDhTVPHv/Captura-de-pantalla-2023-11-03-132237.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (7,'https://i.postimg.cc/y65f4pPM/Captura-de-pantalla-2023-11-03-132153.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (8,'https://i.postimg.cc/2Sn9xdnP/Captura-de-pantalla-2023-11-03-131639.png')

INSERT INTO Rol (Nombre) VALUES ('Administrador');
INSERT INTO Rol (Nombre) VALUES ('Usuario');
INSERT INTO Usuario (NombreUsuario, Pass, IdRol, Email) VALUES ('User', 'user', 1, 'user@prueba.com');
INSERT INTO Usuario (NombreUsuario, Pass, IdRol, Email) VALUES ('Admin', 'admin', 2, 'admin@prueba.com');

INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (1, 10, 'S', 'A')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (1, 10, 'M', 'A')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (1, 10, 'L', 'A')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (1, 10, 'XL', 'A')

INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (2, 10, 'S', 'B')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (2, 10, 'M', 'B')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (2, 10, 'L', 'B')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (2, 10, 'XL', 'B')

INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (3, 10, 'S', 'C')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (3, 10, 'M', 'C')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (3, 10, 'L', 'C')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (3, 10, 'XL', 'C')

INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (4, 10, 'S', 'D')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (4, 10, 'M', 'D')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (4, 10, 'L', 'D')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (4, 10, 'XL', 'D')

INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (5, 10, 'S', 'E')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (5, 10, 'M', 'E')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (5, 10, 'L', 'E')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (5, 10, 'XL', 'E')

INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (6, 10, 'S', 'F')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (6, 10, 'M', 'F')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (6, 10, 'L', 'F')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (6, 10, 'XL', 'F')

INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (7, 10, 'S', 'G')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (7, 10, 'M', 'G')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (7, 10, 'L', 'G')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (7, 10, 'XL', 'G')

INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (8, 10, 'S', 'H')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (8, 10, 'M', 'H')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (8, 10, 'L', 'H')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (8, 10, 'XL', 'H')

INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (9, 10, 'S', 'I')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (9, 10, 'M', 'I')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (9, 10, 'L', 'I')
INSERT INTO Stock (IdPrenda, Cantidad, Talle, Lote) values (9, 10, 'XL', 'I')
