using SolarLab.Academy.AppServices.Contexts.User.Repository;
using SolarLab.Academy.AppServices.Helpers;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.User.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<UserDto> RegisterAsync(UserRegisterRequestDto model, CancellationToken cancellationToken)
    {
        var user = new UserDto
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Email = model.Email,
            Login = model.Login,
            BirthDate = model.BirthDate
        };
        var password = CryptoHelper.GetBase64Hash(model.Password);
        
        return _userRepository.RegisterAsync(user, password, cancellationToken);
    }

    public Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _userRepository.GetAllAsync(cancellationToken);
    }
}