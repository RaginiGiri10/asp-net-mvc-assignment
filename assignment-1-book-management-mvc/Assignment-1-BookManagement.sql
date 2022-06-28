--create database Book DB
create database BookDB
go
use BookDB
--create table Book
create table Book(
Id int not null primary key identity(100,1),
Title varchar(50),
Author varchar(50),
Rating int,
Price int)
--insert records into table Book
insert into Book values('Sky is Blue','Carol',3,160),('Umbrella','Revan',4,200),('The roadside','Michael',2,100)
go
select * from Book
