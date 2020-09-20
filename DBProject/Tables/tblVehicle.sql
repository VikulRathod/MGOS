create table tblVehicle
(
V_Id int primary key identity,
V_Number nvarchar(100),
V_Insurance nvarchar(100),
V_Rc nvarchar(100),
V_Permit nvarchar(100),
V_Image nvarchar(500),
VehicleTypeId int foreign key references tblVehicleType(Vt_Id)
)
