create database Peliculas;
go
use Peliculas;
go

create table Movies(
 CategoriaId int identity(1,1) primary key,
 Descripcion varchar(30) 
);

insert into Movies(Descripcion) values('La vida es bella');

 insert into Movies(Descripcion) values('# metors sobre el cielo');
