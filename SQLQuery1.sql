create table Appointment
(Id int primary key Identity,
Details nvarchar(500),
Schedule date,
GuardianId nvarchar(450),
DepartmentId int ,
foreign key (DepartmentId) references Department(Id),
foreign key (GuardianId) references AspNetUsers(Id)

)