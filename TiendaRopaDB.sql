use master
drop database TiendaRopa

create database TiendaRopa
use TiendaRopa

create table Categoria(
Id int identity(1,1) primary key,
Descripcion Varchar(200) not null,

)

create table Prenda(
Id int  identity(1,1) not null primary key,
Descripcion Varchar(200) not null,
Precio money not null check (Precio>=0),
Stock int default 0 check (Stock>=0),
IdCategoria int not  null foreign key references Categoria(Id),
Talle varchar(10),
)



create table Imagenes(
Id int identity(1,1) primary key,
IdPrenda int Foreign key references Prenda(Id),
ImagenUrl varchar(1000) not null,
)


insert into Categoria (Descripcion) values ('Remeras')
insert into Categoria (Descripcion) values ('Buzos')
insert into Categoria (Descripcion) values ('Camperas')
insert into Categoria (Descripcion) values ('Pantalones')




select * from Imagenes

insert into Prenda(Descripcion,Precio,Stock,IdCategoria,Talle) values ('Remera Gamer Mario Bros',5000,6,1,'L')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,Talle) values ('Campera Gamer Diablo IV',65000,12,3,'XL')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,Talle) values ('Buzo Gamer Halo',42000,8,2,'M')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,Talle) values ('Remera Gamer Bros Star',5000,10,1,'S')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,Talle) values ('Pantalon Hombre Cargo',25000,10,4,'42')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,Talle) values ('Remera Gamer Xbox',7000,6,1,'M')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,Talle) values ('Pantalon Hombre Casual',35000,6,4,'44')
insert into Prenda(Descripcion,Precio,Stock,IdCategoria,Talle) values ('Remera Gamer Bros Gore',6500,8,1,'L')







insert into imagenes (IdPrenda,ImagenUrl) Values (1,'https://scontent.faep6-2.fna.fbcdn.net/v/t39.30808-6/396834483_10230756457685670_5786756224457188654_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeEJ9sgmrsm3dZ_JKqlzzxz2s3OHLDs79Rmzc4csOzv1GRysIGq2lQgHEMJW_RAEh3I&_nc_ohc=v5dOQDJ71aAAX9rMZJv&_nc_ht=scontent.faep6-2.fna&oh=00_AfAxRK1_JRKiZOkzXJgDfK7Hh0VazGQyeTXq0iTNANKi4Q&oe=654F355E')
insert into imagenes (IdPrenda,ImagenUrl) Values (2,'https://scontent.faep6-2.fna.fbcdn.net/v/t39.30808-6/396838183_10230756454965602_3571236313194356966_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeGduAZiejIT1DJgsQqssTTeRDkrSu3GxkBEOStK7cbGQA3_HWmnqIGkkyrymAoASuA&_nc_ohc=kmgctu84nRgAX9fziRs&_nc_ht=scontent.faep6-2.fna&oh=00_AfAfj5B6Anc2UeK-G2XpzE85vZlCKs_7xhBGkYK_KRF2CQ&oe=654EAF0F')
insert into imagenes (IdPrenda,ImagenUrl) Values (3,'https://scontent.faep6-1.fna.fbcdn.net/v/t39.30808-6/397918888_10230756457645669_5733846871625231050_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeFjNM8Dcz9sPWyKCvwjhFmGFyXAMDyYUAgXJcAwPJhQCM9Tewz2ZZN4fxqaU6ng5Jk&_nc_ohc=hPDjw46PLgwAX8etsFp&_nc_ht=scontent.faep6-1.fna&oh=00_AfCSmEDYv27-vNPHmE50Ej1CUiSJhHQ9N6ZDhNCfJPVQHw&oe=654F1286')
insert into imagenes (IdPrenda,ImagenUrl) Values (4,'https://scontent.faep6-1.fna.fbcdn.net/v/t39.30808-6/396729860_10230756457805673_4320190690794583364_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeFKEl3imGEICUM1R26OAryf57uzaijGdb7nu7NqKMZ1vnStjj7AbTYxw4vRXTkCvjA&_nc_ohc=br1B28ArLIEAX_5cDKk&_nc_ht=scontent.faep6-1.fna&oh=00_AfCUgv55tTz0Ku4XYciBvU5uqzn57qFB8e1s9a-ogQyXlA&oe=65505BE7')
insert into imagenes (IdPrenda,ImagenUrl) Values (5,'https://scontent.faep6-1.fna.fbcdn.net/v/t39.30808-6/396732356_10230756458645694_4411705958570618040_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeH4EdXc2V9ZUyDh-iFt5mHCzWQ0OePRerTNZDQ549F6tP4C0f3TqwgZ4wnEa-ByiOg&_nc_ohc=uIOXxGfQTzwAX_NxjHz&_nc_ht=scontent.faep6-1.fna&oh=00_AfAxwQBXJhp4l3mkUgRj74LmhAMmQxOPfemWXjSEAjTQxg&oe=654EC400')
insert into imagenes (IdPrenda,ImagenUrl) Values (6,'https://scontent.faep6-1.fna.fbcdn.net/v/t39.30808-6/396731713_10230756458685695_3881787065047617635_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeFNi0iQSy0SRnQiLiR6Z16ix_w7ZP9f7sbH_Dtk_1_uxsAnsKk4ei_NJnbDtDeXlAw&_nc_ohc=g5Dmzj4egbQAX_sR3qt&_nc_ht=scontent.faep6-1.fna&oh=00_AfCuUSDH1cAw_8JsXvLOCyLFgXvJ_agQbhfHsdmCgSj4cg&oe=654FB9C9')
insert into imagenes (IdPrenda,ImagenUrl) Values (7,'https://scontent.faep6-1.fna.fbcdn.net/v/t39.30808-6/396732205_10230756458325686_7532596896816048791_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeG3vyhuldEEu7YJ7ZhJKZyrM7vwSVZDajozu_BJVkNqOsCXjHt8SW0MNCpVc-iGZmo&_nc_ohc=fREQ5t7_XggAX9bOsug&_nc_ht=scontent.faep6-1.fna&oh=00_AfCa41NZLiR4PrTwGXLa280Z5hU1WwmSnsMJce63loN0fg&oe=654F0728')
insert into imagenes (IdPrenda,ImagenUrl) Values (8,'https://scontent.faep6-1.fna.fbcdn.net/v/t39.30808-6/397984163_10230756455805623_5038733250868377136_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeHDiVkl7nR4hn8igUSMZRgtRG4_g6OwBB1Ebj-Do7AEHSsFaX6iFUZ2I3osvjp5AHQ&_nc_ohc=XiH-CojXl-4AX_gK3Gf&_nc_ht=scontent.faep6-1.fna&oh=00_AfCXDJp-QsN3X5yGi6s6KNfIP-i45hhzuwsqmxJTckRv6A&oe=6550168E')

select Precio from Prenda
