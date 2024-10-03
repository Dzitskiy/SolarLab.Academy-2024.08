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
using SolarLab.Academy.ComponentRegistrar.MapProfiles;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;
using SolarLab.Academy.Tests.Stubs;
using Xunit;

namespace SolarLab.Academy.Tests.AppServicesTests.Contexts.Adverts.Services;

/// <summary>
/// Тесты для <see cref="AdvertService"/>
/// </summary>
public class AdvertServiceWithStubsTests
{
    private readonly AdvertService _service;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture;
    private readonly CancellationToken _token;
    private readonly FakeTimeProvider _fakeTimeProvider;
    private readonly Mock<IStructuralLoggingService> _structuralLoggingServiceMock;
    private readonly Mock<ILogger<AdvertService>> _loggerMock;

    public AdvertServiceWithStubsTests()
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
        var advertRepositoryStub = new AdvertRepositoryStub();
        var advertSpecificationBuilderStub = new AdvertSpecificationBuilderStub();
        _loggerMock = new Mock<ILogger<AdvertService>>();
        _service = new AdvertService(
            advertRepositoryStub,
            advertSpecificationBuilderStub,
            _loggerMock.Object,
            _mapper,
            _structuralLoggingServiceMock.Object,
            _fakeTimeProvider);
        _fixture = new Fixture();

        // TODO: рассказать про отличая new CancellationTokenSource().Token и CancellationToken.None
        _token = new CancellationTokenSource().Token;
    }

    [Fact]
    public async Task GetByCategoryAsync_Should_Call_RepositoryMethod2_Async()
    {
        // Arrange
        var categoryId = _fixture.Create<Guid>();

        // Act
        var result = await _service.GetByCategoryAsync(categoryId, _token);

        // Assert
        Assert.NotNull(result);
    }
}
