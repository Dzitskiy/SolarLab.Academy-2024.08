using AutoFixture;
using AutoMapper;
using Moq;
using SolarLab.Academy.AppServices.Contexts.Adverts.Builders;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.ComponentRegistrar.MapProfiles;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Domain;
using Xunit;

namespace SolarLab.Academy.Tests.AppServicesTests.Contexts.Adverts.Services;

/// <summary>
/// Тесты для <see cref="AdvertService"/>
/// </summary>
public class AdvertServiceTests
{
    private readonly AdvertService _service;
    private readonly Mock<IAdvertRepository> _advertRepositoryMock;
    private readonly Mock<IAdvertSpecificationBuilder> _advertSpecificationBuilderMock;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture;
    private readonly CancellationToken _token;

    public AdvertServiceTests()
    {
        _advertRepositoryMock = new Mock<IAdvertRepository>();
        _advertSpecificationBuilderMock = new Mock<IAdvertSpecificationBuilder>();
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
        _service = new AdvertService(_advertRepositoryMock.Object, _advertSpecificationBuilderMock.Object, _mapper);
        _fixture = new Fixture();

        // TODO: рассказать про отличая new CancellationTokenSource().Token и CancellationToken.None
        _token = new CancellationTokenSource().Token;
    }

    [Fact]
    public async Task CreateAsync_Should_Call_RepositoryMethod_Async()
    {
        // Arrange
        var request = _fixture.Create<CreateAdvertRequest>();
        var advertId = _fixture.Create<Guid>();

        // Act
        var result = await _service.CreateAsync(request, _token);
        
        // Assert
        //TODO: как это исправить и что мы ожидаем как результат работы теста?
        Assert.NotEqual(Guid.Empty, result);
    }
}
