using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.User.Repository;

public interface IUserRepository
{
    Task<UserDto> RegisterAsync(UserDto dto, string password, CancellationToken cancellationToken);
    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken);
}