use[ParkSharkDb]
go
create schema PL
go


create table PL.ParkingLots
(
ParkingLot_ID uniqueidentifier not null default newid(),
ParkingLot_Name varchar(100) not null,
Division_ID uniqueidentifier not null,
BuildingType varchar(50) check (BuildingType in('AboveGround', 'UnderGround')) not null,
ParkingLot_Capacity int not null,
ParkingLot_StreetName varchar(100) not null,
ParkingLot_StreetNumber varchar(100) not null,
ContactPerson_FirstName varchar(100) not null,
ContactPerson_LastName varchar(100) not null,
ContactPerson_Email varchar(100) not null,
ContactPerson_StreetName varchar(100) not null,
ContactPerson_StreetNumber varchar(100) not null,
ContactPerson_City_ZIP int not null,
ContactPerson_PhoneNumber varchar (50),
ContactPerson_MobileNumber varchar (50),
ParkingLot_City_ZIP int not null,
ParkingLot_PricePerHour decimal not null
constraint ParkingLots_pk primary key (ParkingLot_ID)
)
alter table PL.ParkingLots
add constraint PhoneNumber_Only_One check ((ContactPerson_PhoneNumber is null and ContactPerson_MobileNumber is not null) or (ContactPerson_PhoneNumber is not null and ContactPerson_MobileNumber is null) or (ContactPerson_PhoneNumber is not null and ContactPerson_MobileNumber is not null))

alter table PL.ParkingLots
add constraint ParkingLots_Divisions_fk foreign key (Division_ID) references Div.Division(Division_ID)

alter table PL.ParkingLots
add constraint ParkingLots_Cities_fk foreign key (ParkingLot_City_ZIP) references Mem.Cities(City_ZIP)

alter table PL.ParkingLots
add constraint ContactPerson_Cities_fk foreign key (ContactPerson_City_ZIP) references Mem.Cities(City_ZIP)