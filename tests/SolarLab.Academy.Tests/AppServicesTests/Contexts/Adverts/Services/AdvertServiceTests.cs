using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using SolarLab.Academy.AppServices.Contexts.Adverts.Builders;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.ComponentRegistrar.MapProfiles;
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
    }

    [Fact]
    public async Task CreateAsync_Should_Call_RepositoryMethod_Async()
    {
        // Arrange

        // Act

        // Assert
    }
}
