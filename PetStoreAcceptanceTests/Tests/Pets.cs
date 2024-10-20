using NUnit.Framework;
using FluentAssertions;
using RestSharp;
using System.Threading.Tasks;
using PetStoreAcceptanceTests.Models;
using RestSharp.Authenticators.OAuth2;

namespace PetStoreAcceptanceTests.Tests
{
    [TestFixture]
    public class Pets : ApiTestBase
    {
        public static readonly string PetEndPoint = "pet";
        [Test]
        public async Task PetPost_ShouldReturnSuccessAndCreatePet()
        {
            // Arrange
            CreateClient();
            var pet = new Pet()
            {
                Name = "Doggie",
                Status = PetStatus.Available
            };

            //Act
            var response = await PostRequestAsync<Pet, Pet>(PetEndPoint, pet);
            
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var createdPet = response.Data;
            createdPet.Should().NotBeNull();
            createdPet.Id.Should().BeGreaterThan(0);

            //Tear down
            var deleteResponse = await DeleteRequestAsync($"{PetEndPoint}/{createdPet.Id}");
        }

    }
}
   
   