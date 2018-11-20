using NSubstitute;
using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.Members.Mappers;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.API.Controllers.ParkingLots.DTO;
using ParkShark.API.Controllers.ParkingLots.Mappers;
using ParkShark.API.Controllers.ParkingLots.Mappers.Interfaces;
using ParkShark.Domain.Members;
using ParkShark.Domain.ParkingLots;
using System;
using System.Collections.Generic;
using Xunit;

namespace ParkShark.API.Tests.ParkingLotApiUnitTests
{
    public class ParkingLotApiUnitTests
    {
        
        [Fact]
        public void GivenCreateParkingLotFromParkingLotDTO_WhenGivenParkinglotToCreate_ThenCreateParkingLot()
        {
            var stubpark = Substitute.For<IParkingLotMapper>();
            ParkingLotMapper parkmap = new ParkingLotMapper(new AddressMapper(new CityMapper()), new ContactPersonMapper( new AddressMapper(new CityMapper())));
            var cityDTO = new CityDTO { ZIP = 2050, CityName = "Antwerpen", CountryName = "Belgium" };

            var addres = new AddressDTO { StreetName = "teststreet", StreetNumber = "58", CityDTO = cityDTO };
            var contactPerson = new ContactPersonDTO { FirstName = "lars", Address = addres, Email = "lars@lasr.com", LastName = "peelman", MobilePhoneNumber = "55555", PhoneNumber = "55555" };

            var parkinglotDTO = new ParkingLotDTO_Create { Address = addres, Buildingtype = BuildingType.AboveGround.ToString(), Capacity = 5, ContactPerson = contactPerson, DivisionID = new Guid(), Name = "lasr", PricePerHour = 5.00M };
            var result = parkmap.FromParkingLotCreateToParkingLot(parkinglotDTO);

            Assert.IsType<ParkingLot>(result);
        }

        [Fact]
        public void GivenCreateParkingLotDTOReturnFromParkingLot_WhenGivenParkinglotDTOReturnToCreate_ThenCreateParkingLotDTOReturn()
        {
            var stubpark = Substitute.For<IParkingLotMapper>();
            var stubAddress = Substitute.For<IAddressMapper>();
            AddressMapper addressmap = new AddressMapper(new CityMapper());
            ParkingLotMapper parkmap = new ParkingLotMapper(new AddressMapper(new CityMapper()), new ContactPersonMapper(new AddressMapper(new CityMapper())));

            var city = City.CreateCity(2050, "Antwerpen", "Belgium");
            var contactPerson = ContactPerson.CreateNewContactPerson("lasr", "peelman", Address.CreateAddress("test", "5", city), "lasr@lars.com", "5454548564", "5456456456");

            var parkinglot = ParkingLotBuilder.CreateNewParkingLot()
                .WithBuildingType(BuildingType.AboveGround)
                .WithCapacity(5)
                .WithContactPerson(contactPerson)
                .WithDivision(new Guid())
                .WithName("lasr")
                .WithPricePerHour(5.00M)
                .WithAddress(Address.CreateAddress("test", "5", city))
                .Build();

            var result = parkmap.FromParkingLotToParkingLotDTOReturn(parkinglot);

            Assert.IsType<ParkingLotDTO_Return>(result);
        }

        [Fact]
        public void GivenCreateListOfParkingLotDTOReturnsFromParkingLotList_WhenGivenListOfParkingLosts_ThenReturnListOfParkingLotDTOToReturn()
        {
            var stubpark = Substitute.For<IParkingLotMapper>();
            var stubAddress = Substitute.For<IAddressMapper>();
            AddressMapper addressmap = new AddressMapper(new CityMapper());
            ParkingLotMapper parkmap = new ParkingLotMapper(new AddressMapper(new CityMapper()), new ContactPersonMapper(new AddressMapper(new CityMapper())));
            var city = City.CreateCity(2050, "Antwerpen", "Belgium");

            var contactPerson = ContactPerson.CreateNewContactPerson("lasr", "peelman", Address.CreateAddress("test", "5", city), "lasr@lars.com", "5454548564", "5456456456");

            var parkinglot = ParkingLotBuilder.CreateNewParkingLot()
                .WithBuildingType(BuildingType.AboveGround)
                .WithCapacity(5)
                .WithContactPerson(contactPerson)
                .WithDivision(new Guid())
                .WithName("lasr")
                .WithPricePerHour(5.00M)
                .WithAddress(Address.CreateAddress("test", "5", city))
                .Build();

            var parkinglot2 = ParkingLotBuilder.CreateNewParkingLot()
                .WithBuildingType(BuildingType.AboveGround)
                .WithCapacity(5)
                .WithContactPerson(contactPerson)
                .WithDivision(new Guid())
                .WithName("lasr")
                .WithPricePerHour(5.00M)
                .WithAddress(Address.CreateAddress("test", "5", city))
                .Build();

            List<ParkingLot> newList = new List<ParkingLot>();
            newList.Add(parkinglot);
            newList.Add(parkinglot2);

            var result = parkmap.CreateListOfParkingLotDTOReturnsFromParkingLotList(newList);

            Assert.IsType<List<ParkingLotDTO_Return>>(result);
        }

        [Fact]
        public void GivenFromContactPersonTOContactPersonDTO_WhenGivenContactPerson_ThenCreateContactPersonDTO()
        {
            var stubMapper = Substitute.For<IContactPersonMapper>();
            ContactPersonMapper cmapper = new ContactPersonMapper(new AddressMapper(new CityMapper()));
            var city = City.CreateCity(2050, "Antwerpen", "Belgium");

            var contactPerson = ContactPerson.CreateNewContactPerson("lasr", "peelman", Address.CreateAddress("test", "5", city), "lasr@lars.com", "5454548564", "5456456456");

            var result = cmapper.FromContactPersonTOContactPersonDTO(contactPerson);

            Assert.IsType<ContactPersonDTO>(result);
        }

        [Fact]
        public void GivenFromContactPersonDTOTOContactPerson_WhenGivenContactPersonDTO_ThenCreateContactPerson()
        {
            var stubMapper = Substitute.For<IContactPersonMapper>();
            ContactPersonMapper cmapper = new ContactPersonMapper(new AddressMapper(new CityMapper()));
            var cityDTO = new CityDTO { ZIP = 2050, CityName = "Antwerpen", CountryName = "Belgium" };

            var addres = new AddressDTO { StreetName = "teststreet", StreetNumber = "58", CityDTO = cityDTO };
            var contactPerson = new ContactPersonDTO { FirstName = "lars", Address = addres, Email = "lars@lasr.com", LastName = "peelman", MobilePhoneNumber = "55555", PhoneNumber = "55555" };

            var result = cmapper.FromContactPersonDTOTOContactPerson(contactPerson);

            Assert.IsType<ContactPerson>(result);
        }
    }
}
