using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Time.Testing;
using Moq;
using SolarLab.Academy.AppServices.Contexts.Adverts.Builders;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.AppServices.Contexts.Adverts.Specifications;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.ComponentRegistrar.MapProfiles;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;
using SolarLab.Academy.Domain;
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
    private readonly FakeTimeProvider _fakeTimeProvider;
    private readonly Mock<IAdvertRepository> _advertRepositoryMock;
    private readonly Mock<IAdvertSpecificationBuilder> _advertSpecificationBuilderMock;
    private readonly Mock<IStructuralLoggingService> _structuralLoggingServiceMock;
    private readonly Mock<ILogger<AdvertService>> _loggerMock;

    public AdvertServiceTests()
    {
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
        _fakeTimeProvider = new FakeTimeProvider();
        _structuralLoggingServiceMock = new Mock<IStructuralLoggingService>();
        _advertRepositoryMock = new Mock<IAdvertRepository>();
        _advertSpecificationBuilderMock = new Mock<IAdvertSpecificationBuilder>();
        _loggerMock = new Mock<ILogger<AdvertService>>();
        _service = new AdvertService(
            _advertRepositoryMock.Object,
            _advertSpecificationBuilderMock.Object,
            _loggerMock.Object,
            _mapper,
            _structuralLoggingServiceMock.Object,
            _fakeTimeProvider);
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
        var now = _fixture.Create<DateTime>();
        _fakeTimeProvider.SetUtcNow(now);

        // Act
        var result = await _service.CreateAsync(request, _token);
        
        // Assert
        Assert.Equal(advertId, result);
        _advertRepositoryMock.Verify(x => x.CreateAsync(It.Is<Advert>(x => x.Name == name), _token), Times.Once);
        _advertRepositoryMock.Verify(x => x.CreateAsync(It.Is<Advert>(x => x.Created == now), _token), Times.Once);
    }

    [Fact]
    public async Task GetByCategoryAsync_Should_Call_RepositoryMethod_Async()
    {
        // Arrange
        var categoryId = _fixture.Create<Guid>();
        var listResult = new List<ShortAdvertResponse>
        {
            new ShortAdvertResponse()
        };
        var specification = new ByCategorySpecification(categoryId);
        _advertSpecificationBuilderMock
            .Setup(x => x.Build(categoryId))
            .Returns(specification);
        _advertRepositoryMock
            .Setup(x => x.GetBySpecificationAsync(specification, _token))
            .ReturnsAsync(listResult);

        // Act
        var result = await _service.GetByCategoryAsync(categoryId, _token);

        // Assert
        Assert.Equal(listResult, result);
        _advertRepositoryMock.Verify(x => x.GetBySpecificationAsync(It.IsAny<ISpecification<Advert>>(), _token), Times.Once);
    }
}
