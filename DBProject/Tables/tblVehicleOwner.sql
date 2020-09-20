create table tblVehicleOwner
(
DriverId int primary key identity,
UserId int foreign key references tblUsers(Id),
Pancard nvarchar(100),
License nvarchar(100),
Location nvarchar(100),
IsActive bit,
AvgRating decimal(5,2),
NoOfTrips int,
VehicleId int foreign key references tblVehicle(VehicleId)
)
