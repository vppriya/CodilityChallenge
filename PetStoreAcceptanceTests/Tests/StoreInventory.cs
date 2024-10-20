using NUnit.Framework;
using FluentAssertions;
using RestSharp;
using System.Threading.Tasks;
using PetStoreAcceptanceTests.Models;
using RestSharp.Authenticators.OAuth2;

namespace PetStoreAcceptanceTests.Tests
{
    [TestFixture]
    public class StoreInventory : ApiTestBase
    {
        private const string InventoryEndpoint = "store/inventory";
        [Test]
        public async Task StoreInventoryGet_ShouldReturnSuccess()
        {
            // Arrange
            CreateClient();
            var request = CreateRequest(InventoryEndpoint, Method.Get);

            // Act
            var response = await Client.ExecuteAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }

        [Test]
        public async Task StoreInventoryPost_ShouldReturnSuccessAndCreateOrder()
        {
            // Arrange
            CreateClient();
            // Create a pet
            var pet = new Pet()
            {
                Name = "Dog",
                Status = PetStatus.Available
            };
            var response = await PostRequestAsync<Pet, Pet>(Pets.PetEndPoint, pet);
            var createdPet = response.Data;
            var order = new Order()
            {
                Quantity = 2,
                PetId = createdPet.Id,
                ShipDate = new DateTime(),
                Complete = true
            };
            //Act
            var response2 = await PostRequestAsync<Order, Order>(InventoryEndpoint, order);
            var createdOrder = response2.Data;
            // Assert
            response2.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            createdOrder.Should().NotBeNull();
            createdOrder.PetId.Should().Be(createdPet.Id);
        }
    }
}
   
   