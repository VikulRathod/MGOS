create table tblVehicleOwner
(
d_Id int primary key identity,
UserId int foreign key references tblUsers(Id),
d_Pancard nvarchar(100),
d_License nvarchar(100),
d_Location nvarchar(100),
d_IsActive bit,
d_AvgRating decimal(5,2),
d_NoOfTrips int,
VehicleId int foreign key references tblVehicle(V_Id)
)
