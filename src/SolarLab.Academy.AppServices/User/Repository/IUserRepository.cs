using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.User.Repository;

public interface IUserRepository
{
    Task<UserDto> RegisterAsync(UserDto dto, string password, CancellationToken cancellationToken);
    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken);
}
public class UserRepository : IUserRepository
{
    public Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> RegisterAsync(UserDto dto, string password, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
