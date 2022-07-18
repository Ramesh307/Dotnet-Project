create table Bills
(Id int primary key Identity,
Billstatus nvarchar(500),
BillDate date,
StudentId nvarchar(450),
Amount nvarchar(450),
foreign key (StudentId) references AspNetUsers(Id),
)