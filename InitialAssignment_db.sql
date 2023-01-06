create database InitialAssignment
go

use InitialAssignment
go

create table Books(
Id int constraint PK_BOOKS primary key identity(1,1),
Author varchar(100) not null,
Classification varchar(100) not null,
Edition int not null,
Editorial varchar(50) not null,
Title varchar(100) not null,
Price decimal(5,2) not null,
PublicationDate datetime not null
) 
go

/*Los campos Autor y Clasificación son solo demostración,
dado que deben ir en otra tabla cada uno para cumplir con la 3° forma normal*/