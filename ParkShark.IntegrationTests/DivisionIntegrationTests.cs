using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using ParkShark.API;
using ParkShark.API.Controllers.Divisions.DTO;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkShark.IntegrationTests
{
    public class DivisionIntegrationTests : IDisposable
    {
        private readonly HttpClient _client;

        public DivisionIntegrationTests()
        {
            _client = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>())
                .CreateClient();
        }

        private DivisionDTO_Create CreateDivisionDTO()
        {
            return new DivisionDTO_Create
            {
                Director = "lars",
                Name = "BestDivision",
                OriginalName = "BetterDivision"
            };



        }
        [Fact]
        public async Task CreateDivision ()
        {
            DivisionDTO_Create divisionToCreate = CreateDivisionDTO();

            var content = JsonConvert.SerializeObject(divisionToCreate);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/divisions", stringContent);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var createdDivision = JsonConvert.DeserializeObject<DivisionDTO_Return>(responseString);

            AssertDivisionIsEqual(divisionToCreate, createdDivision);
            Assert.True(createdDivision.DivisionID == Guid.Empty);
        }

        private void AssertDivisionIsEqual(DivisionDTO_Create divisionToCreate, DivisionDTO_Return createdDivision)
        {
            Assert.Equal(divisionToCreate.Director, createdDivision.Director);
            Assert.Equal(divisionToCreate.Name, createdDivision.Name);
            Assert.Equal(divisionToCreate.OriginalName, createdDivision.OriginalName);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
