using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.User.Services;

public interface IUserService
{
    Task<UserDto> RegisterAsync(UserRegisterRequestDto model, CancellationToken cancellationToken);
    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken);
}