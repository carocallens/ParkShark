USE [ParkSharkDb]
go

create schema MemL
go

create table MemL.MembershipLevel(
MembershipLevel_ID  varchar(100) not null,
MembershipLevel_Name varchar (100) not null,
MembershipLevel_MonthlyCost decimal not null,
MembershipLevel_PSA_PriceReduction float not null,
MembershipLevel_PSA_MaxTime time(7) not null
constraint MembershipLevel_pk primary key (MembershipLevel_ID))


insert into MemL.MembershipLevel
(
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
