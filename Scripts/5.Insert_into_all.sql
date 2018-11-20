USE [ParkSharkDb]
go

insert into Div.Division
	(
		Division_Name,
		Division_OrgName,
		Division_Director 
	)
	values
	(
		'SomeSpace',
		'Enerco',
		'Francis Collossis'
	),
	(
		'SpcaeTokenzz',
		'TokenWars',
		'Abegieen Merceris'
	),
	(
		'MainSpace',
		'Graindor-Coffie',
		'Luc Van Carglass'
	);
	
insert into Mem.MembershipLevel
	(
		MembershipLevel_ID ,
		MembershipLevel_Description,
		MembershipLevel_Name ,
		MembershipLevel_MonthlyCost ,
		MembershipLevel_PSA_PriceReduction, 
		MembershipLevel_PSA_MaxTime
	)
	values
	(
		0,
		'bronze level subscription',
		'Bronze',
		0,
		0,
		cast('4:00' as time)
	),
	(
		1,
		'Silver level subscription',
		'Silver',
		10,
		20,
		cast('6:00' as time)
	),
	(
		2,
		'Gold level subscription',
		'Gold',
		40,
		30,
		cast('23:59:59.999' as time)
	)

insert into Mem.Cities
	(
		City_ZIP,
		City_Name,
		City_CountryName
	)
	values
	(
		5540,
		'Lier',
		'Belgie'
	),
	(
		3340,
		'Hasselt',
		'Belgie'
	),
	(
		3000,
		'Leuven',
		'Belgie'
	),
	(
		1210,
		'Lubbeek',
		'Belgie'
	),
	(
		3370,
		'Boutersem',
		'Belgie'
	),
	(
		6500,
		'Hoegaarden',
		'Belgie'
	)

insert into Mem.Members 
	(
		Member_FirstName,
		Member_LastName,
		Member_StreetName,
		Member_StreetNumber,
		City_ZIP,
		Member_RegistrationDate,
		Member_MembershipLevel_ID
	)
	values
	(
		'Filip',
		'Derese', 
		'Nieuwstraat', 
		'15C',
		5540,
		CONVERT(date,'1-11-2018', 103),
		0
	),
	(
		'Dominique',
		'VanLier', 
		'Apenstraat', 
		'13',
		3340,
		CONVERT(date,'11-11-2018', 103),
		0
	),
	(
		'Filip',
		'Zwartkop', 
		'koppeleikenstraat', 
		'335',
		3000,
		CONVERT(date,'14-11-2018', 103),
		0
	),
	(
		'Gwen',
		'Verbruggen', 
		'Oudenbolweg', 
		'55',
		1210,
		CONVERT(date,'15-11-2018', 103),
		0
	),
	(
		'Evert',
		'Everen', 
		'Blijdeinkomstraat', 
		'65A',
		3000,
		CONVERT(date,'15-11-2018', 103),
		0
	)

insert into Mem.PhoneNumbers
	(
		Member_ID,
		PhoneNumber
	)
	values
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'Derese' ),
		 '018532624'
	),
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'VanLier' ),
		 '018333333'
	),
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'Zwartkop' ),
		 '015326598'
	),
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'Verbruggen' ),
		 '016707070'
	),
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'Verbruggen' ),
		 '0474138562'
	),
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'Everen' ),
		 '013313131'
	)

insert into Mem.LicensePlates
	(
		Member_ID,
		LicensePlate,
		IssueingCountry
	)
	values
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'Derese' ),
		 '1-uwr-156',
		 'Belgium'
	),
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'VanLier' ),
		  '1-abc-222',
		 'Belgium'
	),
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'Zwartkop' ),
		 '1-qsr-453',
		 'Belgium'
	),
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'Zwartkop' ),
		 '1-lll-444',
		 'Belgium'
	),
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'Verbruggen' ),
		 'abs156za1s',
		 'France'
	),
	(
		(select Member_ID
		from Mem.Members
		where Member_LastName like 'Everen' ),
		  '1-aaa-001',
		 'Belgium'
	)


insert into PL.ParkingLots
	(
      ParkingLot_Name,
		Division_ID,
      BuildingType,
      ParkingLot_Capacity,
      ParkingLot_StreetName,
      ParkingLot_StreetNumber,
      ContactPerson_FirstName,
      ContactPerson_LastName,
      ContactPerson_Email,
      ContactPerson_StreetName,
      ContactPerson_StreetNumber,
      ContactPerson_City_ZIP,
      ContactPerson_PhoneNumber,
      ContactPerson_MobileNumber,
      ParkingLot_City_ZIP,
      ParkingLot_PricePerHour
	)
	values
	(
		'ParkingZone_LotsOfSpace',
		(select Division_ID
		from Div.Division
		where Division_Name like 'SomeSpace'),
		'Bigtype',
		300,
		'Oudestraat',
		'33',
		'Franky',
		'Boeghe',
		'FB@mail.com',
		'NatteLouStraat',
		'21',
		3000,
		'016785632',
		'0464853215',
		6500,
		2.9	
	),
	(
		'ParkingZone_LotsOfSpace',
		(select Division_ID
		from Div.Division
		where Division_Name like 'SomeSpace'),
		'SmallType',
		72,
		'Smalwegske',
		'11',
		'Franky',
		'Boeghe',
		'FB@mail.com',
		'NatteLouStraat',
		'21',
		3000,
		'016785632',
		'0464853215',
		6500,
		2.9	
	),
	(
		'ParkingZone_LotsOfSpace',
		(select Division_ID
		from Div.Division
		where Division_Name like 'SpcaeTokenzz'),
		'Bigtype',
		600,
		'Oudestraat',
		'33',
		'Patrick',
		'Deille',
		'PartickD@mail.com',
		'PistachStaat',
		'16C',
		3370,
		null,
		'0464853215',
		3000,
		3.1	
	)
	