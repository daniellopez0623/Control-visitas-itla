create database db_Control_VisitasItla
go

use db_Control_VisitasItla
go

drop table tbl_visitantes
-------------------------------------------TABLES
create table tbl_visitantes(
id int identity(1,1) primary key not null,
codigo_visitas as ('VS'+right('00'+CONVERT(varchar,id),(2))),
nombre varchar(50) not null,
apellido varchar(50) not null,
edificio varchar(50) not null,
aula varchar(50) not null,
telefono nvarchar(20) not null,
tipo_visita nvarchar(20) not null,
hora_entrada datetime not null,
hora_salida datetime not null,
carrera varchar(50) null,
correo nvarchar(50) unique null,
matricula varchar(10) unique null,
motivo_visita nvarchar(max) null,
foto image null
) 
go

drop table tbl_usuarios

select * from tbl_usuarios

create table tbl_usuarios(
id int identity(1,1) primary key not null,
codigo_usuarios as ('US'+right('00'+CONVERT(varchar,id),(2))),
_user nvarchar(100) not null,
_pass nvarchar(100) not null,
Nombre nvarchar(100) not null,
Apellido nvarchar(100) not null,
Cargo varchar(50) not null,
Fecha datetime not null,
)

 insert into tbl_usuarios values ('jlucas', 'j12345','JOSE', 'LUCAS', 'Administrador', '2020-11-08')

----------------------------------------------PROCEDURES
create or alter procedure sp_guardar_visitantes
@nombre varchar(50),
@apellido varchar(50),
@edificio varchar(50),
@aula varchar(50),
@telefono nvarchar(20),
@tipo_visita nvarchar(20),
@hora_entrada datetime,
@hora_salida datetime,
@carrera varchar(50) null,
@correo nvarchar(50) null,
@matricula varchar(10) null,
@motivo_visita nvarchar(max),
@foto image null
as
insert into tbl_visitantes ( nombre, apellido, edificio, aula, telefono, tipo_visita, hora_entrada, hora_salida, carrera, correo, matricula, motivo_visita, foto) 
                   values  (@nombre,@apellido,@edificio,@aula,@telefono,@tipo_visita,@hora_entrada,@hora_salida,@carrera,@correo,@matricula,@motivo_visita,@foto)
go

select * from tbl_visitantes

create or alter procedure sp_editar_visitantes
@id int,
@nombre varchar(50),
@apellido varchar(50),
@edificio varchar(50),
@aula varchar(50),
@telefono nvarchar(20),
@tipo_visita nvarchar(20),
@hora_entrada datetime,
@hora_salida datetime,
@carrera varchar(50),
@correo nvarchar(50),
@matricula varchar(10),
@motivo_visita nvarchar(max),
@foto image null
as
update tbl_visitantes set  nombre = @nombre, 
                           apellido = @apellido, 
						   edificio = @edificio, 
						   aula = @aula, 
						   telefono = @telefono,
						   tipo_visita = @tipo_visita, 
						   hora_entrada = @hora_entrada,
						   hora_salida = @hora_salida, 
						   carrera = @carrera, 
						   correo = @correo, 
						   motivo_visita = @motivo_visita, 
						   foto = @foto
            where id = @id or matricula = @matricula
go

create or alter proc sp_buscar_visitantes
@id int,
@nombre  varchar(50)
as
select * from tbl_visitantes
         where id = @id and
		       nombre like  @nombre + '%' 		  
go

exec sp_buscar_visitante 3,'j'

create or alter proc sp_borrar_visitantes
@id int
as
delete from tbl_visitantes
         where id = @id
go
------------------------------------------------------------------------------------------------------------------------------------

create or alter procedure sp_guardar_usuarios
@_user nvarchar(100),
@_pass nvarchar(100),
@nombre varchar(50),
@apellido varchar(50),
@cargo varchar(50),
@fecha datetime
as
insert into tbl_usuarios ( _user, _pass, nombre, apellido, cargo, fecha)
                  values (@_user,@_pass,@nombre,@apellido,@cargo,@fecha)
go

select * from tbl_usuarios

create or alter procedure sp_editar_usuarios
@id int,
@_user nvarchar(100),
@_pass nvarchar(100),
@nombre varchar(50),
@apellido varchar(50),
@cargo varchar(50),
@fecha datetime
as
update tbl_usuarios set  _user = @_user,
                         _pass = @_pass, 
						 nombre = @nombre, 
						 apellido = @apellido, 
						 cargo = @cargo, 
						 fecha = @fecha
				  where  id = @id
go

create or alter proc sp_buscar_usuarios
@id int,
@_user nvarchar(100)
as
select * from tbl_usuarios
         where id = @id and
		       _user like  @_user + '%' 		  
go

create or alter proc sp_borrar_usuarios
@id int
as
delete from tbl_usuarios
         where id = @id
go

create or alter proc SP_Loging
@_user nvarchar(100),
@_pass nvarchar(100)
as
select * from tbl_usuarios 
where _user = @_user and 
      _pass = @_pass
go


--------------------------------------------VIEW
create or alter view vw_visitante
as
select v.codigo_visitas 'Codigo Visitas', 
       v.nombre 'Nombre',
	   v.apellido 'Apellido',
	   v.edificio 'Edificio',
	   v.aula 'Aula',
	   v.telefono 'Telefono',
	   v.tipo_visita 'Tipo de visita',
	   v.hora_entrada 'Hora entrada',
	   v.hora_salida 'Hora salida',
	   v.carrera 'Carrera',
	   v.correo 'Correo',
	   v.matricula 'Matricula',
	   v.motivo_visita 'Motivo de visita',
	   v.foto 'Imagen' 
from tbl_visitantes v
go

create or alter view vw_usuarios
as
select u.codigo_usuarios 'Codigo usuario',
       u.Nombre,
	   u.Apellido,
	   u._user 'Usuario',
	   u._pass 'Contraceña',
	   u.Cargo 'Cargo',
	   u.Fecha 'Fecha'
from tbl_usuarios u
go

select * from tbl_visitantes