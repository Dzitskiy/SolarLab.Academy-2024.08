using AutoFixture;
using AutoMapper;
using FluentAssertions;
using SolarLab.Academy.ComponentRegistrar.MapProfiles;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;
using SolarLab.Academy.Domain;
using Xunit;

namespace SolarLab.Academy.Tests.MapProfilesTests;

public class AdvertProfileTests
{
    private readonly MapperConfiguration _configurationProvider;

    private IMapper Mapper { get; }

    private Fixture Fixture { get; }

    public AdvertProfileTests()
    {
        _configurationProvider = new MapperConfiguration(delegate (IMapperConfigurationExpression configure)
        {
            configure.AddProfiles(new List<Profile>
            {
                new AdvertProfile()
            });
        });
        Fixture = new Fixture();
        Mapper = _configurationProvider.CreateMapper();
    }

    [Fact]
    public void AutoMapperProfile_CheckConfigurationIsValid()
    {
        _configurationProvider.AssertConfigurationIsValid();
    }

    /// <summary>
    /// Проверка <see cref="AdvertProfile"/>.
    /// </summary>
    [Fact]
    public void AdvertProfile_CreateAdvertRequest_To_Advert()
    {
        // TODO: Показать чем отличается Shoudly от Assert
        // TODO: Как можно сделать вызов двух профайлеров и их проверку в одном тесте?

        // Arrange
        var name = Fixture.Create<string>();
        var description = Fixture.Create<string>();
        var price = Fixture.Create<decimal>();
        var categoryId = Fixture.Create<Guid>();

        var source = Fixture
            .Build<CreateAdvertRequest>()
            .OmitAutoProperties()
            .With(x => x.Name, name)
            .With(x => x.Description, description)
            .With(x => x.Price, price)
            .With(x => x.CategoryId, categoryId)
            .Create();

        // Act
        var result = Mapper.Map<CreateAdvertRequest, Advert>(source);

        // Assert
        result.Should().BeEquivalentTo(
            new
            {
                name,
                description,
                price,
                categoryId,
            },
            opt => opt.ExcludingMissingMembers());
    }

    /// <summary>
    /// Проверка <see cref="AdvertProfile"/>.
    /// </summary>
    [Fact]
    public void AdvertProfile_Advert_To_ShortAdvertResponse()
    {
        // TODO: что будет, если мы Advert.Category зададим?

        // Arrange
        var id = Guid.NewGuid();
        var name = "name";
        var price = 12;
        var created = DateTime.UtcNow;
        var categoryId = Guid.NewGuid();

        var source = new Advert()
        {
            Id = id,
            Name = name,
            Price = price,
            Created = created,
            CategoryId = categoryId,
        };

        // Act
        var result = Mapper.Map<Advert, ShortAdvertResponse>(source);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(name, result.Name);
        Assert.Equal(price, result.Price);
        Assert.Equal(created, result.Created);
        Assert.Equal(categoryId, result.CategoryId);
    }
}
