
create table tblVehicleType
(
VehicleTypeId int primary key identity,
Name nvarchar(100),
Capacity int,
BoxSize nvarchar(100),
VehicleTypeImage nvarchar(500),
RatePerKm int,
Offer decimal(5,2),
)



