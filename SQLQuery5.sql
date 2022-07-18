create table Leave(
Id int primary key identity,
StudentId nvarchar(450),
Lstatus nvarchar(50) DEFAULT 'Pending',
LDescription nvarchar(450),
foreign key (StudentId) references AspNetUsers(Id)


)