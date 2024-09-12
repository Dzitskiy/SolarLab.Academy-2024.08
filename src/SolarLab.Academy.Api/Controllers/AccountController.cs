using System.Net;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.User.Services;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Учетные записи.
/// </summary>
[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountsController(IUserService userService)
    {
        _userService = userService;
    }
    
    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="model">Модель регистрации пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Зарегистрированный пользователь.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequestDto model, CancellationToken cancellationToken)
    {
        var user = await _userService.RegisterAsync(model, cancellationToken);

        return Ok(user);
    }
    
}