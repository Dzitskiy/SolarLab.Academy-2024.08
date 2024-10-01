using FluentAssertions;
using FluentValidation.TestHelper;
using Moq;
using SolarLab.Academy.AppServices.Contexts.Categories.Services;
using SolarLab.Academy.AppServices.Validators;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using Xunit;

namespace SolarLab.Academy.Tests;

/// <summary>
/// Тесты для <see cref="CreateAdvertValidator"/>
/// </summary>
public class CreateAdvertValidatorTests
{
    private readonly CreateAdvertValidator _validator;
    private readonly Mock<ICategoryService> _categoryServiceMock;

    public CreateAdvertValidatorTests()
    {
        _categoryServiceMock = new Mock<ICategoryService>();
        _validator = new CreateAdvertValidator(_categoryServiceMock.Object);
    }

    /// <summary>
    /// Test valid
    /// </summary>
    [Fact]
    public void Check_CreateAdvertRequest_Success()
    {
        // Arrange
        var token = CancellationToken.None;
        var categoryId = Guid.NewGuid();
        var request = new CreateAdvertRequest
        {
            Name = "Name",
            Description = "Description",
            CategoryId = categoryId,
            Price = 1
        };
        _categoryServiceMock.Setup(x => x.IsExistsAsync(categoryId, token)).ReturnsAsync(true);

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    /// <summary>
    /// test invalid
    /// </summary>
    [Fact]
    public void Check_CreateAdvertRequest_Invalid_Name()
    {
        // Arrange
        var token = CancellationToken.None;
        var categoryId = Guid.NewGuid();
        var request = new CreateAdvertRequest
        {
            Name = string.Empty,
            Description = "Description",
            CategoryId = categoryId,
            Price = 1
        };
        _categoryServiceMock.Setup(x => x.IsExistsAsync(categoryId, token)).ReturnsAsync(true);

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result
            .ShouldHaveValidationErrorFor(req => req.Name)
            .WithErrorMessage("'Name' must not be empty.");
    }
}
