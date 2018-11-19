use [ParkSharkDb]
go
/*
drop schema Mem
*/
create schema Mem
go

/*
drop table Mem.Members
*/
create table Mem.Members(
Member_ID uniqueidentifier not null default newid(),
Member_FirstName varchar(100) not null,
Member_LastName varchar(100) not null,
Member_StreetName varchar(100) not null,
Member_StreetNumber varchar(100) not null,
City_ZIP int not null,
Member_RegistrationDate date not null,
Member_MembershipLevel_ID  varchar(100) not null
constraint Members_pk primary key (Member_ID)
)
/*
drop table Mem.Cities
*/
create table Mem.Cities(
City_ZIP int not null,
City_Name varchar(100) not null,
City_CountryName varchar(100) not null
constraint Cities_pk primary key(City_ZIP)
)
/*
drop table Mem.PhoneNumbers
*/
create table Mem.PhoneNumbers(
Member_ID uniqueidentifier not null,
PhoneNumber varchar(100) not null
)
/*
drop table Mem.LicensePlates
*/
create table Mem.LicensePlates(
Member_ID uniqueidentifier not null,
LicensePlate varchar(100) not null,
IssueingCountry varchar(100) not null
)
/*
drop table Mem.MembershipLevel
*/
create table Mem.MembershipLevel(
MembershipLevel_ID  varchar(100) not null,
MembershipLevel_Name varchar (100) not null,
MembershipLevel_MonthlyCost decimal not null,
MembershipLevel_PSA_PriceReduction float not null,
MembershipLevel_PSA_MaxTime time(7) not null
constraint MembershipLevel_pk primary key (MembershipLevel_ID))

alter table Mem.Members
add constraint Members_MembershipLevel_FK
foreign key (Member_MembershipLevel_ID) references Mem.MembershipLevel(MembershipLevel_ID)

alter table Mem.Members
add constraint Members_Cities_FK
foreign key (City_ZIP) references Mem.Cities(City_ZIP)

alter table Mem.PhoneNumbers
add constraint PhoneNumbers_Members_FK
foreign key (Member_ID) references Mem.Members(Member_ID)

alter table Mem.Licenseplates
add constraint Licenseplates_Members_FK
foreign key (Member_ID) references Mem.Members(Member_ID)

insert into Mem.MembershipLevel(
	MembershipLevel_ID ,
	MembershipLevel_Name ,
	MembershipLevel_MonthlyCost ,
	MembershipLevel_PSA_PriceReduction, 
	MembershipLevel_PSA_MaxTime
	)
	values
	(
	'Bronze',
	'Bronze',
	0,
	0,
	cast('4:00' as time)
	),
	(
	'Silver',
	'Silver',
	10,
	20,
	cast('6:00' as time)
	),
	(
	'Gold',
	'Gold',
	40,
	30,
	cast('23:59:59.999' as time)
	)

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
	Member_RegistrationDate,
	Member_MembershipLevel_ID)
	values
	('1firstName',
	'1lastName', 
	'1streetName', 
	'1StreetNumber',
	1234,
	CONVERT(date,'15-11-2018', 103),
	'Bronze'
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

