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
        var request = _fixture.Create<CreateAdvertRequest>();

        // Act
        var result = await _service.CreateAsync(request, _token);
        
        // Assert
        Assert.NotEqual(Guid.Empty, result);
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
