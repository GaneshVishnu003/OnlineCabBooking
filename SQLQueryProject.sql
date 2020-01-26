create proc insertIntoCustomer
@fName varchar(10),
@lName varchar(10),
@mailId varchar(25),
@phone varchar(10),
@location varchar(15)
as
begin
insert into UserDb(fName,lName,mailId,phone,location) values(@fName,@lName,@mailId,@phone,@location)
end

create table UserDb
(
id int primary key identity(201,1),
fName varchar(10),
lName varchar(10),
mailId varchar(25),
phone varchar(10),
location varchar(15));

select * from UserDb