
/*
MembersTable creation
CitiesTable Creation
PhoneNumbersTable Creation
LicensePlatesTable Creation
MembershipLevelTable Creation
*/
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
	Member_RegistrationDate date not null,
	Member_MembershipLevel_ID int not null
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

create table Mem.MembershipLevel(
	MembershipLevel_ID  int not null,
	MembershipLevel_Name varchar (100) not null,
	MembershipLevel_Description varchar (100) not null,
	MembershipLevel_MonthlyCost decimal not null,
	MembershipLevel_PSA_PriceReduction float not null,
	MembershipLevel_PSA_MaxTime time(7) not null
	constraint MembershipLevel_pk primary key (MembershipLevel_ID)
)



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
