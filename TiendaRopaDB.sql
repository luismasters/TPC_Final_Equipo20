use master
drop database TiendaRopa

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
Stock int default 0 check (Stock>=0),
IdCategoria int not  null foreign key references Categoria(Id),
IdLinea int not  null foreign key references Linea(Id),
IdGenero int not  null foreign key references Genero(Id),
Talle varchar(10),
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

CREATE TABLE [dbo].[CiudadEnvio](
	[IDCiudad] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[PrecioEnvio] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DetalleVentas](
	[IDDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IDVenta] [int] NOT NULL,
	[IDPrenda] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Envios](
	[IDEnvio] [int] IDENTITY(1,1) NOT NULL,
	[IDVenta] [int] NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](30) NULL,
	[Observaciones] [varchar](300) NULL,
	[Entregado] [bit] NULL,
	[IDCiudad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEnvio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MedioPago](
	[IDPago] [tinyint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].[Ventas](
	[IDVenta] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[MedioPago] [tinyint] NOT NULL,
	[PrecioTotal] [int] NOT NULL,
	[Pagado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleVentas]  WITH CHECK ADD FOREIGN KEY([IDPrenda])
REFERENCES [dbo].[Prenda] ([Id])
GO
ALTER TABLE [dbo].[DetalleVentas]  WITH CHECK ADD FOREIGN KEY([IDVenta])
REFERENCES [dbo].[Ventas] ([IDVenta])
GO
ALTER TABLE [dbo].[Envios]  WITH CHECK ADD FOREIGN KEY([IDCiudad])
REFERENCES [dbo].[CiudadEnvio] ([IDCiudad])
GO
ALTER TABLE [dbo].[Envios]  WITH CHECK ADD FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Envios]  WITH CHECK ADD FOREIGN KEY([IDVenta])
REFERENCES [dbo].[Ventas] ([IDVenta])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([MedioPago])
REFERENCES [dbo].[MedioPago] ([IDPago])

--Modificaciones tabla ventas (6/12/2023)

ALTER TABLE Ventas MODIFY COLUMN PrecioTotal FLOAT;
alter table Ventas add IDEnvio int
alter table Envios add constraint fk_Ventas_Envios foreign key (IDEnvio) references Envios (IDEnvio)

Insert into CiudadEnvio values ('Ciudad Autonoma de Buenos Aires', 1500, 'GBA Sur', 2000, 'GBA Norte', 2000, 'GBA Oeste', 2000, 'Rosario', 3000, 'Cordoba', 3500)

Insert into MedioPago values ('Efectivo', 'Debito', 'Credito')


---

insert into Categoria (Descripcion) values ('Remeras')
insert into Categoria (Descripcion) values ('Buzos')
insert into Categoria (Descripcion) values ('Camperas')
insert into Categoria (Descripcion) values ('Pantalones')
insert into Categoria (Descripcion) values ('Todas')


insert into Genero (Descripcion) values ('Masculino')
insert into Genero (Descripcion) values ('Femenino')



insert into Linea (Descripcion) values ('Gamer')
insert into Linea (Descripcion) values ('Casual')
insert into Linea (Descripcion) values ('deportiva')
insert into Linea (Descripcion) values ('Formal')
insert into Linea (Descripcion) values ('Playa')
insert into Linea (Descripcion) values ('Todas')




select * from Imagenes

insert into Prenda(Descripcion,Precio,Stock,IdCategoria,IdGenero,IdLinea,Talle) values ('Remera Gamer Mario Bros',5000,6,1,1,1,'L')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,IdGenero,IdLinea,Talle) values ('Campera Gamer Diablo IV',65000,12,3,1,1,'XL')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,IdGenero,IdLinea,Talle) values ('Buzo Gamer Halo',42000,8,2,1,1,'M')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,IdGenero,IdLinea,Talle) values ('Remera Gamer Bros Star',5000,10,1,1,1,'S')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,IdGenero,IdLinea,Talle) values ('Pantalon Hombre Cargo',25000,10,4,1,2,'42')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,IdGenero,IdLinea,Talle)values ('Remera Gamer Xbox',7000,6,1,1,1,'M')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,IdGenero,IdLinea,Talle) values ('Pantalon Hombre Casual',35000,6,4,1,2,'44')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,IdGenero,IdLinea,Talle) values ('Remera Gamer Bros Gore',6500,8,1,1,1,'L')







insert into imagenes (IdPrenda,ImagenUrl) Values (2,'https://i.postimg.cc/j2WZnys3/Captura-de-pantalla-2023-11-03-131244.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (3,'https://i.postimg.cc/pXw18c5f/Captura-de-pantalla-2023-11-03-132030.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (4,'https://i.postimg.cc/C5WJGd5h/Captura-de-pantalla-2023-11-03-131944.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (5,'https://i.postimg.cc/L8FNhqGv/Captura-de-pantalla-2023-11-03-132344.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (6,'https://i.postimg.cc/sDhTVPHv/Captura-de-pantalla-2023-11-03-132237.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (7,'https://i.postimg.cc/y65f4pPM/Captura-de-pantalla-2023-11-03-132153.png')
insert into imagenes (IdPrenda,ImagenUrl) Values (8,'https://i.postimg.cc/2Sn9xdnP/Captura-de-pantalla-2023-11-03-131639.png')


SELECT P.Id, P.Descripcion, P.Precio, P.Stock, P.IdCategoria, C.Descripcion AS CategoriaDescripcion, P.IdGenero, G.Descripcion AS Genero, P.IdLinea, L.Descripcion AS Linea, P.Talle FROM Prenda P 
INNER JOIN Categoria C ON P.IdCategoria = C.Id 
INNER JOIN Genero G ON P.IdGenero = G.Id
INNER JOIN Linea L ON P.IdLinea = L.Id;

INSERT INTO Rol (Nombre) VALUES ('Administrador');
INSERT INTO Rol (Nombre) VALUES ('Comprador');
INSERT INTO Usuario (NombreUsuario, Pass, IdRol, Email) VALUES ('prueba', '123', 2, 'prueba@prueba.com');

select * from linea
select * from genero
select * from Categoria
select * from Usuario
select * from Rol
delete from usuario where id=6;
DECLARE @NombreUsuario NVARCHAR(100) = 'pruebaprueba',
        @Pass NVARCHAR(100) = '123123',
        @IdRol INT = 2,
        @Email NVARCHAR(100) = 'prueba@pruebaprueba.com';
INSERT INTO Usuario (NombreUsuario, Pass, IdRol, Email) VALUES (@NombreUsuario, @Pass, @IdRol, @Email)

