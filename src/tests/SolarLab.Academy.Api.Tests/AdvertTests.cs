using System.Net;
using System.Net.Http.Json;
using Shouldly;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.Api.Tests
{
    /// <summary>
    /// Тесты для работы с объявлениями.
    /// </summary>
    public class AdvertTests : IClassFixture<TestWebApplication>
    {
        private readonly TestWebApplication _application;
        private readonly CancellationToken _cancellationToken;

        public AdvertTests(TestWebApplication application)
        {
            _application = application;
            _cancellationToken = new CancellationTokenSource().Token;
        }

        /// <summary>
        /// Успешное получение объявления.
        /// </summary>
        [Fact]
        public async Task GetValidAdvert_Should_Success()
        {
            // arrange
            var httpClient = _application.CreateClient();

            // act
            var response = await httpClient.GetAsync($"api/Advert/{DataSeedHelper.TestAdvertId}", _cancellationToken);
            
            // assert
            response.ShouldNotBeNull();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var advert = await response.Content.ReadFromJsonAsync<AdvertResponse>(_cancellationToken);
            advert.ShouldNotBeNull();
            advert.Id.ShouldBe(DataSeedHelper.TestAdvertId);
        }

        /// <summary>
        /// Успешное создание объявления.
        /// </summary>
        [Fact]
        public async Task CreateAdvert_Should_Success()
        {
            // arrange
            var httpClient = _application.CreateClient();

            var request = new CreateAdvertRequest
            {
                Name = "new_test_advert_name",
                Description = "new_test_advert_desc",
                Price = 150,
                CategoryId = DataSeedHelper.TestCategoryId
            };

            // act
            var response = await httpClient.PostAsJsonAsync("api/Advert", request, _cancellationToken);

            // assert
            response.ShouldNotBeNull();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var advertId = await response.Content.ReadFromJsonAsync<Guid>(_cancellationToken);
            
            await using var dbContext = _application.CreateDbContext();
            var advertFromDb = dbContext.Find<Advert>(advertId);

            advertFromDb.ShouldNotBeNull();
            advertFromDb.Id.ShouldBe(advertId);
            advertFromDb.Name.ShouldBe(request.Name);
            advertFromDb.Description.ShouldBe(request.Description);
            advertFromDb.Price.ShouldBe(request.Price.Value);
        }
    }
}