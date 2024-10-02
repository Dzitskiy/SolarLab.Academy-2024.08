using AutoFixture;
using AutoMapper;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.ComponentRegistrar.MapProfiles;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Tests.Stubs;
using Xunit;

namespace SolarLab.Academy.Tests.AppServicesTests.Contexts.Adverts.Services;

/// <summary>
/// Тесты для <see cref="AdvertService"/>
/// </summary>
public class AdvertServiceTests
{
    private readonly AdvertService _service;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture;
    private readonly CancellationToken _token;

    public AdvertServiceTests()
    {
        var advertRepositoryStub = new AdvertRepositoryStub();
        var advertSpecificationBuilderStub = new AdvertSpecificationBuilderStub();
        var configurationProvider = new MapperConfiguration(delegate (IMapperConfigurationExpression configure)
        {
            configure.AddProfiles(new List<Profile>
            {
                new AdvertProfile(),
                new CategoryProfile(),
            });
        });
        configurationProvider.AssertConfigurationIsValid();
        _mapper = configurationProvider.CreateMapper();
        _service = new AdvertService(advertRepositoryStub, advertSpecificationBuilderStub, _mapper);
        _fixture = new Fixture();

        // TODO: рассказать про отличая new CancellationTokenSource().Token и CancellationToken.None
        _token = new CancellationTokenSource().Token;
    }

    [Fact]
    public async Task CreateAsync_Should_Call_RepositoryMethod_Async()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var request = _fixture
            .Build<CreateAdvertRequest>()
            .With(x => x.Name, name)
            .Create();
        var advertId = _fixture.Create<Guid>();
        _advertRepositoryMock
            .Setup(x => x.CreateAsync(It.IsAny<Advert>(), _token))
            .ReturnsAsync(advertId);

        // Act
        var result = await _service.CreateAsync(request, _token);
        
        // Assert
        Assert.Equal(advertId, result);
        //TODO: почему дату так просто не проверить?
        // _advertRepositoryMock.Verify(x => x.CreateAsync(It.Is<Advert>(x => x.Created == DateTime.UtcNow), _token), Times.Once);
        _advertRepositoryMock.Verify(x => x.CreateAsync(It.Is<Advert>(x => x.Name == name), _token), Times.Once);
        var now = DateTime.UtcNow;
        _advertRepositoryMock.Verify(x => x.CreateAsync(It.Is<Advert>(x => x.Created.Year == now.Year && x.Created.Month == now.Month && x.Created.Day == now.Day && x.Created.Hour == now.Hour && x.Created.Minute == now.Minute), _token), Times.Once);
    }

    [Fact]
    public async Task GetByCategoryAsync_Should_Call_RepositoryMethod_Async()
    {
        // Arrange
        var categoryId = _fixture.Create<Guid>();

        // Act
        var result = await _service.GetByCategoryAsync(categoryId, _token);

        // Assert
        Assert.NotNull(result);
    }
}
