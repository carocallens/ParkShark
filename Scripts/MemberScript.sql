create schema Div
go

create table Div.Members(
Member_ID varchar(100) not null,
Member_FirstName varchar(100) not null,
Member_LastName varchar(100) not null,
Member_StreetName varchar(100) not null,
Member_StreetNumber varchar(100) not null,
City_ZIP int not null,
Member_RegistrationDate date not null
constraint Members_pk primary key (Member_ID)
)

create table Div.Cities(
City_ZIP int not null,
City_Name varchar(100) not null,
City_CountryName varchar(100) not null
constraint Cities_pk primary key(City_ZIP)
)

create table Div.PhoneNumbers(
Member_ID varchar(100) not null,
PhoneNumber varchar(100) not null
)

create table Div.LicensePlates(
Member_ID varchar(100) not null,
LicensePlate varchar(100) not null,
IssueingCountry varchar(100) not null
)

alter table Div.Members
add constraint Members_Addresses_FK
foreign key (Address_ID) references Div.Addresses(Address_ID)

alter table Div.Members
add constraint Members_Cities_FK
foreign key (City_ZIP) references Div.Cities(City_ZIP)

alter table Div.PhoneNumbers
add constraint PhoneNumbers_Members_FK
foreign key (Member_ID) references Div.Members(Member_ID)

alter table Div.Licenseplates
add constraint Licenseplates_Members_FK
foreign key (Member_ID) references Div.Members(Member_ID)

insert into div.Cities(
	City_ZIP,
	City_Name,
	City_CountryName)
	values
	(1234,'1cityName','1countryName')

insert into div.Addresses (
	Address_ID,
	Address_StreetName,
	Address_StreetNumber,
	City_ZIP)
	values
	('e5b51d36-2159-4a80-8e77-473f516804d7', '1streetName', '1StreetNumber',1234)

insert into div.Members (
	Member_ID,
	Member_FirstName,
	Member_LastName,
	Address_ID,
	Member_RegistrationDate)
	values
	('e5b51e36-2159-4a80-8e77-473f516804d7', 
	'1firstName',
	'1lastName', 
	'e5b51d36-2159-4a80-8e77-473f516804d7', 
	CONVERT(date,'15-11-2018', 103)
	)

insert into div.PhoneNumbers(
	Member_ID,
	PhoneNumber)
	values
	('e5b51e36-2159-4a80-8e77-473f516804d7', '1phonenumber')

insert into div.LicensePlates(
	Member_ID,
	LicensePlate,
	IssueingCountry)
	values
	('e5b51e36-2159-4a80-8e77-473f516804d7','1licensePlate','1issueingCountry')
