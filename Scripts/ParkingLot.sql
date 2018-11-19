USE [ParkSharkDb]
go
create schema PL
go

create table PL.BuildingTypes
(
BuildingType_ID varchar(100) not null,
BuidlingType_Description varchar(100) not null
constraint BuildingType_pk primary key (BuildingType_ID)
)

create table PL.ContactPersons
(
	ContactPerson_ID varchar(100) not null,
	ContactPerson_FirstName varchar(100) not null,
	ContactPerson_LastName varchar(100) not null,
	ContactPerson_Email varchar(100) not null,
	ContactPerson_StreetName varchar(100) not null,
	ContactPerson_StreetNumber varchar(100) not null,
	City_ZIP int not null
	constraint ContactPersons_pk primary key (ContactPerson_ID)
	constraint ContactPersons_Cities_fk foreign key (City_ZIP) references Mem.Cities(City_ZIP)
)

create table PL.ParkingLots
(
ParkingLot_ID varchar(100) not null,
ParkingLot_Name varchar(100) not null,
Division_ID varchar(100) not null,
BuildingType_ID varchar(100) not null,
Capacity int not null,
ContactPerson_ID varchar(100) not null,
ParkingLot_StreetName varchar(100) not null,
ParkingLot_StreetNumber varchar(100) not null,
City_ZIP int not null,
ParkingLot_PricePerHour decimal not null
constraint ParkingLot_pk primary key (ParkingLot_ID)
)

alter table PL.ParkingLots
add constraint ParkingLots_Divisions_fk foreign key (Division_ID) references Div.Division(Division_ID)

alter table PL.ParkingLots
add constraint ParkingLots_BuildingType_fk foreign key (BuildingType_ID) references PL.BuildingTypes(BuildingType_ID)

alter table PL.ParkingLots
add constraint ParkingLots_ContactPersons_fk foreign key (ContactPerson_ID) references PL.ContactPersons(ContactPerson_ID)

alter table PL.ParkingLots
add constraint ParkingLots_Cities_fk foreign key (City_ZIP) references Mem.Cities(City_ZIP)