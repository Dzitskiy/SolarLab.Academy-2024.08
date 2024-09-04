using System.Collections.Immutable;
using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.AppServices.User.Repository;
using SolarLab.Academy.Contracts.User;
using SolarLab.Academy.Domain.Entities;

namespace SolarLab.Academy.DataAccess.FakeDB;

public class UserRepository : IUserRepository
{
    private List<User> _users = new List<User>();

    public Task<UserDto> RegisterAsync(UserDto dto, string password, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            BirthDate = dto.BirthDate,
            CreatedAt = DateTime.UtcNow,
            Email = dto.Email,
            Login = dto.Login,
            Password = password,
            Name = dto.Name
        };
        _users.Add(user);

        return Task.FromResult(new UserDto
        {
            Id = user.Id,
            BirthDate = user.BirthDate,
            Email = user.Email,
            Login = user.Login,
            Name = user.Name
        });
    }

    public Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        if (_users.Count == 0)
        {
            throw new EntitiesNotFoundException("Сущности пользователей не были найдены");
        }   
        
        var result = _users.Select(u => new UserDto
        {
            Id = u.Id,
            BirthDate = u.BirthDate,
            Email = u.Email,
            Login = u.Login,
            Name = u.Name
        });
        return Task.FromResult(result);
    }
}