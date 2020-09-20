create table tblVehicle
(
VehicleId int primary key identity,
VehicleNumber nvarchar(100),
Insurance nvarchar(100),
Rc nvarchar(100),
Permit nvarchar(100),
VehicleImage nvarchar(500),
VehicleTypeId int foreign key references tblVehicleType(VehicleTypeId)
)
