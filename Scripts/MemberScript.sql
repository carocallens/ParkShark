use [ParkSharkDb]
go

create schema Mem
go

create table Mem.Members(
Member_ID uniqueidentifier not null default newid(),
Member_FirstName varchar(100) not null,
Member_LastName varchar(100) not null,
Member_StreetName varchar(100) not null,
Member_StreetNumber varchar(100) not null,
City_ZIP int not null,
Member_RegistrationDate date not null
constraint Members_pk primary key (Member_ID)
)

create table Mem.Cities(
City_ZIP int not null,
City_Name varchar(100) not null,
City_CountryName varchar(100) not null
constraint Cities_pk primary key(City_ZIP)
)

create table Mem.PhoneNumbers(
Member_ID uniqueidentifier not null,
PhoneNumber varchar(100) not null
)

create table Mem.LicensePlates(
Member_ID uniqueidentifier not null,
LicensePlate varchar(100) not null,
IssueingCountry varchar(100) not null
)

alter table Mem.Members
add constraint Members_Cities_FK
foreign key (City_ZIP) references Mem.Cities(City_ZIP)

alter table Mem.PhoneNumbers
add constraint PhoneNumbers_Members_FK
foreign key (Member_ID) references Mem.Members(Member_ID)

alter table Mem.Licenseplates
add constraint Licenseplates_Members_FK
foreign key (Member_ID) references Mem.Members(Member_ID)

insert into Mem.Cities(
	City_ZIP,
	City_Name,
	City_CountryName)
	values
	(1234,'1cityName','1countryName')

insert into Mem.Members (
	Member_FirstName,
	Member_LastName,
	Member_StreetName,
	Member_StreetNumber,
	City_ZIP,
	Member_RegistrationDate)
	values
	('1firstName',
	'1lastName', 
	'1streetName', 
	'1StreetNumber',
	1234,
	CONVERT(date,'15-11-2018', 103)
	)

insert into Mem.PhoneNumbers(
	Member_ID,
	PhoneNumber)
	values
	(
	(select Member_ID
	from Mem.Members)
	, '1phonenumber')

insert into Mem.LicensePlates(
	Member_ID,
	LicensePlate,
	IssueingCountry)
	values
	((select Member_ID
	from Mem.Members),'1licensePlate','1issueingCountry')