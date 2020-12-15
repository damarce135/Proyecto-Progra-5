/* CREAR BASE DE DATOS */
drop database evaluaProfe; --Only if needed 
create database evaluaProfe; --Paso 1
use evaluaProfe; --Paso 2



/* CREAR TABLAS */
--Crear tabla administrador 
--create table administrador ( 
--idAdministrador int identity(1,1) primary key,  
--nombre varchar(45), 
--apellido1 varchar(45), 
--apellido2 varchar(45), 
--email varchar(100), 
--telefono varchar(45), 
--contrasena varbinary, 
--habilitado bit
--);


--Crear tabla profesor 
create table profesor ( 
idProfesor int identity(1,1) primary key, 
nombre varchar(45), 
apellido1 varchar(45), 
apellido2 varchar(45) 
); 


--Crear tabla carrera 
create table carrera ( 
idCarrera int identity(1,1) primary key, 
nombreCarrera varchar(200) 
); 


--Crear tabla curso 
create table curso ( 
idCurso int identity(1,1) primary key, 
nombreCurso varchar(200), 
idCarrera int
); 


--Crear tabla calificacion
create table calificacion ( 
idCalificacion int identity(1,1) primary key, 
idProfesor int, 
idCurso int, 
idCarrera int,
facilidad tinyint, 
apoyo tinyint, 
claridad tinyint, 
estado bit, 
comentario varchar(500), 
idEtiqueta int,
recomienda bit, 
puntaje tinyint
); 


----Crear tabla cursoCarrera 
--create table cursoCarrera ( 
--idCursoCarrera int identity(1,1) primary key, 
--idCurso int, 
--idCarrera int 
--); 


----Crear tabla profCurso 
--create table profCurso ( 
--idProfCurso int identity(1,1) primary key, 
--idProfesor int, 
--idCurso int 
--); 


--Crear tabla etiquetas 
create table etiqueta ( 
idEtiqueta int identity(1,1) primary key, 
nombreEtiqueta varchar(50) 
); 


----Crear tabla calEtiquetas 
--create table calEtiqueta ( 
--idCalEtiqueta int identity(1,1) primary key, 
--idCalificacion int, 
--idEtiqueta int 
--); 



/* CREAR LLAVES FORANEAS */ 


--Relacion de calificaciones 
alter table calificacion  
add foreign key (idCurso) references curso(idCurso); 

alter table calificacion  
add foreign key (idProfesor) references profesor(idProfesor); 

alter table calificacion  
add foreign key (idCarrera) references carrera(idCarrera);  

alter table calificacion  
add foreign key (idEtiqueta) references etiqueta(idEtiqueta); 

--Relacion de cursos 
alter table curso  
add foreign key (idCarrera) references carrera(idCarrera); 


----Relacion cursos con carreras 
--alter table cursoCarrera 
--add foreign key (idCurso) references curso(idCurso); 

--alter table cursoCarrera 
--add foreign key (idCarrera) references carrera(idCarrera); 


----Relacion profesor con cursos 
--alter table profCurso  
--add foreign key (idProfesor) references profesor(idProfesor); 

--alter table profCurso   
--add foreign key (idCurso) references curso(idCurso); 


----Relacion calificacion con etiquetas 
--alter table calEtiqueta 
--add foreign key (idCalificacion) references calificacion(idCalificacion); 

--alter table calEtiqueta   
--add foreign key (idEtiqueta) references etiqueta(idEtiqueta); 