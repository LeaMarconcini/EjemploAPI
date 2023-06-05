create database carsdb;
use carsdb;
create table cars (
id int not null auto_increment,
make varchar(255),
model varchar(255),
color varchar(255),
years int,
doors int,
primary key(id),
unique (id)
);

insert into cars (make,model,color,years,doors) values ('A','B','C',5,4);

select * from cars;