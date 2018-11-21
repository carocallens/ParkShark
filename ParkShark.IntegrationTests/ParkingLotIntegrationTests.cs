using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NSubstitute;
using ParkShark.API;
using ParkShark.API.Controllers.Members.DTO;
using ParkShark.API.Controllers.ParkingLots.DTO;
using ParkShark.Data;
using ParkShark.Services.ParkingLots;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkShark.IntegrationTests
{
    public class ParkingLotIntegrationTests
    {
        private readonly HttpClient _client;

        public ParkingLotIntegrationTests()
        {
            _client = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>())
                .CreateClient();
        }

        private ParkingLotDTO_Create CreateParkingLotDTO()
        {

            return new ParkingLotDTO_Create
            {
                Address = new AddressDTO { CityDTO = new CityDTO { CityName = "brussel", CountryName = "BE", ZIP = 1000 }, StreetName = "brusselstraat", StreetNumber = "5" },
                Capacity = 5,
                ContactPerson = new ContactPersonDTO { Address = new AddressDTO { CityDTO = new CityDTO { CityName = "brussel", CountryName = "BE", ZIP = 1000 }, StreetName = "brusselstraat", StreetNumber = "5" }, Email = "lasr@gmail.com", FirstName = "lars", LastName = "peelman", MobilePhoneNumber = "445545" },
                Name = "test",
                DivisionID = new Guid("6A996F59-5E2C-4D59-A78C-045697F570C4"),
                PricePerHour = 5.0M
            };



        }
        [Fact]
        public async Task CreateParkingLot()
        {
            ParkingLotDTO_Create divisionToCreate = CreateParkingLotDTO();

            var content = JsonConvert.SerializeObject(divisionToCreate);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/parkinglots", stringContent);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var createdParkingLot = JsonConvert.DeserializeObject<ParkingLotDTO_Return>(responseString);

            AssertParkingLotIsEqual(divisionToCreate, createdParkingLot);
            Assert.True(createdParkingLot.DivisionID != Guid.Empty);
        }

        [Fact]
        public async Task CreateParkingLot_givenParkingLotNotValidForCreationBecauseOfMissingName_thenBadRequestStatusReturned()
        {
            ParkingLotDTO_Create parkingLotToCreate = CreateParkingLotDTO();
            parkingLotToCreate.Name = string.Empty;

            var content = JsonConvert.SerializeObject(parkingLotToCreate);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/parkinglots", stringContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


        }

        [Fact]
        public async Task GetAllParkingLots()
        {
            ParkingLotDTO_Create parkingLotToCreate = CreateParkingLotDTO();

            var content = JsonConvert.SerializeObject(parkingLotToCreate);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            await _client.PostAsync("/api/parkinglots", stringContent);
            await _client.PostAsync("/api/parkinglots", stringContent);

            var response = await _client.GetAsync("/api/parkinglots");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var allParkingLots = JsonConvert.DeserializeObject<IEnumerable<ParkingLotDTO_Return>>(responseString);

            Assert.NotEmpty(allParkingLots);
        }


        private void AssertParkingLotIsEqual(ParkingLotDTO_Create parkingLotToCreate, ParkingLotDTO_Return parkingLotReturn)
        {
            Assert.Equal(parkingLotToCreate.Name, parkingLotReturn.Name);
            Assert.Equal(parkingLotToCreate.PricePerHour, parkingLotReturn.PricePerHour);
            Assert.Equal(parkingLotToCreate.ContactPerson.Email, parkingLotReturn.ContactPerson.Email);
            Assert.Equal(parkingLotToCreate.Address.CityDTO.ZIP, parkingLotReturn.Address.CityDTO.ZIP);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
